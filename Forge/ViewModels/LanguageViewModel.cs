using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Forge.ViewModels
{
    public class LanguageViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<LanguageCollection> _languageCollection = new BindableCollection<LanguageCollection>();
        private int _selectedIndex = -1;
        private string _languageName;
        private string _languageDescription;
        private bool _isLanguageSelected = false;
        #endregion

        #region Public Variables
        public BindableCollection<LanguageCollection> LanguageCollection
        {
            get { return _languageCollection; }
            set
            {
                if (_languageCollection != value)
                {
                    _languageCollection = value;
                    NotifyOfPropertyChange(() => LanguageCollection);
                }
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    NotifyOfPropertyChange(() => SelectedIndex);

                    if (_selectedIndex >= 0)
                    {
                        IsLanguageSelected = true;
                    }
                    else
                    {
                        IsLanguageSelected = false;
                    }
                }
            }
        }
        public string LanguageName
        {
            get { return _languageName; }
            set
            {
                if (_languageName != value)
                {
                    _languageName = value;
                    NotifyOfPropertyChange(() => LanguageName);
                }
            }
        }
        public string LanguageDescription
        {
            get { return _languageDescription; }
            set
            {
                if (_languageDescription != value)
                {
                    _languageDescription = value;
                    NotifyOfPropertyChange(() => LanguageDescription);
                }
            }
        }
        public bool IsLanguageSelected
        {
            get { return _isLanguageSelected; }
            set
            {
                if (_isLanguageSelected != value)
                {
                    _isLanguageSelected = value;
                    NotifyOfPropertyChange(() => IsLanguageSelected);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public LanguageViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
            PopulateLanguageCollection();
        }
        #region Private Methods
        private void PopulateLanguageCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempLanguageCollection = new BindableCollection<LanguageCollection>();

            foreach(var language in forgeDatabase.Languages)
            {
                tempLanguageCollection.Add(new LanguageCollection
                {
                    ID = language.ID,
                    Name = language.Name,
                    Description = language.Description
                });
            }

            if (tempLanguageCollection.SequenceEqual(Global.Instance.LanguageCollection))
            {
                LanguageCollection = new BindableCollection<LanguageCollection>(tempLanguageCollection);
            }
            else
            {
                Global.Instance.LanguageCollection = new BindableCollection<LanguageCollection>(tempLanguageCollection);
                LanguageCollection = new BindableCollection<LanguageCollection>(tempLanguageCollection);
            }
        }

        private void ClearLanguageInfo()
        {
            LanguageName = string.Empty;
            LanguageDescription = string.Empty;
            IsLanguageSelected = false;
        }
        #endregion

        #region Public Methods
        public void LanguageSelectionChanged(object sender)
        {
            ListBox languageListBox = (ListBox)sender;

            if (SelectedIndex != -1)
            {
                LanguageName = LanguageCollection[SelectedIndex].Name;
                LanguageDescription = LanguageCollection[SelectedIndex].Description;
            }

        }

        public void AddLanguage()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddLanguageDialog");
        }

        public void DeleteLanguage()
        {
            try
            {
                int languageID = LanguageCollection[SelectedIndex].ID;

                var forgeDatabase = Global.Instance.ForgeDatabase();

                LANGUAGE language = forgeDatabase.Languages.Single(x => x.ID == languageID);

                forgeDatabase.Languages.DeleteOnSubmit(language);
                forgeDatabase.SubmitChanges();

                LanguageCollection.RemoveAt(SelectedIndex);
                Global.Instance.LanguageCollection = new BindableCollection<LanguageCollection>(LanguageCollection);

                ClearLanguageInfo();
                SelectedIndex = -1;
            }
            catch { }
        }

        public void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                LanguageCollection = new BindableCollection<LanguageCollection>(Global.Instance.LanguageCollection);
            else
                LanguageCollection = new BindableCollection<LanguageCollection>(
                    Global.Instance.LanguageCollection.Where(
                        x => x.Name.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0));
        }

        public void Search_OnKeyDown(string sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search(sender);
        }
        #endregion

        #region IHandle Method
        public void Handle(string message)
        {
            switch (message)
            {
                case "AcceptAddLanguageDialog":
                    PopulateLanguageCollection();
                    ClearLanguageInfo();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

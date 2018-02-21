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
    [Export(typeof(SkillsViewModel))]
    public class SkillsViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<SkillCollection> _skillCollection = new BindableCollection<SkillCollection>();
        private int _selectedIndex = -1;
        private string _skillName;
        private string _skillDescription;
        private bool _isSkillSelected = false;
        #endregion

        #region Public Variables
        public BindableCollection<SkillCollection> SkillCollection
        {
            get { return _skillCollection; }
            set
            {
                if(_skillCollection != value)
                {
                    _skillCollection = value;
                    NotifyOfPropertyChange(() => SkillCollection);
                }
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if(_selectedIndex != value)
                {
                    _selectedIndex = value;
                    NotifyOfPropertyChange(() => SelectedIndex);

                    if (_selectedIndex >= 0)
                    {
                        IsSkillSelected = true;
                    }
                    else
                    {
                        IsSkillSelected = false;
                    }
                }
            }
        }
        public string SkillName
        {
            get { return _skillName; }
            set
            {
                if(_skillName != value)
                {
                    _skillName = value;
                    NotifyOfPropertyChange(() => SkillName);
                }
            }
        }
        public string SkillDescription
        {
            get { return _skillDescription; }
            set
            {
                if(_skillDescription != value)
                {
                    _skillDescription = value;
                    NotifyOfPropertyChange(() => SkillDescription);
                }
            }
        }
        public bool IsSkillSelected
        {
            get { return _isSkillSelected; }
            set
            {
                if(_isSkillSelected != value)
                {
                    _isSkillSelected = value;
                    NotifyOfPropertyChange(() => IsSkillSelected);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public SkillsViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
            PopulateSkillCollection();
        }

        #region Private Methods
        private void PopulateSkillCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempSkillCollection = new BindableCollection<SkillCollection>();

            foreach(var skill in forgeDatabase.Skills)
            {
                tempSkillCollection.Add(new SkillCollection
                {
                    ID = skill.ID,
                    Name = skill.Name,
                    Description = skill.Description
                });
            }

            if(tempSkillCollection.SequenceEqual(Global.Instance.SkillCollection))
            {
                SkillCollection = new BindableCollection<SkillCollection>(tempSkillCollection);
            }
            else
            {
                Global.Instance.SkillCollection = new BindableCollection<SkillCollection>(tempSkillCollection);
                SkillCollection = new BindableCollection<SkillCollection>(tempSkillCollection);
            }
        }

        private void ClearSkillInfo()
        {
            SkillName = string.Empty;
            SkillDescription = string.Empty;
            IsSkillSelected = false;
        }
        #endregion

        #region Public Methods
        public void SkillSelectionChanged(object sender)
        {
            ListBox skillListBox = (ListBox)sender;

            if(SelectedIndex != -1)
            {
                SkillName = SkillCollection[SelectedIndex].Name;
                SkillDescription = SkillCollection[SelectedIndex].Description;
            }
            
        }

        public void AddSkill()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddSkillDialog");
        }

        public void DeleteSkill()
        {
            try
            {
                int skillID = SkillCollection[SelectedIndex].ID;

                var forgeDatabase = Global.Instance.ForgeDatabase();

                SKILL skill = forgeDatabase.Skills.Single(x => x.ID == skillID);

                forgeDatabase.Skills.DeleteOnSubmit(skill);
                forgeDatabase.SubmitChanges();

                SkillCollection.RemoveAt(SelectedIndex);
                Global.Instance.SkillCollection = new BindableCollection<SkillCollection>(SkillCollection);

                ClearSkillInfo();
                SelectedIndex = -1;
            }
            catch { }
        }

        public void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                SkillCollection = new BindableCollection<SkillCollection>(Global.Instance.SkillCollection);
            else
                SkillCollection = new BindableCollection<SkillCollection>(
                    Global.Instance.SkillCollection.Where(
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
                case "AcceptAddSkillDialog":
                    PopulateSkillCollection();
                    ClearSkillInfo();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

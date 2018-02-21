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
    [Export(typeof(FactionViewModel))]
    public class FactionViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<FactionCollection> _factionCollection = new BindableCollection<FactionCollection>();
        private int _selectedIndex = -1;
        private string _factionName;
        private string _factionDescription;
        private bool _isFactionSelected = false;
        #endregion

        #region Public Variables
        public BindableCollection<FactionCollection> FactionCollection
        {
            get { return _factionCollection; }
            set
            {
                if (_factionCollection != value)
                {
                    _factionCollection = value;
                    NotifyOfPropertyChange(() => FactionCollection);
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
                        IsFactionSelected = true;
                    }
                    else
                    {
                        IsFactionSelected = false;
                    }
                }
            }
        }
        public string FactionName
        {
            get { return _factionName; }
            set
            {
                if (_factionName != value)
                {
                    _factionName = value;
                    NotifyOfPropertyChange(() => FactionName);
                }
            }
        }
        public string FactionDescription
        {
            get { return _factionDescription; }
            set
            {
                if (_factionDescription != value)
                {
                    _factionDescription = value;
                    NotifyOfPropertyChange(() => FactionDescription);
                }
            }
        }
        public bool IsFactionSelected
        {
            get { return _isFactionSelected; }
            set
            {
                if (_isFactionSelected != value)
                {
                    _isFactionSelected = value;
                    NotifyOfPropertyChange(() => IsFactionSelected);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public FactionViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
            PopulateFactionCollection();
        }

        #region Private Methods
        private void PopulateFactionCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempFactionCollection = new BindableCollection<FactionCollection>();

            foreach(var faction in forgeDatabase.Factions)
            {
                tempFactionCollection.Add(new FactionCollection
                {
                    ID = faction.ID,
                    Name = faction.Name,
                    Description = faction.Description
                });
            }

            if (tempFactionCollection.SequenceEqual(Global.Instance.FactionCollection))
            {
                FactionCollection = new BindableCollection<FactionCollection>(tempFactionCollection);
            }
            else
            {
                Global.Instance.FactionCollection = new BindableCollection<FactionCollection>(tempFactionCollection);
                FactionCollection = new BindableCollection<FactionCollection>(tempFactionCollection);
            }
        }

        private void ClearFactionInfo()
        {
            FactionName = string.Empty;
            FactionDescription = string.Empty;
            IsFactionSelected = false;
        }
        #endregion

        #region Public Methods
        public void FactionSelectionChanged(object sender)
        {
            ListBox skillListBox = (ListBox)sender;

            if (SelectedIndex != -1)
            {
                FactionName = FactionCollection[SelectedIndex].Name;
                FactionDescription = FactionCollection[SelectedIndex].Description;
            }

        }

        public void AddFaction()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddFactionDialog");
        }

        public void DeleteFaction()
        {
            try
            {
                int factionID = FactionCollection[SelectedIndex].ID;

                var forgeDatabase = Global.Instance.ForgeDatabase();

                FACTION faction = forgeDatabase.Factions.Single(x => x.ID == factionID);

                forgeDatabase.Factions.DeleteOnSubmit(faction);
                forgeDatabase.SubmitChanges();

                FactionCollection.RemoveAt(SelectedIndex);
                Global.Instance.FactionCollection = new BindableCollection<FactionCollection>(FactionCollection);

                ClearFactionInfo();
                SelectedIndex = -1;
            }
            catch { }
        }

        public void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                FactionCollection = new BindableCollection<FactionCollection>(Global.Instance.FactionCollection);
            else
                FactionCollection = new BindableCollection<FactionCollection>(
                    Global.Instance.FactionCollection.Where(
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
                case "AcceptAddFactionDialog":
                    PopulateFactionCollection();
                    ClearFactionInfo();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

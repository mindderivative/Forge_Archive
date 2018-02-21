using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forge.Controls
{
    /// <summary>
    /// Interaction logic for AddPlayerDialog.xaml
    /// </summary>
    public partial class AddPlayerDialog : UserControl, INotifyPropertyChanged
    {
        private string _playerNameTxt;
        private string _characterNameTxt;
        private string _hitPointsTxt;
        private string _armorClassTxt;
        private string _touchACTxt;
        private string _flatFootedACTxt;
        private string _cmdTxt;
        private string _fortTxt;
        private string _refTxt;
        private string _willTxt;
        private string _strTxt;
        private string _dexTxt;
        private string _conTxt;
        private string _intTxt;
        private string _wisTxt;
        private string _chaTxt;

        public string PlayerNameTxt
        {
            get { return _playerNameTxt; }
            set
            {
                _playerNameTxt = value;
                NotifyOfPropertyChanged("PlayerNameTxt");
            }
        }
        public string CharacterNameTxt
        {
            get { return _characterNameTxt; }
            set
            {
                _characterNameTxt = value;
                NotifyOfPropertyChanged("CharacterNameTxt");
            }
        }
        public string HitPointsTxt
        {
            get { return _hitPointsTxt; }
            set
            {
                _hitPointsTxt = value;
                NotifyOfPropertyChanged("HitPointsTxt");
            }
        }
        public string ArmorClassTxt
        {
            get { return _armorClassTxt; }
            set
            {
                _armorClassTxt = value;
                NotifyOfPropertyChanged("ArmorClassTxt");
            }
        }
        public string TouchACTxt
        {
            get { return _touchACTxt; }
            set
            {
                _touchACTxt = value;
                NotifyOfPropertyChanged("TouchACTxt");
            }
        }
        public string FlatFootedACTxt
        {
            get { return _flatFootedACTxt; }
            set
            {
                _flatFootedACTxt = value;
                NotifyOfPropertyChanged("FlatFootedACTxt");
            }
        }
        public string CMDTxt
        {
            get { return _cmdTxt; }
            set
            {
                _cmdTxt = value;
                NotifyOfPropertyChanged("CMDTxt");
            }
        }
        public string FortTxt
        {
            get { return _fortTxt; }
            set
            {
                _fortTxt = value;
                NotifyOfPropertyChanged("FortTxt");
            }
        }
        public string RefTxt
        {
            get { return _refTxt; }
            set
            {
                _refTxt = value;
                NotifyOfPropertyChanged("RefTxt");
            }
        }
        public string WillTxt
        {
            get { return _willTxt; }
            set
            {
                _willTxt = value;
                NotifyOfPropertyChanged("WillTxt");
            }
        }
        public string StrTxt
        {
            get { return _strTxt; }
            set
            {
                _strTxt = value;
                NotifyOfPropertyChanged("StrTxt");
            }
        }
        public string DexTxt
        {
            get { return _dexTxt; }
            set
            {
                _dexTxt = value;
                NotifyOfPropertyChanged("DexTxt");
            }
        }
        public string ConTxt
        {
            get { return _conTxt; }
            set
            {
                _conTxt = value;
                NotifyOfPropertyChanged("ConTxt");
            }
        }
        public string IntTxt
        {
            get { return _intTxt; }
            set
            {
                _intTxt = value;
                NotifyOfPropertyChanged("IntTxt");
            }
        }
        public string WisTxt
        {
            get { return _wisTxt; }
            set
            {
                _wisTxt = value;
                NotifyOfPropertyChanged("WisTxt");
            }
        }
        public string ChaTxt
        {
            get { return _chaTxt; }
            set
            {
                _chaTxt = value;
                NotifyOfPropertyChanged("ChaTxt");
            }
        }

        private BindableCollection<FactionCollection> _factionCollection = new BindableCollection<FactionCollection>();
        public BindableCollection<FactionCollection> FactionCollection
        {
            get { return _factionCollection; }
            set
            {
                _factionCollection = value;
                NotifyOfPropertyChanged("FactionCollection");
            }
        }

        public AddPlayerDialog()
        {
            InitializeComponent();
            PopulateFactionCollection();
        }

        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {

            PLAYER player = new PLAYER()
            {
                StoryID = Global.Instance.StoryID,
                PlayerName = PlayerName.Text,
                CharacterName = CharacterName.Text,
                HitPoints = ParseString(HitPoints.Text),
                Alignment = Alignment.Text,
                ArmorClass = ParseString(ArmorClass.Text),
                TouchAC = ParseString(TouchAC.Text),
                FlatFootedAC = ParseString(FlatFootedAC.Text),
                CMD = ParseString(CMD.Text),
                Fort = ParseString(Fort.Text),
                Ref = ParseString(Ref.Text),
                Will = ParseString(Will.Text),
                Str = ParseString(Str.Text),
                Dex = ParseString(Dex.Text),
                Con = ParseString(Con.Text),
                Int = ParseString(Int.Text),
                Wis = ParseString(Wis.Text),
                Cha = ParseString(Cha.Text)
            };

            var forgeDatabase = Global.Instance.ForgeDatabase();

            forgeDatabase.Players.InsertOnSubmit(player);
            forgeDatabase.SubmitChanges();

            IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddPlayerDialog");
            IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
        }

        private int ParseString(string text)
        {
            bool result = int.TryParse(text, out int x);

            if (result)
                return x;
            else
                return x = 0;
        }

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

            if(tempFactionCollection.SequenceEqual(Global.Instance.FactionCollection))
            {
                FactionCollection = new BindableCollection<FactionCollection>(tempFactionCollection);
            }
            else
            {
                Global.Instance.FactionCollection = new BindableCollection<FactionCollection>(tempFactionCollection);
                FactionCollection = new BindableCollection<FactionCollection>(tempFactionCollection);
            }
        }

        #region PropteryChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyOfPropertyChanged(string sProp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProp));
        }
        #endregion
    }
}

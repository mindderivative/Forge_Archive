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
    /// Interaction logic for ChangePlayerDialog.xaml
    /// </summary>
    public partial class ChangePlayerDialog : UserControl, INotifyPropertyChanged
    {
        #region Validation Variables
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
        private string _skillRankTxt;

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
        public string SkillRankTxt
        {
            get { return _skillRankTxt; }
            set
            {
                if(_skillRankTxt != value)
                {
                    _skillRankTxt = value;
                    NotifyOfPropertyChanged("SkillRankTxt");
                }
            }
        }
        #endregion

        #region Private Variables
        private int _currentPlayerID;
        private int _storyID;
        private BindableCollection<FactionCollection> _factionCollection = new BindableCollection<FactionCollection>();
        private BindableCollection<SkillCollection> _skillCollection = new BindableCollection<SkillCollection>();
        private BindableCollection<LanguageCollection> _languageCollection = new BindableCollection<LanguageCollection>();
        private BindableCollection<PlayerFactionCollection> _playerFactionCollection = new BindableCollection<PlayerFactionCollection>();
        private BindableCollection<PlayerSkillCollection> _playerSkillCollection = new BindableCollection<PlayerSkillCollection>();
        private BindableCollection<PlayerLanguageCollection> _playerLanguageCollection = new BindableCollection<PlayerLanguageCollection>();
        private string _playerFactionStatus;
        private int _playerRankUpdate;
        #endregion

        #region Public Variables
        public int CurrentPlayerID
        {
            get { return _currentPlayerID; }
            set
            {
                _currentPlayerID = value;
                NotifyOfPropertyChanged("ID");
            }
        }
        public int StoryID
        {
            get { return _storyID; }
            set
            {
                _storyID = value;
                NotifyOfPropertyChanged("StoryID");
            }
        }
        public BindableCollection<FactionCollection> FactionCollection
        {
            get { return _factionCollection; }
            set
            {
                _factionCollection = value;
                NotifyOfPropertyChanged("FactionCollection");
            }
        }
        public BindableCollection<SkillCollection> SkillCollection
        {
            get { return _skillCollection; }
            set
            {
                if(_skillCollection != value)
                {
                    _skillCollection = value;
                    NotifyOfPropertyChanged("SkillCollection");
                }
            }
        }
        public BindableCollection<LanguageCollection> LanguageCollection
        {
            get { return _languageCollection; }
            set
            {
                if(_languageCollection != value)
                {
                    _languageCollection = value;
                    NotifyOfPropertyChanged("LanguageCollection");
                }
            }
        }
        public BindableCollection<PlayerFactionCollection> PlayerFactionCollection
        {
            get { return _playerFactionCollection; }
            set
            {
                _playerFactionCollection = value;
                NotifyOfPropertyChanged("PlayerFactionCollection");
            }
        }
        public BindableCollection<PlayerSkillCollection> PlayerSkillCollection
        {
            get { return _playerSkillCollection; }
            set
            {
                if(_playerSkillCollection != value)
                {
                    _playerSkillCollection = value;
                    NotifyOfPropertyChanged("PlayerSkillCollection");
                }
            }
        }
        public BindableCollection<PlayerLanguageCollection> PlayerLanguageCollection
        {
            get { return _playerLanguageCollection; }
            set
            {
                if(_playerLanguageCollection != value)
                {
                    _playerLanguageCollection = value;
                    NotifyOfPropertyChanged("PlayerLanguageCollection");
                }
            }
        }
        #endregion

        public ChangePlayerDialog()
        {
            InitializeComponent();
            PopulatePlayerInfo();
            PopulateFactionCollection();
            PopulateSkillCollection();
            PopulateLanguageCollection();
            PopulatePlayerFactionCollection();
            PopulatePlayerSkillCollection();
            PopulatePlayerLanguageCollection();
        }

        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER player = forgeDatabase.Players.Single(p => p.ID == CurrentPlayerID);

            player.PlayerName = PlayerName.Text;
            player.CharacterName = CharacterName.Text;
            player.HitPoints = ParseString(HitPoints.Text);
            player.Alignment = Alignment.Text;
            player.ArmorClass = ParseString(ArmorClass.Text);
            player.TouchAC = ParseString(ArmorClass.Text);
            player.FlatFootedAC = ParseString(FlatFootedAC.Text);
            player.CMD = ParseString(CMD.Text);
            player.Fort = ParseString(Fort.Text);
            player.Ref = ParseString(Ref.Text);
            player.Will = ParseString(Will.Text);
            player.Str = ParseString(Str.Text);
            player.Dex = ParseString(Dex.Text);
            player.Con = ParseString(Con.Text);
            player.Int = ParseString(Int.Text);
            player.Wis = ParseString(Wis.Text);
            player.Cha = ParseString(Cha.Text);

            forgeDatabase.SubmitChanges();

            IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddPlayerDialog");
            IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
        }

        private void AddPlayerFaction(object sender, RoutedEventArgs e)
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_FACTION playerFaction = new PLAYER_FACTION
            {
                PlayerID = CurrentPlayerID,
                FactionID = ParseString(FactionList.SelectedValue.ToString()),
                Status = FactionStatus.Text
            };

            forgeDatabase.PlayerFactions.InsertOnSubmit(playerFaction);
            forgeDatabase.SubmitChanges();

            PopulatePlayerFactionCollection();
        }

        private void AddPlayerSkill(object sender, RoutedEventArgs e)
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_SKILL playerSkill = new PLAYER_SKILL
            {
                PlayerID = CurrentPlayerID,
                SkillID = ParseString(SkillList.SelectedValue.ToString()),
                Rank = ParseString(SkillRank.Text)
            };

            forgeDatabase.PlayerSkills.InsertOnSubmit(playerSkill);
            forgeDatabase.SubmitChanges();

            PopulatePlayerSkillCollection();
        }

        private void AddPlayerLanguage(object sender, RoutedEventArgs e)
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_LANGUAGE playerLanguage = new PLAYER_LANGUAGE
            {
                PlayerID = CurrentPlayerID,
                LanguageID = ParseString(LanguageList.SelectedValue.ToString())
            };

            forgeDatabase.PlayerLanguages.InsertOnSubmit(playerLanguage);
            forgeDatabase.SubmitChanges();

            PopulatePlayerLanguageCollection();
        }

        private void UpdatePlayerFaction(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_FACTION playerFaction = forgeDatabase.PlayerFactions.Single(x => x.ID == ParseString(btn.Tag.ToString()));

            playerFaction.Status = _playerFactionStatus;
            forgeDatabase.SubmitChanges();

            PopulatePlayerFactionCollection();
        }

        private void UpdatePlayerSkill(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_SKILL playerSkill = forgeDatabase.PlayerSkills.Single(x => x.ID == ParseString(btn.Tag.ToString()));

            playerSkill.Rank = _playerRankUpdate;
            forgeDatabase.SubmitChanges();

            PopulatePlayerSkillCollection();
        }

        private void DeletePlayerFaction(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_FACTION playerFaction = forgeDatabase.PlayerFactions.Single(x => x.ID == ParseString(btn.Tag.ToString()));

            forgeDatabase.PlayerFactions.DeleteOnSubmit(playerFaction);
            forgeDatabase.SubmitChanges();

            PopulatePlayerFactionCollection();
        }

        private void DeletePlayerSkill(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_SKILL playerSkill = forgeDatabase.PlayerSkills.Single(x => x.ID == ParseString(btn.Tag.ToString()));

            forgeDatabase.PlayerSkills.DeleteOnSubmit(playerSkill);
            forgeDatabase.SubmitChanges();

            PopulatePlayerSkillCollection();
        }

        private void DeletePlayerLanguage(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            var forgeDatabase = Global.Instance.ForgeDatabase();

            PLAYER_LANGUAGE playerLanguage = forgeDatabase.PlayerLanguages.Single(x => x.ID == ParseString(btn.Tag.ToString()));

            forgeDatabase.PlayerLanguages.DeleteOnSubmit(playerLanguage);
            forgeDatabase.SubmitChanges();

            PopulatePlayerLanguageCollection();
        }

        private void PlayerFactionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();

            _playerFactionStatus = cb;
        }

        private void PlayerRankTextChanged(object sender, TextChangedEventArgs e)
        {
            var rank = ParseString((sender as TextBox).Text);

            _playerRankUpdate = rank;
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

            foreach (var faction in forgeDatabase.Factions)
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

        private void PopulateSkillCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempSkillCollection = new BindableCollection<SkillCollection>();

            foreach (var skill in forgeDatabase.Skills)
            {
                tempSkillCollection.Add(new SkillCollection
                {
                    ID = skill.ID,
                    Name = skill.Name,
                    Description = skill.Description
                });
            }

            if (SkillCollection.SequenceEqual(Global.Instance.SkillCollection))
            {
                SkillCollection = new BindableCollection<SkillCollection>(tempSkillCollection);
            }
            else
            {
                Global.Instance.SkillCollection = new BindableCollection<SkillCollection>(tempSkillCollection);
                SkillCollection = new BindableCollection<SkillCollection>(tempSkillCollection);
            }
        }

        private void PopulateLanguageCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempLanguageCollection = new BindableCollection<LanguageCollection>();

            foreach (var language in forgeDatabase.Languages)
            {
                tempLanguageCollection.Add(new LanguageCollection
                {
                    ID = language.ID,
                    Name = language.Name,
                    Description = language.Description
                });
            }

            if (LanguageCollection.SequenceEqual(Global.Instance.LanguageCollection))
            {
                LanguageCollection = new BindableCollection<LanguageCollection>(tempLanguageCollection);
            }
            else
            {
                Global.Instance.LanguageCollection = new BindableCollection<LanguageCollection>(tempLanguageCollection);
                LanguageCollection = new BindableCollection<LanguageCollection>(tempLanguageCollection);
            }
        }

        private void PopulatePlayerFactionCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempPlayerFactionCollection = new BindableCollection<PlayerFactionCollection>();

            foreach (var playerFaction in forgeDatabase.PlayerFactions.Where(x => x.PlayerID == CurrentPlayerID))
            {
                tempPlayerFactionCollection.Add(new PlayerFactionCollection
                {
                    ID = playerFaction.ID,
                    FactionName = playerFaction.FACTION.Name,
                    FactionDescription = playerFaction.FACTION.Description,
                    FactionStatus = playerFaction.Status
                });
            }

            PlayerFactionCollection = new BindableCollection<PlayerFactionCollection>(tempPlayerFactionCollection);
        }

        private void PopulatePlayerSkillCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempPlayerSkillCollection = new BindableCollection<PlayerSkillCollection>();

            foreach (var playerSkill in forgeDatabase.PlayerSkills.Where(x => x.PlayerID == CurrentPlayerID))
            {
                tempPlayerSkillCollection.Add(new PlayerSkillCollection
                {
                    ID = playerSkill.ID,
                    SkillName = playerSkill.SKILL.Name,
                    SkillDescription = playerSkill.SKILL.Description,
                    SkillRank = playerSkill.Rank
                });
            }

            PlayerSkillCollection = new BindableCollection<PlayerSkillCollection>(tempPlayerSkillCollection);
        }

        private void PopulatePlayerLanguageCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempPlayerLanguageCollection = new BindableCollection<PlayerLanguageCollection>();

            foreach(var playerLanguage in forgeDatabase.PlayerLanguages.Where(x => x.PlayerID == CurrentPlayerID))
            {
                tempPlayerLanguageCollection.Add(new PlayerLanguageCollection
                {
                    ID = playerLanguage.ID,
                    LanguageName = playerLanguage.LANGUAGE.Name,
                    LanguageDescription = playerLanguage.LANGUAGE.Description
                });
            }

            PlayerLanguageCollection = new BindableCollection<Classes.PlayerLanguageCollection>(tempPlayerLanguageCollection);
        }

        private void PopulatePlayerInfo()
        {
            CurrentPlayerID = Global.Instance.SelectedPlayerID;

            try
            {
                var forgeDatabase = Global.Instance.ForgeDatabase();

                PLAYER player = forgeDatabase.Players.Single(p => p.ID == CurrentPlayerID);

                StoryID = player.StoryID;
                PlayerName.Text = player.PlayerName;
                CharacterName.Text = player.CharacterName;
                HitPoints.Text = player.HitPoints.ToString();
                Alignment.Text = player.Alignment;
                ArmorClass.Text = player.ArmorClass.ToString();
                TouchAC.Text = player.TouchAC.ToString();
                FlatFootedAC.Text = player.TouchAC.ToString();
                CMD.Text = player.CMD.ToString();
                Fort.Text = player.Fort.ToString();
                Ref.Text = player.Ref.ToString();
                Will.Text = player.Will.ToString();
                Str.Text = player.Str.ToString();
                Dex.Text = player.Dex.ToString();
                Con.Text = player.Con.ToString();
                Int.Text = player.Int.ToString();
                Wis.Text = player.Wis.ToString();
                Cha.Text = player.Cha.ToString();
            }
            catch
            { }
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

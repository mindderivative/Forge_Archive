using Caliburn.Micro;
using System.ComponentModel.Composition;
using MaterialDesignColors;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SQLite;
using Forge.Controls;
using Forge.Classes;

namespace Forge.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<object>, IShell, IHandle<string>
    {
        #region Private Variables
        private readonly IWindowManager _windowManager;
        private bool _isRootDialogOpen = false;
        private bool _isRootContentVisible = true;
        private object _rootDialogContent;
        private SnackbarMessageQueue _rootMessageQueue;
        private bool _isStoryLoaded = false;
        private string _loadedStoryName;
        private string _loadedForge = string.Empty;
        private bool _isSkillVisible = false;
        private bool _isCombatVisible = false;
        private bool _isMiscellaneousVisible = false;
        #endregion

        #region Public Variables
        public bool IsRootDialogOpen
        {
            get { return _isRootDialogOpen; }
            set
            {
                if (_isRootDialogOpen != value)
                {
                    _isRootDialogOpen = value;
                    NotifyOfPropertyChange(() => IsRootDialogOpen);
                }
            }
        }
        public bool IsRootContentVisible
        {
            get { return _isRootContentVisible; }
            set
            {
                if (_isRootContentVisible != value)
                {
                    _isRootContentVisible = value;
                    NotifyOfPropertyChange(() => IsRootContentVisible);
                }
            }
        }
        public object RootDialogContent
        {
            get { return _rootDialogContent; }
            set
            {
                if (_rootDialogContent != value)
                {
                    _rootDialogContent = value;
                    NotifyOfPropertyChange(() => RootDialogContent);
                }
            }
        }
        public SnackbarMessageQueue RootMessageQueue
        {
            get { return _rootMessageQueue; }
            set
            {
                if (_rootMessageQueue != value)
                {
                    _rootMessageQueue = value;
                    NotifyOfPropertyChange(() => RootMessageQueue);
                }
            }
        }
        public bool IsStoryLoaded
        {
            get { return _isStoryLoaded; }
            set
            {
                if(_isStoryLoaded != value)
                {
                    _isStoryLoaded = value;
                    NotifyOfPropertyChange(() => IsStoryLoaded);
                }
            }
        }
        public string LoadedStoryName
        {
            get { return _loadedStoryName; }
            set
            {
                if(_loadedStoryName != value)
                {
                    _loadedStoryName = value;
                    NotifyOfPropertyChange(() => LoadedStoryName);
                }
            }
        }
        public string LoadedForge
        {
            get { return _loadedForge; }
            set
            {
                if(_loadedForge != value)
                {
                    _loadedForge = value;
                    NotifyOfPropertyChange(() => LoadedForge);
                }
            }
        }
        public bool IsSkillVisible
        {
            get { return _isSkillVisible; }
            set
            {
                if(_isSkillVisible != value)
                {
                    _isSkillVisible = value;
                    NotifyOfPropertyChange(() => IsSkillVisible);
                }
            }
        }
        public bool IsCombatVisible
        {
            get { return _isCombatVisible; }
            set
            {
                if(_isCombatVisible != value)
                {
                    _isCombatVisible = value;
                    NotifyOfPropertyChange(() => IsCombatVisible);
                }
            }
        }
        public bool IsMiscellaneousVisible
        {
            get { return _isMiscellaneousVisible; }
            set
            {
                if(_isMiscellaneousVisible != value)
                {
                    _isMiscellaneousVisible = value;
                    NotifyOfPropertyChange(() => IsMiscellaneousVisible);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            IoC.Get<IEventAggregator>().Subscribe(this);
            GetLocalApplicationInfo();
            PopulateNameInfo();

            DisplayName = "Mind Derivative's - Story Forge";

            Global.Instance.LoadedForge = "Dashboard";
            LoadedForge = Global.Instance.LoadedForge;
            ActivateItem(new DashboardViewModel());

            //InitiateDatabase();
        }

        #region Private Methods
        private void CallSnackBarMessageQueue(string message)
        {
            RootMessageQueue = new SnackbarMessageQueue();
            Task.Factory.StartNew(() => RootMessageQueue.Enqueue(message));
        }

        private void InitiateDatabase()
        {
            if (File.Exists("ForgeDatabase.sqlite"))
            {
                Global.Instance.InitiateDatabase();
            }
        }

        private void GetLocalApplicationInfo()
        {
            string _localApplicationPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Mind Derivative\Story Forge";
            string _localApplicationImagePath = _localApplicationPath + @"\Images";

            if (Directory.Exists(_localApplicationPath))
                Global.Instance.LocalApplicationPath = _localApplicationPath;
            else
            {
                Directory.CreateDirectory(_localApplicationPath);

                if(Directory.Exists(_localApplicationPath))
                    Global.Instance.LocalApplicationPath = _localApplicationPath;
            }

            if (Directory.Exists(_localApplicationImagePath))
                Global.Instance.LocalApplicationImagePath = _localApplicationImagePath;
            else
            {
                Directory.CreateDirectory(_localApplicationImagePath);

                if (Directory.Exists(_localApplicationImagePath))
                    Global.Instance.LocalApplicationImagePath = _localApplicationImagePath;
            }
        }

        private void PopulateNameInfo()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();

            foreach(var prefix in forgeDatabase.Prefixes)
            {
                Global.Instance.PrefixCollection.Add(new NamePrefix
                {
                    ID = prefix.ID,
                    Prefix = prefix.Prefix,
                    Race = prefix.Race,
                    Sex = prefix.Sex,
                    FirstLast = prefix.FirstLast
                });
            }

            foreach(var suffix in forgeDatabase.Suffixes)
            {
                Global.Instance.SuffixCollection.Add(new NameSuffix
                {
                    ID = suffix.ID,
                    Suffix = suffix.Suffix,
                    Race = suffix.Race,
                    Sex = suffix.Sex,
                    FirstLast = suffix.FirstLast
                });
            }

            foreach(var infix in forgeDatabase.Infixes)
            {
                Global.Instance.InfixCollection.Add(new NameInfix
                {
                    ID = infix.ID,
                    Infix = infix.Infix,
                    Race = infix.Race,
                    Sex = infix.Sex,
                    FirstLast = infix.FirstLast
                });
            }

            foreach(var affix in forgeDatabase.Affixes)
            {
                Global.Instance.AffixCollection.Add(new NameAffix
                {
                    ID = affix.ID,
                    Affix = affix.Affix,
                    Race = affix.Race,
                    Sex = affix.Sex
                });
            }

            foreach(var postfix in forgeDatabase.Postfixes)
            {
                Global.Instance.PostfixCollection.Add(new NamePostfix
                {
                    ID = postfix.ID,
                    Postfix = postfix.Postfix,
                    Race = postfix.Race,
                    Sex =  postfix.Sex
                });
            }
        }
        #endregion

        #region Public Methods
        public void MenuControl(int sender)
        {
            switch (sender)
            {
                case 0:
                    Global.Instance.LoadedForge = "Dashboard";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new DashboardViewModel());
                    break;
                case 1:
                    Global.Instance.LoadedForge = "Realm Forge";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new RealmForgeViewModel());
                    break;
                case 2:
                    Global.Instance.LoadedForge = "Event Forge";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new EventForgeViewModel());
                    break;
                case 3:
                    Global.Instance.LoadedForge = "Encounter Forge";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new EncounterForgeViewModel());
                    break;
                case 4:
                    Global.Instance.LoadedForge = "Timeline";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new TimelineViewModel());
                    break;
                case 5:
                    ActivateItem(new CodexViewModel());
                    break;
                case 6:
                    Global.Instance.LoadedForge = "Settings";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new IconPackViewModel());
                    break;
                default:
                    Global.Instance.LoadedForge = "Dashboard";
                    LoadedForge = Global.Instance.LoadedForge;
                    ActivateItem(new DashboardViewModel());
                    break;
            }
        }

        public void SetIsSkillVisible()
        {
            if(IsSkillVisible)
            {
                IsSkillVisible = false;
            }
            else
            {
                IsCombatVisible = false;
                IsMiscellaneousVisible = false;
                IsSkillVisible = true;
            }
        }

        public void SetIsCombatVisible()
        {
            if (IsCombatVisible)
            {
                IsCombatVisible = false;
            }
            else
            {
                IsSkillVisible = false;
                IsMiscellaneousVisible = false;
                IsCombatVisible = true;
            }
        }

        public void SetIsMiscellaneousVisible()
        {
            if (IsMiscellaneousVisible)
            {
                IsMiscellaneousVisible = false;
            }
            else
            {
                IsSkillVisible = false;
                IsCombatVisible = false;
                IsMiscellaneousVisible = true;
            }
        }
        #endregion

        #region IHandle Method
        public void Handle(string message)
        {
            switch (message)
            {
                case "AcceptRootDialog":
                    IsRootDialogOpen = false;
                    break;
                case "CancelRootDialog":
                    IsRootDialogOpen = false;
                    break;
                case "OpenCreateStoryDialog":
                    RootDialogContent = new AddStoryDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenStory":
                    IsStoryLoaded = true;
                    LoadedStoryName = Global.Instance.StoryName;
                    break;
                case "DeleteStory":
                    IsStoryLoaded = false;
                    LoadedStoryName = string.Empty;
                    break;
                case "StorySettings":
                    RootDialogContent = new StorySettingsDialog();
                    IsStoryLoaded = false;
                    IsRootDialogOpen = true;
                    LoadedStoryName = string.Empty;
                    break;
                case "OpenAddMapDialog":
                    RootDialogContent = new AddMapDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenAddPointDialog":
                    RootDialogContent = new AddPointDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenSubMap":
                    ActivateItem(new RealmForgeViewModel());
                    break;
                case "OpenAddSkillDialog":
                    RootDialogContent = new AddSkillDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenAddFeatDialog":
                    RootDialogContent = new AddFeatDialog();
                    IsRootDialogOpen = true;
                    break;
                case "SetLoadedForge":
                    LoadedForge = Global.Instance.LoadedForge;
                    break;
                case "OpenAddSpellDialog":
                    RootDialogContent = new AddSpellDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenProgressDialog":
                    RootDialogContent = new InProgressDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenAddFactionDialog":
                    RootDialogContent = new AddFactionDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenAddLanguageDialog":
                    RootDialogContent = new AddLanguageDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenAddPlayerDialog":
                    RootDialogContent = new AddPlayerDialog();
                    IsRootDialogOpen = true;
                    break;
                case "OpenChangePlayerDialog":
                    RootDialogContent = new ChangePlayerDialog();
                    IsRootDialogOpen = true;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

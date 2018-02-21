using Caliburn.Micro;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class Global
    {
        #region Singleton Pattern
        private static Global _instance;

        private Global() { }

        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }

                return _instance;
            }
        }
        #endregion

        #region Private Variables
        private SQLiteConnection _forgeDBConnection = null;
        private int _storyID;
        private string _storyName;
        private string _storyAuthor;
        private string _dateCreated;
        private string _storyType;
        private string _storyDescription;
        private SQLiteDataReader _sqlQueryResults;
        private bool _storyLoaded = false;
        private bool _baseMapLoaded = false;
        private string _loadedForge = string.Empty;
        #endregion

        #region NameGenerator
        private BindableCollection<NameAffix> _affixCollection = new BindableCollection<NameAffix>();
        private BindableCollection<NameInfix> _infixCollection = new BindableCollection<NameInfix>();
        private BindableCollection<NamePostfix> _postfixCollection = new BindableCollection<NamePostfix>();
        private BindableCollection<NamePrefix> _prefixCollection = new BindableCollection<NamePrefix>();
        private BindableCollection<NameSuffix> _suffixCollection = new BindableCollection<NameSuffix>();

        public BindableCollection<NameAffix> AffixCollection
        {
            get { return _affixCollection; }
            set
            {
                if (_affixCollection != value)
                    _affixCollection = value;
            }
        }
        public BindableCollection<NameInfix> InfixCollection
        {
            get { return _infixCollection; }
            set
            {
                if (_infixCollection != value)
                    _infixCollection = value;
            }
        }
        public BindableCollection<NamePostfix> PostfixCollection
        {
            get { return _postfixCollection; }
            set
            {
                if (_postfixCollection != value)
                    _postfixCollection = value;
            }
        }
        public BindableCollection<NamePrefix> PrefixCollection
        {
            get { return _prefixCollection; }
            set
            {
                if (_prefixCollection != value)
                    _prefixCollection = value;
            }
        }
        public BindableCollection<NameSuffix> SuffixCollection
        {
            get { return _suffixCollection; }
            set
            {
                if (_suffixCollection != value)
                    _suffixCollection = value;
            }
        }
        #endregion

        #region Codex Variables
        private BindableCollection<StoryCollection> _storyCollection = new BindableCollection<StoryCollection>();
        private BindableCollection<SpellCollection> _spellCollection = new BindableCollection<SpellCollection>();
        private BindableCollection<FeatCollection> _featCollection = new BindableCollection<FeatCollection>();
        private BindableCollection<SkillCollection> _skillCollection = new BindableCollection<SkillCollection>();
        private BindableCollection<FactionCollection> _factionCollection = new BindableCollection<FactionCollection>();
        private BindableCollection<LanguageCollection> _languageCollection = new BindableCollection<LanguageCollection>();
        private BindableCollection<BestiaryCollection> _bestiaryCollection = new BindableCollection<BestiaryCollection>();
        private BindableCollection<PlayerCollection> _playerCollection = new BindableCollection<PlayerCollection>();
        private BindableCollection<PushPinCollection> _pushPinCollection = new BindableCollection<PushPinCollection>();
        private BindableCollection<MapCollection> _mapCollection = new BindableCollection<MapCollection>();

        public BindableCollection<StoryCollection> StoryCollection
        {
            get { return _storyCollection; }
            set
            {
                if (_storyCollection != value)
                    _storyCollection = value;
            }
        }
        public BindableCollection<SpellCollection> SpellCollection
        {
            get { return _spellCollection; }
            set
            {
                if (_spellCollection != value)
                    _spellCollection = value;
            }
        }
        public BindableCollection<FeatCollection> FeatCollection
        {
            get { return _featCollection; }
            set
            {
                if (_featCollection != value)
                    _featCollection = value;
            }
        }
        public BindableCollection<SkillCollection> SkillCollection
        {
            get { return _skillCollection; }
            set
            {
                if (_skillCollection != value)
                    _skillCollection = value;
            }
        }
        public BindableCollection<FactionCollection> FactionCollection
        {
            get { return _factionCollection; }
            set
            {
                if (_factionCollection != value)
                    _factionCollection = value;
            }
        }
        public BindableCollection<LanguageCollection> LanguageCollection
        {
            get { return _languageCollection; }
            set
            {
                if (_languageCollection != value)
                    _languageCollection = value;
            }
        }
        public BindableCollection<BestiaryCollection> BestiaryCollection
        {
            get { return _bestiaryCollection; }
            set
            {
                if (_bestiaryCollection != value)
                    _bestiaryCollection = value;
            }
        }
        public BindableCollection<PlayerCollection> PlayerCollection
        {
            get { return _playerCollection; }
            set
            {
                if (_playerCollection != value)
                    _playerCollection = value;
            }
        }
        public BindableCollection<PushPinCollection> PushPinCollection
        {
            get { return _pushPinCollection; }
            set
            {
                if (_pushPinCollection != value)
                    _pushPinCollection = value;
            }
        }
        public BindableCollection<MapCollection> MapCollection
        {
            get { return _mapCollection; }
            set
            {
                if (_mapCollection != value)
                    _mapCollection = value;
            }
        }
        #endregion

        #region Local Application Variables
        private string _localApplicationPath;
        private string _localApplicationImagePath;

        public string LocalApplicationPath
        {
            get { return _localApplicationPath; }
            set
            {
                if (_localApplicationPath != value)
                    _localApplicationPath = value;
            }
        }
        public string LocalApplicationImagePath
        {
            get { return _localApplicationImagePath; }
            set
            {
                if (_localApplicationImagePath != value)
                    _localApplicationImagePath = value;
            }
        }
        #endregion

        #region Map Variables
        private int _mapID = -1;
        private int _baseMapID = -1;
        private int _previousMapID = -1;
        private int? _parentMapID = -1;
        private int? _baseParentMapID = -1;
        private string _mapName;
        private string _baseMapName;
        private string _mapPath;
        private string _baseMapPath;
        private int _mapWidth;
        private int _baseMapWidth;
        private int _mapHeight;
        private int _baseMapHeight;
        private bool _isBaseMap;
        private bool _baseIsBaseMap;
        private double _currentMapTop;
        private double _currentMapLeft;

        public int MapID
        {
            get { return _mapID; }
            set
            {
                if (_mapID != value)
                    _mapID = value;
            }
        }
        public int BaseMapID
        {
            get { return _baseMapID; }
            set
            {
                if (_baseMapID != value)
                    _baseMapID = value;
            }
        }
        public int PreviousMapID
        {
            get { return _previousMapID; }
            set
            {
                if (_previousMapID != value)
                    _previousMapID = value;
            }
        }
        public int? ParentMapID
        {
            get { return _parentMapID; }
            set
            {
                if (_parentMapID != value)
                    _parentMapID = value;
            }
        }
        public int? BaseParentMapID
        {
            get { return _baseParentMapID; }
            set
            {
                if (_baseParentMapID != value)
                    _baseParentMapID = value;
            }
        }
        public string MapName
        {
            get { return _mapName; }
            set
            {
                if (_mapName != value)
                    _mapName = value;
            }
        }
        public string BaseMapName
        {
            get { return _baseMapName; }
            set
            {
                if (_baseMapName != value)
                    _baseMapName = value;
            }
        }
        public string MapPath
        {
            get { return _mapPath; }
            set
            {
                if (_mapPath != value)
                    _mapPath = value;
            }
        }
        public string BaseMapPath
        {
            get { return _baseMapPath; }
            set
            {
                if (_baseMapPath != value)
                    _baseMapPath = value;
            }
        }
        public int MapWidth
        {
            get { return _mapWidth; }
            set
            {
                if (_mapWidth != value)
                    _mapWidth = value;
            }
        }
        public int BaseMapWidth
        {
            get { return _baseMapWidth; }
            set
            {
                if (_baseMapWidth != value)
                    _baseMapWidth = value;
            }
        }
        public int MapHeight
        {
            get { return _mapHeight; }
            set
            {
                if (_mapHeight != value)
                    _mapHeight = value;
            }
        }
        public int BaseMapHeight
        {
            get { return _baseMapHeight; }
            set
            {
                if (_baseMapHeight != value)
                    _baseMapHeight = value;
            }
        }
        public bool IsBaseMap
        {
            get { return _isBaseMap; }
            set
            {
                if (_isBaseMap != value)
                    _isBaseMap = value;
            }
        }
        public bool BaseIsBaseMap
        {
            get { return _baseIsBaseMap; }
            set
            {
                if (_baseIsBaseMap != value)
                    _baseIsBaseMap = value;
            }
        }
        public double CurrentMapTop
        {
            get { return _currentMapTop; }
            set
            {
                if (_currentMapTop != value)
                    _currentMapTop = value;
            }
        }
        public double CurrentMapLeft
        {
            get { return _currentMapLeft; }
            set
            {
                if (_currentMapLeft != value)
                    _currentMapLeft = value;
            }
        }
        #endregion

        #region Layer Variables
        private int _layerBaseID;
        private int _layerPointID;
        private int _layerRegionID;
        private int _layerRelationID;

        public int LayerBaseID
        {
            get { return _layerBaseID; }
            set
            {
                if (_layerBaseID != value)
                    _layerBaseID = value;
            }
        }
        public int LayerPointID
        {
            get { return _layerPointID; }
            set
            {
                if (_layerPointID != value)
                    _layerPointID = value;
            }
        }
        public int LayerRegionID
        {
            get { return _layerRegionID; }
            set
            {
                if (_layerRegionID != value)
                    _layerRegionID = value;
            }
        }
        public int LayerRelationID
        {
            get { return _layerRelationID; }
            set
            {
                if (_layerRelationID != value)
                    _layerRelationID = value;
            }
        }
        #endregion

        #region Public Variables
        public SQLiteConnection ForgeDBConnection
        {
            get { return _forgeDBConnection; }
            set
            {
                if (_forgeDBConnection != value)
                    _forgeDBConnection = value;
            }
        }
        public int StoryID
        {
            get { return _storyID; }
            set
            {
                if (_storyID != value)
                    _storyID = value;
            }
        }
        public string StoryName
        {
            get { return _storyName; }
            set
            {
                if (_storyName != value)
                    _storyName = value;
            }
        }
        public string StoryAuthor
        {
            get { return _storyAuthor; }
            set
            {
                if (_storyAuthor != value)
                    _storyAuthor = value;
            }
        }
        public string DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                    _dateCreated = value;
            }
        }
        public string StoryType
        {
            get { return _storyType; }
            set
            {
                if (_storyType != value)
                    _storyType = value;
            }
        }
        public string StoryDescription
        {
            get { return _storyDescription; }
            set
            {
                if (_storyDescription != value)
                    _storyDescription = value;
            }
        }
        public SQLiteDataReader SQLQueryResults
        {
            get { return _sqlQueryResults; }
            set
            {
                if (_sqlQueryResults != value)
                    _sqlQueryResults = value;
            }
        }
        public bool StoryLoaded
        {
            get { return _storyLoaded; }
            set
            {
                if (_storyLoaded != value)
                    _storyLoaded = value;
            }
        }
        public bool BaseMapLoaded
        {
            get { return _baseMapLoaded; }
            set
            {
                if (_baseMapLoaded != value)
                    _baseMapLoaded = value;
            }
        }
        public string LoadedForge
        {
            get { return _loadedForge; }
            set
            {
                if (_loadedForge != value)
                    _loadedForge = value;
            }
        }
        #endregion

        #region Player Variables
        private int _selectedPlayerID;

        public int SelectedPlayerID
        {
            get { return _selectedPlayerID; }
            set
            {
                if (_selectedPlayerID != value)
                    _selectedPlayerID = value;
            }
        }
        #endregion

        #region Methods
        public void InitiateDatabase()
        {
            try
            {
                if(File.Exists("ForgeDatabase.sqlite"))
                {
                    ForgeDBConnection = new SQLiteConnection(@"Data Source=ForgeDatabase.sqlite;foreign keys=True");
                    ForgeDBConnection.Open();
                }
            }
            catch { }
        }

        public ForgeDataContext ForgeDatabase()
        {
            try
            {
                if(File.Exists("ForgeDatabase.sdf"))
                {
                    string uriPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    string localPath = new Uri(uriPath).LocalPath;
                    var connection = new SqlCeConnection("Data Source=" + localPath + @"\ForgeDatabase.sdf;Max Database Size=4091;Persist Security Info=False;");
                    ForgeDataContext context = new ForgeDataContext(connection);
                    return context;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public void InitiateDatabaseNonQuery()
        {
            try
            {
                if (File.Exists("ForgeDatabase.sqlite"))
                {
                    ForgeDBConnection = new SQLiteConnection(@"Data Source=ForgeDatabase.sqlite");
                    ForgeDBConnection.Open();
                }
            }
            catch { }
        }

        public void CloseDatabase()
        {
            if(ForgeDBConnection.State == ConnectionState.Open)
                ForgeDBConnection.Close();
        }

        public void SQLInsert(string sql)
        {
            if (ForgeDBConnection.State == ConnectionState.Open)
            {               
                SQLiteCommand command = new SQLiteCommand(sql, ForgeDBConnection);
                command.ExecuteNonQuery();
                //int x = await command.ExecuteNonQueryAsync();
            }
        }

        public SQLiteDataReader SQLQuery(string sql)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, ForgeDBConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        public void UpdateNote(string note)
        {
            var date = DateTime.Now.ToShortDateString();
            var forgeDatabase = ForgeDatabase();
            UPDATED update = new UPDATED()
            {
                StoryID = StoryID,
                LastUpdated = date,
                Note = note
            };

            forgeDatabase.Updated.InsertOnSubmit(update);
            forgeDatabase.SubmitChanges();
        }

        public string StringContains(string text)
        {
            if (text.Contains("'"))
            {
                text = text.Replace("'", "''");
                return text;
            }
            return text;
        }
        #endregion
    }
}

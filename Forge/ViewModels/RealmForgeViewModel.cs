using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Linq;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forge.ViewModels
{
    [Export(typeof(RealmForgeViewModel))]
    public class RealmForgeViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private int _mapID;
        private int _storyID;
        private int? _parentMapID;
        private string _mapName;
        private string _mapPath;
        private int _mapWidth;
        private int _mapHeight;
        private bool _isBaseMap;
        private bool _noBaseMapLoaded = true;
        private BindableCollection<MapCollection> _mapCollection = new BindableCollection<MapCollection>();
        private BindableCollection<TableMap> _mapConverted = new BindableCollection<TableMap>();
        private Point _lastMousePosition;
        private ZoomableCanvas BaseCanvas;
        private bool _isSelectorChecked = true;
        private Cursor _selectorCursor;
        private int _selectedLayer = 0;
        private bool _mapContextMenuEnabled = false;
        private bool _baseContextEnabled = true;
        private bool _pointContextEnabled = false;
        private bool _regionContextEnabled = false;
        private bool _relationContextEnabled = false;
        private double _mousePositionX;
        private double _mousePositionY;
        private BindableCollection<PushPinCollection> _pushPinCollection = new BindableCollection<PushPinCollection>();
        private BindableCollection<TablePushPin> _pushPinConverted = new BindableCollection<TablePushPin>();
        private ImageSource _mapImage;
        private BindableCollection<PlayerCollection> _playerCollection = new BindableCollection<PlayerCollection>();
        
        #endregion

        #region Public Variables
        public int MapID
        {
            get { return _mapID; }
            set
            {
                if(_mapID != value)
                {
                    _mapID = value;
                    NotifyOfPropertyChange(() => MapID);
                }
            }
        }
        public int StoryID
        {
            get { return _storyID; }
            set
            {
                if(_storyID != value)
                {
                    _storyID = value;
                    NotifyOfPropertyChange(() => StoryID);
                }
            }
        }
        public int? ParentMapID
        {
            get { return _parentMapID; }
            set
            {
                if(_parentMapID != value)
                {
                    _parentMapID = value;
                    NotifyOfPropertyChange(() => ParentMapID);
                }
            }
        }
        public string MapName
        {
            get { return _mapName; }
            set
            {
                if(_mapName != value)
                {
                    _mapName = value;
                    NotifyOfPropertyChange(() => MapName);
                }
            }
        }
        public string MapPath
        {
            get { return _mapPath; }
            set
            {
                if(_mapPath != value)
                {
                    _mapPath = value;
                    NotifyOfPropertyChange(() => MapPath);
                }
            }
        }
        public int MapWidth
        {
            get { return _mapWidth; }
            set
            {
                if(_mapWidth != value)
                {
                    _mapWidth = value;
                    NotifyOfPropertyChange(() => MapWidth);
                }
            }
        }
        public int MapHeight
        {
            get { return _mapHeight; }
            set
            {
                if(_mapHeight != value)
                {
                    _mapHeight = value;
                    NotifyOfPropertyChange(() => MapHeight);
                }
            }
        }
        public bool IsBaseMap
        {
            get { return _isBaseMap; }
            set
            {
                if(_isBaseMap != value)
                {
                    _isBaseMap = value;
                    NotifyOfPropertyChange(() => IsBaseMap);
                }
            }
        }
        public bool NoBaseMapLoaded
        {
            get { return _noBaseMapLoaded; }
            set
            {
                if(_noBaseMapLoaded != value)
                {
                    _noBaseMapLoaded = value;
                    NotifyOfPropertyChange(() => NoBaseMapLoaded);
                }
            }
        }
        public BindableCollection<MapCollection> MapCollection
        {
            get { return _mapCollection; }
            set
            {
                if(_mapCollection != value)
                {
                    _mapCollection = value;
                    NotifyOfPropertyChange(() => MapCollection);
                }
            }
        }
        public bool IsSelectorChecked
        {
            get { return _isSelectorChecked; }
            set
            {
                if(_isSelectorChecked != value)
                {
                    _isSelectorChecked = value;
                    NotifyOfPropertyChange(() => IsSelectorChecked);
                }
            }
        }
        public Cursor SelectorCursor
        {
            get { return _selectorCursor; }
            set
            {
                if(_selectorCursor != value)
                {
                    _selectorCursor = value;
                    NotifyOfPropertyChange(() => SelectorCursor);
                }
            }
        }
        public int SelectedLayer
        {
            get { return _selectedLayer; }
            set
            {
                if(_selectedLayer != value)
                {
                    _selectedLayer = value;
                    NotifyOfPropertyChange(() => SelectedLayer);
                }
            }
        }
        public bool MapContextMenuEnabled
        {
            get { return _mapContextMenuEnabled; }
            set
            {
                if(_mapContextMenuEnabled != value)
                {
                    _mapContextMenuEnabled = value;
                    NotifyOfPropertyChange(() => MapContextMenuEnabled);
                }
            }
        }
        public bool BaseContextEnabled
        {
            get { return _baseContextEnabled; }
            set
            {
                if (_baseContextEnabled != value)
                {
                    _baseContextEnabled = value;
                    NotifyOfPropertyChange(() => BaseContextEnabled);
                }
            }
        }
        public bool PointContextEnabled
        {
            get { return _pointContextEnabled; }
            set
            {
                if (_pointContextEnabled != value)
                {
                    _pointContextEnabled = value;
                    NotifyOfPropertyChange(() => PointContextEnabled);
                }
            }
        }
        public bool RegionContextEnabled
        {
            get { return _regionContextEnabled; }
            set
            {
                if (_regionContextEnabled != value)
                {
                    _regionContextEnabled = value;
                    NotifyOfPropertyChange(() => RegionContextEnabled);
                }
            }
        }
        public bool RelationContextEnabled
        {
            get { return _relationContextEnabled; }
            set
            {
                if (_relationContextEnabled != value)
                {
                    _relationContextEnabled = value;
                    NotifyOfPropertyChange(() => RelationContextEnabled);
                }
            }
        }
        public double MousePositionX
        {
            get { return _mousePositionX; }
            set
            {
                if(_mousePositionX != value)
                {
                    _mousePositionX = value;
                    NotifyOfPropertyChange(() => MousePositionX);
                }
            }
        }
        public double MousePositionY
        {
            get { return _mousePositionY; }
            set
            {
                if (_mousePositionY != value)
                {
                    _mousePositionY = value;
                    NotifyOfPropertyChange(() => MousePositionY);
                }
            }
        }
        public BindableCollection<PushPinCollection> PushPinCollection
        {
            get { return _pushPinCollection; }
            set
            {
                if(_pushPinCollection != value)
                {
                    _pushPinCollection = value;
                    NotifyOfPropertyChange(() => PushPinCollection);
                }
            }
        }
        public ImageSource MapImage
        {
            get { return _mapImage; }
            set
            {
                _mapImage = value;
                NotifyOfPropertyChange(() => MapImage);
            }
        }
        public BindableCollection<PlayerCollection> PlayerCollection
        {
            get { return _playerCollection; }
            set
            {
                if(_playerCollection != null)
                {
                    _playerCollection = value;
                    NotifyOfPropertyChange(() => PlayerCollection);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public RealmForgeViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
            PopulateMapCollection();
            PopulatePlayerCollection();
            GetMap();
        }

        #region Private Methods        
        private void PopulateMapCollection()
        {
            try
            {
                var forgeDatabase = Global.Instance.ForgeDatabase();
                var tempMapCollection = new BindableCollection<MapCollection>();

                foreach(var map in forgeDatabase.Maps)
                {
                    bool isBaseMap = false;

                    if (map.IsBaseMap == 0)
                        isBaseMap = false;

                    if (map.IsBaseMap == 1)
                        isBaseMap = true;

                    tempMapCollection.Add(new MapCollection
                    {
                        MapID = map.ID,
                        StoryID = map.StoryID,
                        ParentMapID = map.ParentID,
                        MapName = map.Name,
                        MapPath = map.Path,
                        MapWidth = map.Width,
                        MapHeight = map.Height,
                        IsBaseMap = isBaseMap
                    });
                }

                if (tempMapCollection.SequenceEqual(Global.Instance.MapCollection))
                {
                    MapCollection = new BindableCollection<MapCollection>(tempMapCollection);
                }
                else
                {
                    Global.Instance.MapCollection = new BindableCollection<MapCollection>(tempMapCollection);
                    MapCollection = new BindableCollection<MapCollection>(tempMapCollection);
                }
            }
            catch { }
        }
        private void GetMap()
        {
            if (!Global.Instance.BaseMapLoaded)
            {
                if (MapCollection.Count() > 0)
                {
                    var count = MapCollection.Where(x => x.IsBaseMap == true).ToList();
                    if (count.Count() == 1)
                    {
                        foreach (var map in MapCollection.Where(x => x.IsBaseMap == true))
                        {
                            Global.Instance.BaseMapID = map.MapID;
                            Global.Instance.BaseParentMapID = map.ParentMapID;
                            Global.Instance.BaseMapName = map.MapName;
                            Global.Instance.BaseMapPath = map.MapPath;
                            Global.Instance.BaseMapWidth = map.MapWidth;
                            Global.Instance.BaseMapHeight = map.MapHeight;
                            Global.Instance.BaseIsBaseMap = map.IsBaseMap;
                        }

                        Global.Instance.BaseMapLoaded = true;

                        Global.Instance.MapID = Global.Instance.BaseMapID;
                        Global.Instance.ParentMapID = Global.Instance.BaseParentMapID;
                        Global.Instance.MapName = Global.Instance.BaseMapName;
                        Global.Instance.MapPath = Global.Instance.BaseMapPath;
                        Global.Instance.MapWidth = Global.Instance.BaseMapWidth;
                        Global.Instance.MapHeight = Global.Instance.BaseMapHeight;
                        Global.Instance.IsBaseMap = Global.Instance.BaseIsBaseMap;

                        NoBaseMapLoaded = false;

                        if (Global.Instance.MapID > -1)
                        {
                            //Get MapPath and load Image into memory
                            MapID = Global.Instance.MapID;
                            StoryID = Global.Instance.StoryID;
                            ParentMapID = Global.Instance.ParentMapID;
                            MapName = Global.Instance.MapName;
                            MapPath = Global.Instance.MapPath;
                            MapWidth = Global.Instance.MapWidth;
                            MapHeight = Global.Instance.MapHeight;
                            IsBaseMap = Global.Instance.IsBaseMap;

                            MapImage = null;

                            var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                            Task bkThread = Task.Factory.StartNew(() => MapImage = null)
                                .ContinueWith(t1 => MapImage = LoadMapToMemory(MapPath), uiThread);

                            GetLayers();
                            PopulatePushPinCollection();
                            NoBaseMapLoaded = false;
                        }
                        else
                        {
                            NoBaseMapLoaded = true;
                        }
                    }
                }
                else
                {
                    NoBaseMapLoaded = true;
                }
            }
            else
            {
                if(Global.Instance.MapID > -1)
                {
                    //Get MapPath and load Image into memory
                    MapID = Global.Instance.MapID;
                    StoryID = Global.Instance.StoryID;
                    ParentMapID = Global.Instance.ParentMapID;
                    MapName = Global.Instance.MapName;
                    MapPath = Global.Instance.MapPath;
                    MapWidth = Global.Instance.MapWidth;
                    MapHeight = Global.Instance.MapHeight;
                    IsBaseMap = Global.Instance.IsBaseMap;

                    //MapImage = null;

                    var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                    Task bkThread = Task.Factory.StartNew(() => MapImage = null)
                        .ContinueWith(t1 => MapImage = LoadMapToMemory(MapPath), uiThread);

                    //MapImage = LoadMapToMemory(MapPath);
                    GetLayers();
                    PopulatePushPinCollection();
                    NoBaseMapLoaded = false;
                }
                else
                {
                    NoBaseMapLoaded = true;
                }
            }
        }
        private void PopulatePushPinCollection()
        {
            try
            {
                var forgeDatabase = Global.Instance.ForgeDatabase();
                var tempPushPinCollection = new BindableCollection<PushPinCollection>();

                foreach(var pushPin in forgeDatabase.PushPins)
                {
                    bool hasMap = false;
                    if(pushPin.MapID != null || pushPin.MapID > 0)
                    {
                        hasMap = true;
                    }

                    tempPushPinCollection.Add(new PushPinCollection
                    {
                        PushPinID = pushPin.ID,
                        LayerID = pushPin.LayerID,
                        PushPinTop = pushPin.Top,
                        PushPinLeft = pushPin.Left,
                        PushPinName = pushPin.Name,
                        PushPinColor = pushPin.Color,
                        MapID = pushPin.MapID,
                        EncounterID = pushPin.EncounterID,
                        EventID = pushPin.EventID,
                        HasMap = hasMap
                    });
                }

                if (tempPushPinCollection.SequenceEqual(Global.Instance.PushPinCollection))
                {
                    PushPinCollection = new BindableCollection<PushPinCollection>(tempPushPinCollection);
                }
                else
                {
                    Global.Instance.PushPinCollection = new BindableCollection<PushPinCollection>(tempPushPinCollection);
                    PushPinCollection = new BindableCollection<PushPinCollection>(tempPushPinCollection);
                }
            }
            catch
            { }
        }
        private void GetLayers()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();

            foreach(var layer in forgeDatabase.Layers.Where(x => x.MapID == Global.Instance.MapID))
            {
                if(layer.Name == "Base Map Layer")
                {
                    Global.Instance.LayerBaseID = layer.ID;
                }

                if(layer.Name == "Point Layer")
                {
                    Global.Instance.LayerPointID = layer.ID;
                }

                if(layer.Name == "Region Layer")
                {
                    Global.Instance.LayerRegionID = layer.ID;
                }

                if(layer.Name == "Relation Layer")
                {
                    Global.Instance.LayerRelationID = layer.ID;
                }
            }
        }
        private BitmapImage LoadMapToMemory(string mapSource)
        {
            BitmapImage _image = new BitmapImage();

            using (var stream = new FileStream(mapSource, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                _image.BeginInit();
                _image.CacheOption = BitmapCacheOption.OnLoad;
                _image.StreamSource = stream;
                _image.EndInit();
                _image.Freeze();
            }

            return _image;
        }
        private void PopulatePlayerCollection()
        {
            try
            {
                var forgeDatabase = Global.Instance.ForgeDatabase();
                var tempPlayerCollection = new BindableCollection<PlayerCollection>();

                foreach(var player in forgeDatabase.Players.Where(x => x.StoryID == Global.Instance.StoryID))
                {
                    var playerFactions = new BindableCollection<PlayerFactionCollection>();
                    var playerSkills = new BindableCollection<PlayerSkillCollection>();
                    var playerLanguages = new BindableCollection<PlayerLanguageCollection>();

                    foreach(var faction in player.Factions)
                    {
                        playerFactions.Add(new PlayerFactionCollection
                        {
                            FactionName = faction.Name,
                            FactionDescription = faction.Description,
                            FactionStatus = faction.FactionStatus
                        });
                    }

                    foreach(var skill in forgeDatabase.PlayerSkills.Where(x => x.PlayerID == player.ID))
                    {
                        playerSkills.Add(new PlayerSkillCollection
                        {
                            SkillName = skill.SKILL.Name,
                            SkillDescription = skill.SKILL.Description,
                            SkillRank = skill.Rank
                        });
                    }

                    foreach(var language in player.Languages)
                    {
                        playerLanguages.Add(new PlayerLanguageCollection
                        {
                            LanguageName = language.Name,
                            LanguageDescription = language.Description
                        });
                    }

                    tempPlayerCollection.Add(new PlayerCollection {

                        PlayerID = player.ID,
                        StoryID = player.StoryID,
                        PlayerName = player.PlayerName,
                        CharacterName = player.CharacterName,
                        HitPoints = player.HitPoints,
                        Alignment = player.Alignment,
                        ArmorClass = player.ArmorClass,
                        TouchAC = player.TouchAC,
                        FlatFootedAC = player.FlatFootedAC,
                        CMD = player.CMD,
                        Fort = player.Fort,
                        Ref = player.Ref,
                        Will = player.Will,
                        Str = player.Str,
                        Dex = player.Dex,
                        Con = player.Con,
                        Int = player.Int,
                        Wis = player.Wis,
                        Cha = player.Cha,
                        Factions = new BindableCollection<PlayerFactionCollection>(playerFactions),
                        Skills = new BindableCollection<PlayerSkillCollection>(playerSkills),
                        Languages = new BindableCollection<PlayerLanguageCollection>(playerLanguages)
                    });
                }

                if (tempPlayerCollection.SequenceEqual(Global.Instance.PlayerCollection))
                {
                    PlayerCollection = new BindableCollection<PlayerCollection>(tempPlayerCollection);
                }
                else
                {
                    Global.Instance.PlayerCollection = new BindableCollection<PlayerCollection>(tempPlayerCollection);
                    PlayerCollection = new BindableCollection<PlayerCollection>(tempPlayerCollection);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region Public Methods
        public void AddMap()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddMapDialog");
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            Grid gridContainer = (Grid)sender;
            var position = e.GetPosition(gridContainer);

            if (IsSelectorChecked)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    BaseCanvas.Offset -= position - _lastMousePosition;

                    e.Handled = true;
                }

                _lastMousePosition = position;

                SelectorCursor = Cursors.SizeAll;
            }
            else
            {
                SelectorCursor = Cursors.Arrow;
            }
        }
        public void MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (IsSelectorChecked)
            {
                //handle mouse position
                Grid gridContainer = (Grid)sender;
                var position = e.GetPosition(gridContainer);

                //set layer MatrixTransforms
                var baseTransform = BaseCanvas.LayoutTransform as MatrixTransform;

                //set matrix for each transform
                var baseMatrix = baseTransform.Matrix;
                
                //set scale factor
                var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1);

                //set ScaleAtPrepend for each layer matrix
                baseMatrix.ScaleAtPrepend(scale, scale, position.X, position.Y);

                //set MatrixTransform to each layer Matrix
                baseTransform.Matrix = baseMatrix;

                //Handle the mouseWheel event
                e.Handled = true;
            }
        }
        public void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            var baseCanvas = (ZoomableCanvas)sender;
            var position = e.GetPosition(baseCanvas);

            position.X = Math.Round(position.X);
            position.Y = Math.Round(position.Y);

            MousePositionX = position.X;
            MousePositionY = position.Y;

            e.Handled = true;
        }
        public void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            var baseCanvas = (ZoomableCanvas)sender;
            var cMouse = Mouse.Capture(baseCanvas);
            var position = e.GetPosition(baseCanvas);

            Global.Instance.CurrentMapLeft = position.X - 8.0;
            Global.Instance.CurrentMapTop = position.Y - 8.0;

            cMouse = Mouse.Capture(null);
        }

        public void BaseMapLayer_Loaded(object sender, RoutedEventArgs e)
        {
            BaseCanvas = (ZoomableCanvas)sender;
        }

        public void LayerSelection(int selection)
        {
            SelectedLayer = selection;

            switch(SelectedLayer)
            {
                case 0:
                    BaseContextEnabled = true;
                    PointContextEnabled = false;
                    RegionContextEnabled = false;
                    RelationContextEnabled = false;
                    break;
                case 1:
                    BaseContextEnabled = false;
                    PointContextEnabled = true;
                    RegionContextEnabled = false;
                    RelationContextEnabled = false;
                    break;
                case 2:
                    BaseContextEnabled = false;
                    PointContextEnabled = false;
                    RegionContextEnabled = true;
                    RelationContextEnabled = false;
                    break;
                case 3:
                    BaseContextEnabled = false;
                    PointContextEnabled = false;
                    RegionContextEnabled = false;
                    RelationContextEnabled = true;
                    break;
                default:
                    break;
            }
        }
        public void AddPoint()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddPointDialog");
        }
        public void DeletePoint(int id)
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            PUSHPIN pushpin = forgeDatabase.PushPins.Single(p => p.ID == id);

            

            if(pushpin.MapID != null && pushpin.MapID > 0)
            {
                var mapID = pushpin.MapID;
                MAP map = forgeDatabase.Maps.Single(m => m.ID == mapID);

                //MessageBox.Show(map.ID.ToString());

                if(File.Exists(map.Path))
                {
                    File.Delete(map.Path);
                }

                forgeDatabase.PushPins.DeleteOnSubmit(pushpin);
                forgeDatabase.SubmitChanges();

                forgeDatabase.Maps.DeleteOnSubmit(map);
                forgeDatabase.SubmitChanges();

                PopulatePushPinCollection();
            }
            else
            {
                forgeDatabase.PushPins.DeleteOnSubmit(pushpin);
                forgeDatabase.SubmitChanges();

                PopulatePushPinCollection();
            }

            
        }

        public void ChangePoint(int id)
        {
            //var forgeDatabase = Global.Instance.ForgeDatabase();
            //PUSHPIN pushpin = forgeDatabase.PushPins.Single(p => p.ID == id);

            MessageBox.Show(id.ToString());

            /*if(pushpin.MapID != null && pushpin.MapID > 0)
            {
                var mapID = pushpin.MapID;
                MAP map = forgeDatabase.Maps.Single(m => m.ID == mapID);

                if(File.Exists(map.Path))
                {
                    File.Delete(map.Path);
                }

                forgeDatabase.Maps.DeleteOnSubmit(map);
                forgeDatabase.SubmitChanges();
            }*/

            //forgeDatabase.PushPins.DeleteOnSubmit(pushpin);
            //forgeDatabase.SubmitChanges();

            //PopulatePushPinCollection();
        }

        public void ChangePlayer(int id)
        {
            Global.Instance.SelectedPlayerID = id;
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenChangePlayerDialog");
        }

        public void OpenBaseMap()
        {
            if (Global.Instance.BaseMapLoaded)
            {
                Global.Instance.PreviousMapID = Global.Instance.MapID;

                Global.Instance.MapID = Global.Instance.BaseMapID;
                Global.Instance.ParentMapID = Global.Instance.BaseParentMapID;
                Global.Instance.MapName = Global.Instance.BaseMapName;
                Global.Instance.MapPath = Global.Instance.BaseMapPath;
                Global.Instance.MapWidth = Global.Instance.BaseMapWidth;
                Global.Instance.MapHeight = Global.Instance.BaseMapHeight;
                Global.Instance.IsBaseMap = Global.Instance.BaseIsBaseMap;

                IoC.Get<IEventAggregator>().PublishOnUIThread("OpenSubMap");
            }
        }
        public void OpenPreviousMap()
        {
            if(Global.Instance.PreviousMapID != -1)
            {
                OpenSubMap(Global.Instance.PreviousMapID);
            }
        }
        public void OpenSubMap(int mapID)
        {
            if (MapCollection.Count() > 0)
            {
                var subMap = MapCollection.Where(x => x.MapID == mapID).ToList();
                if (subMap.Count() == 1)
                {
                    Global.Instance.PreviousMapID = Global.Instance.MapID;

                    foreach (var map in subMap)
                    {
                        Global.Instance.MapID = map.MapID;
                        Global.Instance.ParentMapID = map.ParentMapID;
                        Global.Instance.MapName = map.MapName;
                        Global.Instance.MapPath = map.MapPath;
                        Global.Instance.MapWidth = map.MapWidth;
                        Global.Instance.MapHeight = map.MapHeight;
                        Global.Instance.IsBaseMap = map.IsBaseMap;
                    }
                    IoC.Get<IEventAggregator>().PublishOnUIThread("OpenSubMap");
                }
                else
                {
                    MessageBox.Show("There is no map with this ID or more then one hap has this ID");
                }
            }
            else
            {
                MessageBox.Show("MapCollection has no maps");
            }
        }

        public void AddPlayer()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddPlayerDialog");
        }
        #endregion

        #region IHandle Method
        public void Handle(string message)
        {
            switch (message)
            {
                case "AcceptAddMapDialog":
                    PopulateMapCollection();
                    GetMap();
                    break;
                case "AcceptAddPushPinDialog":
                    PopulatePushPinCollection();
                    PopulateMapCollection();
                    break;
                case "DeleteMapSource":
                    MapPath = string.Empty;                    
                    break;
                case "AcceptAddPlayerDialog":
                    PopulatePlayerCollection();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

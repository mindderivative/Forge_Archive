using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
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
    /// Interaction logic for AddPointDialog.xaml
    /// </summary>
    public partial class AddPointDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variable
        private int _storyID;
        private int _layerID;
        private int? _mapID = null;
        private double _pushPinTop;
        private double _pushPinLeft;
        private int? _encounterID = null;
        private int? _eventID = null;
        private string _pushPinColor = "#FF000000";

        private int _parentMapID;
        private string _mapName;
        private string _mapPath;
        private int _mapWidth;
        private int _mapHeight;
        private int _isBaseMap;
        private string _mapFormat;

        private bool _mapLocationLoaded = false;

        private string _nameTxt;
        #endregion

        #region Public Varibales
        public string NameTxt
        {
            get { return _nameTxt; }
            set
            {
                _nameTxt = value;
                NotifyOfPropertyChanged("NameTxt");
            }
        }
        #endregion

        public AddPointDialog()
        {
            InitializeComponent();
            GetVariables();
        }

        private void GetVariables()
        {
            _storyID = Global.Instance.StoryID;
            _parentMapID = Global.Instance.MapID;

            var forgeDatabase = Global.Instance.ForgeDatabase();

            LAYER layer = forgeDatabase.Layers.Single(l => l.MapID == Global.Instance.MapID && l.Name.Contains("Point Layer"));
            _layerID = layer.ID;

            PopupBoxIcon.Foreground = Brushes.Black;

            _pushPinTop = Global.Instance.CurrentMapTop;
            _pushPinLeft = Global.Instance.CurrentMapLeft;

            IsBaseMapCheckbox.IsChecked = false;
            IsBaseMapCheckbox.IsEnabled = false;
        }

        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private string GUID()
        {
            return Guid.NewGuid().ToString().Split('-').First();
        }

        private void SaveMap()
        {
            string _guid = GUID();
            if (MapLocation.Text != string.Empty || MapLocation.Text != "")
            {
                File.Copy(MapLocation.Text, Global.Instance.LocalApplicationImagePath + @"\" + Global.Instance.StoryID + @"_" + _guid + _mapFormat);

                if (File.Exists(Global.Instance.LocalApplicationImagePath + @"\" + Global.Instance.StoryID + @"_" + _guid + _mapFormat))
                {
                    _mapPath = Global.Instance.LocalApplicationImagePath + @"\" + Global.Instance.StoryID + @"_" + _guid + _mapFormat;
                }
            }
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(PushPinName))
            {
                if (_mapLocationLoaded)
                {
                    //Save Map to Database
                    SaveMap();

                    _mapName = MapName.Text;

                    int.TryParse(MapWidth.Text, out _mapWidth);
                    int.TryParse(MapHeight.Text, out _mapHeight);

                    var forgeDatabase = Global.Instance.ForgeDatabase();
                    MAP map = new MAP()
                    {
                        StoryID = _storyID,
                        ParentID = _parentMapID,
                        Name = _mapName,
                        Path = _mapPath,
                        Width = _mapWidth,
                        Height = _mapHeight,
                        IsBaseMap = _isBaseMap
                    };
                    forgeDatabase.Maps.InsertOnSubmit(map);
                    forgeDatabase.SubmitChanges();

                    MAP newMap = forgeDatabase.Maps.Single(m => m.Path.Contains(_mapPath));

                    int newMapID = newMap.ID;
                    _mapID = newMapID;
                    List<LAYER> layers = new List<LAYER>
                    {
                        new LAYER
                        {
                            MapID = newMapID,
                            Name = "Base Map Layer",
                            ZIndex = "60"
                        },

                        new LAYER
                        {
                            MapID = newMapID,
                            Name = "Point Layer",
                            ZIndex = "70"
                        },

                        new LAYER
                        {
                            MapID = newMapID,
                            Name = "Region Layer",
                            ZIndex = "80"
                        },

                        new LAYER
                        {
                            MapID = newMapID,
                            Name = "Relation Layer",
                            ZIndex = "90"
                        }
                    };


                    forgeDatabase.Layers.InsertAllOnSubmit(layers);
                    forgeDatabase.SubmitChanges();
                }

                string pushPinName = PushPinName.Text;

                var forgeDatabasePushPin = Global.Instance.ForgeDatabase();
                PUSHPIN pushpin = new PUSHPIN()
                {
                    LayerID = _layerID,
                    Top = _pushPinTop,
                    Left = _pushPinLeft,
                    Name = pushPinName,
                    Color = _pushPinColor,
                    MapID = _mapID,
                    EncounterID = _encounterID,
                    EventID = _eventID
                };

                forgeDatabasePushPin.PushPins.InsertOnSubmit(pushpin);
                forgeDatabasePushPin.SubmitChanges();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddPushPinDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
            }
        }

        private void ColorSelected(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            _pushPinColor = radioButton.Background.ToString();

            PopupBoxIcon.Foreground = radioButton.Background;
            PushPinColorWheelCenterButton.Background = radioButton.Background;
            PushPinColorWheelCenterButton.ToolTip = "Selected color - " + radioButton.Background.ToString();
        }

        private async void BrowseMapAsync(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = "*.png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string filename = dlg.FileName;
                MapLocation.Text = filename;

                MapName.Text = dlg.SafeFileName;
                _mapFormat = System.IO.Path.GetExtension(filename);

                await LoadMapImage(filename);
            }
        }

        public async Task LoadMapImage(string filename)
        {

            var bmp = await Task.Run(() =>
            {
                using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    return BitmapFrame.Create(fileStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            });

            bmp.Freeze();
            MapWidth.Text = bmp.PixelWidth.ToString();
            MapHeight.Text = bmp.PixelHeight.ToString();

            _mapLocationLoaded = true;

            MapInfo.Visibility = Visibility.Visible;
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

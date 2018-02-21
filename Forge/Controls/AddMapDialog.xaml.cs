using Caliburn.Micro;
using System;
using System.Collections.Generic;
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
using Forge.Classes;
using System.Data.SQLite;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using Forge.Tables;

namespace Forge.Controls
{
    /// <summary>
    /// Interaction logic for AddMapDialog.xaml
    /// </summary>
    public partial class AddMapDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variables
        private int _storyID;
        private int? _parentMapID;
        private string _mapName;
        private string _mapPath;
        private int _mapWidth;
        private int _mapHeight;
        private int _isBaseMap;
        private string _mapFormat;
        private string _mapLocationTxt;
        #endregion

        #region Public Variables
        public string MapLocationTxt
        {
            get { return _mapLocationTxt; }
            set
            {
                _mapLocationTxt = value;
                NotifyOfPropertyChanged("MapLocationTxt");
            }
        }
        #endregion

        public AddMapDialog()
        {
            InitializeComponent();
        }

        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(MapLocation))
            {
                _storyID = Global.Instance.StoryID;
                SaveMap();

                if (IsBaseMapCheckbox.IsChecked == true)
                {
                    _parentMapID = null;
                    _isBaseMap = 1;
                }
                else
                {
                    _parentMapID = Global.Instance.ParentMapID;
                    _isBaseMap = 0;
                }
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

                var frogeDatabaseMap = Global.Instance.ForgeDatabase();

                MAP newMap = frogeDatabaseMap.Maps.Single(m => m.Path.Contains(_mapPath));

                int newMapID = newMap.ID;
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


                frogeDatabaseMap.Layers.InsertAllOnSubmit(layers);
                frogeDatabaseMap.SubmitChanges();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddMapDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
            }
        }

        private void SaveMap()
        {
            string _guid = GUID();
            if(MapLocation.Text != string.Empty || MapLocation.Text != "")
            {
                File.Copy(MapLocation.Text, Global.Instance.LocalApplicationImagePath + @"\" + Global.Instance.StoryID + @"_" + _guid + _mapFormat);

                if(File.Exists(Global.Instance.LocalApplicationImagePath + @"\" + Global.Instance.StoryID + @"_" + _guid + _mapFormat))
                {
                    _mapPath = Global.Instance.LocalApplicationImagePath + @"\" + Global.Instance.StoryID + @"_" + _guid + _mapFormat;
                }
            }
        }

        private string GUID()
        {
            return Guid.NewGuid().ToString().Split('-').First();
        }

        private async void BrowseMapAsync(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = "*.png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if(result.HasValue && result.Value)
            {
                string filename = dlg.FileName;
                MapLocation.Text = filename;

                MapName.Text = dlg.SafeFileName;
                _mapFormat = System.IO.Path.GetExtension(filename);

                await LoadMapImage(filename);
            }
        }

        private void CheckBaseMap()
        {
            if(Global.Instance.BaseMapLoaded)
            {
                IsBaseMapCheckbox.IsEnabled = false;
            }
            else
            {
                IsBaseMapCheckbox.IsEnabled = true;
                IsBaseMapCheckbox.IsChecked = true;
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

            MapInfo.Visibility = Visibility.Visible;
            CheckBaseMap();
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

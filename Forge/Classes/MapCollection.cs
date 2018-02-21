using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class MapCollection : PropertyChangedBase
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
        #endregion

        #region Public Variables
        public int MapID
        {
            get { return _mapID; }
            set
            {
                if (_mapID != value)
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
                if (_storyID != value)
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
                if (_parentMapID != value)
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
                if (_mapName != value)
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
                if (_mapPath != value)
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
                if (_mapWidth != value)
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
                if (_mapHeight != value)
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
                if (_isBaseMap != value)
                {
                    _isBaseMap = value;
                    NotifyOfPropertyChange(() => IsBaseMap);
                }
            }
        }
        #endregion
    }
}

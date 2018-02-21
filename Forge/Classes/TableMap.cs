using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class TableMap : PropertyChangedBase
    {
        #region Private Variables
        private object _mapID;
        private object _storyID;
        private object _parentMapID;
        private object _mapName;
        private object _mapPath;
        private object _mapWidth;
        private object _mapHeight;
        private object _isBaseMap;
        #endregion

        #region Public Variables
        public object MapID
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
        public object StoryID
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
        public object ParentMapID
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
        public object MapName
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
        public object MapPath
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
        public object MapWidth
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
        public object MapHeight
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
        public object IsBaseMap
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
        #endregion

    }
}

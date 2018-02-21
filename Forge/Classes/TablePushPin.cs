using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class TablePushPin : PropertyChangedBase
    {
        private object _pushPinID;
        private object _layerID;
        private object _pushPinTop;
        private object _pushPinLeft;
        private object _pushPinName;
        private object _pushPinColor;
        private object _mapID;
        private object _encounterID;
        private object _eventID;

        public object PushPinID
        {
            get { return _pushPinID; }
            set
            {
                if(_pushPinID != value)
                {
                    _pushPinID = value;
                    NotifyOfPropertyChange(() => PushPinID);
                }
            }
        }
        public object LayerID
        {
            get { return _layerID; }
            set
            {
                if(_layerID != value)
                {
                    _layerID = value;
                    NotifyOfPropertyChange(() => LayerID);
                }
            }
        }
        public object PushPinTop
        {
            get { return _pushPinTop; }
            set
            {
                if(_pushPinTop != value)
                {
                    _pushPinTop = value;
                    NotifyOfPropertyChange(() => PushPinTop);
                }
            }
        }
        public object PushPinLeft
        {
            get { return _pushPinLeft; }
            set
            {
                if(_pushPinLeft != value)
                {
                    _pushPinLeft = value;
                    NotifyOfPropertyChange(() => PushPinLeft);
                }
            }
        }
        public object PushPinName
        {
            get { return _pushPinName; }
            set
            {
                if(_pushPinName != value)
                {
                    _pushPinName = value;
                    NotifyOfPropertyChange(() => PushPinName);
                }
            }
        }
        public object PushPinColor
        {
            get { return _pushPinColor; }
            set
            {
                if(_pushPinColor != value)
                {
                    _pushPinColor = value;
                    NotifyOfPropertyChange(() => PushPinColor);
                }
            }
        }
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
        public object EncounterID
        {
            get { return _encounterID; }
            set
            {
                if(_encounterID != value)
                {
                    _encounterID = value;
                    NotifyOfPropertyChange(() => EncounterID);
                }
            }
        }
        public object EventID
        {
            get { return _eventID; }
            set
            {
                if(_eventID != value)
                {
                    _eventID = value;
                    NotifyOfPropertyChange(() => EventID);
                }
            }
        }
    }
}

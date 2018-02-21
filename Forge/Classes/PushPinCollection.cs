using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class PushPinCollection : PropertyChangedBase
    {
        private int _pushPinID;
        private int _layerID;
        private double _pushPinTop;
        private double _pushPinLeft;
        private string _pushPinName;
        private string _pushPinColor;
        private int? _mapID;
        private int? _encounterID;
        private int? _eventID;
        private bool _hasMap;

        public int PushPinID
        {
            get { return _pushPinID; }
            set
            {
                if (_pushPinID != value)
                {
                    _pushPinID = value;
                    NotifyOfPropertyChange(() => PushPinID);
                }
            }
        }
        public int LayerID
        {
            get { return _layerID; }
            set
            {
                if (_layerID != value)
                {
                    _layerID = value;
                    NotifyOfPropertyChange(() => LayerID);
                }
            }
        }
        public double PushPinTop
        {
            get { return _pushPinTop; }
            set
            {
                if (_pushPinTop != value)
                {
                    _pushPinTop = value;
                    NotifyOfPropertyChange(() => PushPinTop);
                }
            }
        }
        public double PushPinLeft
        {
            get { return _pushPinLeft; }
            set
            {
                if (_pushPinLeft != value)
                {
                    _pushPinLeft = value;
                    NotifyOfPropertyChange(() => PushPinLeft);
                }
            }
        }
        public string PushPinName
        {
            get { return _pushPinName; }
            set
            {
                if (_pushPinName != value)
                {
                    _pushPinName = value;
                    NotifyOfPropertyChange(() => PushPinName);
                }
            }
        }
        public string PushPinColor
        {
            get { return _pushPinColor; }
            set
            {
                if (_pushPinColor != value)
                {
                    _pushPinColor = value;
                    NotifyOfPropertyChange(() => PushPinColor);
                }
            }
        }
        public int? MapID
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
        public int? EncounterID
        {
            get { return _encounterID; }
            set
            {
                if (_encounterID != value)
                {
                    _encounterID = value;
                    NotifyOfPropertyChange(() => EncounterID);
                }
            }
        }
        public int? EventID
        {
            get { return _eventID; }
            set
            {
                if (_eventID != value)
                {
                    _eventID = value;
                    NotifyOfPropertyChange(() => EventID);
                }
            }
        }
        public bool HasMap
        {
            get { return _hasMap; }
            set
            {
                if(_hasMap != value)
                {
                    _hasMap = value;
                    NotifyOfPropertyChange(() => HasMap);
                }
            }
        }
    }
}

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class PlayerCollection : PropertyChangedBase
    {
        private int _playerID;
        private int _storyID;
        private string _playerName;
        private string _characterName;
        private int _hitPoints;
        private string _alignment;
        private int _armorClass;
        private int _touchAC;
        private int _flatFootedAC;
        private int _cmd;
        private int _fort;
        private int _ref;
        private int _will;
        private int _str;
        private int _dex;
        private int _con;
        private int _int;
        private int _wis;
        private int _cha;
        private BindableCollection<PlayerLanguageCollection> _languages = new BindableCollection<PlayerLanguageCollection>();
        private BindableCollection<PlayerSkillCollection> _skills = new BindableCollection<PlayerSkillCollection>();
        private BindableCollection<PlayerFactionCollection> _factions = new BindableCollection<PlayerFactionCollection>();

        public int PlayerID
        {
            get { return _playerID; }
            set
            {
                _playerID = value;
                NotifyOfPropertyChange(() => PlayerID);
            }
        }
        public int StoryID
        {
            get { return _storyID; }
            set
            {
                _storyID = value;
                NotifyOfPropertyChange(() => StoryID);
            }
        }
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                NotifyOfPropertyChange(() => PlayerName);
            }
        }
        public string CharacterName
        {
            get { return _characterName; }
            set
            {
                _characterName = value;
                NotifyOfPropertyChange(() => CharacterName);
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                NotifyOfPropertyChange(() => HitPoints);
            }
        }
        public string Alignment
        {
            get { return _alignment; }
            set
            {
                _alignment = value;
                NotifyOfPropertyChange(() => Alignment);
            }
        }
        public int ArmorClass
        {
            get { return _armorClass; }
            set
            {
                _armorClass = value;
                NotifyOfPropertyChange(() => ArmorClass);
            }
        }
        public int TouchAC
        {
            get { return _touchAC; }
            set
            {
                _touchAC = value;
                NotifyOfPropertyChange(() => TouchAC);
            }
        }
        public int FlatFootedAC
        {
            get { return _flatFootedAC; }
            set
            {
                _flatFootedAC = value;
                NotifyOfPropertyChange(() => FlatFootedAC);
            }
        }
        public int CMD
        {
            get { return _cmd; }
            set
            {
                _cmd = value;
                NotifyOfPropertyChange(() => CMD);
            }
        }
        public int Fort
        {
            get { return _fort; }
            set
            {
                _fort = value;
                NotifyOfPropertyChange(() => Fort);
            }
        }
        public int Ref
        {
            get { return _ref; }
            set
            {
                _ref = value;
                NotifyOfPropertyChange(() => Ref);
            }
        }
        public int Will
        {
            get { return _will; }
            set
            {
                _will = value;
                NotifyOfPropertyChange(() => Will);
            }
        }
        public int Str
        {
            get { return _str; }
            set
            {
                _str = value;
                NotifyOfPropertyChange(() => Str);
            }
        }
        public int Dex
        {
            get { return _dex; }
            set
            {
                _dex = value;
                NotifyOfPropertyChange(() => Dex);
            }
        }
        public int Con
        {
            get { return _con; }
            set
            {
                _con = value;
                NotifyOfPropertyChange(() => Con);
            }
        }
        public int Int
        {
            get { return _int; }
            set
            {
                _int = value;
                NotifyOfPropertyChange(() => Int);
            }
        }
        public int Wis
        {
            get { return _wis; }
            set
            {
                _wis = value;
                NotifyOfPropertyChange(() => Wis);
            }
        }
        public int Cha
        {
            get { return _cha; }
            set
            {
                _cha = value;
                NotifyOfPropertyChange(() => Cha);
            }
        }
        public BindableCollection<PlayerLanguageCollection> Languages
        {
            get { return _languages; }
            set
            {
                _languages = value;
                NotifyOfPropertyChange(() => Languages);
            }
        }
        public BindableCollection<PlayerSkillCollection> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                NotifyOfPropertyChange(() => Skills);
            }
        }
        public BindableCollection<PlayerFactionCollection> Factions
        {
            get { return _factions; }
            set
            {
                _factions = value;
                NotifyOfPropertyChange(() => Factions);
            }
        }
    }
}

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class ImportBestiaryCollection : PropertyChangedBase
    {
        #region Private Variables
        private string _name;
        private float _cr;
        private int _xp;
        private string _race;
        private string _class1;
        private int _class1Level;
        private string _class2;
        private int _class2Level;
        private string _alignment;
        private string _size;
        private string _type;
        private string _subType1;
        private string _subType2;
        private string _subType3;
        private string _subType4;
        private string _subType5;
        private string _subType6;
        private int _ac;
        private int _acTouch;
        private int _acFlatFooted;
        private int _hp;
        private string _hd;
        private string _fort;
        private string _ref;
        private string _will;
        private string _melee;
        private string _ranged;
        private string _reach;
        private string _str;
        private string _dex;
        private string _con;
        private string _int;
        private string _wis;
        private string _cha;
        private string _feats;
        private string _skills;
        private string _racialMods;
        private string _languages;
        private string _sq;
        private string _environment;
        private string _organization;
        private string _treasure;
        private string _group;
        private string _gear;
        private string _otherGear;
        private string _speed;
        #endregion

        #region Public Variables
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
        }
        public float CR
        {
            get { return _cr; }
            set
            {
                if (_cr != value)
                {
                    _cr = value;
                    NotifyOfPropertyChange(() => CR);
                }
            }
        }
        public int XP
        {
            get { return _xp; }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                    NotifyOfPropertyChange(() => XP);
                }
            }
        }
        public string Race
        {
            get { return _race; }
            set
            {
                if (_race != value)
                {
                    _race = value;
                    NotifyOfPropertyChange(() => Race);
                }
            }
        }
        public string Class1
        {
            get { return _class1; }
            set
            {
                if (_class1 != value)
                {
                    _class1 = value;
                    NotifyOfPropertyChange(() => Class1);
                }
            }
        }
        public int Class1Level
        {
            get { return _class1Level; }
            set
            {
                if (_class1Level != value)
                {
                    _class1Level = value;
                    NotifyOfPropertyChange(() => Class1Level);
                }
            }
        }
        public string Class2
        {
            get { return _class2; }
            set
            {
                if (_class2 != value)
                {
                    _class2 = value;
                    NotifyOfPropertyChange(() => Class2);
                }
            }
        }
        public int Class2Level
        {
            get { return _class2Level; }
            set
            {
                if (_class2Level != value)
                {
                    _class2Level = value;
                    NotifyOfPropertyChange(() => Class2Level);
                }
            }
        }
        public string Alignment
        {
            get { return _alignment; }
            set
            {
                if (_alignment != value)
                {
                    _alignment = value;
                    NotifyOfPropertyChange(() => Alignment);
                }
            }
        }
        public string Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    NotifyOfPropertyChange(() => Size);
                }
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    NotifyOfPropertyChange(() => Type);
                }
            }
        }
        public string SubType1
        {
            get { return _subType1; }
            set
            {
                if (_subType1 != value)
                {
                    _subType1 = value;
                    NotifyOfPropertyChange(() => SubType1);
                }
            }
        }
        public string SubType2
        {
            get { return _subType2; }
            set
            {
                if (_subType2 != value)
                {
                    _subType2 = value;
                    NotifyOfPropertyChange(() => SubType2);
                }
            }
        }
        public string SubType3
        {
            get { return _subType3; }
            set
            {
                if (_subType3 != value)
                {
                    _subType3 = value;
                    NotifyOfPropertyChange(() => SubType3);
                }
            }
        }
        public string SubType4
        {
            get { return _subType4; }
            set
            {
                if (_subType4 != value)
                {
                    _subType4 = value;
                    NotifyOfPropertyChange(() => SubType4);
                }
            }
        }
        public string SubType5
        {
            get { return _subType5; }
            set
            {
                if (_subType5 != value)
                {
                    _subType5 = value;
                    NotifyOfPropertyChange(() => SubType5);
                }
            }
        }
        public string SubType6
        {
            get { return _subType6; }
            set
            {
                if (_subType6 != value)
                {
                    _subType6 = value;
                    NotifyOfPropertyChange(() => SubType6);
                }
            }
        }
        public int AC
        {
            get { return _ac; }
            set
            {
                if (_ac != value)
                {
                    _ac = value;
                    NotifyOfPropertyChange(() => AC);
                }
            }
        }
        public int ACTouch
        {
            get { return _acTouch; }
            set
            {
                if (_acTouch != value)
                {
                    _acTouch = value;
                    NotifyOfPropertyChange(() => ACTouch);
                }
            }
        }
        public int ACFlatFooted
        {
            get { return _acFlatFooted; }
            set
            {
                if (_acFlatFooted != value)
                {
                    _acFlatFooted = value;
                    NotifyOfPropertyChange(() => ACFlatFooted);
                }
            }
        }
        public int HP
        {
            get { return _hp; }
            set
            {
                if (_hp != value)
                {
                    _hp = value;
                    NotifyOfPropertyChange(() => HP);
                }
            }
        }
        public string HD
        {
            get { return _hd; }
            set
            {
                if (_hd != value)
                {
                    _hd = value;
                    NotifyOfPropertyChange(() => HD);
                }
            }
        }
        public string Fort
        {
            get { return _fort; }
            set
            {
                if (_fort != value)
                {
                    _fort = value;
                    NotifyOfPropertyChange(() => Fort);
                }
            }
        }
        public string Ref
        {
            get { return _ref; }
            set
            {
                if (_ref != value)
                {
                    _ref = value;
                    NotifyOfPropertyChange(() => Ref);
                }
            }
        }
        public string Will
        {
            get { return _will; }
            set
            {
                if (_will != value)
                {
                    _will = value;
                    NotifyOfPropertyChange(() => Will);
                }
            }
        }
        public string Melee
        {
            get { return _melee; }
            set
            {
                if (_melee != value)
                {
                    _melee = value;
                    NotifyOfPropertyChange(() => Melee);
                }
            }
        }
        public string Ranged
        {
            get { return _ranged; }
            set
            {
                if (_ranged != value)
                {
                    _ranged = value;
                    NotifyOfPropertyChange(() => Ranged);
                }
            }
        }
        public string Reach
        {
            get { return _reach; }
            set
            {
                if (_reach != value)
                {
                    _reach = value;
                    NotifyOfPropertyChange(() => Reach);
                }
            }
        }
        public string Str
        {
            get { return _str; }
            set
            {
                if (_str != value)
                {
                    _str = value;
                    NotifyOfPropertyChange(() => Str);
                }
            }
        }
        public string Dex
        {
            get { return _dex; }
            set
            {
                if (_dex != value)
                {
                    _dex = value;
                    NotifyOfPropertyChange(() => Dex);
                }
            }
        }
        public string Con
        {
            get { return _con; }
            set
            {
                if (_con != value)
                {
                    _con = value;
                    NotifyOfPropertyChange(() => Con);
                }
            }
        }
        public string Int
        {
            get { return _int; }
            set
            {
                if (_int != value)
                {
                    _int = value;
                    NotifyOfPropertyChange(() => Int);
                }
            }
        }
        public string Wis
        {
            get { return _wis; }
            set
            {
                if (_wis != value)
                {
                    _wis = value;
                    NotifyOfPropertyChange(() => Wis);
                }
            }
        }
        public string Cha
        {
            get { return _cha; }
            set
            {
                if (_cha != value)
                {
                    _cha = value;
                    NotifyOfPropertyChange(() => Cha);
                }
            }
        }
        public string Feats
        {
            get { return _feats; }
            set
            {
                if (_feats != value)
                {
                    _feats = value;
                    NotifyOfPropertyChange(() => Feats);
                }
            }
        }
        public string Skills
        {
            get { return _skills; }
            set
            {
                if (_skills != value)
                {
                    _skills = value;
                    NotifyOfPropertyChange(() => Skills);
                }
            }
        }
        public string RacialMods
        {
            get { return _racialMods; }
            set
            {
                if (_racialMods != value)
                {
                    _racialMods = value;
                    NotifyOfPropertyChange(() => RacialMods);
                }
            }
        }
        public string Languages
        {
            get { return _languages; }
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    NotifyOfPropertyChange(() => Languages);
                }
            }
        }
        public string SQ
        {
            get { return _sq; }
            set
            {
                if (_sq != value)
                {
                    _sq = value;
                    NotifyOfPropertyChange(() => SQ);
                }
            }
        }
        public string Environment
        {
            get { return _environment; }
            set
            {
                if (_environment != value)
                {
                    _environment = value;
                    NotifyOfPropertyChange(() => Environment);
                }
            }
        }
        public string Organization
        {
            get { return _organization; }
            set
            {
                if (_organization != value)
                {
                    _organization = value;
                    NotifyOfPropertyChange(() => Organization);
                }
            }
        }
        public string Treasure
        {
            get { return _treasure; }
            set
            {
                if (_treasure != value)
                {
                    _treasure = value;
                    NotifyOfPropertyChange(() => Treasure);
                }
            }
        }
        public string Group
        {
            get { return _group; }
            set
            {
                if (_group != value)
                {
                    _group = value;
                    NotifyOfPropertyChange(() => Group);
                }
            }
        }
        public string Gear
        {
            get { return _gear; }
            set
            {
                if (_gear != value)
                {
                    _gear = value;
                    NotifyOfPropertyChange(() => Gear);
                }
            }
        }
        public string OtherGear
        {
            get { return _otherGear; }
            set
            {
                if (_otherGear != value)
                {
                    _otherGear = value;
                    NotifyOfPropertyChange(() => OtherGear);
                }
            }
        }
        public string Speed
        {
            get { return _speed; }
            set
            {
                if (_speed != value)
                {
                    _speed = value;
                    NotifyOfPropertyChange(() => Speed);
                }
            }
        }
        #endregion
    }
}

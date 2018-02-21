using Caliburn.Micro;
using System.ComponentModel.Composition;
using MaterialDesignColors;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SQLite;
using Forge.Classes;
using System.Data.OleDb;
using Microsoft.Win32;
using System.Windows;
using System.Data;
using OfficeOpenXml;
using EPPlus.DataExtractor;
using System.Text;
using System.Windows.Input;
using Forge.Tables;

namespace Forge.ViewModels
{
    [Export(typeof(BestiaryViewModel))]
    public class BestiaryViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<BestiaryCollection> _bestiaryCollection = new BindableCollection<BestiaryCollection>();
        private int _selectedIndex = -1;
        private bool _isBestiarySelected = false;
        private bool _isNameSearch = true;
        private bool _isCRSearch = false;
        private bool _isTypeSearch = false;

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
        public BindableCollection<BestiaryCollection> BestiaryCollection
        {
            get { return _bestiaryCollection; }
            set
            {
                if (_bestiaryCollection != value)
                {
                    _bestiaryCollection = value;
                    NotifyOfPropertyChange(() => BestiaryCollection);
                }
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    NotifyOfPropertyChange(() => SelectedIndex);

                    if (_selectedIndex >= 0)
                    {
                        IsBestiarySelected = true;
                    }
                    else
                    {
                        IsBestiarySelected = false;
                    }
                }
            }
        }
        public bool IsBestiarySelected
        {
            get { return _isBestiarySelected; }
            set
            {
                if (_isBestiarySelected != value)
                {
                    _isBestiarySelected = value;
                    NotifyOfPropertyChange(() => IsBestiarySelected);
                }
            }
        }
        public bool IsNameSearch
        {
            get { return _isNameSearch; }
            set
            {
                if (_isNameSearch != value)
                {
                    _isNameSearch = value;
                    NotifyOfPropertyChange(() => IsNameSearch);
                }
            }
        }
        public bool IsCRSearch
        {
            get { return _isCRSearch; }
            set
            {
                if (_isCRSearch != value)
                {
                    _isCRSearch = value;
                    NotifyOfPropertyChange(() => IsCRSearch);
                }
            }
        }
        public bool IsTypeSearch
        {
            get { return _isTypeSearch; }
            set
            {
                if (_isTypeSearch != value)
                {
                    _isTypeSearch = value;
                    NotifyOfPropertyChange(() => IsTypeSearch);
                }
            }
        }

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

        [ImportingConstructor]
        public BestiaryViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);

            PopulateBestiaryCollectionAsync();
        }

        #region Private Methods
        private void PopulateBestiaryCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempBestiaryCollection = new BindableCollection<BestiaryCollection>();

            foreach(var beast in forgeDatabase.Bestiary)
            {
                tempBestiaryCollection.Add(new BestiaryCollection
                {
                    ID = beast.ID,
                    Name = beast.Name,
                    CR = beast.CR,
                    XP = beast.XP,
                    Race = beast.Race,
                    Class1 = beast.Class1,
                    Class1Level = beast.Class1Level,
                    Class2 = beast.Class2,
                    Class2Level = beast.Class2Level,
                    Alignment = beast.Alignment,
                    Size = beast.Size,
                    Type = beast.Type,
                    SubType1 = beast.SubType1,
                    SubType2 = beast.SubType2,
                    SubType3 = beast.SubType3,
                    SubType4 = beast.SubType4,
                    SubType5 = beast.SubType5,
                    SubType6 = beast.SubType6,
                    AC = beast.AC,
                    ACTouch = beast.ACTouch,
                    ACFlatFooted = beast.ACFlatFooted,
                    HP = beast.HP,
                    HD = beast.HD,
                    Fort = beast.Fort,
                    Ref = beast.Ref,
                    Will = beast.Will,
                    Melee = beast.Melee,
                    Ranged = beast.Ranged,
                    Reach = beast.Reach,
                    Str = beast.Str,
                    Dex = beast.Dex,
                    Con = beast.Con,
                    Int = beast.Int,
                    Wis = beast.Wis,
                    Cha = beast.Cha,
                    Feats = beast.Feats,
                    Skills = beast.Skills,
                    RacialMods = beast.RacialMods,
                    Languages = beast.Languages,
                    SQ = beast.SQ,
                    Environment = beast.Environment,
                    Organization = beast.Organization,
                    Treasure = beast.Treasure,
                    Group = beast.Group,
                    Gear = beast.Gear,
                    OtherGear = beast.OtherGear,
                    Speed = beast.Speed
                });
            }

            if (tempBestiaryCollection.SequenceEqual(Global.Instance.BestiaryCollection))
            {
                BestiaryCollection = new BindableCollection<BestiaryCollection>(tempBestiaryCollection);
            }
            else
            {
                Global.Instance.BestiaryCollection = new BindableCollection<BestiaryCollection>(tempBestiaryCollection);
                BestiaryCollection = new BindableCollection<BestiaryCollection>(tempBestiaryCollection);
            }
        }

        private void PopulateBestiaryCollectionAsync()
        {
            if (Global.Instance.BestiaryCollection.Count <= 0)
            {
                var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                Task bk2Thread = Task.Factory.StartNew(() => ClearBestiaryInfo())
                                .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                .ContinueWith(t2 => PopulateBestiaryCollection())
                                .ContinueWith(t3 => ClearBestiaryInfo())
                                .ContinueWith(t4 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
            }
            else if (BestiaryCollection.Count <= 0)
            {
                BestiaryCollection = new BindableCollection<BestiaryCollection>(Global.Instance.BestiaryCollection);
            }
            else
            {
                if (!BestiaryCollection.SequenceEqual(Global.Instance.BestiaryCollection))
                {
                    var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                    Task bk2Thread = Task.Factory.StartNew(() => ClearBestiaryInfo())
                                    .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                    .ContinueWith(t2 => PopulateBestiaryCollection())
                                    .ContinueWith(t3 => ClearBestiaryInfo())
                                    .ContinueWith(t4 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
                }
            }
        }

        private void ClearBestiaryInfo()
        {
            Name = string.Empty;
            CR = 0.0f;
            XP = 0;
            Race = string.Empty;
            Class1 = string.Empty;
            Class1Level = 0;
            Class2 = string.Empty;
            Class2Level = 0;
            Alignment = string.Empty;
            Size = string.Empty;
            Type = string.Empty;
            SubType1 = string.Empty;
            SubType2 = string.Empty;
            SubType3 = string.Empty;
            SubType4 = string.Empty;
            SubType5 = string.Empty;
            SubType6 = string.Empty;
            AC = 0;
            ACTouch = 0;
            ACFlatFooted = 0;
            HP = 0;
            HD = string.Empty;
            Fort = string.Empty;
            Ref = string.Empty;
            Will = string.Empty;
            Melee = string.Empty;
            Ranged = string.Empty;
            Reach = string.Empty;
            Str = string.Empty;
            Dex = string.Empty;
            Con = string.Empty;
            Int = string.Empty;
            Wis = string.Empty;
            Cha = string.Empty;
            Feats = string.Empty;
            Skills = string.Empty;
            RacialMods = string.Empty;
            Languages = string.Empty;
            SQ = string.Empty;
            Environment = string.Empty;
            Organization = string.Empty;
            Treasure = string.Empty;
            Group = string.Empty;
            Gear = string.Empty;
            OtherGear = string.Empty;
            Speed = string.Empty;

        }
        #endregion

        #region Public Methods
        public void BestiarySelectionChanged(object sender)
        {
            if (SelectedIndex != -1)
            {
                CR = BestiaryCollection[SelectedIndex].CR;
                Name = BestiaryCollection[SelectedIndex].Name + " (CR " + CR + ")";
                XP = BestiaryCollection[SelectedIndex].XP;
                Race = BestiaryCollection[SelectedIndex].Race;
                Class1 = BestiaryCollection[SelectedIndex].Class1;
                Class1Level = BestiaryCollection[SelectedIndex].Class1Level;
                Class2 = BestiaryCollection[SelectedIndex].Class2;
                Class2Level = BestiaryCollection[SelectedIndex].Class2Level;
                Alignment = BestiaryCollection[SelectedIndex].Alignment;
                Size = BestiaryCollection[SelectedIndex].Size;
                Type = BestiaryCollection[SelectedIndex].Type;
                SubType1 = BestiaryCollection[SelectedIndex].SubType1;
                SubType2 = BestiaryCollection[SelectedIndex].SubType2;
                SubType3 = BestiaryCollection[SelectedIndex].SubType3;
                SubType4 = BestiaryCollection[SelectedIndex].SubType4;
                SubType5 = BestiaryCollection[SelectedIndex].SubType5;
                SubType6 = BestiaryCollection[SelectedIndex].SubType6;
                AC = BestiaryCollection[SelectedIndex].AC;
                ACTouch = BestiaryCollection[SelectedIndex].ACTouch;
                ACFlatFooted = BestiaryCollection[SelectedIndex].ACFlatFooted;
                HP = BestiaryCollection[SelectedIndex].HP;
                HD = BestiaryCollection[SelectedIndex].HD;
                Fort = BestiaryCollection[SelectedIndex].Fort;
                Ref = BestiaryCollection[SelectedIndex].Ref;
                Will = BestiaryCollection[SelectedIndex].Will;
                Melee = BestiaryCollection[SelectedIndex].Melee;
                Ranged = BestiaryCollection[SelectedIndex].Ranged;
                Reach = BestiaryCollection[SelectedIndex].Reach;
                Str = BestiaryCollection[SelectedIndex].Str;
                Dex = BestiaryCollection[SelectedIndex].Dex;
                Con = BestiaryCollection[SelectedIndex].Con;
                Int = BestiaryCollection[SelectedIndex].Int;
                Wis = BestiaryCollection[SelectedIndex].Wis;
                Cha = BestiaryCollection[SelectedIndex].Cha;
                Feats = BestiaryCollection[SelectedIndex].Feats;
                Skills = BestiaryCollection[SelectedIndex].Skills;
                RacialMods = BestiaryCollection[SelectedIndex].RacialMods;
                Languages = BestiaryCollection[SelectedIndex].Languages;
                SQ = BestiaryCollection[SelectedIndex].SQ;
                Environment = BestiaryCollection[SelectedIndex].Environment;
                Organization = BestiaryCollection[SelectedIndex].Organization;
                Treasure = BestiaryCollection[SelectedIndex].Treasure;
                Group = BestiaryCollection[SelectedIndex].Group;
                Gear = BestiaryCollection[SelectedIndex].Gear;
                OtherGear = BestiaryCollection[SelectedIndex].OtherGear;
                Speed = BestiaryCollection[SelectedIndex].Speed;
            }

        }

        public void AddBestiary()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddBestiaryDialog");
        }

        public void DeleteBestiary()
        {
            try
            {
                int beastID = BestiaryCollection[SelectedIndex].ID;

                var forgeDatabase = Global.Instance.ForgeDatabase();

                BESTIARY beast = forgeDatabase.Bestiary.Single(x => x.ID == beastID);

                forgeDatabase.Bestiary.DeleteOnSubmit(beast);
                forgeDatabase.SubmitChanges();

                BestiaryCollection.RemoveAt(SelectedIndex);
                Global.Instance.BestiaryCollection = new BindableCollection<BestiaryCollection>(BestiaryCollection);

                ClearBestiaryInfo();
                SelectedIndex = -1;
            }
            catch { }
        }

        public void ImportBestiary(string filename, string extension)
        {
            FileInfo file = new FileInfo(filename);
            try
            {
                if (extension.ToLower() == ".xlsx" || extension.ToLower() == ".xls")
                {
                    using (var package = new ExcelPackage(file))
                    {
                        var worksheet = package.Workbook.Worksheets["Sheet1"];
                        int count = worksheet.Dimension.Rows;

                        var bestiary = worksheet.Extract<ImportBestiaryCollection>()
                            .WithProperty(p => p.Name, "A")
                            .WithProperty(p => p.CR, "B")
                            .WithProperty(p => p.XP, "C")
                            .WithProperty(p => p.Race, "D")
                            .WithProperty(p => p.Class1, "E")
                            .WithProperty(p => p.Class1Level, "F")
                            .WithProperty(p => p.Class2, "G")
                            .WithProperty(p => p.Class2Level, "H")
                            .WithProperty(p => p.Alignment, "I")
                            .WithProperty(p => p.Size, "J")
                            .WithProperty(p => p.Type, "K")
                            .WithProperty(p => p.SubType1, "L")
                            .WithProperty(p => p.SubType2, "M")
                            .WithProperty(p => p.SubType3, "N")
                            .WithProperty(p => p.SubType4, "O")
                            .WithProperty(p => p.SubType5, "P")
                            .WithProperty(p => p.SubType6, "Q")
                            .WithProperty(p => p.AC, "R")
                            .WithProperty(p => p.ACTouch, "S")
                            .WithProperty(p => p.ACFlatFooted, "T")
                            .WithProperty(p => p.HP, "U")
                            .WithProperty(p => p.HD, "V")
                            .WithProperty(p => p.Fort, "W")
                            .WithProperty(p => p.Ref, "X")
                            .WithProperty(p => p.Will, "Y")
                            .WithProperty(p => p.Melee, "Z")
                            .WithProperty(p => p.Ranged, "AA")
                            .WithProperty(p => p.Reach, "AB")
                            .WithProperty(p => p.Str, "AC")
                            .WithProperty(p => p.Dex, "AD")
                            .WithProperty(p => p.Con, "AE")
                            .WithProperty(p => p.Int, "AF")
                            .WithProperty(p => p.Wis, "AG")
                            .WithProperty(p => p.Cha, "AH")
                            .WithProperty(p => p.Feats, "AI")
                            .WithProperty(p => p.Skills, "AJ")
                            .WithProperty(p => p.RacialMods, "AK")
                            .WithProperty(p => p.Languages, "AL")
                            .WithProperty(p => p.SQ, "AM")
                            .WithProperty(p => p.Environment, "AN")
                            .WithProperty(p => p.Organization, "AO")
                            .WithProperty(p => p.Treasure, "AP")
                            .WithProperty(p => p.Group, "AQ")
                            .WithProperty(p => p.Gear, "AR")
                            .WithProperty(p => p.OtherGear, "AS")
                            .WithProperty(p => p.Speed, "AT")
                            .GetData(2, count)
                            .ToList();

                        if (bestiary.Count > 0)
                        {
                            var forgeDatabase = Global.Instance.ForgeDatabase();

                            List<BESTIARY> bestiaryList = new List<BESTIARY>();

                            foreach (var b in bestiary)
                            {
                                bestiaryList.Add(new BESTIARY
                                {
                                    Name = b.Name,
                                    CR = b.CR,
                                    XP = b.XP,
                                    Race = b.Race,
                                    Class1 = b.Class1,
                                    Class1Level = b.Class1Level,
                                    Class2 = b.Class2,
                                    Class2Level = b.Class2Level,
                                    Alignment = b.Alignment,
                                    Size = b.Size,
                                    Type = b.Type,
                                    SubType1 = b.SubType1,
                                    SubType2 = b.SubType2,
                                    SubType3 = b.SubType3,
                                    SubType4 = b.SubType4,
                                    SubType5 = b.SubType5,
                                    SubType6 = b.SubType6,
                                    AC = b.AC,
                                    ACTouch = b.ACTouch,
                                    ACFlatFooted = b.ACFlatFooted,
                                    HP = b.HP,
                                    HD = b.HD,
                                    Fort = b.Fort,
                                    Ref = b.Ref,
                                    Will = b.Will,
                                    Melee = b.Melee,
                                    Ranged = b.Ranged,
                                    Reach = b.Reach,
                                    Str = b.Str,
                                    Dex = b.Dex,
                                    Con = b.Con,
                                    Int = b.Int,
                                    Wis = b.Wis,
                                    Cha = b.Cha,
                                    Feats = b.Feats,
                                    Skills = b.Skills,
                                    RacialMods = b.RacialMods,
                                    Languages = b.Languages,
                                    SQ = b.SQ,
                                    Environment = b.Environment,
                                    Organization = b.Organization,
                                    Treasure = b.Treasure,
                                    Group = b.Group,
                                    Gear = b.Gear,
                                    OtherGear = b.OtherGear,
                                    Speed = b.Speed

                                });
                            }

                            forgeDatabase.Bestiary.InsertAllOnSubmit(bestiaryList);
                            forgeDatabase.SubmitChanges();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void BrowseFileAsync()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = "*.xlsx";
            dlg.Filter = "XLSX Files (*.xlsx)|*.xlsx|XLS Files (*.xls)|*.xls";

            Nullable<bool> result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string filename = dlg.FileName;

                string extension = Path.GetExtension(filename);

                var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                Task bkThread = Task.Factory.StartNew(() => ClearBestiaryInfo())
                                .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                .ContinueWith(t2 => ImportBestiary(filename, extension))
                                .ContinueWith(t3 => PopulateBestiaryCollection())
                                .ContinueWith(t4 => ClearBestiaryInfo())
                                .ContinueWith(t5 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
            }
        }

        public void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                BestiaryCollection = new BindableCollection<BestiaryCollection>(Global.Instance.BestiaryCollection);
            else if (IsNameSearch)
                BestiaryCollection = new BindableCollection<BestiaryCollection>(
                    Global.Instance.BestiaryCollection.Where(
                        x => x.Name.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0));
            else if (IsCRSearch)
            {
                float.TryParse(text, out float cr);

                if (cr > 0)
                { 
                BestiaryCollection = new BindableCollection<BestiaryCollection>(
                    Global.Instance.BestiaryCollection.Where(
                        x => x.CR == cr));
                }
            }
            else if(IsTypeSearch)
                BestiaryCollection = new BindableCollection<BestiaryCollection>(
                    Global.Instance.BestiaryCollection.Where(
                        x => x.Type.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0));

        }

        public void Search_OnKeyDown(string sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search(sender);
        }
        #endregion

        #region IHandle Method
        public void Handle(string message)
        {
            switch (message)
            {
                case "AcceptAddBestiaryDialog":
                    PopulateBestiaryCollectionAsync();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

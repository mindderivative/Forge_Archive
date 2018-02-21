using Caliburn.Micro;
using Forge.Classes;
using Forge.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
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
    /// Interaction logic for AddSpellDialog.xaml
    /// </summary>
    public partial class AddSpellDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variables
        private string _spellNameTxt;
        private string _spellSchoolTxt;
        private string _subSchoolTxt;
        private string _levelTxt;
        private string _castingTimeTxt;
        private string _componentsTxt;
        private string _rangeTxt;
        private string _areaTxt;
        private string _effectTxt;
        private string _targetsTxt;
        private string _durationTxt;
        private string _savingThrowTxt;
        private string _descriptionTxt;
        private string _shortDescriptionTxt;
        private string _domainTxt;
        #endregion

        #region Public Variables
        public string SpellNameTxt
        {
            get { return _spellNameTxt; }
            set
            {
                if(_spellNameTxt != value)
                {
                    _spellNameTxt = value;
                    NotifyOfPropertyChanged("SpellNameTxt");
                }
            }
        }
        public string SpellSchoolTxt
        {
            get { return _spellSchoolTxt; }
            set
            {
                if (_spellSchoolTxt != value)
                {
                    _spellSchoolTxt = value;
                    NotifyOfPropertyChanged("SpellSchoolTxt");
                }
            }
        }
        public string SubSchoolTxt
        {
            get { return _subSchoolTxt; }
            set
            {
                if (_subSchoolTxt != value)
                {
                    _subSchoolTxt = value;
                    NotifyOfPropertyChanged("SubSchoolTxt");
                }
            }
        }
        public string LevelTxt
        {
            get { return _levelTxt; }
            set
            {
                if (_levelTxt != value)
                {
                    _levelTxt = value;
                    NotifyOfPropertyChanged("LevelTxt");
                }
            }
        }
        public string CastingTimeTxt
        {
            get { return _castingTimeTxt; }
            set
            {
                if (_castingTimeTxt != value)
                {
                    _castingTimeTxt = value;
                    NotifyOfPropertyChanged("CastingTimeTxt");
                }
            }
        }
        public string ComponentsTxt
        {
            get { return _componentsTxt; }
            set
            {
                if (_componentsTxt != value)
                {
                    _componentsTxt = value;
                    NotifyOfPropertyChanged("ComponentsTxt");
                }
            }
        }
        public string RangeTxt
        {
            get { return _rangeTxt; }
            set
            {
                if (_rangeTxt != value)
                {
                    _rangeTxt = value;
                    NotifyOfPropertyChanged("RangeTxt");
                }
            }
        }
        public string AreaTxt
        {
            get { return _areaTxt; }
            set
            {
                if (_areaTxt != value)
                {
                    _areaTxt = value;
                    NotifyOfPropertyChanged("AreaTxt");
                }
            }
        }
        public string EffectTxt
        {
            get { return _effectTxt; }
            set
            {
                if (_effectTxt != value)
                {
                    _effectTxt = value;
                    NotifyOfPropertyChanged("EffectTxt");
                }
            }
        }
        public string TargetsTxt
        {
            get { return _targetsTxt; }
            set
            {
                if (_targetsTxt != value)
                {
                    _targetsTxt = value;
                    NotifyOfPropertyChanged("TargetsTxt");
                }
            }
        }
        public string DurationTxt
        {
            get { return _durationTxt; }
            set
            {
                if (_durationTxt != value)
                {
                    _durationTxt = value;
                    NotifyOfPropertyChanged("DurationTxt");
                }
            }
        }
        public string SavingThrowTxt
        {
            get { return _savingThrowTxt; }
            set
            {
                if (_savingThrowTxt != value)
                {
                    _savingThrowTxt = value;
                    NotifyOfPropertyChanged("SavingThrowTxt");
                }
            }
        }
        public string DescriptionTxt
        {
            get { return _descriptionTxt; }
            set
            {
                if (_descriptionTxt != value)
                {
                    _descriptionTxt = value;
                    NotifyOfPropertyChanged("DescriptionTxt");
                }
            }
        }
        public string ShortDescriptionTxt
        {
            get { return _shortDescriptionTxt; }
            set
            {
                if (_shortDescriptionTxt != value)
                {
                    _shortDescriptionTxt = value;
                    NotifyOfPropertyChanged("ShortDescriptionTxt");
                }
            }
        }
        public string DomainTxt
        {
            get { return _domainTxt; }
            set
            {
                if (_domainTxt != value)
                {
                    _domainTxt = value;
                    NotifyOfPropertyChanged("DomainTxt");
                }
            }
        }
        #endregion

        public AddSpellDialog()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(SpellName) && !Validation.GetHasError(School) 
                && !Validation.GetHasError(SubSchool) && !Validation.GetHasError(Level) 
                && !Validation.GetHasError(CastingTime) && !Validation.GetHasError(Components) 
                && !Validation.GetHasError(Range) && !Validation.GetHasError(Area) 
                && !Validation.GetHasError(Effect) && !Validation.GetHasError(Targets) 
                && !Validation.GetHasError(Duration) && !Validation.GetHasError(SavingThrow) 
                && !Validation.GetHasError(SpellDescription) && !Validation.GetHasError(ShortDescription)
                && !Validation.GetHasError(Domain))
            {
                string spellName = SpellName.Text;
                string school = School.Text;
                string subSchool = SubSchool.Text;
                string effect = Effect.Text;
                string castingTime = CastingTime.Text;
                string components = Components.Text;
                string range = Range.Text;
                string area = Area.Text;
                string targets = Targets.Text;
                string duration = Duration.Text;
                string savingThrow = SavingThrow.Text;
                string spellRes = SpellResistance.Text;
                string spellDes = SpellDescription.Text;
                string level = Level.Text;
                string shortDes = ShortDescription.Text;
                string domain = Domain.Text;

                var forgeDatabase = Global.Instance.ForgeDatabase();
                SPELL spell = new SPELL()
                {
                    Name = spellName,
                    School = school,
                    SubSchool = subSchool,
                    Effect = effect,
                    CastingTime = castingTime,
                    Components = components,
                    Range = range,
                    Area = area,
                    Targets = targets,
                    Duration = duration,
                    SavingThrow = savingThrow,
                    SpellResistance = spellRes,
                    Description = spellDes,
                    Level = level,
                    ShortDescription = shortDes,
                    Domain = domain
                };

                forgeDatabase.Spells.InsertOnSubmit(spell);
                forgeDatabase.SubmitChanges();

                PopulateSpellCollection();

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptAddSpellDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
            }
        }

        private void PopulateSpellCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempSpellCollection = new BindableCollection<SpellCollection>();

            foreach (var spell in forgeDatabase.Spells)
            {
                tempSpellCollection.Add(new SpellCollection
                {

                    ID = spell.ID,
                    Name = spell.Name,
                    School = spell.School,
                    SubSchool = spell.SubSchool,
                    Effect = spell.Effect,
                    CastingTime = spell.CastingTime,
                    Components = spell.Components,
                    Range = spell.Range,
                    Area = spell.Area,
                    Targets = spell.Targets,
                    Duration = spell.Duration,
                    SavingThrow = spell.SavingThrow,
                    SpellResistance = spell.SpellResistance,
                    Description = spell.Description,
                    Level = spell.Level,
                    ShortDescription = spell.ShortDescription,
                    Domain = spell.Domain
                });
            }

            if (!tempSpellCollection.SequenceEqual(Global.Instance.SpellCollection))
            {
                Global.Instance.SpellCollection = new BindableCollection<SpellCollection>(tempSpellCollection);
            }
        }
        #endregion

        #region PropteryChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyOfPropertyChanged(string sProp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProp));
        }
        #endregion
    }
}

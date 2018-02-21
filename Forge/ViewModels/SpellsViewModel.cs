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
    [Export(typeof(SpellsViewModel))]
    public class SpellsViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<SpellCollection> _spellCollection = new BindableCollection<SpellCollection>();
        private int _selectedIndex = -1;
        private bool _isSpellSelected = false;

        private string _spellName;
        private string _school;
        private string _subSchool;
        private string _effect;
        private string _castingTime;
        private string _components;
        private string _range;
        private string _area;
        private string _targets;
        private string _duration;
        private string _savingThrow;
        private string _spellResistance;
        private string _description;
        private string _level;
        private string _shortDescription;
        private string _domain;
        #endregion

        #region Public Variables
        public BindableCollection<SpellCollection> SpellCollection
        {
            get { return _spellCollection; }
            set
            {
                if (_spellCollection != value)
                {
                    _spellCollection = value;
                    NotifyOfPropertyChange(() => SpellCollection);
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
                        IsSpellSelected = true;
                    }
                    else
                    {
                        IsSpellSelected = false;
                    }
                }
            }
        }
        public bool IsSpellSelected
        {
            get { return _isSpellSelected; }
            set
            {
                if (_isSpellSelected != value)
                {
                    _isSpellSelected = value;
                    NotifyOfPropertyChange(() => IsSpellSelected);
                }
            }
        }

        public string SpellName
        {
            get { return _spellName; }
            set
            {
                if (_spellName != value)
                {
                    _spellName = value;
                    NotifyOfPropertyChange(() => SpellName);
                }
            }
        }
        public string School
        {
            get { return _school; }
            set
            {
                if (_school != value)
                {
                    _school = value;
                    NotifyOfPropertyChange(() => School);
                }
            }
        }
        public string SubSchool
        {
            get { return _subSchool; }
            set
            {
                if (_subSchool != value)
                {
                    _subSchool = value;
                    NotifyOfPropertyChange(() => SubSchool);
                }
            }
        }
        public string Effect
        {
            get { return _effect; }
            set
            {
                if (_effect != value)
                {
                    _effect = value;
                    NotifyOfPropertyChange(() => Effect);
                }
            }
        }
        public string CastingTime
        {
            get { return _castingTime; }
            set
            {
                if (_castingTime != value)
                {
                    _castingTime = value;
                    NotifyOfPropertyChange(() => CastingTime);
                }
            }
        }
        public string Components
        {
            get { return _components; }
            set
            {
                if (_components != value)
                {
                    _components = value;
                    NotifyOfPropertyChange(() => Components);
                }
            }
        }
        public string Range
        {
            get { return _range; }
            set
            {
                if (_range != value)
                {
                    _range = value;
                    NotifyOfPropertyChange(() => Range);
                }
            }
        }
        public string Area
        {
            get { return _area; }
            set
            {
                if (_area != value)
                {
                    _area = value;
                    NotifyOfPropertyChange(() => Area);
                }
            }
        }
        public string Targets
        {
            get { return _targets; }
            set
            {
                if (_targets != value)
                {
                    _targets = value;
                    NotifyOfPropertyChange(() => Targets);
                }
            }
        }
        public string Duration
        {
            get { return _duration; }
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    NotifyOfPropertyChange(() => Duration);
                }
            }
        }
        public string SavingThrow
        {
            get { return _savingThrow; }
            set
            {
                if (_savingThrow != value)
                {
                    _savingThrow = value;
                    NotifyOfPropertyChange(() => SavingThrow);
                }
            }
        }
        public string SpellResistance
        {
            get { return _spellResistance; }
            set
            {
                if (_spellResistance != value)
                {
                    _spellResistance = value;
                    NotifyOfPropertyChange(() => SpellResistance);
                }
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }
        public string Level
        {
            get { return _level; }
            set
            {
                if(_level != value)
                {
                    _level = value;
                    NotifyOfPropertyChange(() => Level);
                }
            }
        }
        public string ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                if (_shortDescription != value)
                {
                    _shortDescription = value;
                    NotifyOfPropertyChange(() => ShortDescription);
                }
            }
        }
        public string Domain
        {
            get { return _domain; }
            set
            {
                if (_domain != value)
                {
                    _domain = value;
                    NotifyOfPropertyChange(() => Domain);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public SpellsViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);

            PopulateSpellCollectionAsync();
        }

        #region Private Methods
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


            if(tempSpellCollection.SequenceEqual(Global.Instance.SpellCollection))
            {
                SpellCollection = new BindableCollection<SpellCollection>(tempSpellCollection);
            }
            else
            {
                Global.Instance.SpellCollection = new BindableCollection<SpellCollection>(tempSpellCollection);
                SpellCollection = new BindableCollection<SpellCollection>(tempSpellCollection);
            }
        }

        private void PopulateSpellCollectionAsync()
        {
            if (Global.Instance.SpellCollection.Count <= 0)
            {
                var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                Task bk2Thread = Task.Factory.StartNew(() => ClearSpellInfo())
                                .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                .ContinueWith(t2 => PopulateSpellCollection())
                                .ContinueWith(t3 => ClearSpellInfo())
                                .ContinueWith(t4 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
            }
            else if(SpellCollection.Count <= 0)
            {
                SpellCollection = new BindableCollection<SpellCollection>(Global.Instance.SpellCollection);
            }
            else
            {
                if(!SpellCollection.SequenceEqual(Global.Instance.SpellCollection))
                {
                    var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                    Task bk2Thread = Task.Factory.StartNew(() => ClearSpellInfo())
                                    .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                    .ContinueWith(t2 => PopulateSpellCollection())
                                    .ContinueWith(t3 => ClearSpellInfo())
                                    .ContinueWith(t4 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
                }
            }
        }

        private void ClearSpellInfo()
        {
            SpellName = string.Empty;
            School = string.Empty;
            SubSchool = string.Empty;
            Effect = string.Empty;
            CastingTime = string.Empty;
            Components = string.Empty;
            Range = string.Empty;
            Area = string.Empty;
            Targets = string.Empty;
            Duration = string.Empty;
            SavingThrow = string.Empty;
            SpellResistance = string.Empty;
            Description = string.Empty;
            Level = string.Empty;
            ShortDescription = string.Empty;
            Domain = string.Empty;
            IsSpellSelected = false;
            
        }
        #endregion

        #region Public Methods
        public void SpellSelectionChanged(object sender)
        {
            if (SelectedIndex != -1)
            {
                SpellName = SpellCollection[SelectedIndex].Name;
                School = SpellCollection[SelectedIndex].School;
                SubSchool = SpellCollection[SelectedIndex].SubSchool;
                Effect = SpellCollection[SelectedIndex].Effect;
                CastingTime = SpellCollection[SelectedIndex].CastingTime;
                Components = SpellCollection[SelectedIndex].Components;
                Range = SpellCollection[SelectedIndex].Range;
                Area = SpellCollection[SelectedIndex].Area;
                Targets = SpellCollection[SelectedIndex].Targets;
                Duration = SpellCollection[SelectedIndex].Duration;
                SavingThrow = SpellCollection[SelectedIndex].SavingThrow;
                SpellResistance = SpellCollection[SelectedIndex].SpellResistance;
                Description = SpellCollection[SelectedIndex].Description;
                Level = SpellCollection[SelectedIndex].Level;
                ShortDescription = SpellCollection[SelectedIndex].ShortDescription;
                Domain = SpellCollection[SelectedIndex].Domain;
            }

        }

        public void AddSpell()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddSpellDialog");
        }

        public void DeleteSpell()
        {
            try
            {
                int spellID = SpellCollection[SelectedIndex].ID;

                var forgeDatabase = Global.Instance.ForgeDatabase();

                SPELL spell = forgeDatabase.Spells.Single(x => x.ID == spellID);

                forgeDatabase.Spells.DeleteOnSubmit(spell);
                forgeDatabase.SubmitChanges();

                SpellCollection.RemoveAt(SelectedIndex);
                Global.Instance.SpellCollection = new BindableCollection<SpellCollection>(SpellCollection);

                ClearSpellInfo();
                SelectedIndex = -1;
            }
            catch { }
        }

        public void ImportSpells(string filename, string extension)
        {
            FileInfo file = new FileInfo(filename);
            try
            {
                if(extension.ToLower() == ".xlsx" || extension.ToLower() == ".xls")
                {
                    using (var package = new ExcelPackage(file))
                    {
                        var worksheet = package.Workbook.Worksheets["Sheet1"];
                        int count = worksheet.Dimension.Rows;

                        var spells = worksheet.Extract<ImportSpellCollection>()
                            .WithProperty(p => p.SpellName, "A")
                            .WithProperty(p => p.School, "B")
                            .WithProperty(p => p.SubSchool, "C")
                            .WithProperty(p => p.Level, "D")
                            .WithProperty(p => p.CastingTime, "E")
                            .WithProperty(p => p.Components, "F")
                            .WithProperty(p => p.Range, "G")
                            .WithProperty(p => p.Area, "H")
                            .WithProperty(p => p.Effect, "I")
                            .WithProperty(p => p.Targets, "J")
                            .WithProperty(p => p.Duration, "K")
                            .WithProperty(p => p.SavingThrow, "L")
                            .WithProperty(p => p.SpellResistance, "M")
                            .WithProperty(p => p.Description, "N")
                            .WithProperty(p => p.Domain, "O")
                            .WithProperty(p => p.ShortDescription, "P")
                            .GetData(2, count)
                            .ToList();

                        if(spells.Count > 0)
                        {
                            var forgeDatabase = Global.Instance.ForgeDatabase();

                            List<SPELL> spellList = new List<SPELL>();

                            foreach(var s in spells)
                            {
                                spellList.Add(new SPELL
                                {
                                    Name = s.SpellName,
                                    School = s.School,
                                    SubSchool = s.SubSchool,
                                    Effect = s.Effect,
                                    CastingTime = s.CastingTime,
                                    Components = s.Components,
                                    Range = s.Range,
                                    Area = s.Area,
                                    Targets = s.Targets,
                                    Duration = s.Duration,
                                    SavingThrow = s.SavingThrow,
                                    SpellResistance = s.SpellResistance,
                                    Description = s.Description,
                                    Level = s.Level,
                                    ShortDescription = s.ShortDescription,
                                    Domain = s.Domain
                                });
                            }

                            forgeDatabase.Spells.InsertAllOnSubmit(spellList);
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

                Task bkThread = Task.Factory.StartNew(() => ClearSpellInfo())
                                .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                .ContinueWith(t2 => ImportSpells(filename, extension))
                                .ContinueWith(t3 => PopulateSpellCollection())
                                .ContinueWith(t4 => ClearSpellInfo())
                                .ContinueWith(t5 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
            }
        }

        public void Search(object obj)
        {
            var text = obj as string;
            if (string.IsNullOrWhiteSpace(text))
                SpellCollection = new BindableCollection<SpellCollection>(Global.Instance.SpellCollection);
            else
                SpellCollection = new BindableCollection<SpellCollection>(
                    Global.Instance.SpellCollection.Where(
                        x => x.Name.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0));
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
                case "AcceptAddSpellDialog":
                    PopulateSpellCollectionAsync();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

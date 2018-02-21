using Caliburn.Micro;
using EPPlus.DataExtractor;
using Forge.Classes;
using Forge.Tables;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Linq;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Forge.ViewModels
{
    [Export(typeof(FeatViewModel))]
    public class FeatViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<FeatCollection> _featskillCollection = new BindableCollection<FeatCollection>();
        private int _selectedIndex = -1;
        private string _featName;
        private string _featDescription;
        private string _featBenefit;
        private string _featPrerequisites;
        private string _featSpecial;
        private string _featType;
        private string _featNormal;
        private bool _isFeatSelected = false;
        private bool _isTypeSearch = false;
        #endregion

        #region Public Variables
        public BindableCollection<FeatCollection> FeatCollection
        {
            get { return _featskillCollection; }
            set
            {
                if (_featskillCollection != value)
                {
                    _featskillCollection = value;
                    NotifyOfPropertyChange(() => FeatCollection);
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
                        IsFeatSelected = true;
                    }
                    else
                    {
                        IsFeatSelected = false;
                    }
                }
            }
        }
        public string FeatName
        {
            get { return _featName; }
            set
            {
                if (_featName != value)
                {
                    _featName = value;
                    NotifyOfPropertyChange(() => FeatName);
                }
            }
        }
        public string FeatDescription
        {
            get { return _featDescription; }
            set
            {
                if (_featDescription != value)
                {
                    _featDescription = value;
                    NotifyOfPropertyChange(() => FeatDescription);
                }
            }
        }
        public string FeatBenefit
        {
            get { return _featBenefit; }
            set
            {
                if (_featBenefit != value)
                {
                    _featBenefit = value;
                    NotifyOfPropertyChange(() => FeatBenefit);
                }
            }
        }
        public string FeatPrerequisites
        {
            get { return _featPrerequisites; }
            set
            {
                if (_featPrerequisites != value)
                {
                    _featPrerequisites = value;
                    NotifyOfPropertyChange(() => FeatPrerequisites);
                }
            }
        }
        public string FeatSpecial
        {
            get { return _featSpecial; }
            set
            {
                if (_featSpecial != value)
                {
                    _featSpecial = value;
                    NotifyOfPropertyChange(() => FeatSpecial);
                }
            }
        }
        public string FeatType
        {
            get { return _featType; }
            set
            {
                if (_featType != value)
                {
                    _featType = value;
                    NotifyOfPropertyChange(() => FeatType);
                }
            }
        }
        public string FeatNormal
        {
            get { return _featNormal; }
            set
            {
                if (_featNormal != value)
                {
                    _featNormal = value;
                    NotifyOfPropertyChange(() => FeatNormal);
                }
            }
        }
        public bool IsFeatSelected
        {
            get { return _isFeatSelected; }
            set
            {
                if (_isFeatSelected != value)
                {
                    _isFeatSelected = value;
                    NotifyOfPropertyChange(() => IsFeatSelected);
                }
            }
        }
        public bool IsTypeSearch
        {
            get { return _isTypeSearch; }
            set
            {
                if(_isTypeSearch != value)
                {
                    _isTypeSearch = value;
                    NotifyOfPropertyChange(() => IsTypeSearch);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public FeatViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);
            PopulateFeatCollectionAsync();
        }

        #region Private Methods
        private void PopulateFeatCollection()
        {
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempFeatCollection = new BindableCollection<FeatCollection>();

            foreach (var feat in forgeDatabase.Feats)
            {
                tempFeatCollection.Add(new FeatCollection
                {
                    FeatID = feat.ID,
                    FeatName = feat.Name,
                    FeatDescription = feat.Description,
                    FeatBenefit = feat.Benefit,
                    FeatPrerequisites = feat.Prerequisites,
                    FeatSpecial = feat.Special,
                    FeatType = feat.Type,
                    FeatNormal = feat.Normal
                });
            }

            if(tempFeatCollection.SequenceEqual(Global.Instance.FeatCollection))
            {
                FeatCollection = new BindableCollection<FeatCollection>(tempFeatCollection);
            }
            else
            {
                Global.Instance.FeatCollection = new BindableCollection<FeatCollection>(tempFeatCollection);
                FeatCollection = new BindableCollection<FeatCollection>(tempFeatCollection);
            }
        }

        private void PopulateFeatCollectionAsync()
        {
            if (Global.Instance.FeatCollection.Count <= 0)
            {
                var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                Task bk2Thread = Task.Factory.StartNew(() => ClearFeatInfo())
                                .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                .ContinueWith(t2 => PopulateFeatCollection())
                                .ContinueWith(t3 => ClearFeatInfo())
                                .ContinueWith(t4 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
            }
            else if (FeatCollection.Count <= 0)
            {
                FeatCollection = new BindableCollection<FeatCollection>(Global.Instance.FeatCollection);
            }
            else
            {
                if (!FeatCollection.SequenceEqual(Global.Instance.FeatCollection))
                {
                    var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                    Task bk2Thread = Task.Factory.StartNew(() => ClearFeatInfo())
                                    .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                    .ContinueWith(t2 => PopulateFeatCollection())
                                    .ContinueWith(t3 => ClearFeatInfo())
                                    .ContinueWith(t4 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
                }
            }
        }

        private void ClearFeatInfo()
        {
            FeatName = string.Empty;
            FeatDescription = string.Empty;
            FeatBenefit = string.Empty;
            FeatPrerequisites = string.Empty;
            FeatSpecial = string.Empty;
            FeatType = string.Empty;
            FeatNormal = string.Empty;
            IsFeatSelected = false;
        }
        #endregion

        #region Public Methods
        public void FeatSelectionChanged(object sender)
        {
            if (SelectedIndex != -1)
            {
                FeatName = FeatCollection[SelectedIndex].FeatName;
                FeatDescription = FeatCollection[SelectedIndex].FeatDescription;
                FeatBenefit = FeatCollection[SelectedIndex].FeatBenefit;
                FeatPrerequisites = FeatCollection[SelectedIndex].FeatPrerequisites;
                FeatSpecial = FeatCollection[SelectedIndex].FeatSpecial;
                FeatType = FeatCollection[SelectedIndex].FeatType;
                FeatNormal = FeatCollection[SelectedIndex].FeatNormal;
            }

        }

        public void AddFeat()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenAddFeatDialog");
        }

        public void DeleteFeat()
        {
            try
            {
                int featID = FeatCollection[SelectedIndex].FeatID;

                var forgeDatabase = Global.Instance.ForgeDatabase();

                FEAT feat = forgeDatabase.Feats.Single(x => x.ID == featID);

                forgeDatabase.Feats.DeleteOnSubmit(feat);
                forgeDatabase.SubmitChanges();

                FeatCollection.RemoveAt(SelectedIndex);
                Global.Instance.FeatCollection = new BindableCollection<FeatCollection>(FeatCollection);

                ClearFeatInfo();
                SelectedIndex = -1;
            }
            catch { }
        }

        public void ImportFeat(string filename, string extension)
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

                        var feat = worksheet.Extract<ImportFeatCollection>()
                            .WithProperty(p => p.FeatName, "A")
                            .WithProperty(p => p.FeatType, "B")
                            .WithProperty(p => p.FeatDescription, "C")
                            .WithProperty(p => p.FeatPrerequisites, "D")
                            .WithProperty(p => p.FeatBenefit, "E")
                            .WithProperty(p => p.FeatNormal, "F")
                            .WithProperty(p => p.FeatSpecial, "G")
                            .GetData(2, count)
                            .ToList();

                        if (feat.Count > 0)
                        {
                            var forgeDatabase = Global.Instance.ForgeDatabase();

                            List<FEAT> featList = new List<FEAT>();

                            foreach (var f in feat)
                            {
                                featList.Add(new FEAT
                                {
                                    Name = f.FeatName,
                                    Description = f.FeatDescription,
                                    Benefit = f.FeatBenefit,
                                    Prerequisites = f.FeatPrerequisites,
                                    Special = f.FeatSpecial,
                                    Type = f.FeatType,
                                    Normal = f.FeatNormal
                                });
                            }

                            forgeDatabase.Feats.InsertAllOnSubmit(featList);
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
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = "*.xlsx",
                Filter = "XLSX Files (*.xlsx)|*.xlsx|XLS Files (*.xls)|*.xls"
            };

            Nullable<bool> result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string filename = dlg.FileName;

                string extension = Path.GetExtension(filename);

                var uiThread = TaskScheduler.FromCurrentSynchronizationContext();

                Task bkThread = Task.Factory.StartNew(() => ClearFeatInfo())
                                .ContinueWith(t1 => IoC.Get<IEventAggregator>().PublishOnUIThread("OpenProgressDialog"), uiThread)
                                .ContinueWith(t2 => ImportFeat(filename, extension))
                                .ContinueWith(t3 => PopulateFeatCollection())
                                .ContinueWith(t4 => ClearFeatInfo())
                                .ContinueWith(t5 => IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog"), uiThread);
            }
        }

        public void Search(object obj)
        {
            var text = obj as string;

            if(IsTypeSearch)
            {
                if (string.IsNullOrWhiteSpace(text))
                    FeatCollection = new BindableCollection<FeatCollection>(Global.Instance.FeatCollection);
                else
                    FeatCollection = new BindableCollection<FeatCollection>(
                        Global.Instance.FeatCollection.Where(
                            x => x.FeatType.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(text))
                    FeatCollection = new BindableCollection<FeatCollection>(Global.Instance.FeatCollection);
                else
                    FeatCollection = new BindableCollection<FeatCollection>(
                        Global.Instance.FeatCollection.Where(
                            x => x.FeatName.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0));
            }
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
                case "AcceptAddFeatDialog":
                    PopulateFeatCollectionAsync();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

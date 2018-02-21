using Caliburn.Micro;
using System;
using System.Collections.Generic;
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
using Forge.Classes;
using System.Data.SQLite;
using System.ComponentModel;
using Forge.Tables;

namespace Forge.Controls
{
    /// <summary>
    /// Interaction logic for StorySettingsDialog.xaml
    /// </summary>
    public partial class StorySettingsDialog : UserControl
    {
        #region Private Variables
        private int _storyID;
        private string _title = string.Empty;
        private string _author = string.Empty;
        private string _description = string.Empty;
        #endregion

        #region Public Variables
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChanged("Title");
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                NotifyOfPropertyChanged("Author");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChanged("Description");
            }
        }
        #endregion




        public StorySettingsDialog()
        {
            InitializeComponent();
            GetStories();
        }

        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(StoryTitle) && !Validation.GetHasError(StoryAuthor) && !Validation.GetHasError(StoryDescription))
            {
                var contains = new StringContains();

                string _storyTitle = StoryTitle.Text;
                string _storyAuthor = StoryAuthor.Text;
                string _storyDate = StoryDate.Text;
                string _storyType = StoryType.Text;
                string _storyDescription = StoryDescription.Text;

                var forgeDatabase = Global.Instance.ForgeDatabase();
                STORY story = forgeDatabase.Stories.Single(s => s.ID == Global.Instance.StoryID);

                story.Name = _storyTitle;
                story.Author = _storyAuthor;
                story.Created = _storyDate;
                story.Type = _storyType;
                story.Description = _storyDescription;

                forgeDatabase.SubmitChanges();

                Global.Instance.UpdateNote(@"Story UPDATED! (Name = " + _storyTitle + @") (Author = " + _storyAuthor + @") (Created = " + _storyDate + @") (Type = " + _storyType + @") (Description  = " + _storyDescription + @")");

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRealmUpdate");
            }
        }

        private void GetStories()
        {
            try
            {
                _storyID = Global.Instance.StoryID;
                StoryTitle.Text = Global.Instance.StoryName;
                StoryAuthor.Text = Global.Instance.StoryAuthor;
                StoryDate.Text = Global.Instance.DateCreated;
                StoryDescription.Text = Global.Instance.StoryDescription;

                switch(Global.Instance.StoryType)
                {
                    case "General Fantasy":
                        StoryType.SelectedIndex = 0;
                        break;
                    case "General Sci-Fi":
                        StoryType.SelectedIndex = 1;
                        break;
                    case "Pathfinder":
                        StoryType.SelectedIndex = 2;
                        break;
                    case "DnD 5e":
                        StoryType.SelectedIndex = 3;
                        break;
                    default:
                        StoryType.SelectedIndex = -1;
                        break;
                }
            }
            catch { }
        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyOfPropertyChanged(string sProp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProp));
        }
        #endregion
    }
}

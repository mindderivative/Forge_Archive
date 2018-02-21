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
    /// Interaction logic for CreateStoryDialog.xaml
    /// </summary>
    public partial class AddStoryDialog : UserControl, INotifyPropertyChanged
    {
        #region Private Variables
        private string _titleTxt = string.Empty;
        private string _authorTxt = string.Empty;
        private string _descriptionTxt = string.Empty;
        #endregion

        #region Public Variables
        public string TitleTxt
        {
            get { return _titleTxt; }
            set
            {
                _titleTxt = value;
                NotifyOfPropertyChanged("TitleTxt");
            }
        }
        public string AuthorTxt
        {
            get { return _authorTxt; }
            set
            {
                _authorTxt = value;
                NotifyOfPropertyChanged("AuthorTxt");
            }
        }
        public string DescriptionTxt
        {
            get { return _descriptionTxt; }
            set
            {
                _descriptionTxt = value;
                NotifyOfPropertyChanged("DescriptionTxt");
            }
        }
        #endregion

        public AddStoryDialog()
        {
            InitializeComponent();

            Date.Text = DateTime.Now.ToShortDateString();
        }

        private void CancelDialog(object sender, RoutedEventArgs e)
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("CancelRootDialog");
        }

        private void AcceptDialog(object sender, RoutedEventArgs e)
        {
            if (!Validation.GetHasError(Title) && !Validation.GetHasError(Author) && !Validation.GetHasError(Description))
            {
                string _storyTitle = Title.Text;
                string _storyAuthor = Author.Text;
                string _storyDate = Date.Text;
                string _storyType = Type.Text;
                string _storyDescription = Description.Text;

                STORY story = new STORY()
                {
                    Name = _storyTitle,
                    Author = _storyAuthor,
                    Created = _storyDate,
                    Type = _storyType,
                    Description = _storyDescription
                };

                var forgeDatabase = Global.Instance.ForgeDatabase();
                forgeDatabase.Stories.InsertOnSubmit(story);
                forgeDatabase.SubmitChanges();

                /*string sql = @"insert into STORY (StoryName, StoryAuthor, DateCreated, StoryType, StoryDescription) 
                            values ('" + _storyTitle + "','" + _storyAuthor + "','" + _storyDate + "','" + _storyType + "','" + _storyDescription + "')";

                Global.Instance.InitiateDatabaseNonQuery();
                Global.Instance.SQLInsert(sql);
                Global.Instance.CloseDatabase();*/

                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRootDialog");
                IoC.Get<IEventAggregator>().PublishOnUIThread("AcceptRealmCreation");
            }
        }

        #region PropteryChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyOfPropertyChanged(string sProp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProp));
        }
        #endregion
    }
}

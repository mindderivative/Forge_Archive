using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forge.Classes;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows;
using Forge.Tables;

namespace Forge.ViewModels
{
    [Export(typeof(DashboardViewModel))]
    public class DashboardViewModel : Screen, IHandle<string>
    {
        #region Private Variables
        private BindableCollection<StoryCollection> _storyCollection = new BindableCollection<StoryCollection>();
        private int _selectedIndex = -1;
        private bool _isStorySelected = false;
        private bool _isStoryLoaded = false;
        private string _storyLoadedName;
        private string _storyLoadedAuthor;
        private string _loadedDateCreated;
        private string _storyLoadedType;
        private string _storyLoadedDescription;
        #endregion

        #region Public Variables
        public BindableCollection<StoryCollection> StoryCollection
        {
            get { return _storyCollection; }
            set
            {
                if(_storyCollection != value)
                {
                    _storyCollection = value;
                    NotifyOfPropertyChange(() => StoryCollection);
                }
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if(_selectedIndex != value)
                {
                    _selectedIndex = value;
                    NotifyOfPropertyChange(() => SelectedIndex);

                    if(_selectedIndex >= 0)
                    {
                        IsStorySelected = true;
                    }
                    else
                    {
                        IsStorySelected = false;
                    }
                }
            }
        }
        public bool IsStorySelected
        {
            get { return _isStorySelected; }
            set
            {
                if(_isStorySelected != value)
                {
                    _isStorySelected = value;
                    NotifyOfPropertyChange(() => IsStorySelected);
                }
            }
        }
        public bool IsStoryLoaded
        {
            get { return _isStoryLoaded; }
            set
            {
                if(_isStoryLoaded != value)
                {
                    _isStoryLoaded = value;
                    NotifyOfPropertyChange(() => IsStoryLoaded);
                }
            }
        }
        public string StoryLoadedName
        {
            get { return _storyLoadedName; }
            set
            {
                if(_storyLoadedName != value)
                {
                    _storyLoadedName = value;
                    NotifyOfPropertyChange(() => StoryLoadedName);
                }
            }
        }
        public string StoryLoadedAuthor
        {
            get { return _storyLoadedAuthor; }
            set
            {
                if(_storyLoadedAuthor != value)
                {
                    _storyLoadedAuthor = value;
                    NotifyOfPropertyChange(() => StoryLoadedAuthor);
                }
            }
        }
        public string LoadedDateCreated
        {
            get { return _loadedDateCreated; }
            set
            {
                if(_loadedDateCreated != value)
                {
                    _loadedDateCreated = value;
                    NotifyOfPropertyChange(() => LoadedDateCreated);
                }
            }
        }
        public string StoryLoadedType
        {
            get { return _storyLoadedType; }
            set
            {
                if(_storyLoadedType != value)
                {
                    _storyLoadedType = value;
                    NotifyOfPropertyChange(() => StoryLoadedType);
                }
            }
        }
        public string StoryLoadedDescription
        {
            get { return _storyLoadedDescription; }
            set
            {
                if(_storyLoadedDescription != value)
                {
                    _storyLoadedDescription = value;
                    NotifyOfPropertyChange(() => StoryLoadedDescription);
                }
            }
        }
        #endregion

        [ImportingConstructor]
        public DashboardViewModel()
        {
            IoC.Get<IEventAggregator>().Subscribe(this);

            PopulateStoryCollection();

            if (!Global.Instance.StoryLoaded)
            {
                IsStoryLoaded = false;
            }
            else
            {
                StoryLoadedName = Global.Instance.StoryName;
                StoryLoadedAuthor = Global.Instance.StoryAuthor;
                LoadedDateCreated = Global.Instance.DateCreated;
                StoryLoadedType = Global.Instance.StoryType;
                StoryLoadedDescription = Global.Instance.StoryDescription;
                IsStoryLoaded = true;
                IoC.Get<IEventAggregator>().PublishOnUIThread("OpenStory");
            }
        }

        #region Private Methods
        private void PopulateStoryCollection()
        {
            StoryCollection = new BindableCollection<StoryCollection>();
            var forgeDatabase = Global.Instance.ForgeDatabase();
            var tempStoryCollection = new BindableCollection<StoryCollection>();


            foreach (var story in forgeDatabase.Stories)
            {
                tempStoryCollection.Add(new StoryCollection
                {

                    ID = story.ID,
                    Name = story.Name,
                    Author = story.Author,
                    Created = story.Created,
                    Type = story.Type,
                    Description = story.Description
                });
            }


            if (tempStoryCollection.SequenceEqual(Global.Instance.StoryCollection))
            {
                StoryCollection = new BindableCollection<StoryCollection>(tempStoryCollection);
            }
            else
            {
                Global.Instance.StoryCollection = new BindableCollection<StoryCollection>(tempStoryCollection);
                StoryCollection = new BindableCollection<StoryCollection>(tempStoryCollection);
            }
        }

        #endregion

        #region Public Methods
        public void CreateStory()
        {
            IoC.Get<IEventAggregator>().PublishOnUIThread("OpenCreateStoryDialog");
        }

        public void DeleteStory()
        {
            try
            {
                var forgeDatabase = Global.Instance.ForgeDatabase();
                int storyID = StoryCollection[SelectedIndex].ID;

                List<string> mapPath = new List<string>();

                foreach(var map in forgeDatabase.Maps.Where(x => x.StoryID == storyID))
                {
                    mapPath.Add(map.Path);
                }

                STORY story = forgeDatabase.Stories.Single(s => s.ID == storyID);

                //MessageBox.Show(story.ID.ToString());
                forgeDatabase.Stories.DeleteOnSubmit(story);
                forgeDatabase.SubmitChanges();

                PopulateStoryCollection();

                Global.Instance.StoryID = -1;
                Global.Instance.StoryName = string.Empty;
                Global.Instance.StoryAuthor = string.Empty;
                Global.Instance.DateCreated = string.Empty;
                Global.Instance.StoryType = string.Empty;
                Global.Instance.StoryDescription = string.Empty;
                Global.Instance.StoryLoaded = false;

                StoryLoadedName = string.Empty;
                StoryLoadedAuthor = string.Empty;
                LoadedDateCreated = string.Empty;
                StoryLoadedType = string.Empty;
                StoryLoadedDescription = string.Empty;
                IsStoryLoaded = false;

                Global.Instance.MapID = -1;
                Global.Instance.ParentMapID = -1;
                Global.Instance.MapName = string.Empty;
                Global.Instance.MapPath = string.Empty;
                Global.Instance.MapWidth = -1;
                Global.Instance.MapHeight = -1;
                Global.Instance.IsBaseMap = false;
                Global.Instance.BaseMapLoaded = false;

                Global.Instance.BaseMapID = -1;
                Global.Instance.BaseParentMapID = -1;
                Global.Instance.BaseMapName = string.Empty;
                Global.Instance.BaseMapPath = string.Empty;
                Global.Instance.BaseMapWidth = -1;
                Global.Instance.BaseMapHeight = -1;
                Global.Instance.BaseIsBaseMap = false;

                foreach (var map in mapPath)
                 {
                     if(File.Exists(map))
                     {
                         File.Delete(map);
                     }
                     else
                    {
                        MessageBox.Show("Map not found: " + map);
                    }
                 }

                
                IoC.Get<IEventAggregator>().PublishOnUIThread("DeleteStory");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void OpenStory()
        {
            try
            {
                if (SelectedIndex >= 0)
                {
                    Global.Instance.StoryID = StoryCollection[SelectedIndex].ID;
                    Global.Instance.StoryName = StoryCollection[SelectedIndex].Name;
                    Global.Instance.StoryAuthor = StoryCollection[SelectedIndex].Author;
                    Global.Instance.DateCreated = StoryCollection[SelectedIndex].Created;
                    Global.Instance.StoryType = StoryCollection[SelectedIndex].Type;
                    Global.Instance.StoryDescription = StoryCollection[SelectedIndex].Description;
                    Global.Instance.StoryLoaded = true;

                    StoryLoadedName = Global.Instance.StoryName;
                    StoryLoadedAuthor = Global.Instance.StoryAuthor;
                    LoadedDateCreated = Global.Instance.DateCreated;
                    StoryLoadedType = Global.Instance.StoryType;
                    StoryLoadedDescription = Global.Instance.StoryDescription;
                    IsStoryLoaded = true;
                    IoC.Get<IEventAggregator>().PublishOnUIThread("OpenStory");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void StorySettings()
        {
            try
            {
                Global.Instance.StoryID = StoryCollection[SelectedIndex].ID;
                Global.Instance.StoryName = StoryCollection[SelectedIndex].Name;
                Global.Instance.StoryAuthor = StoryCollection[SelectedIndex].Author;
                Global.Instance.DateCreated = StoryCollection[SelectedIndex].Created;
                Global.Instance.StoryType = StoryCollection[SelectedIndex].Type;
                Global.Instance.StoryDescription = StoryCollection[SelectedIndex].Description;

                IsStoryLoaded = false;
                IoC.Get<IEventAggregator>().PublishOnUIThread("StorySettings");
            }
            catch { }
        }
        #endregion

        #region IHandle Method
        public void Handle(string message)
        {
            switch (message)
            {
                case "AcceptRealmCreation":
                    PopulateStoryCollection();
                    break;
                case "AcceptRealmUpdate":
                    PopulateStoryCollection();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

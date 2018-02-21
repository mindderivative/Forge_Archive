using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class TableStory : PropertyChangedBase
    {
        private object _storyID;
        private object _storyName;
        private object _storyAuthor;
        private object _dateCreated;
        private object _storyType;
        private object _storyDescription;

        public object StoryID
        {
            get { return _storyID; }
            set
            {
                if(_storyID != value)
                {
                    _storyID = value;
                    NotifyOfPropertyChange(() => StoryID);
                }
            }
        }
        public object StoryName
        {
            get { return _storyName; }
            set
            {
                if(_storyName != value)
                {
                    _storyName = value;
                    NotifyOfPropertyChange(() => StoryName);
                }
            }
        }
        public object StoryAuthor
        {
            get { return _storyAuthor; }
            set
            {
                if(_storyAuthor != value)
                {
                    _storyAuthor = value;
                    NotifyOfPropertyChange(() => StoryAuthor);
                }
            }
        }
        public object DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if(_dateCreated != value)
                {
                    _dateCreated = value;
                    NotifyOfPropertyChange(() => DateCreated);
                }
            }
        }
        public object StoryType
        {
            get { return _storyType; }
            set
            {
                if(_storyType != value)
                {
                    _storyType = value;
                    NotifyOfPropertyChange(() => StoryType);
                }
            }
        }
        public object StoryDescription
        {
            get { return _storyDescription; }
            set
            {
                if(_storyDescription != value)
                {
                    _storyDescription = value;
                    NotifyOfPropertyChange(() => StoryDescription);
                }
            }
        }
    }
}

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class PlayerSkillCollection : PropertyChangedBase
    {
        private int _id;
        private string _skillName;
        private string _skillDescription;
        private int _skillRank;

        public int ID
        {
            get { return _id; }
            set
            {
                if(_id != value)
                {
                    _id = value;
                    NotifyOfPropertyChange(() => ID);
                }
            }
        }
        public string SkillName
        {
            get { return _skillName; }
            set
            {
                if (_skillName != value)
                {
                    _skillName = value;
                    NotifyOfPropertyChange(() => SkillName);
                }
            }
        }
        public string SkillDescription
        {
            get { return _skillDescription; }
            set
            {
                if (_skillDescription != value)
                {
                    _skillDescription = value;
                    NotifyOfPropertyChange(() => SkillDescription);
                }
            }
        }
        public int SkillRank
        {
            get { return _skillRank; }
            set
            {
                if (_skillRank != value)
                {
                    _skillRank = value;
                    NotifyOfPropertyChange(() => SkillRank);
                }
            }
        }
    }
}

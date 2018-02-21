using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Forge.Tables
{
    [Table]
    public class PLAYER_SKILL
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int PlayerID { get; set; }
        private EntityRef<PLAYER> _player = new EntityRef<PLAYER>();
        [Association(Name ="FK_PLAYER_SKILL_PLAYER", IsForeignKey = true, Storage = "_player", ThisKey = "PlayerID")]
        public PLAYER PLAYER
        {
            get { return _player.Entity; }
            set { _player.Entity = value; }
        }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int SkillID { get; set; }
        private EntityRef<SKILL> _skill = new EntityRef<SKILL>();
        [Association(Name = "FK_PLAYER_SKILL_SKILL", IsForeignKey = true, Storage = "_skill", ThisKey = "SkillID")]
        public SKILL SKILL
        {
            get { return _skill.Entity; }
            set { _skill.Entity = value; }
        }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Rank { get; set; }
    }
}

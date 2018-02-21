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
    public class PLAYER_FACTION
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID;

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int PlayerID { get; set; }
        private EntityRef<PLAYER> _player = new EntityRef<PLAYER>();
        [Association(Name = "FK_PLAYER_FACTION_PLAYER", IsForeignKey = true, Storage = "_player", ThisKey = "PlayerID")]
        public PLAYER PLAYER
        {
            get { return _player.Entity; }
            set { _player.Entity = value; }
        }
        

        [Column(UpdateCheck = UpdateCheck.Never)]
        public int FactionID { get; set; }
        private EntityRef<FACTION> _faction = new EntityRef<FACTION>();
        [Association(Name = "FK_PLAYER_FACTION_FACTION", IsForeignKey = true, Storage = "_faction", ThisKey = "FactionID")]
        public FACTION FACTION
        {
            get { return _faction.Entity; }
            set { _faction.Entity = value; }
        }

        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Status { get; set; }
    }
}

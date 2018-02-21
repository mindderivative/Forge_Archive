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
    public class FACTION
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Description { get; set; }

        private EntitySet<PLAYER_FACTION> _playerFaction = new EntitySet<PLAYER_FACTION>();
        [Association(Name = "FK_PLAYER_FACTION_FACTION", Storage = "_playerFaction", OtherKey = "FactionID", ThisKey = "ID")]
        private ICollection<PLAYER_FACTION> PLAYER_FACTION
        {
            get { return _playerFaction; }
            set { _playerFaction.Assign(value); }
        }

        public ICollection<PLAYER> Players { get { return (from pf in PLAYER_FACTION select pf.PLAYER).ToList(); } }
        public string FactionStatus { get { return (from pf in PLAYER_FACTION where pf.FactionID == ID select pf.Status).FirstOrDefault(); } }
    }
}

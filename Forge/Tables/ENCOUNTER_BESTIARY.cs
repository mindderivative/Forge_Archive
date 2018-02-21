using System.Data.Linq.Mapping;

namespace Forge.Tables
{
    [Table]
    public class ENCOUNTER_BESTIARY
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int EncounterID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int BeastID { get; set; }
    }
}

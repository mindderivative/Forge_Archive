using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table]
    public class REGION
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int LayerID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Color { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int MapID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int EncounterID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int EventID { get; set; }
    }
}

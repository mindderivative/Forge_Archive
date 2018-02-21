using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table]
    public class REGION_POINTS
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int RegionID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Top { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Left { get; set; }
    }
}

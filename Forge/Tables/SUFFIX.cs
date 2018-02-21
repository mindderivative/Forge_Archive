using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table]
    public class SUFFIX
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Suffix { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Race { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Sex { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string FirstLast { get; set; }
    }
}

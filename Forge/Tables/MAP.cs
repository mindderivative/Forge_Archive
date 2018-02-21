using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Tables
{
    [Table]
    public class MAP
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int ID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int StoryID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int? ParentID { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public string Path { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Width { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int Height { get; set; }
        [Column(UpdateCheck = UpdateCheck.Never)]
        public int IsBaseMap { get; set; }
    }
}

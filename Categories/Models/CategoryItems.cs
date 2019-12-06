using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Categories.Models
{
    [Table("category")]
    public class CategoryItems
    {   [Key]
        [Column("categoryid")]
        public int? CategoryId { get; set; }
        [Column("categorygroup")]
        public string CategoryGroup { get; set; }
        [Column("categoryname")]
        public string CategoryName { get; set; }
        [Column("categorydescription")]
        public string CategoryDescription { get; set; }
    }
}

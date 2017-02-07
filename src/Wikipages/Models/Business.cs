 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wikipages.Models
{
    [Table("Businesses")]
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set;} 
    }
}

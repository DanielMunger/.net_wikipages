using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Wikipages.Models
{
    [Table("Types")]
    public class Type
    {
        public Type()
        {
            this.Businesses = new HashSet<Business>();
        }

        [Key]
        public int TypeId { get; set; }
        public string type { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}

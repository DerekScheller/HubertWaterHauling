using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models
{
    public abstract class HWHBase
    {
            [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        [Required]
        public DateTime ModifiedDateTime { get; set; }

        protected HWHBase()
        {
            ModifiedDateTime = DateTime.Now;
            CreatedDateTime = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190314_PhamThanhHoi.DTO
{
    [Table("ThanhPho")]
    public class TP
    {
        [Key][StringLength(2)]
        public string MaTP { get; set; }
        [StringLength(int.MaxValue)]
        public string TenTP { get; set; }
    }
}

using _102190314_PhamThanhHoi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190314_PhamThanhHoi.View
{
    [Table("NhaCungCap")]
    public class NCC
    {
        public NCC()
        {
            SPs = new HashSet<SP>();
        }
        [Key]
        public int MaNCC { get; set; }
        [StringLength(int.MaxValue)]
        public string TenNCC { get; set; }
        public string MaTP { get; set; }
        [ForeignKey("MaTP")]
        public virtual TP TP { get; set; }
        public virtual ICollection<SP> SPs { get; set; }
    }
}

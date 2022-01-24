using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190314_PhamThanhHoi.View
{
    [Table("SanPham")]
    public class SP
    {
        [Key][StringLength(10)]
        public string MaSP { get; set; }
        [StringLength(int.MaxValue)]
        public string TenSP { get; set; }
        public double GiaNhapSP { get; set; }
        public DateTime NgayNhapSP { get; set; }
        public int SoLuongSP { get; set; }
        public int MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NCC NCC { get; set; }
    }
}

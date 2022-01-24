using _102190314_PhamThanhHoi.DTO;
using _102190314_PhamThanhHoi.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190314_PhamThanhHoi
{    
    class CreateDB : CreateDatabaseIfNotExists<QLSP>
    {
        protected override void Seed(QLSP context)
        {
            context.TPs.AddRange(new TP[]
            {
                new TP{MaTP = "01", TenTP = "Da Nang"},
                new TP{MaTP = "02", TenTP = "Quang Nam"}
            });
            context.NCCs.AddRange(new NCC[]
            {
                new NCC{MaNCC = 1, TenNCC = "Nuoc ngot", MaTP = "01"},
                new NCC{MaNCC = 2, TenNCC = "Dien thoa", MaTP = "02"},
                new NCC{MaNCC = 3, TenNCC = "Dung cu hoc tap", MaTP = "01"},
            });
            context.SPs.AddRange(new SP[]
            {
                new SP{MaSP = "SP001", TenSP = "Pepsi", GiaNhapSP = 5000, NgayNhapSP = DateTime.Now, SoLuongSP = 4, MaNCC = 1},
                new SP{MaSP = "SP002", TenSP = "Sting", GiaNhapSP = 7000, NgayNhapSP = DateTime.Now, SoLuongSP = 3, MaNCC = 1},
                new SP{MaSP = "SP003", TenSP = "SamSung", GiaNhapSP = 1000000, NgayNhapSP = DateTime.Now, SoLuongSP = 1, MaNCC = 2},
                new SP{MaSP = "SP004", TenSP = "Iphone", GiaNhapSP = 1500000, NgayNhapSP = DateTime.Now, SoLuongSP = 2, MaNCC = 2},
                new SP{MaSP = "SP005", TenSP = "Thuoc", GiaNhapSP = 2000, NgayNhapSP = DateTime.Now, SoLuongSP = 3, MaNCC = 3}

            });
        }
    }
}

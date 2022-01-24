using _102190314_PhamThanhHoi.DTO;
using _102190314_PhamThanhHoi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190314_PhamThanhHoi.BLL
{
    class BLL_QLSP
    {
        private static BLL_QLSP _Instance;
        public static BLL_QLSP cnn { get; set; }
        public static BLL_QLSP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLSP();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_QLSP() { }        
        public List<CBBItem> GetCBBItem_TP()
        {
            QLSP db = new QLSP();
            List<CBBItem> data = new List<CBBItem>();
            foreach (TP i in db.TPs)
            {
                data.Add(new CBBItem
                {
                    Text = i.TenTP,
                    Value = i.MaTP
                });
            }
            return data;
        }
        public List<CBBItem> GetCBBItem_NCC(string ID_TP)
        {
            QLSP db = new QLSP();
            List<CBBItem> data = new List<CBBItem>();
            if (ID_TP == "")
            {
                foreach (NCC i in db.NCCs)
                {
                    data.Add(new CBBItem
                    {
                        Text = i.TenNCC,
                        Value = i.MaNCC
                    });
                }
            }
            else
            {
                foreach (NCC i in db.NCCs.Where(p => p.MaTP.Contains(ID_TP)))
                {
                    data.Add(new CBBItem
                    {
                        Text = i.TenNCC,
                        Value = i.MaNCC
                    });
                }
            }
            return data;
        }
        public List<ListSPView> GetListSP_BLL(string ID_TP, int ID_NCC,string name)
        {
            QLSP db = new QLSP();
            List<SP> s = new List<SP>();            
            List<ListSPView> data = new List<ListSPView>();     
            if(ID_TP == "")
            {
                
                if (ID_NCC == -1)
                {
                    if (name == "")
                    {
                        s = db.SPs.Select(p => p).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                    else
                    {
                        s = db.SPs.Where(p =>p.TenSP.Contains(name)).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                }
                else
                {
                    if (name == "")
                    {
                        s = db.SPs.Where(p => p.MaNCC == ID_NCC + 1).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                    else
                    {
                        s = db.SPs.Where(p => p.MaNCC == ID_NCC + 1 && p.TenSP.Contains(name)).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                }
            }
            else
            {
                if (ID_NCC == -1)
                {
                    if (name == "")
                    {
                        s = db.SPs.Where(p => p.NCC.MaTP.Contains(ID_TP)).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                    else
                    {
                        s = db.SPs.Where(p => p.NCC.MaTP.Contains(ID_TP) && p.TenSP.Contains(name)).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                }
                else
                {
                    if (name == "")
                    {
                        s = db.SPs.Where(p => p.MaNCC == ID_NCC + 1).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                    else
                    {
                        s = db.SPs.Where(p => p.MaNCC == ID_NCC + 1 && p.TenSP.Contains(name)).ToList();
                        data = GetListSPView(s);
                        return data;
                    }
                }
            }            
                       
        }
        public ListSPView Chuyendoi(SP s)
        {
            QLSP db = new QLSP();
            ListSPView data = new ListSPView();
            data.MaSP = s.MaSP;
            data.TenSP = s.TenSP;
            data.GiaNhapSP = s.GiaNhapSP;
            data.SoLuongSP = s.SoLuongSP;
            data.NgayNhapSP = s.NgayNhapSP;
            if (s.SoLuongSP == 0) data.TinhTrang = false;
            else data.TinhTrang = true;
            foreach (NCC i in db.NCCs)
            {
                if (s.MaNCC == i.MaNCC) data.TenNCC = i.TenNCC;
            }
            foreach (TP i in db.TPs)
            {
                if (s.NCC.MaTP == i.MaTP) data.TenTP = i.TenTP;
            }
            return data;
        }
        public List<ListSPView> GetListSPView(List<SP> s)
        {
            QLSP db = new QLSP();
            
            List<ListSPView> data = new List<ListSPView>();
            foreach(SP i in s)
            {
                data.Add(Chuyendoi(i));
            }
            return data;
        }
        public ListSPView GetSPByMaSP_BLL(string MaSP)
        {
            QLSP db = new QLSP();
            SP s = new SP();
            s = db.SPs.Find(MaSP);
            if (s == null) return null;
            else return Chuyendoi(s);
        }
        public void ExecuteDB(SP s)
        {
            QLSP db = new QLSP();
            if (db.SPs.Find(s.MaSP) == null)
            {
                db.SPs.Add(s);
                db.SaveChanges();
            }
            else
            {
                SP sedit = db.SPs.Find(s.MaSP);
                sedit.TenSP = s.TenSP;
                sedit.NgayNhapSP = s.NgayNhapSP;
                sedit.SoLuongSP = s.SoLuongSP;                
                sedit.GiaNhapSP = s.GiaNhapSP;                
                sedit.MaNCC = s.MaNCC;                
                db.SaveChanges();
            }
        }
        public void DeleteSP_BLL(DataGridViewSelectedRowCollection r)
        {
            QLSP db = new QLSP();
            foreach (DataGridViewRow i in r)
            {
                string MaSP = i.Cells["MaSP"].Value.ToString();
                SP sdel = db.SPs.Find(MaSP);
                db.SPs.Remove(sdel);
                db.SaveChanges();
            }
        }
        public List<ListSPView> SortSP_BLL(string item)
        {
            QLSP db = new QLSP();
            List<SP> s = new List<SP>();
            if (item == "Ten SP") s = db.SPs.OrderBy(p => p.TenSP).ToList();
            if (item == "Gia nhap SP") s = db.SPs.OrderBy(p => p.GiaNhapSP).ToList();
            if(item == "Tinh trang") s = db.SPs.OrderBy(p => p.SoLuongSP).ToList();
            return GetListSPView(s);
        }
    }
}

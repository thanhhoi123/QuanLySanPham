using _102190314_PhamThanhHoi.BLL;
using _102190314_PhamThanhHoi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190314_PhamThanhHoi.View
{
    public partial class PhamThanhHoi_DF : Form
    {
        public string MaSP { get; set; }
        public delegate void Mydel(string ID_TP, int ID_NCC,string name);
        public Mydel d { get; set; }
        public PhamThanhHoi_DF(string m)
        {
            InitializeComponent();
            MaSP = m;
            SetCBB_Form2();
            SetGUI();
        }
        public void SetCBB_Form2()
        {
            cbbTP.Items.AddRange(BLL_QLSP.Instance.GetCBBItem_TP().ToArray());
        }

        private void cbbTP_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbNCC.Items.Clear();
            string ID_TP = ((CBBItem)cbbTP.SelectedItem).Value.ToString();
            cbbNCC.Items.AddRange(BLL_QLSP.Instance.GetCBBItem_NCC(ID_TP).ToArray());
        }
        public void SetGUI()
        {
            if (BLL_QLSP.Instance.GetSPByMaSP_BLL(MaSP) != null)
            {
                ListSPView s = new ListSPView();
                s = BLL_QLSP.Instance.GetSPByMaSP_BLL(MaSP);
                txtMaSP.Text = s.MaSP;
                txtGiaSP.Text = s.GiaNhapSP.ToString();
                txtSoLuongSP.Text = s.SoLuongSP.ToString();
                txtTenSP.Text = s.TenSP;
                dateTimePicker1.Value = s.NgayNhapSP;
                cbbTP.Text = s.TenTP;
                cbbNCC.Text = s.TenNCC;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            SP s = new SP()
            {
                MaSP = txtMaSP.Text,
                GiaNhapSP = Convert.ToDouble(txtGiaSP.Text),
                SoLuongSP = Convert.ToInt32(txtSoLuongSP.Text),                
                TenSP = txtTenSP.Text,
                NgayNhapSP = dateTimePicker1.Value,
                MaNCC = Convert.ToInt32(((CBBItem)cbbNCC.SelectedItem).Value)

            };
            BLL_QLSP.Instance.ExecuteDB(s);
            d("", -1 ,null);
            this.Dispose();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            d("", -1, null);
            this.Dispose();
        }
    }
}

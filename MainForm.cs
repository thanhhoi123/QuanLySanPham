using _102190314_PhamThanhHoi.BLL;
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
    public partial class PhamThanhHoi_MF : Form
    {
        public PhamThanhHoi_MF()
        {
            InitializeComponent();
            SetCBB();
        }        
        public void SetCBB()
        {
            cbbTP.Items.Add(new CBBItem { Value = "", Text = "All" });
            cbbTP.Items.AddRange(BLL_QLSP.Instance.GetCBBItem_TP().ToArray());            
        }
        public void Show(string ID_TP,int ID_NCC, string name)
        {
            dgvSP.DataSource = BLL_QLSP.Instance.GetListSP_BLL(ID_TP, ID_NCC,txtSearch.Text);
            dgvSP.Columns["MaSP"].Visible = false;
            dgvSP.Columns["SoLuongSP"].Visible = false;
        }
        private void PhamThanhHoi_MF_Load(object sender, EventArgs e)
        {
            Show("", -1, null);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string ID_TP = ((CBBItem)cbbTP.SelectedItem).Value.ToString();
            int ID_NCC = cbbNCC.SelectedIndex;           
            
            Show(ID_TP, ID_NCC, txtSearch.Text);
        }        

        private void cbbTP_SelectedValueChanged(object sender, EventArgs e)
        {
            cbbNCC.Items.Clear();
            cbbNCC.Text = "";
            string ID_TP = ((CBBItem)cbbTP.SelectedItem).Value.ToString();            
            cbbNCC.Items.AddRange(BLL_QLSP.Instance.GetCBBItem_NCC(ID_TP).ToArray());
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            PhamThanhHoi_DF f = new PhamThanhHoi_DF(null);
            f.d += new PhamThanhHoi_DF.Mydel(Show);
            f.Show();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (dgvSP.SelectedRows.Count == 1)
            {
                string MaSP = dgvSP.SelectedRows[0].Cells["MaSP"].Value.ToString();
                PhamThanhHoi_DF f = new PhamThanhHoi_DF(MaSP);
                f.d += new PhamThanhHoi_DF.Mydel(Show);
                f.Show();
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (dgvSP.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection r = dgvSP.SelectedRows;
                BLL_QLSP.Instance.DeleteSP_BLL(r);
                string ID_TP = ((CBBItem)cbbTP.SelectedItem).Value.ToString();
                int ID_NCC = cbbNCC.SelectedIndex;
                Show(ID_TP, ID_NCC, txtSearch.Text);
            }
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            string item = cbbSort.SelectedItem.ToString();            
            dgvSP.DataSource = BLL_QLSP.Instance.SortSP_BLL(item);            
        }        
    }
}

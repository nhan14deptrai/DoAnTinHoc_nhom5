using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Form1 : Form
    {

        private List<CDanhBa> dsDB = new List<CDanhBa>();
        public void hienDSDanhBa()
        {
            dgvDanhBa.DataSource = dsDB.ToList();
        }
        private CDanhBa timDanhBa(string sdt)
        {
            foreach (CDanhBa db in dsDB)
            {
                if (db.SDT == sdt)
                    return db;
            }
            return null;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dsDB = new List<CDanhBa>();
            hienDSDanhBa();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CDanhBa db = new CDanhBa();
            db.SDT = txtSDT.Text;
            db.HoTen = txtHoten.Text;
            db.Email = txtEmail.Text;
            db.Diachi = txtDiachi.Text;
            if (timDanhBa(db.SDT) == null)
            {
                dsDB.Add(db);
                hienDSDanhBa();
            }
            else
            {
                MessageBox.Show("Số điện thoại " + db.SDT + "đã tồn tại.\nKhông thể thêm!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            CDanhBa danhBa = new CDanhBa();
            danhBa.SDT = txtSDT.Text;
            if(danhBa.SDT == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (timDanhBa(danhBa.SDT) != null)
            {
                dsDB.Remove(timDanhBa(danhBa.SDT));
                hienDSDanhBa();
                MessageBox.Show("Xóa số điện thoại " + danhBa.SDT + " thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Số điện thoại " + danhBa.SDT + "không tồn tại.\nKhông thể xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}

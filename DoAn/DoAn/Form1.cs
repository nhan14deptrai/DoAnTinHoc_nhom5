using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            LoadDanhBa();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sdtCanTim = txtSDT.Text;

            if (string.IsNullOrWhiteSpace(sdtCanTim))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại của liên hệ cần sửa vào ô 'Số điện thoại'.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Tìm đối tượng Danh Bạ (CDanhBa) cần sửa trong List
            CDanhBa dbCanSua = timDanhBa(sdtCanTim);

            if (dbCanSua != null)
            {
                // 2. Cập nhật các thông tin khác từ TextBox (SDT vẫn giữ nguyên)
                dbCanSua.HoTen = txtHoten.Text;
                dbCanSua.Email = txtEmail.Text;
                dbCanSua.Diachi = txtDiachi.Text;

                // 3. Hiển thị lại danh sách để DataGridView được cập nhật
                hienDSDanhBa();

                MessageBox.Show($"Đã cập nhật thông tin thành công cho số điện thoại: {sdtCanTim}!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Số điện thoại " + sdtCanTim + " không tồn tại.\nKhông thể sửa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnLuuFile_Click(object sender, EventArgs e)
        {
           using (StreamWriter sw = new StreamWriter("DanhBa.txt"))
            {
                foreach (CDanhBa db in dsDB)
                {
                    sw.WriteLine("{0},{1},{2},{3}", db.SDT, db.HoTen, db.Email, db.Diachi);

                }
                MessageBox.Show("Lưu danh bạ thành công!");

            }
        }
        public void LoadDanhBa()
        {
            dsDB.Clear();
            using (StreamReader sr = new StreamReader("DanhBa.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        CDanhBa db = new CDanhBa(parts[0], parts[1], parts[2], parts[3]);
                        dsDB.Add(db);
                    }
                }
            }
            hienDSDanhBa();
        }

       
    }
}

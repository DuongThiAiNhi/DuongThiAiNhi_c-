using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class Login : Form
    {
        string tentaikhoan = "nhi";
        string matkhau = "1";
        string strCon = @"Data Source=LAPTRONGVIEN\SQLEXPRESS;Initial Catalog=UserManager;User Id=sa;Trust Server Certificate=True";
        SqlConnection sqlCon = null;
        public Login()
        {
            InitializeComponent();
        }
        public bool kt;

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult q = MessageBox.Show("Are you exit?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q.Equals(DialogResult.Yes))
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (KiemTraDangNhap(tbUserName.Text, tbPassWord.Text))
            {
                UserManager f = new UserManager();
                f.Show();
                this.Hide();
                f.LogOut += F_LogOut;
                tbUserName.Text = "";
                tbPassWord.Text = "";
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Error");
                tbUserName.Focus();
            }

        }

        private void F_LogOut(object sender, EventArgs e)
        {
            (sender as UserManager).isThoat = false;
            (sender as UserManager).Close();
            this.Show();

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassWord.UseSystemPasswordChar = true;
            }
        }
        bool KiemTraDangNhap(string tentaikhoan, string matkhau)
        {
            if (tentaikhoan == this.tentaikhoan && matkhau == this.matkhau)
            {
                return true;
            }
            return false;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gbInformation_Enter(object sender, EventArgs e)
        {

        }
    }
}

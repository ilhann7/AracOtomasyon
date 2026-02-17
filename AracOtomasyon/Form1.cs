using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = "SELECT Id, Role FROM Users WHERE Username=@user AND Password=@pass";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) 
                        {
                            string rol = dr["Role"].ToString();
                        

                            MessageBox.Show($"Hoşgeldiniz, {username}. Yetkiniz: {rol}");

                            if (rol == "Admin")
                            {
                                MainForm adminPaneli = new MainForm();
                                adminPaneli.Show();
                            }
                            else
                            {
                                int userId = Convert.ToInt32(dr["Id"]);
                                UserForm musteriPaneli = new UserForm(userId);
                                musteriPaneli.Show();
                            }
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                }
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            RegisterForm kayitFormu = new RegisterForm();
            kayitFormu.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool surukleniyor = false;
        Point baslangicNoktasi = new Point(0, 0);

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            surukleniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            surukleniyor = false;
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukleniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - baslangicNoktasi.X, p.Y - baslangicNoktasi.Y);
            }
        }
    }
}
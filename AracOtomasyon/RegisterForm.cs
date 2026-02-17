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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
           // panel1.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            
            string secilenCinsiyet = "";

            if (rbErkek.Checked)
            {
                secilenCinsiyet = "Male";
            }
            else if (rbKadin.Checked)
            {
                secilenCinsiyet = "Female";
            }
            else
            {
                MessageBox.Show("Lütfen cinsiyet seçiniz.");
                return; 
            }
            if(string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtRegUser.Text) ||
                string.IsNullOrWhiteSpace(txtRegPass.Text) ||
                string.IsNullOrWhiteSpace(mskTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT INTO Users (AdSoyad, Username, Password, Role, Telefon, Email, DogumTarihi, Cinsiyet) " +
                                 "VALUES (@ad, @user, @pass, 'User', @tel, @mail, @dogum, @cinsiyet)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@user", txtRegUser.Text);
                        cmd.Parameters.AddWithValue("@pass", txtRegPass.Text);
                        cmd.Parameters.AddWithValue("@tel", mskTelefon.Text);
                        cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@dogum", dtpDogumTarihi.Value.ToString("yyyy-MM-dd"));

                        cmd.Parameters.AddWithValue("@cinsiyet", secilenCinsiyet);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt Başarılı! Giriş yapabilirsiniz.");

                      
                        Form1 login = new Form1();
                        login.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt Hatası: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    
    bool surukleniyor = false;
        Point baslangicNoktasi = new Point(0, 0);

        private void RegisterForm_MouseDown(object sender, MouseEventArgs e)
        {
            surukleniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void RegisterForm_MouseUp(object sender, MouseEventArgs e)
        {
            surukleniyor = false;
        }

        private void RegisterForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukleniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - baslangicNoktasi.X, p.Y - baslangicNoktasi.Y);
            }
        }
    }
    }

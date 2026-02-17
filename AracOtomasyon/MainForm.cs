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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AraclariListele();
            TumKiralamalariGetir(); 
           // GrafigiCiz(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           // AraclariListele();
        }
        void AraclariListele()
        {
            if (dgvAraclar == null) return;

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Araclar WHERE Durum = 1";
                    using (var da = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvAraclar.DataSource = dt;

                        
                        for (int i = 0; i < dgvAraclar.Columns.Count; i++)
                        {
                            dgvAraclar.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        if (dgvAraclar.Columns.Contains("Resim"))
                        {
                            var resimSutunu = dgvAraclar.Columns["Resim"] as DataGridViewImageColumn;
                            if (resimSutunu != null)
                            {
                                resimSutunu.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; 
                                resimSutunu.Width = 150; 
                                resimSutunu.ImageLayout = DataGridViewImageCellLayout.Zoom; 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (pbxAracResmi.Image == null)
            {
                MessageBox.Show("Lütfen bir araç resmi seçiniz!");
                return;
            }
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    
                    string sql = "INSERT INTO Araclar (Plaka, Marka, Model, Ucret, Durum, Resim) VALUES (@plaka, @marka, @model, @ucret, 1, @resim)"; using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                        cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                        cmd.Parameters.AddWithValue("@model", txtModel.Text);
                        cmd.Parameters.AddWithValue("@ucret", numUcret.Value);
                        cmd.Parameters.AddWithValue("@resim", ResimToByte(pbxAracResmi.Image));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Araç ve Resim Eklendi!");
                    AraclariListele(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAraclar.SelectedRows.Count > 0)
            {
                int seciliId = Convert.ToInt32(dgvAraclar.SelectedRows[0].Cells["Id"].Value);

                DialogResult cevap = MessageBox.Show("Bu aracı silmek istiyor musunuz?", "Sil", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "UPDATE Araclar SET Durum = 0 WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", seciliId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    AraclariListele();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.");
            }
        }
        void Temizle()
        {
            txtPlaka.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            numUcret.Value = 0;
        }
        private byte[] ResimToByte(System.Drawing.Image resim)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private System.Drawing.Image ByteToResim(byte[] veri)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(veri))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbxAracResmi.Image = new Bitmap(ofd.FileName);
            }
        }

        private void dgvAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtPlaka.Text = dgvAraclar.Rows[e.RowIndex].Cells["Plaka"].Value.ToString();
            txtMarka.Text = dgvAraclar.Rows[e.RowIndex].Cells["Marka"].Value.ToString();
            txtModel.Text = dgvAraclar.Rows[e.RowIndex].Cells["Model"].Value.ToString();

            numUcret.Value = Convert.ToDecimal(dgvAraclar.Rows[e.RowIndex].Cells["Ucret"].Value);

            var seciliHucre = dgvAraclar.Rows[e.RowIndex].Cells["Resim"].Value;

            if (seciliHucre != DBNull.Value)
            {
                byte[] resimVerisi = (byte[])seciliHucre;
                pbxAracResmi.Image = ByteToResim(resimVerisi); 
            }
            else
            {
                pbxAracResmi.Image = null; 
            }

          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvAraclar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek aracı seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dgvAraclar.SelectedRows[0].Cells["Id"].Value);

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Araclar SET Plaka=@p, Marka=@m, Model=@mo, Ucret=@u WHERE Id=@id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@p", txtPlaka.Text);
                        cmd.Parameters.AddWithValue("@m", txtMarka.Text);
                        cmd.Parameters.AddWithValue("@mo", txtModel.Text);
                        cmd.Parameters.AddWithValue("@u", numUcret.Value);
                        cmd.Parameters.AddWithValue("@id", seciliId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Araç bilgileri güncellendi!");
                    AraclariListele(); 
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                }
            }

        }

        void TumKiralamalariGetir()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

          
                string sql = @"
            SELECT 
                U.Username AS 'Kullanıcı Adı',
                U.AdSoyad AS 'Adı Soyadı',  
                U.Telefon AS 'Telefon',      
                U.Email AS 'E-Posta',
                U.Cinsiyet AS 'Cinsiyet',
                U.DogumTarihi AS 'Doğum Tarihi',
                A.Plaka AS 'Araç Plaka',
                A.Marka AS 'Marka/Model',
                K.AlisTarihi AS 'Alış',
                K.TeslimTarihi AS 'Teslim',
                K.ToplamUcret AS 'Tutar'
                
            FROM Kiralamalar K
            JOIN Users U ON K.KullaniciId = U.Id
            JOIN Araclar A ON K.AracId = A.Id
            ORDER BY K.Id DESC";

                using (var da = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTumGecmis.DataSource = dt;

                    dgvTumGecmis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        void GrafigiCiz()
        {
            chart1.Series.Clear();

            var seri = new System.Windows.Forms.DataVisualization.Charting.Series("Rental Counts");
            seri.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            seri.IsValueShownAsLabel = true;

            chart1.Series.Add(seri);

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT A.Marka, A.Model, COUNT(K.Id) as Sayi 
            FROM Kiralamalar K
            JOIN Araclar A ON K.AracId = A.Id
            GROUP BY A.Marka, A.Model";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string aracAdi = dr["Marka"].ToString() + " " + dr["Model"].ToString();
                            int sayi = Convert.ToInt32(dr["Sayi"]);

                            seri.Points.AddXY(aracAdi, sayi);
                        }
                    }
                }
            }
        }

        private void btnGrafikCiz_Click(object sender, EventArgs e)
        {
         
            GrafigiCiz();

            MessageBox.Show("Grafik güncellendi!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1; 
            TumKiralamalariGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2; 
        }

        /*private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }*/

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
        bool surukleniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
        private void dgvTumGecmis_MouseUp(object sender, MouseEventArgs e)
        {
            surukleniyor = false;
        }

        private void dgvTumGecmis_MouseMove(object sender, MouseEventArgs e)
        {
            surukleniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);

        }

        private void dgvTumGecmis_MouseDown(object sender, MouseEventArgs e)
        {
            surukleniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }
    }
    }



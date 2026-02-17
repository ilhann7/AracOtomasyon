using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracOtomasyon
{
    public partial class UserForm : Form
    {
        int girisYapanKullaniciId; 
        decimal seciliAracGunlukUcret = 0;
        public UserForm(int id)
        {
            InitializeComponent();
            girisYapanKullaniciId = id;
            AraclariListele();
            KullaniciBilgisiGetir();
            ModernGridTasarimi(dgvMusteriAraclar);
            GecmisimiListele(); 



        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            AraclariListele();

            dtpAlis.ValueChanged += TarihDegisti;
            dtpTeslim.ValueChanged += TarihDegisti;
        }
        void AraclariListele()
        {
            if (dgvMusteriAraclar == null) return;

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    
                    string sql = "SELECT * FROM Araclar WHERE Durum = 1";
                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvMusteriAraclar.RowTemplate.Height = 80;

                        dgvMusteriAraclar.DataSource = dt;
                        if (dgvMusteriAraclar.Columns.Contains("Durum")) 
                            dgvMusteriAraclar.Columns["Durum"].Visible = false;

                        if (dgvMusteriAraclar.Columns.Contains("Durum1"))
                            dgvMusteriAraclar.Columns["Durum1"].Visible = false;


                        for (int i = 0; i < dgvMusteriAraclar.Columns.Count; i++)
                        {
                            dgvMusteriAraclar.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }

                        if (dgvMusteriAraclar.Columns.Contains("Resim"))
                        {
                            var resimSutunu = dgvMusteriAraclar.Columns["Resim"] as DataGridViewImageColumn;
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
                    MessageBox.Show("Listeleme Hatası: " + ex.Message);
                }
            }
        }

        private void dgvMusteriAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var ucretDegeri = dgvMusteriAraclar.Rows[e.RowIndex].Cells["Ucret"].Value;
                if (ucretDegeri != null)
                {
                    seciliAracGunlukUcret = Convert.ToDecimal(ucretDegeri);
                    FiyatHesapla(); 
                }

                var resimDegeri = dgvMusteriAraclar.Rows[e.RowIndex].Cells["Resim"].Value;

                if (resimDegeri != null && resimDegeri != DBNull.Value)
                {
                    byte[] resimData = (byte[])resimDegeri;

                    using (MemoryStream ms = new MemoryStream(resimData))
                    {
                        pbxAracResim.Image = Image.FromStream(ms);
                        pbxAracResim.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pbxAracResim.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçim Hatası: " + ex.Message);
            }
        }

        void TarihDegisti(object sender, EventArgs e)
        {
            FiyatHesapla();
        }

        void FiyatHesapla()
        {
            if (seciliAracGunlukUcret == 0) return;

            DateTime alis = dtpAlis.Value.Date;
            DateTime teslim = dtpTeslim.Value.Date;

            
            if (teslim < alis)
            {
                lblToplamTutar.Text = "Hata: Tarihleri kontrol ediniz.";
                lblToplamTutar.ForeColor = Color.Red;
                return;
            }

            lblToplamTutar.ForeColor = Color.Black; 

            TimeSpan fark = teslim - alis;
            int gunSayisi = (int)fark.TotalDays;

            if (gunSayisi <= 0) gunSayisi = 1; 

            decimal toplam = gunSayisi * seciliAracGunlukUcret;

            
            lblToplamTutar.Text = "Total Price: " + toplam.ToString("C2");
        }

        private void btnKirala_Click(object sender, EventArgs e)
        {
            if (dgvMusteriAraclar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir araç seçin.");
                return;
            }

            int aracId = Convert.ToInt32(dgvMusteriAraclar.SelectedRows[0].Cells["Id"].Value);
            DateTime alis = dtpAlis.Value.Date;
            DateTime teslim = dtpTeslim.Value.Date;

            if (teslim < alis)
            {
                MessageBox.Show("Tarihleri kontrol ediniz.");
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                
                string checkSql = @"
                    SELECT COUNT(*) FROM Kiralamalar 
                    WHERE AracId = @aracId 
                    AND (
                        (@yeniAlis <= TeslimTarihi AND @yeniTeslim >= AlisTarihi)
                    )";

                using (var cmdCheck = new SQLiteCommand(checkSql, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@aracId", aracId);
                    cmdCheck.Parameters.AddWithValue("@yeniAlis", alis.ToString("yyyy-MM-dd"));
                    cmdCheck.Parameters.AddWithValue("@yeniTeslim", teslim.ToString("yyyy-MM-dd"));

                    int cakismaSayisi = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (cakismaSayisi > 0)
                    {
                        MessageBox.Show("Üzgünüz, seçtiğiniz tarihlerde bu araç dolu!");
                        return; 
                    }
                }

                TimeSpan fark = teslim - alis;
                int gun = (int)fark.TotalDays == 0 ? 1 : (int)fark.TotalDays;
                decimal toplamUcret = gun * seciliAracGunlukUcret;

                string insertSql = @"
                    INSERT INTO Kiralamalar (KullaniciId, AracId, AlisTarihi, TeslimTarihi, ToplamUcret)
                    VALUES (@uid, @aid, @alis, @teslim, @ucret)";

                using (var cmd = new SQLiteCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", girisYapanKullaniciId);
                    cmd.Parameters.AddWithValue("@aid", aracId);
                    cmd.Parameters.AddWithValue("@alis", alis.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@teslim", teslim.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ucret", toplamUcret);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Kiralama İşlemi Başarılı! İyi yolculuklar.");

                GecmisimiListele(); 
            }
        }
        void ModernGridTasarimi(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None; 
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); 
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; 
            dgv.DefaultCellStyle.SelectionBackColor = Color.SeaGreen; 
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White; 
           
            dgv.EnableHeadersVisualStyles = false; 
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; 
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72); 
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); 
            dgv.ColumnHeadersHeight = 35; 

            
            dgv.RowTemplate.Height = 80; 
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }
        void GecmisimiListele()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"
         SELECT 
             A.Marka, 
             A.Model, 
             A.Plaka, 
             K.AlisTarihi, 
             K.TeslimTarihi, 
             K.ToplamUcret 
         FROM Kiralamalar K
         INNER JOIN Araclar A ON K.AracId = A.Id
         WHERE K.KullaniciId = @id
         ORDER BY K.Id DESC";

                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", girisYapanKullaniciId);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvGecmis.DataSource = dt;

                        dgvGecmis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Geçmiş yüklenirken hata: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void KullaniciBilgisiGetir()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT AdSoyad FROM Users WHERE Id = @id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", girisYapanKullaniciId);

                        object sonuc = cmd.ExecuteScalar();

                        if (sonuc != null && sonuc != DBNull.Value)
                        {
                            lblHosgeldiniz.Text = "Welcome, " + sonuc.ToString();
                        }
                        else
                        {
                            lblHosgeldiniz.Text = "Welcome, Dear Customer";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblHosgeldiniz.Text = "Welcome";
                }
            }
        }

        private void dtpAlis_ValueChanged(object sender, EventArgs e)
        {
            FiyatHesapla();
        }

        private void dtpTeslim_ValueChanged(object sender, EventArgs e)
        {
            FiyatHesapla();

        }

        private void dgvMusteriAraclar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void dgvMusteriAraclar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) //buraya bazı eklemeler yaptım.
        {
            
            if (dgvMusteriAraclar.Columns[e.ColumnIndex].Name == "Resim" && e.Value != null)
            {
                if (e.Value != DBNull.Value)
                {
                    try
                    {
                        
                        byte[] resimData = (byte[])e.Value;

                        
                        using (MemoryStream ms = new MemoryStream(resimData))
                        {
                            e.Value = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        // 
                    }
                }
            }
        }
        bool surukleniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
        private void UserForm_MouseDown(object sender, MouseEventArgs e)
        {
            surukleniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void UserForm_MouseUp(object sender, MouseEventArgs e)
        {
            surukleniyor = false;

        }

        private void UserForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukleniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - baslangicNoktasi.X, p.Y - baslangicNoktasi.Y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
   
}


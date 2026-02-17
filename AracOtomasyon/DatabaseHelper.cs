using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AracOtomasyon
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AracOtomasyon.db");
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

              
                string sqlUser = @"
    CREATE TABLE IF NOT EXISTS Users (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Username TEXT UNIQUE NOT NULL,
        Password TEXT NOT NULL,
        Role TEXT DEFAULT 'User',
        Telefon TEXT,
        Email TEXT,
        DogumTarihi TEXT
    );";
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE Users ADD COLUMN AdSoyad TEXT", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch {
                }
         
                
                    using (var cmd = new SQLiteCommand(sqlUser, conn)) cmd.ExecuteNonQuery();

                string sqlArac = @"
                CREATE TABLE IF NOT EXISTS Araclar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Plaka TEXT UNIQUE NOT NULL,
                    Marka TEXT NOT NULL,
                    Model TEXT NOT NULL,
                    Ucret DECIMAL,
                    Durum TEXT DEFAULT 'Musait',
                    Resim BLOB
                );";
                using (var cmd = new SQLiteCommand(sqlArac, conn)) cmd.ExecuteNonQuery();

                string sqlKira = @"
                CREATE TABLE IF NOT EXISTS Kiralamalar (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    KullaniciId INTEGER,
                    AracId INTEGER,
                    AlisTarihi TEXT,
                    TeslimTarihi TEXT,
                    ToplamUcret DECIMAL,
                    FOREIGN KEY(KullaniciId) REFERENCES Users(Id),
                    FOREIGN KEY(AracId) REFERENCES Araclar(Id)
                );";
                using (var cmd = new SQLiteCommand(sqlKira, conn)) cmd.ExecuteNonQuery();


                string adminCheck = "SELECT COUNT(*) FROM Users";
                using (var cmdCheck = new SQLiteCommand(adminCheck, conn))
                {
                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (count == 0)
                    {
                        string sqlAdmin = "INSERT INTO Users (Username, Password, Role) VALUES ('admin', '1234', 'Admin')";
                        using (var cmdInsert = new SQLiteCommand(sqlAdmin, conn)) cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}

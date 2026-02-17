namespace AracOtomasyon
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKirala = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.lblHosgeldiniz = new System.Windows.Forms.Label();
            this.pbxAracResim = new System.Windows.Forms.PictureBox();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.dtpTeslim = new System.Windows.Forms.DateTimePicker();
            this.dtpAlis = new System.Windows.Forms.DateTimePicker();
            this.dgvMusteriAraclar = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvGecmis = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAracResim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriAraclar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(170, -22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1299, 836);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseDown);
            this.tabControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseMove);
            this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnKirala);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblMesaj);
            this.tabPage1.Controls.Add(this.lblHosgeldiniz);
            this.tabPage1.Controls.Add(this.pbxAracResim);
            this.tabPage1.Controls.Add(this.lblToplamTutar);
            this.tabPage1.Controls.Add(this.dtpTeslim);
            this.tabPage1.Controls.Add(this.dtpAlis);
            this.tabPage1.Controls.Add(this.dgvMusteriAraclar);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1291, 810);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rent A Car";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseDown);
            this.tabPage1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseMove);
            this.tabPage1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(27, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Return Date :";
            // 
            // btnKirala
            // 
            this.btnKirala.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKirala.FlatAppearance.BorderSize = 0;
            this.btnKirala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKirala.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKirala.ForeColor = System.Drawing.Color.Maroon;
            this.btnKirala.ImageList = this.ımageList1;
            this.btnKirala.Location = new System.Drawing.Point(1138, 177);
            this.btnKirala.Name = "btnKirala";
            this.btnKirala.Size = new System.Drawing.Size(78, 45);
            this.btnKirala.TabIndex = 4;
            this.btnKirala.Text = "RENT";
            this.btnKirala.UseVisualStyleBackColor = false;
            this.btnKirala.Click += new System.EventHandler(this.btnKirala_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Rent-A-Space-CT_Rent-Online-Button_1.png");
            this.ımageList1.Images.SetKeyName(1, "5.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(27, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pick-up Date :";
            // 
            // lblMesaj
            // 
            this.lblMesaj.AutoSize = true;
            this.lblMesaj.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMesaj.ForeColor = System.Drawing.Color.DimGray;
            this.lblMesaj.Location = new System.Drawing.Point(646, 88);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(232, 25);
            this.lblMesaj.TabIndex = 8;
            this.lblMesaj.Text = "Thank you for choosing us.";
            // 
            // lblHosgeldiniz
            // 
            this.lblHosgeldiniz.AutoSize = true;
            this.lblHosgeldiniz.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHosgeldiniz.ForeColor = System.Drawing.Color.Teal;
            this.lblHosgeldiniz.Location = new System.Drawing.Point(646, 52);
            this.lblHosgeldiniz.Name = "lblHosgeldiniz";
            this.lblHosgeldiniz.Size = new System.Drawing.Size(122, 29);
            this.lblHosgeldiniz.TabIndex = 7;
            this.lblHosgeldiniz.Text = "Welcome";
            // 
            // pbxAracResim
            // 
            this.pbxAracResim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxAracResim.Location = new System.Drawing.Point(1049, 12);
            this.pbxAracResim.Name = "pbxAracResim";
            this.pbxAracResim.Size = new System.Drawing.Size(167, 159);
            this.pbxAracResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAracResim.TabIndex = 5;
            this.pbxAracResim.TabStop = false;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamTutar.Location = new System.Drawing.Point(189, 53);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(168, 24);
            this.lblToplamTutar.TabIndex = 3;
            this.lblToplamTutar.Text = "Total Price: 0 TL";
            // 
            // dtpTeslim
            // 
            this.dtpTeslim.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTeslim.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTeslim.Location = new System.Drawing.Point(192, 151);
            this.dtpTeslim.Name = "dtpTeslim";
            this.dtpTeslim.Size = new System.Drawing.Size(252, 24);
            this.dtpTeslim.TabIndex = 2;
            this.dtpTeslim.ValueChanged += new System.EventHandler(this.dtpTeslim_ValueChanged);
            // 
            // dtpAlis
            // 
            this.dtpAlis.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpAlis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpAlis.Location = new System.Drawing.Point(192, 89);
            this.dtpAlis.Name = "dtpAlis";
            this.dtpAlis.Size = new System.Drawing.Size(252, 24);
            this.dtpAlis.TabIndex = 1;
            this.dtpAlis.ValueChanged += new System.EventHandler(this.dtpAlis_ValueChanged);
            // 
            // dgvMusteriAraclar
            // 
            this.dgvMusteriAraclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusteriAraclar.GridColor = System.Drawing.Color.Teal;
            this.dgvMusteriAraclar.Location = new System.Drawing.Point(21, 228);
            this.dgvMusteriAraclar.Name = "dgvMusteriAraclar";
            this.dgvMusteriAraclar.ReadOnly = true;
            this.dgvMusteriAraclar.Size = new System.Drawing.Size(1232, 574);
            this.dgvMusteriAraclar.TabIndex = 0;
            this.dgvMusteriAraclar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusteriAraclar_CellClick);
            this.dgvMusteriAraclar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusteriAraclar_CellContentClick);
            this.dgvMusteriAraclar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMusteriAraclar_CellFormatting);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvGecmis);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1291, 810);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvGecmis
            // 
            this.dgvGecmis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGecmis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGecmis.Location = new System.Drawing.Point(3, 3);
            this.dgvGecmis.Name = "dgvGecmis";
            this.dgvGecmis.ReadOnly = true;
            this.dgvGecmis.Size = new System.Drawing.Size(1285, 804);
            this.dgvGecmis.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.ImageKey = "5.png";
            this.button1.Location = new System.Drawing.Point(0, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 66);
            this.button1.TabIndex = 6;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 814);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.DarkRed;
            this.button3.Location = new System.Drawing.Point(0, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 69);
            this.button3.TabIndex = 8;
            this.button3.Text = "Car\'s Rent";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(0, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 69);
            this.button2.TabIndex = 7;
            this.button2.Text = "Rent Screen";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 814);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserForm_MouseUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAracResim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriAraclar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvMusteriAraclar;
        private System.Windows.Forms.Button btnKirala;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.DateTimePicker dtpTeslim;
        private System.Windows.Forms.DateTimePicker dtpAlis;
        private System.Windows.Forms.PictureBox pbxAracResim;
        private System.Windows.Forms.DataGridView dgvGecmis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMesaj;
        private System.Windows.Forms.Label lblHosgeldiniz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
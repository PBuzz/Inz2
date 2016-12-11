namespace Inz
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wspołrzędneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kątyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.długościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tachimetrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.azymutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.database1DataSet = new Inz.Database1DataSet();
            this.tachimetrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tachimetrTableAdapter = new Inz.Database1DataSetTableAdapters.TachimetrTableAdapter();
            this.rinexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachimetrBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.wspołrzędneToolStripMenuItem,
            this.kątyToolStripMenuItem,
            this.długościToolStripMenuItem,
            this.tachimetrToolStripMenuItem,
            this.testToolStripMenuItem,
            this.azymutToolStripMenuItem,
            this.test2ToolStripMenuItem,
            this.rinexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1066, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.ustawieniaToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // wspołrzędneToolStripMenuItem
            // 
            this.wspołrzędneToolStripMenuItem.Name = "wspołrzędneToolStripMenuItem";
            this.wspołrzędneToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.wspołrzędneToolStripMenuItem.Text = "Wspołrzędne";
            this.wspołrzędneToolStripMenuItem.Click += new System.EventHandler(this.wspołrzędneToolStripMenuItem_Click);
            // 
            // kątyToolStripMenuItem
            // 
            this.kątyToolStripMenuItem.Name = "kątyToolStripMenuItem";
            this.kątyToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.kątyToolStripMenuItem.Text = "Kąty";
            this.kątyToolStripMenuItem.Visible = false;
            this.kątyToolStripMenuItem.Click += new System.EventHandler(this.kątyToolStripMenuItem_Click);
            // 
            // długościToolStripMenuItem
            // 
            this.długościToolStripMenuItem.Name = "długościToolStripMenuItem";
            this.długościToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.długościToolStripMenuItem.Text = "Długości";
            this.długościToolStripMenuItem.Visible = false;
            this.długościToolStripMenuItem.Click += new System.EventHandler(this.długościToolStripMenuItem_Click);
            // 
            // tachimetrToolStripMenuItem
            // 
            this.tachimetrToolStripMenuItem.Name = "tachimetrToolStripMenuItem";
            this.tachimetrToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.tachimetrToolStripMenuItem.Text = "Tachimetr";
            this.tachimetrToolStripMenuItem.Click += new System.EventHandler(this.tachimetrToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.testToolStripMenuItem.Text = "Wyrównanie";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // azymutToolStripMenuItem
            // 
            this.azymutToolStripMenuItem.Name = "azymutToolStripMenuItem";
            this.azymutToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.azymutToolStripMenuItem.Text = "Wektory GPS";
            this.azymutToolStripMenuItem.Click += new System.EventHandler(this.azymutToolStripMenuItem_Click);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.test2ToolStripMenuItem.Text = "Test2";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 636);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1066, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tachimetrBindingSource
            // 
            this.tachimetrBindingSource.DataMember = "Tachimetr";
            this.tachimetrBindingSource.DataSource = this.database1DataSet;
            // 
            // tachimetrTableAdapter
            // 
            this.tachimetrTableAdapter.ClearBeforeFill = true;
            // 
            // rinexToolStripMenuItem
            // 
            this.rinexToolStripMenuItem.Name = "rinexToolStripMenuItem";
            this.rinexToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rinexToolStripMenuItem.Text = "Rinex";
            this.rinexToolStripMenuItem.Click += new System.EventHandler(this.rinexToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1066, 658);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Inz";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachimetrBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wspołrzędneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kątyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem długościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tachimetrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource tachimetrBindingSource;
        private Database1DataSetTableAdapters.TachimetrTableAdapter tachimetrTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem azymutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rinexToolStripMenuItem;
    }
}


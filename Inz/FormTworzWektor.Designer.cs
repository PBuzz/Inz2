namespace Inz
{
    partial class FormTworzWektor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Baza = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Rover = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Czas_trwania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rinexTableAdapter = new Inz.Database1DataSetTableAdapters.RinexTableAdapter();
            this.database1DataSet = new Inz.Database1DataSet();
            this.wektoryTableAdapter = new Inz.Database1DataSetTableAdapters.WektoryTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Baza,
            this.Rover,
            this.Czas_trwania});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(2, 24);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(551, 324);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // Baza
            // 
            this.Baza.HeaderText = "Baza";
            this.Baza.Name = "Baza";
            this.Baza.Width = 200;
            // 
            // Rover
            // 
            this.Rover.HeaderText = "Rover";
            this.Rover.Name = "Rover";
            this.Rover.Width = 200;
            // 
            // Czas_trwania
            // 
            this.Czas_trwania.HeaderText = "Czas trwania";
            this.Czas_trwania.Name = "Czas_trwania";
            this.Czas_trwania.ReadOnly = true;
            this.Czas_trwania.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Czas_trwania.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stwórzToolStripMenuItem,
            this.ustawieniaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(558, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stwórzToolStripMenuItem
            // 
            this.stwórzToolStripMenuItem.Name = "stwórzToolStripMenuItem";
            this.stwórzToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.stwórzToolStripMenuItem.Text = "Stwórz";
            this.stwórzToolStripMenuItem.Click += new System.EventHandler(this.stwórzToolStripMenuItem_Click);
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // rinexTableAdapter
            // 
            this.rinexTableAdapter.ClearBeforeFill = true;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wektoryTableAdapter
            // 
            this.wektoryTableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTworzWektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 350);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormTworzWektor";
            this.Text = "FormTworzWektor";
            this.Load += new System.EventHandler(this.FormTworzWektor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private Database1DataSetTableAdapters.RinexTableAdapter rinexTableAdapter;
        private Database1DataSet database1DataSet;
        private Database1DataSetTableAdapters.WektoryTableAdapter wektoryTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn Baza;
        private System.Windows.Forms.DataGridViewComboBoxColumn Rover;
        private System.Windows.Forms.DataGridViewTextBoxColumn Czas_trwania;
        private System.Windows.Forms.Timer timer1;
    }
}
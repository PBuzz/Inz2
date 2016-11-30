namespace Inz
{
    partial class FormDodajBLH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Staly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wspolrzedneTableAdapter1 = new Inz.Database1DataSetTableAdapters.WspolrzedneTableAdapter();
            this.wspolrzedneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new Inz.Database1DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.B,
            this.L,
            this.H,
            this.Staly,
            this.X,
            this.Y,
            this.Z});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(859, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // Nazwa
            // 
            this.Nazwa.Frozen = true;
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            // 
            // B
            // 
            dataGridViewCellStyle13.Format = "N3";
            this.B.DefaultCellStyle = dataGridViewCellStyle13;
            this.B.Frozen = true;
            this.B.HeaderText = "B";
            this.B.Name = "B";
            // 
            // L
            // 
            dataGridViewCellStyle14.Format = "N3";
            this.L.DefaultCellStyle = dataGridViewCellStyle14;
            this.L.Frozen = true;
            this.L.HeaderText = "L";
            this.L.Name = "L";
            // 
            // H
            // 
            dataGridViewCellStyle15.Format = "N3";
            this.H.DefaultCellStyle = dataGridViewCellStyle15;
            this.H.Frozen = true;
            this.H.HeaderText = "H";
            this.H.Name = "H";
            // 
            // Staly
            // 
            this.Staly.Frozen = true;
            this.Staly.HeaderText = "Stały";
            this.Staly.Name = "Staly";
            // 
            // X
            // 
            dataGridViewCellStyle16.Format = "N3";
            this.X.DefaultCellStyle = dataGridViewCellStyle16;
            this.X.Frozen = true;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            dataGridViewCellStyle17.Format = "N3";
            this.Y.DefaultCellStyle = dataGridViewCellStyle17;
            this.Y.Frozen = true;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Z
            // 
            dataGridViewCellStyle18.Format = "N3";
            this.Z.DefaultCellStyle = dataGridViewCellStyle18;
            this.Z.Frozen = true;
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wspolrzedneTableAdapter1
            // 
            this.wspolrzedneTableAdapter1.ClearBeforeFill = true;
            // 
            // wspolrzedneBindingSource
            // 
            this.wspolrzedneBindingSource.DataMember = "Wspolrzedne";
            this.wspolrzedneBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormDodajBLH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 366);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDodajBLH";
            this.Text = "FormDodajBLH";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDodajBLH_FormClosing);
            this.Load += new System.EventHandler(this.FormDodajBLH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Staly;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.Timer timer1;
        private Database1DataSetTableAdapters.WspolrzedneTableAdapter wspolrzedneTableAdapter1;
        private System.Windows.Forms.BindingSource wspolrzedneBindingSource;
        private Database1DataSet database1DataSet;
    }
}
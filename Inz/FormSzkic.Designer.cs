namespace Inz
{
    partial class FormSzkic
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.punktyNieznaneTableAdapter = new Inz.Database1DataSetTableAdapters.PunktyNieznaneTableAdapter();
            this.database1DataSet1 = new Inz.Database1DataSet();
            this.tachimetrTableAdapter = new Inz.Database1DataSetTableAdapters.TachimetrTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Skalax = new System.Windows.Forms.ToolStripStatusLabel();
            this.MousePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // punktyNieznaneTableAdapter
            // 
            this.punktyNieznaneTableAdapter.ClearBeforeFill = true;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tachimetrTableAdapter
            // 
            this.tachimetrTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Skalax,
            this.MousePosition});
            this.statusStrip1.Location = new System.Drawing.Point(0, 621);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1083, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Skalax
            // 
            this.Skalax.Name = "Skalax";
            this.Skalax.Size = new System.Drawing.Size(118, 17);
            this.Skalax.Text = "toolStripStatusLabel1";
            // 
            // MousePosition
            // 
            this.MousePosition.Name = "MousePosition";
            this.MousePosition.Size = new System.Drawing.Size(118, 17);
            this.MousePosition.Text = "toolStripStatusLabel1";
            // 
            // pBox
            // 
            this.pBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox.Location = new System.Drawing.Point(191, 12);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(880, 606);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox.TabIndex = 1;
            this.pBox.TabStop = false;
            this.pBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pBox_Paint);
            this.pBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBox_MouseMove);
            this.pBox.Move += new System.EventHandler(this.pBox_Move);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(0, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(185, 606);
            this.dataGridView1.TabIndex = 2;
            // 
            // Nazwa
            // 
            this.Nazwa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            this.Nazwa.Width = 65;
            // 
            // X
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.X.DefaultCellStyle = dataGridViewCellStyle1;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Y.DefaultCellStyle = dataGridViewCellStyle2;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // FormSzkic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 643);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormSzkic";
            this.Text = "Szkicownik";
            this.Load += new System.EventHandler(this.FormSzkic_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSzkic_Paint);
            this.Resize += new System.EventHandler(this.FormSzkic_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Database1DataSetTableAdapters.PunktyNieznaneTableAdapter punktyNieznaneTableAdapter;
        private Database1DataSet database1DataSet1;
        private Database1DataSetTableAdapters.TachimetrTableAdapter tachimetrTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Skalax;
        private System.Windows.Forms.ToolStripStatusLabel MousePosition;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
    }
}
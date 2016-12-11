namespace Inz
{
    partial class FormWczytajWektor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWczytajWektor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.wektoryBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.wektoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new Inz.Database1DataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wektoryBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.wektoryDataGridView = new System.Windows.Forms.DataGridView();
            this.wczytaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdyz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdzx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wczytane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.niewczytane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.wektoryTableAdapter = new Inz.Database1DataSetTableAdapters.WektoryTableAdapter();
            this.tableAdapterManager = new Inz.Database1DataSetTableAdapters.TableAdapterManager();
            this.button2 = new System.Windows.Forms.Button();
            this.rinexTableAdapter1 = new Inz.Database1DataSetTableAdapters.RinexTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.wektoryBindingNavigator)).BeginInit();
            this.wektoryBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wektoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wektoryDataGridView)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wczytaj wektory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Wczytywanie wektorów";
            // 
            // wektoryBindingNavigator
            // 
            this.wektoryBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wektoryBindingNavigator.BindingSource = this.wektoryBindingSource;
            this.wektoryBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wektoryBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.wektoryBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.wektoryBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.wektoryBindingNavigatorSaveItem,
            this.toolStripButton1,
            this.toolStripButton2});
            this.wektoryBindingNavigator.Location = new System.Drawing.Point(3, 0);
            this.wektoryBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wektoryBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wektoryBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wektoryBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wektoryBindingNavigator.Name = "wektoryBindingNavigator";
            this.wektoryBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wektoryBindingNavigator.Size = new System.Drawing.Size(318, 25);
            this.wektoryBindingNavigator.TabIndex = 2;
            this.wektoryBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Dodaj nowy";
            // 
            // wektoryBindingSource
            // 
            this.wektoryBindingSource.DataMember = "Wektory";
            this.wektoryBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Suma elementów";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Usuń";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Przenieś pierwszy";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Przenieś poprzedni";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Pozycja";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Bieżąca pozycja";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Przenieś następny";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Przenieś ostatni";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // wektoryBindingNavigatorSaveItem
            // 
            this.wektoryBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wektoryBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wektoryBindingNavigatorSaveItem.Image")));
            this.wektoryBindingNavigatorSaveItem.Name = "wektoryBindingNavigatorSaveItem";
            this.wektoryBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.wektoryBindingNavigatorSaveItem.Text = "Zapisz dane";
            this.wektoryBindingNavigatorSaveItem.Click += new System.EventHandler(this.wektoryBindingNavigatorSaveItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // wektoryDataGridView
            // 
            this.wektoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wektoryDataGridView.AutoGenerateColumns = false;
            this.wektoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wektoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wczytaj,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.DX,
            this.DY,
            this.DZ,
            this.sdx,
            this.sdy,
            this.sdz,
            this.sdxy,
            this.sdyz,
            this.sdzx,
            this.ratio,
            this.wczytane,
            this.niewczytane});
            this.wektoryDataGridView.DataSource = this.wektoryBindingSource;
            this.wektoryDataGridView.Location = new System.Drawing.Point(3, 28);
            this.wektoryDataGridView.Name = "wektoryDataGridView";
            this.wektoryDataGridView.Size = new System.Drawing.Size(986, 333);
            this.wektoryDataGridView.TabIndex = 2;
            this.wektoryDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.wektoryDataGridView_CellContentClick);
            // 
            // wczytaj
            // 
            this.wczytaj.DataPropertyName = "Wczytaj";
            this.wczytaj.HeaderText = "Wczytaj";
            this.wczytaj.Name = "wczytaj";
            this.wczytaj.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.wczytaj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "poczatek";
            this.dataGridViewTextBoxColumn2.HeaderText = "poczatek";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "koniec";
            this.dataGridViewTextBoxColumn3.HeaderText = "koniec";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // DX
            // 
            this.DX.DataPropertyName = "DX";
            dataGridViewCellStyle1.Format = "N3";
            this.DX.DefaultCellStyle = dataGridViewCellStyle1;
            this.DX.HeaderText = "DX";
            this.DX.Name = "DX";
            // 
            // DY
            // 
            this.DY.DataPropertyName = "DY";
            dataGridViewCellStyle2.Format = "N3";
            this.DY.DefaultCellStyle = dataGridViewCellStyle2;
            this.DY.HeaderText = "DY";
            this.DY.Name = "DY";
            // 
            // DZ
            // 
            this.DZ.DataPropertyName = "DZ";
            dataGridViewCellStyle3.Format = "N3";
            this.DZ.DefaultCellStyle = dataGridViewCellStyle3;
            this.DZ.HeaderText = "DZ";
            this.DZ.Name = "DZ";
            // 
            // sdx
            // 
            this.sdx.DataPropertyName = "sdx";
            this.sdx.HeaderText = "sdx";
            this.sdx.Name = "sdx";
            // 
            // sdy
            // 
            this.sdy.DataPropertyName = "sdy";
            this.sdy.HeaderText = "sdy";
            this.sdy.Name = "sdy";
            // 
            // sdz
            // 
            this.sdz.DataPropertyName = "sdz";
            this.sdz.HeaderText = "sdz";
            this.sdz.Name = "sdz";
            // 
            // sdxy
            // 
            this.sdxy.DataPropertyName = "sdxy";
            this.sdxy.HeaderText = "sdxy";
            this.sdxy.Name = "sdxy";
            // 
            // sdyz
            // 
            this.sdyz.DataPropertyName = "sdyz";
            this.sdyz.HeaderText = "sdyz";
            this.sdyz.Name = "sdyz";
            // 
            // sdzx
            // 
            this.sdzx.DataPropertyName = "sdzx";
            this.sdzx.HeaderText = "sdzx";
            this.sdzx.Name = "sdzx";
            // 
            // ratio
            // 
            this.ratio.DataPropertyName = "ratio";
            this.ratio.HeaderText = "ratio";
            this.ratio.Name = "ratio";
            // 
            // wczytane
            // 
            this.wczytane.DataPropertyName = "wczytane";
            this.wczytane.HeaderText = "Wczytane";
            this.wczytane.Name = "wczytane";
            this.wczytane.ToolTipText = "Liczba wczytanych epok";
            // 
            // niewczytane
            // 
            this.niewczytane.DataPropertyName = "niewczytane";
            this.niewczytane.HeaderText = "Pominięte";
            this.niewczytane.Name = "niewczytane";
            this.niewczytane.ToolTipText = "Liczba epok pominiętych";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.wektoryBindingNavigator);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.wektoryDataGridView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(992, 374);
            this.toolStripContainer1.Location = new System.Drawing.Point(12, 53);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(992, 399);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // wektoryTableAdapter
            // 
            this.wektoryTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DlugosciTableAdapter = null;
            this.tableAdapterManager.KatyTableAdapter = null;
            this.tableAdapterManager.PunktyNieznaneTableAdapter = null;
            this.tableAdapterManager.RinexTableAdapter = null;
            this.tableAdapterManager.TachimetrTableAdapter = null;
            this.tableAdapterManager.TransformacjaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Inz.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.Wektory2TableAdapter = null;
            this.tableAdapterManager.WektoryTableAdapter = this.wektoryTableAdapter;
            this.tableAdapterManager.WspolrzedneTableAdapter = null;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rinexTableAdapter1
            // 
            this.rinexTableAdapter1.ClearBeforeFill = true;
            // 
            // FormWczytajWektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 464);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "FormWczytajWektor";
            this.Text = "FormWczytajWektor";
            this.Load += new System.EventHandler(this.FormWczytajWektor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wektoryBindingNavigator)).EndInit();
            this.wektoryBindingNavigator.ResumeLayout(false);
            this.wektoryBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wektoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wektoryDataGridView)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource wektoryBindingSource;
        private Database1DataSetTableAdapters.WektoryTableAdapter wektoryTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator wektoryBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton wektoryBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView wektoryDataGridView;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridViewButtonColumn wczytaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdx;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdy;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdz;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdyz;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdzx;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratio;
        private System.Windows.Forms.DataGridViewTextBoxColumn wczytane;
        private System.Windows.Forms.DataGridViewTextBoxColumn niewczytane;
        private System.Windows.Forms.Button button2;
        private Database1DataSetTableAdapters.RinexTableAdapter rinexTableAdapter1;
    }
}
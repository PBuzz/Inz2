namespace Inz
{
    partial class FormWspolrzedne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWspolrzedne));
            this.wspolrzedneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new Inz.Database1DataSet();
            this.wspolrzedneTableAdapter = new Inz.Database1DataSetTableAdapters.WspolrzedneTableAdapter();
            this.tableAdapterManager = new Inz.Database1DataSetTableAdapters.TableAdapterManager();
            this.wspolrzedneDataGridView = new System.Windows.Forms.DataGridView();
            this.KolumnaNazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KolumnaX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KolumnaY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KolumnaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Staly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.wspolrzedneBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.wspolrzedneBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.menuStripwspolrzedne = new System.Windows.Forms.MenuStrip();
            this.dodajBLHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneBindingNavigator)).BeginInit();
            this.wspolrzedneBindingNavigator.SuspendLayout();
            this.menuStripwspolrzedne.SuspendLayout();
            this.SuspendLayout();
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
            // wspolrzedneTableAdapter
            // 
            this.wspolrzedneTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DlugosciTableAdapter = null;
            this.tableAdapterManager.KatyTableAdapter = null;
            this.tableAdapterManager.PunktyNieznaneTableAdapter = null;
            this.tableAdapterManager.TachimetrTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Inz.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WektoryTableAdapter = null;
            this.tableAdapterManager.WspolrzedneTableAdapter = this.wspolrzedneTableAdapter;
            // 
            // wspolrzedneDataGridView
            // 
            this.wspolrzedneDataGridView.AutoGenerateColumns = false;
            this.wspolrzedneDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wspolrzedneDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KolumnaNazwa,
            this.KolumnaX,
            this.KolumnaY,
            this.KolumnaH,
            this.Staly});
            this.wspolrzedneDataGridView.DataSource = this.wspolrzedneBindingSource;
            this.wspolrzedneDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wspolrzedneDataGridView.Location = new System.Drawing.Point(0, 49);
            this.wspolrzedneDataGridView.Name = "wspolrzedneDataGridView";
            this.wspolrzedneDataGridView.Size = new System.Drawing.Size(549, 391);
            this.wspolrzedneDataGridView.TabIndex = 1;
            this.wspolrzedneDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.wspolrzedneDataGridView_DataError);
            // 
            // KolumnaNazwa
            // 
            this.KolumnaNazwa.DataPropertyName = "Nazwa";
            this.KolumnaNazwa.HeaderText = "Nazwa";
            this.KolumnaNazwa.Name = "KolumnaNazwa";
            // 
            // KolumnaX
            // 
            this.KolumnaX.DataPropertyName = "X";
            this.KolumnaX.HeaderText = "X";
            this.KolumnaX.Name = "KolumnaX";
            // 
            // KolumnaY
            // 
            this.KolumnaY.DataPropertyName = "Y";
            this.KolumnaY.HeaderText = "Y";
            this.KolumnaY.Name = "KolumnaY";
            // 
            // KolumnaH
            // 
            this.KolumnaH.DataPropertyName = "H";
            this.KolumnaH.HeaderText = "H";
            this.KolumnaH.Name = "KolumnaH";
            // 
            // Staly
            // 
            this.Staly.DataPropertyName = "Staly";
            this.Staly.HeaderText = "Stały";
            this.Staly.Name = "Staly";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Suma elementów";
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
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Dodaj nowy";
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
            // wspolrzedneBindingNavigatorSaveItem
            // 
            this.wspolrzedneBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wspolrzedneBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wspolrzedneBindingNavigatorSaveItem.Image")));
            this.wspolrzedneBindingNavigatorSaveItem.Name = "wspolrzedneBindingNavigatorSaveItem";
            this.wspolrzedneBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.wspolrzedneBindingNavigatorSaveItem.Text = "Zapisz dane";
            this.wspolrzedneBindingNavigatorSaveItem.Click += new System.EventHandler(this.wspolrzedneBindingNavigatorSaveItem_Click);
            // 
            // wspolrzedneBindingNavigator
            // 
            this.wspolrzedneBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wspolrzedneBindingNavigator.BindingSource = this.wspolrzedneBindingSource;
            this.wspolrzedneBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wspolrzedneBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.wspolrzedneBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.wspolrzedneBindingNavigatorSaveItem});
            this.wspolrzedneBindingNavigator.Location = new System.Drawing.Point(0, 24);
            this.wspolrzedneBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wspolrzedneBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wspolrzedneBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wspolrzedneBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wspolrzedneBindingNavigator.Name = "wspolrzedneBindingNavigator";
            this.wspolrzedneBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wspolrzedneBindingNavigator.Size = new System.Drawing.Size(549, 25);
            this.wspolrzedneBindingNavigator.TabIndex = 0;
            this.wspolrzedneBindingNavigator.Text = "bindingNavigator1";
            // 
            // menuStripwspolrzedne
            // 
            this.menuStripwspolrzedne.AllowMerge = false;
            this.menuStripwspolrzedne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajBLHToolStripMenuItem});
            this.menuStripwspolrzedne.Location = new System.Drawing.Point(0, 0);
            this.menuStripwspolrzedne.Name = "menuStripwspolrzedne";
            this.menuStripwspolrzedne.Size = new System.Drawing.Size(549, 24);
            this.menuStripwspolrzedne.TabIndex = 2;
            this.menuStripwspolrzedne.Text = "menuStrip1";
            // 
            // dodajBLHToolStripMenuItem
            // 
            this.dodajBLHToolStripMenuItem.Name = "dodajBLHToolStripMenuItem";
            this.dodajBLHToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.dodajBLHToolStripMenuItem.Text = "Dodaj BLH";
            this.dodajBLHToolStripMenuItem.Click += new System.EventHandler(this.dodajBLHToolStripMenuItem_Click);
            // 
            // FormWspolrzedne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 440);
            this.Controls.Add(this.wspolrzedneDataGridView);
            this.Controls.Add(this.wspolrzedneBindingNavigator);
            this.Controls.Add(this.menuStripwspolrzedne);
            this.MainMenuStrip = this.menuStripwspolrzedne;
            this.Name = "FormWspolrzedne";
            this.Text = "FormWspolrzedne";
            this.Load += new System.EventHandler(this.FormWspolrzedne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wspolrzedneBindingNavigator)).EndInit();
            this.wspolrzedneBindingNavigator.ResumeLayout(false);
            this.wspolrzedneBindingNavigator.PerformLayout();
            this.menuStripwspolrzedne.ResumeLayout(false);
            this.menuStripwspolrzedne.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource wspolrzedneBindingSource;
        private Database1DataSetTableAdapters.WspolrzedneTableAdapter wspolrzedneTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView wspolrzedneDataGridView;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton wspolrzedneBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator wspolrzedneBindingNavigator;
        private System.Windows.Forms.DataGridViewTextBoxColumn KolumnaNazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn KolumnaX;
        private System.Windows.Forms.DataGridViewTextBoxColumn KolumnaY;
        private System.Windows.Forms.DataGridViewTextBoxColumn KolumnaH;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Staly;
        private System.Windows.Forms.MenuStrip menuStripwspolrzedne;
        private System.Windows.Forms.ToolStripMenuItem dodajBLHToolStripMenuItem;
    }
}
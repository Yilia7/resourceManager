namespace gaoyaxin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("硬盘", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("移动存储", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("其他", System.Windows.Forms.HorizontalAlignment.Left);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_refresh = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.combo_url = new System.Windows.Forms.ComboBox();
            this.btn_next = new System.Windows.Forms.PictureBox();
            this.btn_pre = new System.Windows.Forms.PictureBox();
            this.btn_search = new System.Windows.Forms.PictureBox();
            this.text_search = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.大图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.详细列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.详细大图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_objnum = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_searching = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ch_name = new System.Windows.Forms.ColumnHeader();
            this.ch_type = new System.Windows.Forms.ColumnHeader();
            this.ch_total = new System.Windows.Forms.ColumnHeader();
            this.ch_avail = new System.Windows.Forms.ColumnHeader();
            this.imgList2 = new System.Windows.Forms.ImageList(this.components);
            this.imgList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenu_lv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.item_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.item_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.item_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.item_rename = new System.Windows.Forms.ToolStripMenuItem();
            this.item_new = new System.Windows.Forms.ToolStripMenuItem();
            this.item_newfolder = new System.Windows.Forms.ToolStripMenuItem();
            this.item_newtxt = new System.Windows.Forms.ToolStripMenuItem();
            this.item_newword = new System.Windows.Forms.ToolStripMenuItem();
            this.item_newexcel = new System.Windows.Forms.ToolStripMenuItem();
            this.item_newppt = new System.Windows.Forms.ToolStripMenuItem();
            this.item_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.item_attr = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu_lv2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.item_open = new System.Windows.Forms.ToolStripMenuItem();
            this.item_refresh2 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_revert = new System.Windows.Forms.ToolStripMenuItem();
            this.item_empty = new System.Windows.Forms.ToolStripMenuItem();
            this.item_del = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenu_lv.SuspendLayout();
            this.contextMenu_lv2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_refresh);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.combo_url);
            this.splitContainer1.Panel1.Controls.Add(this.btn_next);
            this.splitContainer1.Panel1.Controls.Add(this.btn_pre);
            this.splitContainer1.Panel1.SizeChanged += new System.EventHandler(this.splitContainer1_Panel1_SizeChanged);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_search);
            this.splitContainer1.Panel2.Controls.Add(this.text_search);
            this.splitContainer1.Panel2.SizeChanged += new System.EventHandler(this.splitContainer1_Panel2_SizeChanged);
            this.splitContainer1.Size = new System.Drawing.Size(1178, 59);
            this.splitContainer1.SplitterDistance = 881;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Image = global::gaoyaxin.Properties.Resources.ico_1;
            this.btn_refresh.Location = new System.Drawing.Point(141, 6);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(40, 40);
            this.btn_refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.TabStop = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gaoyaxin.Properties.Resources.hr2;
            this.pictureBox1.Location = new System.Drawing.Point(95, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // combo_url
            // 
            this.combo_url.BackColor = System.Drawing.SystemColors.Desktop;
            this.combo_url.FormattingEnabled = true;
            this.combo_url.Location = new System.Drawing.Point(185, 11);
            this.combo_url.Name = "combo_url";
            this.combo_url.Size = new System.Drawing.Size(693, 32);
            this.combo_url.TabIndex = 1;
            // 
            // btn_next
            // 
            this.btn_next.Image = global::gaoyaxin.Properties.Resources.next4;
            this.btn_next.Location = new System.Drawing.Point(49, 6);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(40, 40);
            this.btn_next.TabIndex = 1;
            this.btn_next.TabStop = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_pre
            // 
            this.btn_pre.Image = global::gaoyaxin.Properties.Resources.pre3;
            this.btn_pre.Location = new System.Drawing.Point(3, 6);
            this.btn_pre.Name = "btn_pre";
            this.btn_pre.Size = new System.Drawing.Size(40, 40);
            this.btn_pre.TabIndex = 0;
            this.btn_pre.TabStop = false;
            this.btn_pre.Click += new System.EventHandler(this.btn_pre_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Image = global::gaoyaxin.Properties.Resources._094;
            this.btn_search.Location = new System.Drawing.Point(240, 11);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(30, 30);
            this.btn_search.TabIndex = 1;
            this.btn_search.TabStop = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // text_search
            // 
            this.text_search.BackColor = System.Drawing.SystemColors.Desktop;
            this.text_search.Location = new System.Drawing.Point(3, 11);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(231, 30);
            this.text_search.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripButton1,
            this.toolStripSplitButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 59);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1178, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.剪切ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.属性ToolStripMenuItem});
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(67, 28);
            this.toolStripSplitButton1.Text = "组织";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.剪切ToolStripMenuItem.Text = "剪切";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.重命名ToolStripMenuItem.Text = "重命名";
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.属性ToolStripMenuItem.Text = "属性";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(104, 28);
            this.toolStripButton1.Text = "新建文件夹";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大图标ToolStripMenuItem,
            this.小图标ToolStripMenuItem,
            this.列表ToolStripMenuItem,
            this.详细列表ToolStripMenuItem,
            this.详细大图标ToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::gaoyaxin.Properties.Resources._262;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(45, 28);
            this.toolStripSplitButton2.Text = "toolStripSplitButton2";
            this.toolStripSplitButton2.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripSplitButton2_DropDownItemClicked);
            // 
            // 大图标ToolStripMenuItem
            // 
            this.大图标ToolStripMenuItem.Name = "大图标ToolStripMenuItem";
            this.大图标ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.大图标ToolStripMenuItem.Text = "大图标";
            // 
            // 小图标ToolStripMenuItem
            // 
            this.小图标ToolStripMenuItem.Name = "小图标ToolStripMenuItem";
            this.小图标ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.小图标ToolStripMenuItem.Text = "小图标";
            // 
            // 列表ToolStripMenuItem
            // 
            this.列表ToolStripMenuItem.Name = "列表ToolStripMenuItem";
            this.列表ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.列表ToolStripMenuItem.Text = "列表";
            // 
            // 详细列表ToolStripMenuItem
            // 
            this.详细列表ToolStripMenuItem.Name = "详细列表ToolStripMenuItem";
            this.详细列表ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.详细列表ToolStripMenuItem.Text = "详细列表";
            // 
            // 详细大图标ToolStripMenuItem
            // 
            this.详细大图标ToolStripMenuItem.Name = "详细大图标ToolStripMenuItem";
            this.详细大图标ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.详细大图标ToolStripMenuItem.Text = "详细大图标";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lb_objnum,
            this.lb_searching});
            this.statusStrip1.Location = new System.Drawing.Point(0, 713);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 22, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1178, 31);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 24);
            this.toolStripStatusLabel1.Text = "对象数";
            // 
            // lb_objnum
            // 
            this.lb_objnum.Name = "lb_objnum";
            this.lb_objnum.Size = new System.Drawing.Size(21, 24);
            this.lb_objnum.Text = "0";
            // 
            // lb_searching
            // 
            this.lb_searching.Name = "lb_searching";
            this.lb_searching.Size = new System.Drawing.Size(186, 24);
            this.lb_searching.Text = "正在搜索，请稍等........";
            this.lb_searching.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.SkyBlue;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 92);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.listView1);
            this.splitContainer2.Size = new System.Drawing.Size(1178, 621);
            this.splitContainer2.SplitterDistance = 226;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Indent = 10;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(226, 621);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_name,
            this.ch_type,
            this.ch_total,
            this.ch_avail});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            listViewGroup1.Header = "硬盘";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "移动存储";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "其他";
            listViewGroup3.Name = "listViewGroup3";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView1.LargeImageList = this.imgList2;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(950, 621);
            this.listView1.SmallImageList = this.imgList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.MouseEnter += new System.EventHandler(this.listView1_MouseEnter);
            // 
            // ch_name
            // 
            this.ch_name.Text = "名称";
            this.ch_name.Width = 150;
            // 
            // ch_type
            // 
            this.ch_type.Text = "类型";
            this.ch_type.Width = 150;
            // 
            // ch_total
            // 
            this.ch_total.Text = "总大小";
            this.ch_total.Width = 150;
            // 
            // ch_avail
            // 
            this.ch_avail.Text = "可用空间";
            this.ch_avail.Width = 150;
            // 
            // imgList2
            // 
            this.imgList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList2.ImageSize = new System.Drawing.Size(32, 32);
            this.imgList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgList1
            // 
            this.imgList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenu_lv
            // 
            this.contextMenu_lv.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu_lv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_copy,
            this.item_cut,
            this.item_paste,
            this.item_delete,
            this.item_rename,
            this.item_new,
            this.item_refresh,
            this.item_attr});
            this.contextMenu_lv.Name = "contextMenu_lv";
            this.contextMenu_lv.Size = new System.Drawing.Size(162, 244);
            this.contextMenu_lv.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_lv_Opening);
            // 
            // item_copy
            // 
            this.item_copy.Name = "item_copy";
            this.item_copy.Size = new System.Drawing.Size(161, 30);
            this.item_copy.Text = "复制(C)";
            this.item_copy.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_cut
            // 
            this.item_cut.Name = "item_cut";
            this.item_cut.Size = new System.Drawing.Size(161, 30);
            this.item_cut.Text = "剪切(X)";
            this.item_cut.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_paste
            // 
            this.item_paste.Name = "item_paste";
            this.item_paste.Size = new System.Drawing.Size(161, 30);
            this.item_paste.Text = "粘贴(V)";
            this.item_paste.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_delete
            // 
            this.item_delete.Name = "item_delete";
            this.item_delete.Size = new System.Drawing.Size(161, 30);
            this.item_delete.Text = "删除(DEL)";
            this.item_delete.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_rename
            // 
            this.item_rename.Name = "item_rename";
            this.item_rename.Size = new System.Drawing.Size(161, 30);
            this.item_rename.Text = "重命名";
            this.item_rename.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_new
            // 
            this.item_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_newfolder,
            this.item_newtxt,
            this.item_newword,
            this.item_newexcel,
            this.item_newppt});
            this.item_new.Name = "item_new";
            this.item_new.Size = new System.Drawing.Size(161, 30);
            this.item_new.Text = "新建";
            // 
            // item_newfolder
            // 
            this.item_newfolder.Name = "item_newfolder";
            this.item_newfolder.Size = new System.Drawing.Size(225, 34);
            this.item_newfolder.Text = "文件夹";
            this.item_newfolder.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_newtxt
            // 
            this.item_newtxt.Name = "item_newtxt";
            this.item_newtxt.Size = new System.Drawing.Size(225, 34);
            this.item_newtxt.Text = "文本文档";
            this.item_newtxt.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_newword
            // 
            this.item_newword.Name = "item_newword";
            this.item_newword.Size = new System.Drawing.Size(225, 34);
            this.item_newword.Text = "word文档";
            this.item_newword.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_newexcel
            // 
            this.item_newexcel.Name = "item_newexcel";
            this.item_newexcel.Size = new System.Drawing.Size(225, 34);
            this.item_newexcel.Text = "Excel电子表格";
            this.item_newexcel.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_newppt
            // 
            this.item_newppt.Name = "item_newppt";
            this.item_newppt.Size = new System.Drawing.Size(225, 34);
            this.item_newppt.Text = "PPT演示文档";
            this.item_newppt.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_refresh
            // 
            this.item_refresh.Name = "item_refresh";
            this.item_refresh.Size = new System.Drawing.Size(161, 30);
            this.item_refresh.Text = "刷新";
            this.item_refresh.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_attr
            // 
            this.item_attr.Name = "item_attr";
            this.item_attr.Size = new System.Drawing.Size(161, 30);
            this.item_attr.Text = "属性";
            this.item_attr.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // contextMenu_lv2
            // 
            this.contextMenu_lv2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu_lv2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_open,
            this.item_refresh2,
            this.item_revert,
            this.item_empty,
            this.item_del});
            this.contextMenu_lv2.Name = "contextMenu_lv2";
            this.contextMenu_lv2.Size = new System.Drawing.Size(117, 154);
            this.contextMenu_lv2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_lv2_Opening);
            // 
            // item_open
            // 
            this.item_open.Name = "item_open";
            this.item_open.Size = new System.Drawing.Size(116, 30);
            this.item_open.Text = "打开";
            this.item_open.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_refresh2
            // 
            this.item_refresh2.Name = "item_refresh2";
            this.item_refresh2.Size = new System.Drawing.Size(116, 30);
            this.item_refresh2.Text = "刷新";
            this.item_refresh2.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_revert
            // 
            this.item_revert.Name = "item_revert";
            this.item_revert.Size = new System.Drawing.Size(116, 30);
            this.item_revert.Text = "还原";
            this.item_revert.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_empty
            // 
            this.item_empty.Name = "item_empty";
            this.item_empty.Size = new System.Drawing.Size(116, 30);
            this.item_empty.Text = "清空";
            this.item_empty.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // item_del
            // 
            this.item_del.Name = "item_del";
            this.item_del.Size = new System.Drawing.Size(116, 30);
            this.item_del.Text = "删除";
            this.item_del.Click += new System.EventHandler(this.contextMenu_item_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "高雅欣-资源管理器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_search)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenu_lv.ResumeLayout(false);
            this.contextMenu_lv2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private ComboBox combo_url;
        private PictureBox btn_next;
        private PictureBox btn_pre;
        private TextBox text_search;
        private PictureBox btn_search;
        private ToolStrip toolStrip1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem 复制ToolStripMenuItem;
        private ToolStripMenuItem 剪切ToolStripMenuItem;
        private ToolStripMenuItem 粘贴ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private ToolStripMenuItem 重命名ToolStripMenuItem;
        private ToolStripMenuItem 属性ToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripSplitButton toolStripSplitButton2;
        private ToolStripMenuItem 大图标ToolStripMenuItem;
        private ToolStripMenuItem 小图标ToolStripMenuItem;
        private ToolStripMenuItem 列表ToolStripMenuItem;
        private ToolStripMenuItem 详细列表ToolStripMenuItem;
        private ToolStripMenuItem 详细大图标ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lb_objnum;
        private SplitContainer splitContainer2;
        private TreeView treeView1;
        private ListView listView1;
        private ColumnHeader ch_name;
        private ColumnHeader ch_type;
        private ColumnHeader ch_total;
        private ColumnHeader ch_avail;
        private ImageList imgList2;
        private ImageList imgList1;
        private PictureBox btn_refresh;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenu_lv;
        private ToolStripMenuItem item_copy;
        private ToolStripMenuItem item_cut;
        private ToolStripMenuItem item_paste;
        private ToolStripMenuItem item_delete;
        private ToolStripMenuItem item_rename;
        private ToolStripMenuItem item_new;
        private ToolStripMenuItem item_newfolder;
        private ToolStripMenuItem item_newtxt;
        private ToolStripMenuItem item_newword;
        private ToolStripMenuItem item_newexcel;
        private ToolStripMenuItem item_newppt;
        private ToolStripMenuItem item_refresh;
        private ToolStripMenuItem item_attr;
        private ContextMenuStrip contextMenu_lv2;
        private ToolStripMenuItem item_open;
        private ToolStripMenuItem item_refresh2;
        private ToolStripMenuItem item_revert;
        private ToolStripMenuItem item_empty;
        private ToolStripMenuItem item_del;
        private ToolStripStatusLabel lb_searching;
    }
}
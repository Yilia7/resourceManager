using JHR_GetIcon;
using Shell32;
using System.Collections;
using Microsoft.VisualBasic.FileIO;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using File = System.IO.File;
//用到的名空间
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using static System.Net.WebRequestMethods;

namespace gaoyaxin
{
    public partial class Form1 : Form
    {
        ArrayList accesspaths = new ArrayList();
        GetIcon geticon = new GetIcon();
        ArrayList copyobjs = new ArrayList();
        bool iscut = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Icon[] myIcon;
            int[] myindexs = { 15, 34, 43, 8, 11, 7, 101, 4, 2, 0, 16, 17 };
            string[] mykeys = {"computer","desktop","favorites","localdriver","cdrom","movabledriver",
            "recycle","defaultfolder","defaultexeicon","unknowicon","printer","network"};
            for (int i = 0; i < myindexs.Length; i++)
            {
                myIcon = geticon.GetIconByIndex(myindexs[i]);
                imgList1.Images.Add(mykeys[i], myIcon[0]);
                imgList2.Images.Add(mykeys[i], myIcon[1]);
            }

            treeView1.ImageList = imgList1;
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            //桌面节点
            string mypath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            TreeNode desk = new TreeNode("桌面");
            desk.ImageKey = desk.SelectedImageKey = "desktop";
            desk.Tag = mypath;
            treeView1.Nodes.Add(desk);
            //我的电脑
            mypath = "computer";
            TreeNode root = new TreeNode("我的电脑");
            root.SelectedImageKey = root.ImageKey = "computer";
            root.Tag = mypath;
            treeView1.Nodes.Add(root);
            GetDriverTree(root);
            root.Expand();
            //收藏夹
            mypath = "favorites";
            TreeNode tnf = new TreeNode("收藏夹");
            tnf.SelectedImageKey = tnf.ImageKey = "favorites";
            tnf.Tag = mypath;
            treeView1.Nodes.Add(tnf);

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TreeNode tnl = new TreeNode("我的文档");
            myIcon = geticon.GetIconByFileName(mypath, FileAttributes.Directory);
            imgList1.Images.Add("mydocument", myIcon[0]);
            imgList2.Images.Add("mydocument", myIcon[1]);
            tnl.SelectedImageKey = tnl.ImageKey = "mydocument";
            tnl.Tag = mypath;
            tnf.Nodes.Add(tnl);

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            tnl = new TreeNode("我的音乐");
            myIcon = geticon.GetIconByFileName(mypath, FileAttributes.Directory);
            if (myIcon != null)
            {
                imgList1.Images.Add("mymusic", myIcon[0]);
                imgList2.Images.Add("mymusic", myIcon[1]);
                tnl.SelectedImageKey = tnl.ImageKey = "mymusic";
                tnl.Tag = mypath;
                tnf.Nodes.Add(tnl);
            }

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            tnl = new TreeNode("我的图片");
            myIcon = geticon.GetIconByFileName(mypath, FileAttributes.Directory);
            if (myIcon != null)
            {
                imgList1.Images.Add("mypictures", myIcon[0]);
                imgList2.Images.Add("mypictures", myIcon[1]);
                tnl.SelectedImageKey = tnl.ImageKey = "mypictures";
                tnl.Tag = mypath;
                tnf.Nodes.Add(tnl);
            }

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            tnl = new TreeNode("我的视频");
            myIcon = geticon.GetIconByFileName(mypath, FileAttributes.Directory);
            if (myIcon != null)
            {
                imgList1.Images.Add("myvideos", myIcon[0]);
                imgList2.Images.Add("myvideos", myIcon[1]);
                tnl.SelectedImageKey = tnl.ImageKey = "myvideos";
                tnl.Tag = mypath;
                tnf.Nodes.Add(tnl);
            }

            //回收站
            mypath = "recycle";
            TreeNode tnr = new TreeNode("回收站");
            tnr.SelectedImageKey = tnr.ImageKey = "recycle";
            tnr.Tag = mypath;
            treeView1.Nodes.Add(tnr);
            treeView1.EndUpdate();

            GetDriverListview();//listview1

            //地址栏
            accesspaths.Add("我的电脑");
            combo_url.DataSource = accesspaths;
            combo_url.SelectedIndex = 0;

            //安装相关事件
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            combo_url.SelectedIndexChanged += new EventHandler(combo_url_SelectedIndexChanged);
        }

        //我的电脑下的节点的获取
        private static void GetDriverTree(TreeNode root)
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            string keyname = "";
            string drivername = "";
            string drivertag = "";
            foreach (DriveInfo driver in drivers)
            {
                if (driver.IsReady) drivername = driver.VolumeLabel;
                else drivername = "";
                switch (driver.DriveType)
                {
                    case DriveType.Fixed:
                        keyname = "localdriver"; if (drivername.Equals("")) drivername = "本地磁盘";
                        break;
                    case DriveType.Removable:
                        keyname = "movabledriver"; if (drivername.Equals("")) drivername = "移动存储";
                        break;
                    case DriveType.CDRom:
                        keyname = "cdrom"; if (drivername.Equals("")) drivername = "光盘驱动器";
                        break;
                    default:
                        keyname = "movabledriver"; if (drivername.Equals("")) drivername = "未知设备";
                        break;
                }
                drivername = drivername + "(" + driver.Name.Substring(0, 2) + ")";
                drivertag = driver.Name;
                TreeNode tn = new TreeNode(drivername);
                tn.SelectedImageKey = tn.ImageKey = keyname;
                tn.Tag = drivertag;
                if (driver.IsReady)
                {
                    try
                    {
                        DirectoryInfo driver_info = new DirectoryInfo(driver.Name);
                        DirectoryInfo[] dirs = driver_info.GetDirectories();
                        if (dirs.Length > 0) tn.Nodes.Add("temp");
                    }
                    catch { }
                }
                root.Nodes.Add(tn);
            }

        }

        //获取驱动器信息，显示在listview中
        private void GetDriverListview()
        {
            listView1.Items.Clear();
            CreateCol_D();
            DriveInfo[] drivers = DriveInfo.GetDrives();
            string lvname1, lvname2, lvtype, keyname, lvtotal = "", lvfree = "";
            foreach (DriveInfo driver in drivers)
            {
                ListViewItem newitem = new ListViewItem();
                newitem.IndentCount = 1;
                if (driver.IsReady) lvname1 = driver.VolumeLabel;
                else lvname1 = "";
                lvname2 = driver.Name;
                switch (driver.DriveType)
                {
                    case DriveType.Fixed:
                        {
                            keyname = "localdriver";
                            lvtype = "本地磁盘";
                            if (lvname1.Equals("")) lvname1 = "本地磁盘";
                            newitem.Group = listView1.Groups["lvGroup1"];
                            break;
                        }
                    case DriveType.Removable:
                        {
                            keyname = "movabledriver";
                            lvtype = "移动存储";
                            if (lvname1.Equals("")) lvname1 = "移动存储";
                            newitem.Group = listView1.Groups["lvGroup2"];
                            break;
                        }
                    case DriveType.CDRom:
                        {
                            keyname = "cdrom";
                            lvtype = "光盘驱动器";
                            if (lvname1.Equals("")) lvname1 = "光盘启动器";
                            newitem.Group = listView1.Groups["lvGroup2"];
                            break;
                        }
                    default:
                        {
                            keyname = "movabledriver";
                            lvtype = "未知设备";
                            if (lvname1.Equals("")) lvname1 = "未知设备";
                            newitem.Group = listView1.Groups["lvGroup3"];
                            break;
                        }
                }
                newitem.SubItems[0].Text = (lvname1 + "(" + lvname2.Substring(0, 2) + ")");
                newitem.SubItems.Add(lvtype);
                if (driver.IsReady)
                {
                    lvtotal = Math.Round(driver.TotalSize / (1024 * 1024 * 1024 * 1.0), 1).ToString() + "G";
                    lvfree = Math.Round(driver.TotalFreeSpace / (1024 * 1024 * 1024 * 1.0), 1).ToString() + "G";
                }
                newitem.SubItems.Add(lvtotal);
                newitem.SubItems.Add(lvfree);
                newitem.ImageKey = keyname;
                newitem.Tag = lvname2;
                listView1.Items.Add(newitem);
            }
            lb_objnum.Text = listView1.Items.Count.ToString();
        }

        //创建列
        private void CreateCol_D()
        {
            listView1.Columns.Clear();

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "名称";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 200;
            columnHeader1.Name = "chname";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "类型";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 100;
            columnHeader1.Name = "chtype";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "总大小";
            columnHeader1.TextAlign = HorizontalAlignment.Right;
            columnHeader1.Width = 120;
            columnHeader1.Name = "chtotal";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "可用大小";
            columnHeader1.TextAlign = HorizontalAlignment.Right;
            columnHeader1.Width = 120;
            columnHeader1.Name = "chfree";
            listView1.Columns.Add(columnHeader1);

        }

        void combo_url_SelectedIndexChanged(object sender, EventArgs e)
        {
            int flag = 0;
            string newpath = combo_url.Text.Trim();
            switch (newpath)
            {
                case "桌面":
                    {
                        if (flag_pre_next == false)
                        {
                            accesspaths.Remove("桌面");
                            accesspaths.Insert(0, "桌面");
                        }
                        GetDesktopListview(); break;
                    }
                case "我的电脑":
                    {
                        if (flag_pre_next == false)
                        {
                            accesspaths.Remove("我的电脑");
                            accesspaths.Insert(0, "我的电脑");
                        }
                        GetDriverListview(); break;
                    }
                case "回收站":
                    {
                        if (flag_pre_next == false)
                        {
                            accesspaths.Remove("回收站");
                            accesspaths.Insert(0, "回收站");
                        }
                        GetRecyleListView(); break;
                    }
                case "收藏夹":
                    {
                        if (flag_pre_next == false)
                        {
                            accesspaths.Remove("收藏夹");
                            accesspaths.Insert(0, "收藏夹");
                        }
                        GetfavoritesListView(); break;
                    }
                default:
                    {
                        flag = GetFolderListview(newpath);
                        if (flag_pre_next == false)
                        {
                            accesspaths.Remove(newpath);
                            accesspaths.Insert(0, newpath);
                        }
                        break;
                    }
            }

            //重新绑定combo_url
            //前面的方法有没有也要先卸载再重新安装的
            if (flag_pre_next == false)
            {
                combo_url.SelectedIndexChanged -= new EventHandler(combo_url_SelectedIndexChanged);
                combo_url.DataSource = null;
                combo_url.DataSource = accesspaths;
                combo_url.SelectedIndex = 0;
                combo_url.SelectedIndexChanged += new EventHandler(combo_url_SelectedIndexChanged);
            }
            if (flag == 1)
            {
                listView1.Items.Clear();
                MessageBox.Show("访问失败，缺少权限或设备未就绪", "错误");
            }
            flag_pre_next = false;
        }

        private void CreateCol_F()
        {
            listView1.Columns.Clear();

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "名称";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 200;
            columnHeader1.Name = "chname";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "类型";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 100;
            columnHeader1.Name = "chtype";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "修改时间";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 120;
            columnHeader1.Name = "chmodify";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "大小";
            columnHeader1.TextAlign = HorizontalAlignment.Right;
            columnHeader1.Width = 120;
            columnHeader1.Name = "chtotal";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "创建时间";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 120;
            columnHeader1.Name = "chcreate";
            listView1.Columns.Add(columnHeader1);

        }

        //子目录节点的获取-单击+展开
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode tn = e.Node;
            if (tn.Tag.Equals("computer"))
            {
                tn.Nodes.Clear();
                GetDriverTree(tn);
            }
            else
                if (!tn.Tag.Equals("favorites"))
            {
                tn.Nodes.Clear();
                GetFolderTree(tn);
            }
        }

        //根据节点代表的文件夹路径获取子目录
        private void GetFolderTree(TreeNode tn)
        {
            string folderpath = tn.Tag.ToString();
            string[] f_names = Directory.GetDirectories(folderpath);
            foreach (string fn in f_names)
            {
                DirectoryInfo dinfo = new DirectoryInfo(fn);
                TreeNode newtn = new TreeNode(dinfo.Name);
                newtn.Tag = dinfo.FullName;
                newtn.SelectedImageKey = newtn.ImageKey = "defaultfolder";
                try
                {
                    string[] temps = Directory.GetDirectories(fn);
                    if (temps.Length > 0) newtn.Nodes.Add("temp");
                }
                catch { }
                tn.Nodes.Add(newtn);
            }
        }

        //获取指定路径p下的文件和目录对象，显示在listview1
        private int GetFolderListview(string p)
        {
            listView1.Items.Clear();
            CreateCol_F();
            string[] dirs;
            string[] files;
            try
            {
                dirs = Directory.GetDirectories(p);
                files = Directory.GetFiles(p);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return 1;
            }
            foreach (string dir in dirs)
            {
                try
                {
                    DirectoryInfo dinfo = new DirectoryInfo(dir);
                    ListViewItem lv = new ListViewItem(dinfo.Name);
                    lv.Tag = dinfo.FullName;
                    lv.ImageKey = "defaultfolder";
                    lv.SubItems.Add("文件夹");
                    lv.SubItems.Add(dinfo.LastWriteTime.ToString());
                    lv.SubItems.Add("");
                    lv.SubItems.Add(dinfo.CreationTime.ToString());
                    listView1.Items.Add(lv);
                }
                catch { }
            }
            foreach (string f in files)
            {
                try
                {
                    FileInfo finfo = new FileInfo(f);
                    ListViewItem lv = new ListViewItem(finfo.Name);
                    lv.Tag = finfo.FullName;
                    lv.ImageKey = GetFileIconKey(finfo.Extension, finfo.FullName);
                    string typename = geticon.GetTypeName(finfo.FullName);
                    lv.SubItems.Add(typename);
                    lv.SubItems.Add(finfo.LastWriteTime.ToString());
                    long size = finfo.Length;
                    string sizestring = "";
                    if (size < 1024) sizestring = size.ToString() + "Byte";
                    else sizestring = (size / 1024).ToString() + "KB";
                    lv.SubItems.Add(sizestring);
                    lv.SubItems.Add(finfo.CreationTime.ToString());
                    listView1.Items.Add(lv);
                }
                catch { }
            }
            lb_objnum.Text = listView1.Items.Count.ToString();
            return 0;
        }

        //读取收藏夹对象。显示在listview1
        private void GetfavoritesListView()
        {
            listView1.Items.Clear();
            CreateCol_F();
            string mypath = "";

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ListViewItem lv = new ListViewItem("我的文档");
            lv.Tag = mypath;
            lv.ImageKey = "mydocument";
            DirectoryInfo dinfo = new DirectoryInfo(mypath);
            lv.SubItems.Add("文件夹");
            lv.SubItems.Add(dinfo.LastWriteTime.ToString());
            lv.SubItems.Add("");
            lv.SubItems.Add(dinfo.CreationTime.ToString());
            listView1.Items.Add(lv);

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            if (mypath != null && !mypath.Equals(""))
            {
                lv = new ListViewItem("我的音乐");
                lv.Tag = mypath;
                lv.ImageKey = "mymusic";
                dinfo = new DirectoryInfo(mypath);
                lv.SubItems.Add("文件夹");
                lv.SubItems.Add(dinfo.LastWriteTime.ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(dinfo.CreationTime.ToString());
                listView1.Items.Add(lv);
            }

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (mypath != null && !mypath.Equals(""))
            {
                lv = new ListViewItem("我的图片");
                lv.Tag = mypath;
                lv.ImageKey = "mypictures";
                dinfo = new DirectoryInfo(mypath);
                lv.SubItems.Add("文件夹");
                lv.SubItems.Add(dinfo.LastWriteTime.ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(dinfo.CreationTime.ToString());
                listView1.Items.Add(lv);
            }

            mypath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            if (mypath != null && !mypath.Equals(""))
            {
                lv = new ListViewItem("我的视频");
                lv.Tag = mypath;
                lv.ImageKey = "myvideos";
                dinfo = new DirectoryInfo(mypath);
                lv.SubItems.Add("文件夹");
                lv.SubItems.Add(dinfo.LastWriteTime.ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(dinfo.CreationTime.ToString());
                listView1.Items.Add(lv);
            }
            lb_objnum.Text = listView1.Items.Count.ToString();
        }

        //读取回收站对象，显示在listview1
        private void GetRecyleListView()
        {
            listView1.Items.Clear();
            CreateCol_R();
            Shell shell = new Shell();
            Folder recycleBin = shell.NameSpace(10);
            foreach (FolderItem f in recycleBin.Items())
            {
                ListViewItem lv = new ListViewItem(f.Name);
                lv.Tag = f.Path;
                lv.IndentCount = 1;
                if (f.IsFolder)
                {
                    lv.ImageKey = "defaultfolder";
                }
                else
                {
                    lv.ImageKey = GetFileIconKey(f.Path.Substring(f.Path.LastIndexOf('.')), f.Path);
                }
                lv.SubItems.Add(f.Type);
                lv.SubItems.Add(f.Path);
                lv.SubItems.Add(f.ModifyDate.ToString());
                listView1.Items.Add(lv);
            }
            lb_objnum.Text = listView1.Items.Count.ToString();
        }

        private void CreateCol_R()
        {
            listView1.Columns.Clear();

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "名称";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 200;
            columnHeader1.Name = "chname";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "类型";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 100;
            columnHeader1.Name = "chtype";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "位置";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 200;
            columnHeader1.Name = "chpath";
            listView1.Columns.Add(columnHeader1);

            columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "修改日期";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 120;
            columnHeader1.Name = "chdel";
            listView1.Columns.Add(columnHeader1);
        }

        //读取桌面的对象，显示在listview1
        //读取特殊对象，再读取桌面上的普通文件
        private void GetDesktopListview()
        {
            //特殊文件
            listView1.Items.Clear();
            CreateCol_F();
            ListViewItem lv = new ListViewItem("我的电脑");
            lv.Tag = "computer";
            lv.ImageKey = "computer";
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            listView1.Items.Add(lv);

            lv = new ListViewItem("我的文档");
            lv.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            lv.ImageKey = "mydocument";
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            listView1.Items.Add(lv);

            lv = new ListViewItem("网络");
            lv.Tag = "network";
            lv.ImageKey = "network";
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            listView1.Items.Add(lv);

            lv = new ListViewItem("回收站");
            lv.Tag = "recycle";
            lv.ImageKey = "recycle";
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            lv.SubItems.Add("");
            listView1.Items.Add(lv);

            //普通文件的读取
            string[] dirs;
            string[] files;
            string p = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                dirs = Directory.GetDirectories(p);
                files = Directory.GetFiles(p);

                foreach (string dir in dirs)
                {
                    try
                    {
                        DirectoryInfo dinfo = new DirectoryInfo(dir);
                        lv = new ListViewItem(dinfo.Name);
                        lv.Tag = dinfo.FullName;
                        lv.ImageKey = "defaultfolder";
                        lv.SubItems.Add("文件夹");
                        lv.SubItems.Add(dinfo.LastWriteTime.ToString());
                        lv.SubItems.Add("");
                        lv.SubItems.Add(dinfo.CreationTime.ToString());
                        listView1.Items.Add(lv);
                    }
                    catch { }
                }
                //读取文件
                foreach (string f in files)
                {
                    try
                    {
                        FileInfo finfo = new FileInfo(f);
                        lv = new ListViewItem(finfo.Name);
                        lv.Tag = finfo.FullName;
                        lv.ImageKey = GetFileIconKey(finfo.Extension, finfo.FullName);

                        string typename = geticon.GetTypeName(finfo.FullName);
                        lv.SubItems.Add(typename);
                        lv.SubItems.Add(finfo.LastWriteTime.ToString());//看看普通文件的顺序对不对
                        long size = finfo.Length;
                        string sizestring = "";
                        if (size < 1024) sizestring = Size.ToString() + "Byte";
                        else sizestring = (size / 1024).ToString() + "KB";
                        lv.SubItems.Add(sizestring);
                        lv.SubItems.Add(finfo.CreationTime.ToString());
                        listView1.Items.Add(lv);
                    }
                    catch { }
                }
            }
            catch { }
            lb_objnum.Text = listView1.Items.Count.ToString();
        }

        //获取文件的图标
        private string GetFileIconKey(string extension, string fullname)
        {
            string imgkey = "";
            Icon[] myIcon;
            if (extension.ToUpper().Equals(".EXE") || extension.ToUpper().Equals(".LNK"))
            {
                myIcon = geticon.GetIconByFileName(fullname, FileAttributes.Normal);
                if (myIcon != null)
                {
                    if (myIcon[0] != null && myIcon[1] != null)
                    {
                        if (imgList1.Images.ContainsKey(fullname)) imgList1.Images.RemoveByKey(fullname);
                        if (imgList2.Images.ContainsKey(fullname)) imgList2.Images.RemoveByKey(fullname);
                        imgList1.Images.Add(fullname, myIcon[0]);
                        imgList2.Images.Add(fullname, myIcon[1]);
                        imgkey = fullname;
                    }
                }
                if (imgkey == "")
                {
                    if (extension.ToUpper().Equals(".EXE")) imgkey = "defaultextensionicon";
                    else imgkey = "unknowicon";
                }
            }
            else
            {
                myIcon = geticon.GetIconByFileType(extension);
                if (myIcon != null)
                {
                    if (myIcon[0] != null && myIcon[1] != null)
                    {
                        if (imgList1.Images.ContainsKey(extension)) imgList1.Images.RemoveByKey(fullname);
                        if (imgList2.Images.ContainsKey(extension)) imgList2.Images.RemoveByKey(fullname);
                        imgList1.Images.Add(extension, myIcon[0]);
                        imgList2.Images.Add(extension, myIcon[1]);
                        imgkey = extension;
                    }
                    else imgkey = "unknowicon";
                }
                else imgkey = "unknowicon";
            }
            return imgkey;
        }

        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            combo_url.Width = splitContainer1.Panel1.Width - btn_next.Width - btn_pre.Width -pictureBox1.Width-btn_refresh.Width- 30;
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            text_search.Width = splitContainer1.Panel2.Width - btn_search.Width - 6;
        }

        //单击树型目录，选中后读取该节点目录下所有目录和文件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;
            int flag = 0;
            switch (tn.Text)
            {
                case "桌面":
                    {
                        if (accesspaths.IndexOf("桌面") > -1) accesspaths.Remove("桌面");
                        accesspaths.Insert(0, "桌面");
                        GetDesktopListview(); break;
                    }
                case "我的电脑":
                    {
                        if (accesspaths.IndexOf("我的电脑") > -1) accesspaths.Remove("我的电脑");
                        accesspaths.Insert(0, "我的电脑");
                        GetDriverListview(); break;
                    }
                case "回收站":
                    {
                        if (accesspaths.IndexOf("回收站") > -1) accesspaths.Remove("回收站");
                        accesspaths.Insert(0, "回收站");
                        GetRecyleListView(); break;
                    }
                case "收藏夹":
                    {
                        if (accesspaths.IndexOf("收藏夹") > -1) accesspaths.Remove("收藏夹");
                        accesspaths.Insert(0, "收藏夹");
                        GetfavoritesListView(); break;
                    }
                default:
                    {
                        flag = GetFolderListview(tn.Tag.ToString());
                        if (flag == 0)
                        {
                            if (accesspaths.IndexOf(tn.Tag.ToString()) > -1) accesspaths.Remove(tn.Tag.ToString());
                            accesspaths.Insert(0, tn.Tag.ToString());
                        }
                        break;
                    }
            }
            //此处也是先卸载再重新安装
            if (flag == 0)
            {
                combo_url.SelectedIndexChanged -= new EventHandler(combo_url_SelectedIndexChanged);
                combo_url.DataSource = null;
                combo_url.DataSource = accesspaths;
                combo_url.SelectedIndex = 0;
                combo_url.SelectedIndexChanged += new EventHandler(combo_url_SelectedIndexChanged);
            }
            else MessageBox.Show("访问失败，缺少权限或设备未就绪", "错误");
        }

        bool flag_pre_next;
        private void btn_pre_Click(object sender, EventArgs e)
        {
            if (combo_url.SelectedIndex == combo_url.Items.Count - 1)
            {
                MessageBox.Show("已经是后退的最后一个目录了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                flag_pre_next = true;
                combo_url.SelectedIndex += 1;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (combo_url.SelectedIndex == combo_url.Items.Count + 1)
            {
                MessageBox.Show("已经是前进的最后一个目录了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                flag_pre_next = false;
                combo_url.SelectedIndex -= 1;
            }
        }

        //双击listview1的某项
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem fitem = listView1.FocusedItem;
            string fullname = fitem.Tag.ToString();
            string urltext = combo_url.Text;
            string mytype = fitem.SubItems[1].Text;


            if (urltext.Equals("我的电脑"))
            {
                DriveInfo dinfo = new DriveInfo(fullname);
                if (dinfo.IsReady) mytype = "文件夹";
                else
                {
                    MessageBox.Show("设备未就绪，无法读取", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            if (urltext.Equals("回收站"))
            {
                MessageBox.Show("回收站的对象不能直接访问!");
                return;
            }
            if (urltext.Equals("桌面") && fitem.SubItems[0].Text.Equals("网络"))
            {
                MessageBox.Show("网上邻居功能还未实现！");
                return;
            }
            if (urltext.Equals("桌面") && fitem.SubItems[0].Text.Equals("我的文档")) mytype = "文件夹";

            switch (mytype)
            {
                case "文件夹":
                    {
                        GetFolderListview(fullname);
                        combo_url.Text = fullname;
                        combo_url_SelectedIndexChanged(null, null);

                        break;
                    }
                case "":
                    {
                        if (fitem.SubItems[0].Text.Equals("我的电脑"))
                        {
                            if (accesspaths.IndexOf("我的电脑") > -1) accesspaths.Remove("我的电脑");
                            accesspaths.Insert(0, "我的电脑");
                            GetDriverListview();

                            combo_url.SelectedIndexChanged -= new EventHandler(combo_url_SelectedIndexChanged);
                            combo_url.DataSource = null;
                            combo_url.DataSource = accesspaths;
                            combo_url.SelectedIndex = 0;
                            combo_url.SelectedIndexChanged += new EventHandler(combo_url_SelectedIndexChanged);
                        }
                        if (fitem.SubItems[0].Text.Equals("回收站"))
                        {
                            if (accesspaths.IndexOf("回收站") > -1) accesspaths.Remove("回收站");
                            accesspaths.Insert(0, "回收站");
                            GetRecyleListView();

                            combo_url.SelectedIndexChanged -= new EventHandler(combo_url_SelectedIndexChanged);
                            combo_url.DataSource = null;
                            combo_url.DataSource = accesspaths;
                            combo_url.SelectedIndex = 0;
                            combo_url.SelectedIndexChanged += new EventHandler(combo_url_SelectedIndexChanged);
                        }
                        break;
                    }
                default:
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(fullname);
                        }
                        catch
                        {
                            MessageBox.Show("无法打开或运行该文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        break;
                    }
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            //地址栏选中项类似
            combo_url_SelectedIndexChanged(null, null);
        }

        //返回上级
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string currpath = combo_url.Text;
            switch (currpath)
            {
                case "桌面": return;
                case "回收站": combo_url.Text = "桌面"; break;
                case "我的电脑": combo_url.Text = "桌面"; break;
                case "收藏夹": combo_url.Text = "桌面"; break;
                default:
                    {
                        try
                        {
                            combo_url.Text = Directory.GetParent(currpath).FullName;
                            //if (Directory.GetParent(currpath).FullName != null) break;
                            //else combo_url.Text = Directory.GetParent(currpath).FullName;//？C盘的父节点时null但不行 C盘路径和我的电脑是分开的
                            //只是发生了异常，继续下去还是会返回我的电脑的
                        }
                        catch
                        {
                            combo_url.Text = "我的电脑"; break;
                        }
                        break;
                    }
            }
        }

        private void toolStripSplitButton2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripSplitButton tsb = (ToolStripSplitButton)sender;
            for (int i = 0; i < tsb.DropDownItems.Count; i++)
            {
                if (tsb.DropDownItems[i] != e.ClickedItem)
                    ((ToolStripMenuItem)tsb.DropDownItems[i]).Checked = false;
                else
                    ((ToolStripMenuItem)tsb.DropDownItems[i]).Checked = true;
            }
            switch (e.ClickedItem.Text)
            {
                case "大图标": listView1.View = View.LargeIcon; break;
                case "小图标": listView1.View = View.SmallIcon; break;
                case "列表": listView1.View = View.List; break;
                case "详细列表": listView1.View = View.Details; break;
                default: listView1.View = View.Tile; break;
            }
        }

        private void listView1_MouseEnter(object sender, EventArgs e)
        {
            string folderpath = combo_url.Text;
            if (folderpath.Equals("回收站") || folderpath.Equals("收藏夹") || folderpath.Equals("我的电脑"))
                listView1.ContextMenuStrip = contextMenu_lv2;
            else
                listView1.ContextMenuStrip = contextMenu_lv;
        }

        
        private void contextMenu_lv_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenu_lv.Items["item_copy"].Enabled = false;
                contextMenu_lv.Items["item_cut"].Enabled = false;
                if (copyobjs.Count == 0) contextMenu_lv.Items["item_paste"].Enabled = false;
                else contextMenu_lv.Items["item_paste"].Enabled = true;
                contextMenu_lv.Items["item_delete"].Enabled = false;
                contextMenu_lv.Items["item_rename"].Enabled = false;
                contextMenu_lv.Items["item_new"].Enabled = true;
                contextMenu_lv.Items["item_refresh"].Enabled = true;
                contextMenu_lv.Items["item_attr"].Enabled = false;
            }
            else
            {
                contextMenu_lv.Items["item_copy"].Enabled = true;
                contextMenu_lv.Items["item_cut"].Enabled = true;
                contextMenu_lv.Items["item_paste"].Enabled = false;
                contextMenu_lv.Items["item_delete"].Enabled = true;
                contextMenu_lv.Items["item_rename"].Enabled = true;
                contextMenu_lv.Items["item_new"].Enabled = false;
                contextMenu_lv.Items["item_refresh"].Enabled = false;
                contextMenu_lv.Items["item_attr"].Enabled = true;

            }
        }

        private void contextMenu_lv2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenu_lv2.Items["item_refresh2"].Enabled = true;
                contextMenu_lv2.Items["item_open"].Enabled = false;
                contextMenu_lv2.Items["item_revert"].Enabled = false;
                contextMenu_lv2.Items["item_del"].Enabled = false;
                if (combo_url.Text.Equals("回收站"))
                    contextMenu_lv2.Items["item_empty"].Enabled = true;
                else
                    contextMenu_lv2.Items["item_empty"].Enabled = false;
            }
            else
            {
                contextMenu_lv2.Items["item_empty"].Enabled = false;
                contextMenu_lv2.Items["item_refresh2"].Enabled = false;
                if (combo_url.Text.Equals("回收站"))
                {
                    contextMenu_lv2.Items["item_open"].Enabled = false;
                    contextMenu_lv2.Items["item_revert"].Enabled = true;
                    contextMenu_lv2.Items["item_del"].Enabled = true;
                }
                else
                {
                    contextMenu_lv2.Items["item_open"].Enabled = true;
                    contextMenu_lv2.Items["item_revert"].Enabled = false;
                    contextMenu_lv2.Items["item_del"].Enabled = false;
                }
            }
        }

        private void contextMenu_item_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            switch (tsi.Name)
            {
                case "item_copy": docopy(); break;
                case "item_cut": docout(); break;
                case "item_paste": dopaste(); break;
                case "item_delete": dodelete(); break;
                case "item_rename": dorename(); break;
                case "item_refresh": combo_url_SelectedIndexChanged(null, null); break;
                case "item_attr": showattr(listView1.SelectedItems[0].Tag.ToString()); break;
                case "item_newfolder": donew("folder"); break;
                case "item_newword": donew("word"); break;
                case "item_newtxt": donew("txt"); break;
                case "item_newexcel": donew("excel"); break;
                case "item_newppt": donew("ppt"); break;
                case "item_open": OpenObj(listView1.SelectedItems[0]); break;
                case "item_del": doRecycleDel(); break;
                case "item_revert": doRevert(listView1.SelectedItems[0].Text); break;
                case "item_empty": doEmpty(); break;
                case "item_refresh2": combo_url_SelectedIndexChanged(null, null); break;
            }
        }

        private void doEmpty()
        {
            try
            {
                for(int i = 0; i < listView1.Items.Count; i++)
                {
                    string fullname=listView1.Items[i].Tag.ToString();
                    if (File.Exists(fullname))
                    {
                        FileSystem.DeleteFile(fullname, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
                    }
                    else
                    {
                        if (Directory.Exists(fullname))
                            FileSystem.DeleteDirectory(fullname, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
                        else MessageBox.Show(fullname + ",删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
            combo_url_SelectedIndexChanged(null, null);
        }

        private void doRevert(string name)
        {
            //combo_url.Text =fullname;
            readExcel(name);
            
        }

        void readExcel(string name)
        {
            //combo_url.Text = name;
            //创建一个Excel程序
            Excel.Application app = new Excel.Application();
            //在app中打开
            Excel._Workbook wbk = app.Workbooks.Open("C:\\Users\\86348\\Desktop\\saveFile\\SaveFileSourcePath.XLSX");
            //选中wbk中的第一个sheet
            Excel._Worksheet whs = wbk.Sheets[1];
            //激活whs
            whs.Activate();

            var usedRange = whs.UsedRange.CurrentRegion;
            //combo_url.Text = whs.Cells[1, 2].Text;
            //combo_url.Text=usedRange.Rows.Count.ToString();

            string sourcePath="";
            for (int i = 1; i <= 1 + usedRange.Rows.Count; i++)
            {
                //combo_url.Text = whs.Cells[i, 1].Text;
                if (whs.Cells[i, 1].Text == name)
                {
                    string savepath = @"C:\\Users\\86348\\Desktop\\saveFile\\Files";
                    //combo_url.Text = name;
                    //combo_url.Text = whs.Cells[i, 1].Text;
                    //先回到存的目录下，再循环找到文件，再移动。
                    DirectoryInfo root = new DirectoryInfo(savepath);
                    //DirectoryInfo[] dirs = root.GetDirectories();
                    FileInfo[] files = root.GetFiles();
                    //combo_url.Text = files[0].Name;
                    foreach (FileInfo file in files)
                    {
                        //combo_url.Text = file.Name;
                        if (file.Name == name)
                        {
                            sourcePath = whs.Cells[i, 2].Text;
                            doRecycleDel();
                            combo_url.Text = "C:\\Users\\86348\\Desktop\\saveFile\\Files";
                            combo_url_SelectedIndexChanged(null, null);
                            docopy();
                            dodelsave(sourcePath);
                            combo_url.Text = sourcePath;
                            combo_url_SelectedIndexChanged(null, null);
                        }
                    } 
                }
            }
            //关闭wbk
            wbk.Close();
            //退出Excel程序
            app.Quit();
        }

        private void doRecycleDel()
        {
            if (listView1.SelectedItems.Count == 0) return;
            try
            {
                for(int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    string fullname = listView1.SelectedItems[i].Tag.ToString();
                    if (File.Exists(fullname))
                        FileSystem.DeleteFile(fullname, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
                    else
                        if (Directory.Exists(fullname))
                            FileSystem.DeleteDirectory(fullname, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
                        else MessageBox.Show(fullname + ",删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
            combo_url_SelectedIndexChanged(null, null);
        }

        //只有我的电脑和收藏夹能打开--获取其路径打开
        private void OpenObj(ListViewItem listViewItem)
        {
            combo_url.Text = listViewItem.Tag.ToString();//得到路径
            combo_url_SelectedIndexChanged(null, null);//刷新进入
        }

        private void donew(string newtype)
        {
            string newname = "";
            string newext = "";
            switch (newtype)
            {
                case "folder":newname = "新建文件夹";break;
                case "word": newname = "新建word文档";newext=".doc" ; break;
                case "txt": newname = "新建文本文档"; newext = ".txt"; break;
                case "excel": newname = "新建excel文档"; newext = ".xls"; break;
                case "ppt": newname = "新建演示文稿"; newext = ".ppt"; break;
            }
            try
            {
                if (newtype.Equals("folder"))
                {
                    int i = 1;
                    string temp = newname;
                    while (Directory.Exists(Path.Combine(combo_url.Text, newname))) newname = temp + i++.ToString();
                    Directory.CreateDirectory(Path.Combine(combo_url.Text, newname));
                    ListViewItem lv=new ListViewItem(newname);
                    lv.Tag = Path.Combine(combo_url.Text, newname);
                    lv.ImageKey = "defaultfolder";
                    lv.IndentCount = 1;
                    lv.SubItems.Add("文件夹");
                    lv.SubItems.Add(DateTime.Now.ToString());
                    lv.SubItems.Add("");
                    lv.SubItems.Add(DateTime.Now.ToString());
                    listView1.Items.Add(lv);
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
                }
                else
                {
                    int i = 1;
                    string temp = newname;
                    newname += newext;
                    while (File.Exists(Path.Combine(combo_url.Text, newname))) newname = temp + i++.ToString()+newext;
                    File.Create(Path.Combine(combo_url.Text, newname));
                    ListViewItem lv = new ListViewItem(newname);
                    lv.Tag = Path.Combine(combo_url.Text, newname);
                    lv.ImageKey = GetFileIconKey(newext,Path.Combine(combo_url.Text,newname));
                    lv.IndentCount = 1;
                    string typename = geticon.GetTypeName(Path.Combine(combo_url.Text, newname));
                    lv.SubItems.Add(typename);
                    lv.SubItems.Add(DateTime.Now.ToString());
                    lv.SubItems.Add("");
                    lv.SubItems.Add(DateTime.Now.ToString());
                    listView1.Items.Add(lv);
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
            combo_url_SelectedIndexChanged(null, null);
        }

        private void showattr(string fullname)
        {
            //combo_url.Text = fullname;
            Form2 form = new Form2(fullname);
            form.ShowDialog();
        }

        private void dorename()
        {
            if (listView1.SelectedItems.Count == 0) return;
            string oldname = listView1.SelectedItems[0].SubItems[0].Text;
            if (oldname.Equals("我的电脑") || oldname.Equals("网络") || oldname.Equals("回收站")
                || oldname.Equals("我的文档"))
                return;
            listView1.LabelEdit = true;
            try
            {
                listView1.SelectedItems[0].BeginEdit();
            }
            catch(Exception e) { MessageBox.Show(e.Message); }
        }

        int totalDel=1;//最终要放在整个项目的全局文件下，否则每一次打开，都会更新
        private void dodelete()
        {
            try
            {
                if (listView1.SelectedItems.Count == 0) return;
                for(int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    string name = listView1.SelectedItems[i].Text;
                    //string fullname = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).ToString();

                    string fullname = listView1.SelectedItems[i].Tag.ToString();
                    string fullname_parent = Path.GetDirectoryName(fullname);
                    //combo_url.Text = fullname;
                    if (File.Exists(fullname))
                    {
                        docopy();
                        dodelsave("C:\\Users\\86348\\Desktop\\saveFile\\Files");//删除前存
                        //写原位置到表中
                        dataToExcel(totalDel, name, fullname_parent);
                        FileSystem.DeleteFile(fullname, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        totalDel++;
                    }
                    else 
                        if(Directory.Exists(fullname))
                            FileSystem.DeleteDirectory(fullname,UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        else MessageBox.Show(fullname + "，删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
            combo_url_SelectedIndexChanged(null, null);
        }

        void dataToExcel(int index,string name, string sourcePath)
        {
            //创建一个Excel程序
            Excel.Application app = new Excel.Application();
            //在app中打开
            Excel._Workbook wbk = app.Workbooks.Open("C:\\Users\\86348\\Desktop\\saveFile\\SaveFileSourcePath.XLSX");
            //选中wbk中的第一个sheet
            Excel._Worksheet whs = wbk.Sheets[1];
            //激活whs
            whs.Activate();

            whs.Cells[index, 1] = name;
            whs.Cells[index, 2] = sourcePath;

            wbk.Save();
            //关闭wbk
            wbk.Close();
            //退出Excel程序
            app.Quit();
        }



        private void dodelsave(string fullname)
        {
            string currpath = fullname;
            if (currpath.Equals("桌面")) currpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (copyobjs.Count == 0 || !Directory.Exists(currpath) || currpath.Equals(Directory.GetParent(copyobjs[0].ToString()).Name)) 
                return;
            for (int i = 0; i < copyobjs.Count; i++)
            {
                if (File.Exists(copyobjs[i].ToString())) copycut_file(copyobjs[i].ToString(), currpath);
                else if (Directory.Exists(copyobjs[i].ToString())) copycut_directory(copyobjs[i].ToString(), currpath);
            }
            if (iscut == true)
            {
                copyobjs.Clear();
            }
            combo_url_SelectedIndexChanged(null, null);
        }

        private void dopaste()
        {
            string currpath = combo_url.Text;
            if (currpath.Equals("桌面")) currpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (copyobjs.Count == 0 || !Directory.Exists(currpath) || currpath.Equals(Directory.GetParent(copyobjs[0].ToString()).Name)) return;
            for (int i = 0; i < copyobjs.Count; i++)
            {
                if (File.Exists(copyobjs[i].ToString())) copycut_file(copyobjs[i].ToString(), currpath);
                else if (Directory.Exists(copyobjs[i].ToString())) copycut_directory(copyobjs[i].ToString(), currpath);
            }
            if (iscut == true)
            {
                copyobjs.Clear();
            }
            combo_url_SelectedIndexChanged(null, null);
        }

        //在本地文件夹剪切并粘贴会直接删除
        private void copycut_directory(string s, string d)
        {
            try
            {
                DirectoryInfo sinfo = new DirectoryInfo(s);
                string dname = sinfo.Name;
                string destfullpath = Path.Combine(d, dname);
                DialogResult result = DialogResult.Yes;
                if (Directory.Exists(destfullpath))
                {
                    result = MessageBox.Show("目录“" + dname + "”已经存在，是否覆盖。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Directory.Delete(destfullpath,true);
                    }
                    else return;
                }
                DirectoryInfo dinfo = new DirectoryInfo(destfullpath);
                dinfo.Create();
                FileInfo[] files=sinfo.GetFiles();
                foreach(FileInfo file in files)
                {
                    file.CopyTo(Path.Combine(destfullpath, file.Name), true);
                }
                DirectoryInfo[] dirs = sinfo.GetDirectories();
                foreach(DirectoryInfo dir in dirs)
                {
                    copycut_directory(dir.FullName, destfullpath);
                }
                if (iscut == true) sinfo.Delete(true);
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void copycut_file(string fullname, string destpath)
        {
            try
            {
                FileInfo finfo = new FileInfo(fullname);
                string filename = finfo.Name;
                string currpath = destpath;
                string destfullname=Path.Combine(currpath, filename);
                DialogResult result = DialogResult.Yes;
                if (File.Exists(destfullname))
                    result = MessageBox.Show("文件“" + filename + "”已经存在，是否覆盖。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    finfo.CopyTo(destfullname, true);
                    if (iscut == true) File.Delete(fullname);
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void docout()
        {
            if(listView1.SelectedItems.Count==0) return;
            iscut = true;
            copyobjs.Clear();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
                copyobjs.Add(listView1.SelectedItems[i].Tag.ToString());
        }

        private void docopy()
        {
            if (listView1.SelectedItems.Count == 0) return;
            iscut = false;
            copyobjs.Clear();
            for(int i=0;i<listView1.SelectedItems.Count;i++)
                copyobjs.Add(listView1.SelectedItems[i].Tag.ToString());
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                if (e.Label.Trim() == "" || e.Label.Trim().Equals(listView1.Items[e.Item].SubItems[0].Text.Trim()))
                    e.CancelEdit = true;
                else
                {
                    string newname = e.Label.Trim();
                    try
                    {
                        if (File.Exists(listView1.Items[e.Item].Tag.ToString()))
                        {
                            if (File.Exists(Path.Combine(combo_url.Text, newname)))
                            {
                                MessageBox.Show("文件名已经存在，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.CancelEdit = true;
                            }
                            else
                            {
                                File.Move(listView1.Items[e.Item].Tag.ToString(), Path.Combine(combo_url.Text, newname));
                                listView1.Items[e.Item].Tag = Path.Combine(combo_url.Text, newname);
                            }
                        }
                        else
                            if (Directory.Exists(listView1.Items[e.Item].Tag.ToString()))
                        {
                            if (Directory.Exists(Path.Combine(combo_url.Text, newname)))
                            {
                                MessageBox.Show("文件夹已经存在，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.CancelEdit = true;
                            }
                            else
                            {
                                Directory.Move(listView1.Items[e.Item].Tag.ToString(), Path.Combine(combo_url.Text, newname));
                                listView1.Items[e.Item].Tag = Path.Combine(combo_url.Text, newname);
                            }
                        }
                    }
                    catch { }
                }
                listView1.LabelEdit = false;
            }
            catch { }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (text_search.Text.Trim().Equals(""))
            {
                combo_url_SelectedIndexChanged(null, null);
                return;
            }
            if (combo_url.Text.Equals("回收站"))
            {
                for(int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    string temp = listView1.Items[i].SubItems[0].Text.ToUpper();
                    if (temp.IndexOf(text_search.Text.Trim().ToUpper()) == -1) listView1.Items.RemoveAt(i);
                }
            }
            else
            {
                lb_searching.Visible = true;
                lb_objnum.Text = "0";
                statusStrip1.Refresh();
                listView1.Items.Clear();
                CreateCol_R();
                string topfolder = combo_url.Text;
                if (topfolder.Equals("我的电脑"))
                {
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    foreach (DriveInfo drive in drives)
                        if (drive.IsReady) doSearchFile(drive.Name, text_search.Text.Trim());
                }
                else
                    if (topfolder.Equals("收藏夹"))
                {
                    doSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), text_search.Text.Trim());
                    doSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), text_search.Text.Trim());
                    doSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), text_search.Text.Trim());
                    doSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), text_search.Text.Trim());
                }
                else
                    doSearchFile(topfolder, text_search.Text.Trim());
            }
            lb_objnum.Text = listView1.Items.Count.ToString();
            lb_searching.Visible = false;
        }

        private void doSearchFile(string topfolder, string content)
        {
            if (Directory.Exists(topfolder))
            {
                try
                {
                    string[] files = Directory.GetFiles(topfolder);
                    foreach (string f in files)
                    {
                        try
                        {
                            FileInfo finfo = new FileInfo(f);
                            if (finfo.Name.ToUpper().IndexOf(content.ToUpper()) != -1)
                            {
                                ListViewItem lv = new ListViewItem(finfo.Name);
                                lv.Tag = finfo.FullName;
                                lv.IndentCount = 1;
                                lv.ImageKey = GetFileIconKey(finfo.Extension, finfo.FullName);
                                string typename = geticon.GetTypeName(finfo.FullName);
                                lv.SubItems.Add(typename);
                                lv.SubItems.Add(finfo.FullName);
                                lv.SubItems.Add(finfo.LastWriteTime.ToString());
                                listView1.Items.Add(lv);
                            }
                        }
                        catch { }
                    }
                    string[] dirs = Directory.GetDirectories(topfolder);
                    foreach (string d in dirs) doSearchFile(d, content);
                }
                catch { }
            }
        }

        //我的电脑和回收站的路径获取不到
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string text = combo_url.Text;
            string fullname;
            switch (text)
            {
                case "桌面":
                    fullname = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); break;
                case "我的电脑":
                    fullname = ""; break;
                    //不需要在我的电脑排序？？？还有回收站
                    //没有Environment.SpecialFolder.Computer，默认返回空--stack overflow
                    //fullname = "computer"; break;
                    //可以试一试节点
                case "收藏夹":
                    fullname = Environment.GetFolderPath(Environment.SpecialFolder.Favorites); break;
                case "回收站":
                    //Shell shell = new Shell();
                    //Folder recycleBin = shell.NameSpace(10);
                    //combo_url.Text= recycleBin.ToString();
                    fullname = ""; break;
                default:
                    //普通文件可以这么用，特殊的像我的电脑之类的combo_url放的不是其路径
                    fullname = combo_url.Text;break;
            }
            if (fullname != "")
            {
                DirectoryInfo root = new DirectoryInfo(fullname);
                DirectoryInfo[] dirs = root.GetDirectories();
                FileInfo[] files = root.GetFiles();
                string a = listView1.Columns[e.Column].Text.ToString();

                listView1.Items.Clear();
                if (a == "名称")
                {
                    SortAsFileName(files, dirs);
                    DFshowListview1(files, dirs);
                }
                else if (a == "类型")
                {
                    SortAsFileType(files, dirs);
                    DFshowListview1(files, dirs);
                }
                else if ((a == "大小") || (a == "可用大小") || (a == "总大小"))
                {
                    SortAsFileContent(files);
                    DFshowListview1(files, dirs);
                }
                else if ((a == "创建时间") || (a == "创建日期"))
                {
                    SortAsFileCreateTime(files, dirs);
                    DFshowListview1(files, dirs);
                }
                else if (a == "修改时间")
                {
                    SortAsFileChangedTime(files, dirs);
                    DFshowListview1(files, dirs);
                }
                else//位置
                {
                    SortAsFileSite(files, dirs);
                    DFshowListview1(files, dirs);
                }
            }
            else
                combo_url_SelectedIndexChanged(null, null);

        }

        private void SortAsFileName(FileInfo[] files, DirectoryInfo[] dirs)
        {
            Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.Name.CompareTo(y.Name); });
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
        }

        private void SortAsFileType(FileInfo[] files, DirectoryInfo[] dirs)
        {
            Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.GetType().Name.CompareTo(y.GetType().Name); });
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.GetType().Name.CompareTo(y.GetType().Name); });
        }

        private void SortAsFileContent(FileInfo[] files)
        {
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.Length.CompareTo(y.Length); });
        }

        private void SortAsFileCreateTime(FileInfo[] files, DirectoryInfo[] dirs)
        {
            Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
        }

        private void SortAsFileChangedTime(FileInfo[] files, DirectoryInfo[] dirs)
        {
            Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.LastWriteTime.CompareTo(y.LastWriteTime); });
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.LastWriteTime.CompareTo(y.LastWriteTime); });
        }

        private void SortAsFileSite(FileInfo[] files, DirectoryInfo[] dirs)
        {
            Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y) { return x.FullName.CompareTo(y.FullName); });
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.FullName.CompareTo(y.FullName); });
        }

        private void DFshowListview1(FileInfo[] files,DirectoryInfo[] dirs)
        {
            foreach (DirectoryInfo dir in dirs)
            {
                try
                {
                    DirectoryInfo dinfo = dir;
                    ListViewItem lv = new ListViewItem(dinfo.Name);
                    lv.Tag = dinfo.FullName;
                    lv.ImageKey = "defaultfolder";
                    lv.SubItems.Add("文件夹");
                    lv.SubItems.Add(dinfo.LastWriteTime.ToString());
                    lv.SubItems.Add("");
                    lv.SubItems.Add(dinfo.CreationTime.ToString());
                    listView1.Items.Add(lv);
                }
                catch { }
            }
            foreach (FileInfo f in files)
            {
                try
                {
                    FileInfo finfo = f;
                    ListViewItem lv = new ListViewItem(finfo.Name);
                    lv.Tag = finfo.FullName;
                    lv.ImageKey = GetFileIconKey(finfo.Extension, finfo.FullName);
                    string typename = geticon.GetTypeName(finfo.FullName);//为什么类型名显示不完整
                    lv.SubItems.Add(typename);

                    lv.SubItems.Add(finfo.LastWriteTime.ToString());
                    long size = finfo.Length;
                    string sizestring = "";
                    if (size < 1024) sizestring = size.ToString() + "Byte";
                    else sizestring = (size / 1024).ToString() + "KB";
                    lv.SubItems.Add(sizestring);

                    lv.SubItems.Add(finfo.CreationTime.ToString());
                    listView1.Items.Add(lv);
                }
                catch { }
            }
            lb_objnum.Text = listView1.Items.Count.ToString();
        }

    }
}
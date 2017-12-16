namespace FileExplorer
{
    partial class Form1
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Files", System.Windows.Forms.HorizontalAlignment.Left);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.filelistView = new System.Windows.Forms.ListView();
            this.file_name_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.readonly_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.temp_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hidden_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size_col = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.path_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fswatcher = new System.IO.FileSystemWatcher();
            this.DeleteFiles_timer = new System.Windows.Forms.Timer(this.components);
            this.ClearColor_timer = new System.Windows.Forms.Timer(this.components);
            this.preview_btn = new System.Windows.Forms.RadioButton();
            this.menuButton1 = new FileExplorer.MenuButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(197, 417);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // filelistView
            // 
            this.filelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file_name_col,
            this.date_col,
            this.readonly_col,
            this.temp_col,
            this.hidden_col,
            this.size_col});
            this.filelistView.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Folders";
            listViewGroup1.Name = "folder_grp";
            listViewGroup2.Header = "Files";
            listViewGroup2.Name = "files_grp";
            this.filelistView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.filelistView.Location = new System.Drawing.Point(197, 0);
            this.filelistView.Name = "filelistView";
            this.filelistView.Size = new System.Drawing.Size(537, 417);
            this.filelistView.TabIndex = 1;
            this.filelistView.UseCompatibleStateImageBehavior = false;
            this.filelistView.View = System.Windows.Forms.View.Details;
            this.filelistView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filelistView_MouseClick);
            this.filelistView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filelistView_MouseDoubleClick);
            // 
            // file_name_col
            // 
            this.file_name_col.Text = "File Name";
            this.file_name_col.Width = 200;
            // 
            // date_col
            // 
            this.date_col.Text = "Date Modified";
            this.date_col.Width = 130;
            // 
            // readonly_col
            // 
            this.readonly_col.Text = "Read Only";
            this.readonly_col.Width = 80;
            // 
            // temp_col
            // 
            this.temp_col.Text = "Temporary";
            this.temp_col.Width = 70;
            // 
            // hidden_col
            // 
            this.hidden_col.Text = "Hidden";
            // 
            // size_col
            // 
            this.size_col.Text = "Size";
            this.size_col.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.filelistView);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 417);
            this.panel1.TabIndex = 2;
            // 
            // path_txt
            // 
            this.path_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path_txt.Location = new System.Drawing.Point(0, 24);
            this.path_txt.Name = "path_txt";
            this.path_txt.Size = new System.Drawing.Size(731, 20);
            this.path_txt.TabIndex = 3;
            this.path_txt.Text = "Computer";
            this.path_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.path_txt_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.preview_btn);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.menuButton1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.path_txt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 47);
            this.panel2.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Up";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 92);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "Text file";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "Rich Text Format file";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem3.Text = "Word Document";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem4.Text = "Custom";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "New Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 44);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(729, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 5;
            // 
            // fswatcher
            // 
            this.fswatcher.EnableRaisingEvents = true;
            this.fswatcher.SynchronizingObject = this;
            // 
            // DeleteFiles_timer
            // 
            this.DeleteFiles_timer.Interval = 1000;
            this.DeleteFiles_timer.Tick += new System.EventHandler(this.DeleteFiles_timer_Tick);
            // 
            // ClearColor_timer
            // 
            this.ClearColor_timer.Interval = 1000;
            this.ClearColor_timer.Tick += new System.EventHandler(this.ClearColor_timer_Tick);
            // 
            // preview_btn
            // 
            this.preview_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.preview_btn.Appearance = System.Windows.Forms.Appearance.Button;
            this.preview_btn.AutoCheck = false;
            this.preview_btn.Location = new System.Drawing.Point(665, 0);
            this.preview_btn.Name = "preview_btn";
            this.preview_btn.Size = new System.Drawing.Size(57, 23);
            this.preview_btn.TabIndex = 9;
            this.preview_btn.TabStop = true;
            this.preview_btn.Text = "Preview";
            this.preview_btn.UseVisualStyleBackColor = true;
            this.preview_btn.CheckedChanged += new System.EventHandler(this.preview_btn_CheckedChanged);
            this.preview_btn.Click += new System.EventHandler(this.preview_btn_Click);
            // 
            // menuButton1
            // 
            this.menuButton1.Location = new System.Drawing.Point(189, 0);
            this.menuButton1.Menu = this.contextMenuStrip1;
            this.menuButton1.Name = "menuButton1";
            this.menuButton1.Size = new System.Drawing.Size(75, 23);
            this.menuButton1.TabIndex = 7;
            this.menuButton1.Text = "New File";
            this.menuButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fswatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView filelistView;
        private System.Windows.Forms.ColumnHeader file_name_col;
        private System.Windows.Forms.ColumnHeader date_col;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox path_txt;
        private System.Windows.Forms.ColumnHeader hidden_col;
        private System.Windows.Forms.ColumnHeader size_col;
        private System.Windows.Forms.ColumnHeader readonly_col;
        private System.Windows.Forms.ColumnHeader temp_col;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private MenuButton menuButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.IO.FileSystemWatcher fswatcher;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer DeleteFiles_timer;
        private System.Windows.Forms.Timer ClearColor_timer;
        private System.Windows.Forms.RadioButton preview_btn;
    }
}


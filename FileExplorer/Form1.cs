using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            prev = new Previewform(this);
        }

        Previewform prev;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Get logical drive list
            foreach (var item in Directory.GetLogicalDrives())
            {
                treeView1.Nodes.Add(item[0] + ":");
                treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add("*");
                filelistView.Items.Add(item[0] + ":");
                filelistView.Items[filelistView.Items.Count - 1].Group = filelistView.Groups[0];
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // List directories inside a directory in the treeview
            List<string> files = new List<string>();
            string path = e.Node.FullPath + "\\";
            e.Node.Nodes.Clear();
            treeView1.SelectedNode = e.Node;
            try
            {
                if (Directory.Exists(path))
                {
                    files.AddRange(Directory.EnumerateDirectories(path));
                    string[] buff = null;
                    for (int i = 0; i < files.Count; i++)
                    {
                        buff = files[i].Split('\\');
                        e.Node.Nodes.Add(buff[buff.Length - 1]);
                        e.Node.Nodes[e.Node.Nodes.Count - 1].Nodes.Add("*");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not list files in the given directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Open folder in Windows Explorer
            OpenFileFolder(e.Node.FullPath);
        }
        private void ExpandTreeViewPath(TreeNode node, List<string> path)
        {
            path.RemoveAt(0);
            node.Expand();
            if (path.Count == 0 || string.IsNullOrWhiteSpace(path[0]))
            {
                treeView1.SelectedNode = node;
                return;
            }
            foreach (TreeNode mynode in node.Nodes)
                if (mynode.Text == path[0])
                    ExpandTreeViewPath(mynode, path); //recursive call
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Update listview with new selected dir's content
            filelistView.Items.Clear();
            string path = "";
            try
            {
                path = e.Node.FullPath;
                if (Directory.Exists(path + "\\"))
                {
                    UpdateFileFolerListView(path);                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open the requested file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void path_txt_KeyDown(object sender, KeyEventArgs e)
        {
            // Go to path on 'ENTER' press
            if(e.KeyData == Keys.Enter)
            {
                string path = path_txt.Text;
                filelistView.Items.Clear();
                try
                {
                    if (Directory.Exists(path))
                    {
                        UpdateTreeView(path);
                        UpdateFileFolerListView(path);
                    }
                    else if (File.Exists(path))
                        System.Diagnostics.Process.Start(path);
                }
                catch (Exception)
                {
                    MessageBox.Show("The system could not find the path specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void filelistView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Execute file or open directory
            string path;
            if (path_txt.Text == "Computer")
                path = treeView1.SelectedNode.FullPath.Substring(0, 2);
            else
                path = $"{treeView1.SelectedNode.FullPath}\\{filelistView.SelectedItems[0].SubItems[0].Text}";
            if (File.Exists(path))
                OpenFileFolder(path);
            else if(Directory.Exists($"{path}\\"))
            {
                UpdateFileFolerListView(path);
                UpdateTreeView($"{path}\\");
            }
        }
        /// <summary>
        /// Updates the listview with the contents of a directory at the given path.
        /// </summary>
        /// <param name="path">Path to directory</param>
        private void UpdateFileFolerListView(string path)
        {
            ClearColor_timer.Stop();
            DeleteFiles_timer.Stop();
            if(!path.EndsWith("\\"))
                path += "\\";
            path_txt.Text = path;
            FileAttributes atrib;
            string[] buff;
            ListViewItem lvi;
            filelistView.Items.Clear();
            //Files
            try
            {
                foreach (string item in Directory.EnumerateFiles(path))
                {
                    buff = item.Split('\\');
                    lvi = new ListViewItem(buff[buff.Length - 1]);
                    try
                    {
                        lvi.SubItems.Add(File.GetLastAccessTime(item).ToString());
                        atrib = File.GetAttributes(item);
                        lvi.SubItems.Add(atrib.HasFlag(FileAttributes.ReadOnly).ToString());
                        lvi.SubItems.Add(atrib.HasFlag(FileAttributes.Temporary).ToString());
                        lvi.SubItems.Add(atrib.HasFlag(FileAttributes.Hidden).ToString());
                        lvi.SubItems.Add(((new FileInfo(item)).Length / 1000.0).ToString() + " KB");
                        lvi.BackColor = Color.White;
                    }
                    catch (Exception)
                    {
                        lvi.Text = "!#Error";
                    }
                    filelistView.Items.Add(lvi);
                    filelistView.Items[filelistView.Items.Count - 1].Group = filelistView.Groups[1];
                }
                DirectoryInfo dirinfo;
                //Folders
                foreach (string item in Directory.EnumerateDirectories(path))
                {
                    buff = item.Split('\\');
                    lvi = new ListViewItem(buff[buff.Length - 1]);
                    try
                    {
                        lvi.SubItems.Add(Directory.GetLastAccessTime(item).ToString());
                        dirinfo = new DirectoryInfo(item);
                        lvi.SubItems.Add(dirinfo.Attributes.HasFlag(FileAttributes.ReadOnly).ToString());
                        lvi.SubItems.Add(dirinfo.Attributes.HasFlag(FileAttributes.Temporary).ToString());
                        lvi.SubItems.Add(dirinfo.Attributes.HasFlag(FileAttributes.Hidden).ToString());
                        lvi.BackColor = Color.White;
                    }
                    catch (Exception)
                    {
                        lvi.Text = "!#Error";
                    }
                    filelistView.Items.Add(lvi);
                    filelistView.Items[filelistView.Items.Count - 1].Group = filelistView.Groups[0];
                }
                // Setup the file system watcher
                fswatcher.Dispose();
                fswatcher = new FileSystemWatcher(path)
                {
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.DirectoryName| NotifyFilters.Attributes | NotifyFilters.Size,
                    Filter = "*.*",
                    EnableRaisingEvents = true
                };
                fswatcher.Created += Fswatcher_DoUpdate;
                fswatcher.Deleted += Fswatcher_DoUpdate;
                fswatcher.Renamed += Fswatcher_DoUpdate;
                fswatcher.Changed += Fswatcher_DoUpdate;
            }
            catch (Exception)
            {
                fswatcher.Dispose();
                MessageBox.Show("Could not complete the operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fswatcher_DoUpdate(object sender, FileSystemEventArgs e)
        {
            BeginInvoke(new Action( () => fsChanged(e) ));
        }

        private void fsChanged(FileSystemEventArgs e)
        {
            // Does all the color stuff
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                DeleteFiles_timer.Stop();
                foreach (ListViewItem item in filelistView.Items)
                    if (item.Text == e.Name)
                        item.BackColor = Color.Red;
                DeleteFiles_timer.Start();
                return;
            }
            ClearColor_timer.Stop();
            if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Renamed)
                UpdateFileFolerListView(path_txt.Text);
            foreach (ListViewItem item in filelistView.Items)
                if (item.Text == e.Name && item.BackColor == Color.White)
                {
                    if (e.ChangeType == WatcherChangeTypes.Created)
                        item.BackColor = Color.LightGreen;
                    else if (e.ChangeType == WatcherChangeTypes.Changed)
                        item.BackColor = Color.Yellow;
                    else if (e.ChangeType == WatcherChangeTypes.Renamed)
                        item.BackColor = Color.Yellow;
                }
            ClearColor_timer.Start();
        }
        /// <summary>
        /// Updates the treeview to show a certain path
        /// </summary>
        /// <param name="path"></param>
        private void UpdateTreeView(string path)
        {
            if (!path.EndsWith("\\"))
                path += "\\";
            var path_list = path.Split('\\').ToList();
            foreach (TreeNode node in treeView1.Nodes)
                if (node.Text == path_list[0])
                    ExpandTreeViewPath(node, path_list);
        }
        /// <summary>
        /// If path is a file, executes the file, if it's a folder, opens the folder in Windwos Explorer
        /// </summary>
        /// <param name="path"></param>
        private void OpenFileFolder(string path)
        {
            try
            {
                if (Directory.Exists(path + "\\"))
                    System.Diagnostics.Process.Start(path + "\\");
                else
                    System.Diagnostics.Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open the requested file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void path_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string ext = "";
            switch (e.ClickedItem.Text)
            {
                case "Text file":
                    ext = "txt";
                    break;
                case "Rich Text Format file":
                    ext = "rtf";
                    break;
                case "Word Document":
                    ext = "docx";
                    break;
                case "Custom":
                    ext = null;
                    break;
                default:
                    return;
            }
            var dialog = new NewFileDialog(ext, path_txt.Text);
            dialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Delete selected files and folders
            if (filelistView.SelectedItems.Count < 1)
                return;
            string path;
            foreach (ListViewItem item in filelistView.SelectedItems)
            {
                path = path_txt.Text + item.SubItems[0].Text;
                if (Directory.Exists(path))
                {
                    try
                    {
                        Directory.Delete(path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Could not delete the folder: {item.SubItems[0].Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Could not delete the file: {item.SubItems[0].Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // New folder
            var dialog = new NewFileDialog("\\", path_txt.Text);
            dialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // cd ..
            try
            {
                string path = $"{treeView1.SelectedNode.Parent.FullPath}\\";
                UpdateFileFolerListView(path);
                treeView1.SelectedNode.Collapse();
                treeView1.SelectedNode = treeView1.SelectedNode.Parent;
            }
            catch { }
        }

        private void DeleteFiles_timer_Tick(object sender, EventArgs e)
        {
            // removes all red colored items from the list
            foreach (ListViewItem item in filelistView.Items)
                if (item.BackColor == Color.Red)
                    filelistView.Items.Remove(item);
        }

        private void ClearColor_timer_Tick(object sender, EventArgs e)
        {
            // Clears the color of green and yellow colored items
            foreach (ListViewItem item in filelistView.Items)
                if (item.BackColor == Color.LightGreen || item.BackColor == Color.Yellow )
                    item.BackColor = Color.White;
        }
        private void preview_btn_Click(object sender, EventArgs e)
        {
            if (preview_btn.Checked)
                preview_btn.Checked = false;
            else
                preview_btn.Checked = true;
        }

        private void filelistView_MouseClick(object sender, MouseEventArgs e)
        {
            if (preview_btn.Checked) // update preview if it's enabled 
            {
                try
                {
                    prev.preview_txt.Text = File.ReadAllText(path_txt.Text + filelistView.SelectedItems[0].Text);
                    prev.PrintHexDump(File.ReadAllBytes(path_txt.Text + filelistView.SelectedItems[0].Text));
                }
                catch
                {
                    prev.preview_txt.Text = "Could not load preview for the selected item.";
                    prev.hex_prev_txt.Text = "Could not load preview for the selected item.";
                }
            }
        }

        private void preview_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (preview_btn.Checked)
                prev.Show();
            else
                prev.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27._01._21_Log4netInserter
{
    public partial class Form1 : Form
    {
        const string PATh_TO_THE_PATH_SAVING_FILE = "_pathToTheProject.txt";
        private FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();

        private string _txtPathToTheProjectText;

        //public event EventHandler<FilterByExtensionEventArgs> FilterByExtensionEvent;

        public FilterByExtensionHelper IsFilterByExpension { get; set; }

        private decimal IterationsCount { get; set; } = 0;
        private List<string> TakeFileSystem { get; set; }


        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            lblInfoOutput.Text = string.Empty;
            lblInfoOutput.Font = new Font("Arial", 8, System.Drawing.FontStyle.Bold);
            lblInfoOutput.Padding = new Padding(4);
            lblInfoOutput.TextAlign = ContentAlignment.MiddleCenter;
            lblInfoOutput.drawBorder(4, Color.DarkBlue);

            cmbFilterByExtension.Enabled = chkFilterByExtension.Checked;
            cmbFilterByExtension.Items.Add("*.cs");
            cmbFilterByExtension.Items.Add("*.js");
            cmbFilterByExtension.SelectedIndex = 0;

            chkFilterByExtension.CheckedChanged += (object sender, EventArgs e) =>
            {
                cmbFilterByExtension.Enabled = (sender as CheckBox).Checked;
                this.IsFilterByExpension.IsToFilter = (sender as CheckBox).Checked;
            };
            cmbFilterByExtension.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                /*FilterByExtensionEvent?.Invoke(this, new FilterByExtensionEventArgs {
                    IsToFilter = true, TheExtension = (string)(sender as ComboBox).SelectedItem
                    });*/
                this.IsFilterByExpension = new FilterByExtensionHelper(chkFilterByExtension.Checked, (string)(sender as ComboBox).SelectedItem);
                MessageBox.Show($"{IsFilterByExpension.IsToFilter}\n{IsFilterByExpension.TheExtension}");
            };
            IsFilterByExpension = new FilterByExtensionHelper(true, (string)this.cmbFilterByExtension.Items[0]);
            chkFilterByExtension.Checked = true;

            if (File.Exists(PATh_TO_THE_PATH_SAVING_FILE))
            {
                _txtPathToTheProjectText = File.ReadAllText(PATh_TO_THE_PATH_SAVING_FILE);
                txtPathToTheProject.Text = _txtPathToTheProjectText;

            }

            btnGetPathToTheProject.Click += (object sender, EventArgs e) =>
            {
                _folderBrowserDialog.SelectedPath = txtPathToTheProject.Text;
                _folderBrowserDialog.ShowDialog();
                txtPathToTheProject.Text = _folderBrowserDialog.SelectedPath;
                File.WriteAllText("_pathToTheProject.txt", txtPathToTheProject.Text);
            };


            btnProcess.Click += async (object sender, EventArgs e) =>
            {
                Timer timer = new Timer();
                timer.Interval = 1;
                int timeCount = 0;
                timer.Tick += (object senderTimer, EventArgs eTimer) =>
                {
                    lblInfoOutput.Text = $"Please wait {timeCount} miliseconds, the system gather you files\n";
                    timeCount++;
                };
                timer.Start();

                Branch rootBranch = new Branch(txtPathToTheProject.Text);
                rootBranch.IsFilterByExpension = this.IsFilterByExpension;
                rootBranch = await GetFilesAndDirectories(rootBranch);


                //TakeFileSystem = await rootBranch.AllChildrenToString("");
                Task<List<string>> tsk = rootBranch.AllChildrenToString("");
                TakeFileSystem = await tsk;
                if (tsk.IsCompleted)
                {
                    timer.Stop();
                    lblInfoOutput.Text = $"Completed in {timeCount} miliseconds";
                }



                int inserterTasksCount = 0;
                Timer timer2 = new Timer();
                timer2.Interval = 1;
                timer2.Tick += (object senderTimer, EventArgs eTimer) =>
                {
                    lblInfoOutput.Text = $"{inserterTasksCount} of your files are processed\n";
                };
                timer2.Start();
                foreach (string s in TakeFileSystem)
                {
                    if (!TakeFileSystem.Contains("_new_"))
                    {
                        Task inserterTask = Task.Run(() =>
                        {
                            Inserter inserter = new Inserter(s);
                            inserter.Insert(s);
                        });

                        await inserterTask;
                        if (inserterTask.IsCompleted)
                            inserterTasksCount++;

                    }

                }




                if (inserterTasksCount == TakeFileSystem.Count)
                {
                    timer2.Stop();
                    lblInfoOutput.Text = $"{inserterTasksCount} files finishedd\n";
                }

            };









            txtPathToTheProject.TextChanged += (object sender, EventArgs e) =>
            {
                _txtPathToTheProjectText = (sender as TextBox).Text;
            };
            Application.ApplicationExit += (object sender, EventArgs e) =>
            {
                File.WriteAllText("_pathToTheProject.txt", _txtPathToTheProjectText);
            };
        }






        private async Task<Branch> GetFilesAndDirectories(Branch rootBranch)
        {
            IterationsCount++;
            return await Task.Run(async () =>
            {
                string[] files = Directory.GetFiles(rootBranch.FileOrDirectory);
                string[] folders = Directory.GetDirectories(rootBranch.FileOrDirectory);



                foreach (string s in files)
                {
                    rootBranch.AddChild(new Leaf(s));
                }

                foreach (string s in folders)
                {
                    Branch branch = new Branch(s);
                    branch.IsFilterByExpension = this.IsFilterByExpension;
                    try
                    {

                        branch = await GetFilesAndDirectories(branch);
                        //branch.LengthOfFileOrDirectory = branch.GetSize();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    rootBranch.AddChild(branch);
                    //rootBranch.LengthOfFileOrDirectory = rootBranch.GetSize();

                }

                return rootBranch;
            });
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S1084_AutoRelease
{
    public partial class AddSubProject : Form
    {
        public string name = "";
        public string outputType = "";
        public string outputPath = "";
        public string versionPath = "";
        public string releasesPath = "";
        public string archivePath = "";

        public AddSubProject()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            name = ProjectNameTextBox.Text;
            outputType = OutputTypeTextBox.Text;
            outputPath = OutputPathTextBox.Text;
            versionPath = VersionPathTextBox.Text;
            releasesPath = ReleasesPathTextBox.Text;
            archivePath = ArchivePathTextBox.Text;

            if (name == "Please enter name")
            {
                MessageBox.Show("Please enter the Sxxxx name for the sub-project");
                return;
            }
            //Please enter a.extension
            if (outputType == "Please enter a.extension")
            {
                MessageBox.Show("Please enter a valid file extension, including the dot [EG .bin]");
                return;
            }

            if ((outputPath == "Please enter path") ||
                (versionPath == "Please enter path") ||
                (releasesPath == "Please enter path") ||
                (archivePath == "Please enter path"))
            {
                MessageBox.Show("Please enter a valid directory path [C:\\...]");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

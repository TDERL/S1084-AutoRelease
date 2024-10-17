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
        public string number = "Please enter number";
        public string shortName = "";
        public string platform = "";
        public string description = "";
        public string outputType = "Please enter a .extension";
        public string outputPath = "Please enter path";
        public string versionPath = "Please enter path";
        public string releasesPath = "Please enter path";
        public string archivePath = "Please enter path";

        public AddSubProject()
        {
            InitializeComponent();
        }
        public void Refresh()
        {
            SoftwareNumberTextBox.Text = number;
            SoftwareNameTextBox.Text = shortName;
            PlaftormTextBox.Text = platform;
            DescriptionTextBox.Text = description;
            OutputTypeTextBox.Text = outputType;
            OutputPathTextBox.Text = outputPath;
            VersionPathTextBox.Text = versionPath;
            ReleasesPathTextBox.Text = releasesPath;
            ArchivePathTextBox.Text = archivePath;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            number = SoftwareNumberTextBox.Text;
            shortName = SoftwareNameTextBox.Text;
            platform = PlaftormTextBox.Text;
            description = DescriptionTextBox.Text;
            outputType = OutputTypeTextBox.Text;
            outputPath = OutputPathTextBox.Text;
            versionPath = VersionPathTextBox.Text;
            releasesPath = ReleasesPathTextBox.Text;
            archivePath = ArchivePathTextBox.Text;

            if (number == "Please enter number")
            {
                MessageBox.Show("Please enter the Sxxxx number for the sub-project (and ONLY the Sxxxx number)");
                return;
            }

            //Please enter a.extension
            if (outputType == "Please enter a .extension")
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

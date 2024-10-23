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
using System.Xml;

namespace S1084_AutoRelease
{
    public partial class AddSubProject : Form
    {
        public string number = "";
        public string shortName = "";
        public string platform = "";
        public string description = "";
        public string outputType = "Please enter a .extension";
        public string outputPath = "Please enter path";
        public string active = "inactive";

        public AddSubProject(string number)
        {
            InitializeComponent();
            SoftwareNumberLabel.Text = number;
            this.number = number;
        }
        public void Refresh()
        {
            SoftwareNumberLabel.Text = number;
            SoftwareNameTextBox.Text = shortName;
            PlaftormTextBox.Text = platform;
            DescriptionTextBox.Text = description;
            OutputTypeTextBox.Text = outputType;
            OutputPathTextBox.Text = outputPath;

            if (active == "inactive")
                ActiveCheckBox.Checked = false;
            else
                ActiveCheckBox.Checked = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            number = SoftwareNumberLabel.Text;
            shortName = SoftwareNameTextBox.Text;
            platform = PlaftormTextBox.Text;
            description = DescriptionTextBox.Text;
            outputType = OutputTypeTextBox.Text;
            outputPath = OutputPathTextBox.Text;

            if (ActiveCheckBox.Checked == false)
                active = "inactive";
            else
                active = "active";

            if (number == "Please enter number")
            {
                MessageBox.Show("Please enter the Sxxxx number for the sub-project (and ONLY the Sxxxx number)");
                return;
            }

            //Please enter a.extension
            if (outputType == "")
            {
                MessageBox.Show("Please enter a valid file extension, including the dot [EG .bin]");
                return;
            }

            if (outputPath == "")
            {
                MessageBox.Show("Please enter a valid directory path [C:\\...]");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}

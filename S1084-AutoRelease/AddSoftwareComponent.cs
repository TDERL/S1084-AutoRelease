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
    public partial class AddSoftwareComponent : Form
    {
        public string number = "S";
        public string shortName = "";
        public string platform = "";
        public string description = "";
        public string active = "inactive";

        public AddSoftwareComponent()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            SoftwareNumberTextBox.Text = number;
            SoftwareNameTextBox.Text = shortName;
            PlaftormTextBox.Text = platform;
            DescriptionTextBox.Text = description;

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
            number = SoftwareNumberTextBox.Text;
            shortName = SoftwareNameTextBox.Text;
            platform = PlaftormTextBox.Text;
            description = DescriptionTextBox.Text;

            if (ActiveCheckBox.Checked == false)
                active = "inactive";
            else
                active = "active";

            if (number == "S")
            {
                MessageBox.Show("Please enter the Sxxxx number for the sub-project (and ONLY the Sxxxx number)");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}

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
    public partial class AddHardwareComponent : Form
    {
        public string number = "EDA";
        public string shortName = "";
        public string description = "";
        public string active = "inactive";

        public AddHardwareComponent()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            HardwareNumberTextBox.Text = number;
            HardwareNameTextBox.Text = shortName;
            HWDescriptionTextBox.Text = description;

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
            number = HardwareNumberTextBox.Text;
            shortName = HardwareNameTextBox.Text;
            description = HWDescriptionTextBox.Text;

            if (ActiveCheckBox.Checked == false)
                active = "inactive";
            else
                active = "active";

            if (number == "EDA")
            {
                MessageBox.Show("Please enter the EDAxxxx number for the PCB Assembly");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}

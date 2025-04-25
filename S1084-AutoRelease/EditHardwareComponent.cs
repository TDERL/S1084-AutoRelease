using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace S1084_AutoRelease
{
    internal class EditHardwareComponent
    {
        public EditHardwareComponent(XmlDocument db, string projectName)
        {
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("HardwareProjects")[0];
            AddHardwareComponent EDAxxxx = new AddHardwareComponent();
            XmlNode node = SoftwareProjects.GetElementsByTagName(projectName)[0];
            EDAxxxx.number = node.Name;
            EDAxxxx.shortName = node.Attributes["shortName"].Value;
            EDAxxxx.active = node.Attributes["active"].Value;
            EDAxxxx.description = node.InnerText;
            EDAxxxx.Refresh();

            var result = EDAxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                node.Attributes["shortName"].Value = EDAxxxx.shortName;
                node.Attributes["active"].Value = EDAxxxx.active;
                node.InnerText = EDAxxxx.description;
                db.Save(db.DocumentElement.GetAttribute("path"));
            }
        }
    }

}

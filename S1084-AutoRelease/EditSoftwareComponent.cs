﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace S1084_AutoRelease
{
    internal class EditSoftwareComponent
    {
        public EditSoftwareComponent(XmlDocument db, string projectName)
        {
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];
//            AddSoftwareComponent Sxxxx = new AddSoftwareComponent(projectName);
            AddSoftwareComponent Sxxxx = new AddSoftwareComponent();
            XmlNode node = SoftwareProjects.GetElementsByTagName(projectName)[0];
            Sxxxx.number = node.Name;
            Sxxxx.shortName = node.Attributes["shortName"].Value;
            Sxxxx.platform = node.Attributes["platform"].Value;
            Sxxxx.active = node.Attributes["active"].Value;
            Sxxxx.description = node.InnerText;
            Sxxxx.Refresh();

            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                node.Attributes["shortName"].Value = Sxxxx.shortName;
                node.Attributes["platform"].Value = Sxxxx.platform;
                node.Attributes["active"].Value = Sxxxx.active;
                node.InnerText = Sxxxx.description;
                db.Save(db.DocumentElement.GetAttribute("path"));
            }
        }
    }

}

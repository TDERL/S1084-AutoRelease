using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace S1084_AutoRelease
{
    internal partial class EditSubProject
    {
        public EditSubProject(XmlDocument db, string projectName)
        {
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];
            AddSubProject Sxxxx = new AddSubProject(projectName);
            XmlNode node = SoftwareProjects.GetElementsByTagName(projectName)[0];
            Sxxxx.number = node.Name;
            Sxxxx.shortName = node.Attributes["shortName"].Value;
            Sxxxx.platform = node.Attributes["platform"].Value;
            Sxxxx.outputType = node.Attributes["outputType"].Value;
            Sxxxx.outputPath = node.Attributes["outputPath"].Value;
            Sxxxx.versionPath = node.Attributes["versionPath"].Value;
            Sxxxx.releasesPath = node.Attributes["releasesPath"].Value;
            Sxxxx.archivePath = node.Attributes["archivePath"].Value;
            Sxxxx.description = node.InnerText;
            Sxxxx.Refresh();

            var result = Sxxxx.ShowDialog();
            if (result == DialogResult.OK)
            {
                node.Attributes["shortName"].Value = Sxxxx.shortName;
                node.Attributes["platform"].Value = Sxxxx.platform;
                node.Attributes["outputType"].Value = Sxxxx.outputType;
                node.Attributes["outputPath"].Value = Sxxxx.outputPath;
                node.Attributes["versionPath"].Value = Sxxxx.versionPath;
                node.Attributes["releasesPath"].Value = Sxxxx.releasesPath;
                node.Attributes["archivePath"].Value = Sxxxx.archivePath;
                node.InnerText = Sxxxx.description;
                db.Save(db.DocumentElement.GetAttribute("path"));
            }
        }
    }

}

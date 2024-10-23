using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace S1084_AutoRelease
{
    internal class Paths
    {
        XmlDocument db;
        public Paths(XmlDocument db)
        {
            this.db = db;
        }
        public string GetBase()
        {
            string basePath = db.GetElementsByTagName("S1084")[0].Attributes["path"].Value;
            string[] temp = basePath.Split('\\');
            basePath = "";
            for (int i = 0; i < (temp.Length - 1); i++)
                basePath += temp[i] + "\\";

            return basePath;
        }
        public string GetProject(string projectName)
        {
            string desc = db.GetElementsByTagName(projectName)[0].Attributes["desName"].Value;
            string projectPath = GetBase() + projectName + " - " + desc + "\\";
            return projectPath;
        }
        public string GetReleases(string projectName)
        {
            string releasesPath = GetProject(projectName) + "Releases\\";
            return releasesPath;
        }
    }
}

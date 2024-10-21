using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace S1084_AutoRelease
{
    internal class GenerateReport
    {
        public GenerateReport(XmlDocument db, string projectName)
        {
            XmlElement project = (XmlElement)db.GetElementsByTagName(projectName)[0];
            XmlElement software = (XmlElement)project.GetElementsByTagName("Software")[0];
            XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];

            string path = sprints.GetAttribute("reportPath");
            path += '\\';
            int noOfSprints = sprints.ChildNodes.Count;
            string reportName = projectName + "_" + sprints.ChildNodes[noOfSprints - 1].Name;

            using (FileStream fs = new FileStream(path + reportName + ".html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs))
                {
                    XmlNode node = db.SelectSingleNode("Project");
                    w.WriteLine("<!DOCTYPE html>");
                    w.WriteLine("<html>");
                    w.WriteLine("<style>");
                    w.WriteLine("table, th, td {border:1px solid black; border-collapse: collapse; border-color: #96D4D4;}");
                    w.WriteLine("tr:hover {background-color: #D6EEEE;}");
                    w.WriteLine("td {text-align: center;}");
                    w.WriteLine("th {background-color: #D6EEEE;}");
                    w.WriteLine("</style>");
                    w.WriteLine("<body style=\"font-family: verdana\">");
                    w.WriteLine("<h3 style=\"color:orange \">" + projectName + " - " + project.Attributes["desName"].Value + "</h3>");
                    w.WriteLine("<table>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Project: </th><th>" + projectName + " - " + project.Attributes["desName"].Value + "</th></tr>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Date, Time: </th><th><span id='date'></span>, <span id='time'></span></th></tr>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Reporter: </th><th>" + Environment.UserName + "</th></tr>");
              //      w.WriteLine("<tr><th style=\"padding:8px\">Micro: </th><th>" + node.Attributes["micro"].Value + "</th></tr>");
                    w.WriteLine("</table>");
                    w.WriteLine("<h2 style=\"color:orange \">IO Allocation</h2>");



                    w.WriteLine("");
                    w.WriteLine("<script> var dt = new Date(); let d = dt.toLocaleDateString(); let t = dt.toLocaleTimeString();");
                    w.WriteLine("document.getElementById('date').innerHTML = d; document.getElementById('time').innerHTML = t; </script >");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }
            }
        }
    }
}

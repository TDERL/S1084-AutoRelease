﻿using System;
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
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            string path = sprints.GetAttribute("reportPath");
            path += '\\';
            int noOfSprints = sprints.ChildNodes.Count;
            string reportName = projectName + "_" + sprints.ChildNodes[noOfSprints - 1].Name;

            int total = 0;
            int completed = 0;
            foreach (XmlNode node in sprints.ChildNodes)
                total += int.Parse(node.Attributes["done"].Value);

            completed = total;
            total += int.Parse(sprints.ChildNodes[noOfSprints - 1].Attributes["todo"].Value);
            total += int.Parse(sprints.ChildNodes[noOfSprints - 1].Attributes["inProgress"].Value);
            int percentCompleted = (int)(((float)completed / (float)total) * 100);

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
                    w.WriteLine("<h2 style=\"color:orange \">" + projectName + " - " + project.Attributes["desName"].Value + " - Project Report</h2>");
                    w.WriteLine("Generated on: <span id='date'></span>, <span id='time'></span><br>");
                    w.WriteLine("Generated by: " + Environment.UserName);

                    w.WriteLine("<h3 style=\"color:purple \">Current Release</h2>");
                    w.WriteLine("<table>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Sprint (Version): </th><td style=\"min-width: 200px\">" + sprints.ChildNodes[noOfSprints - 1].Name + "</td></tr>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Total Scope (points): </th><td style=\"min-width: 200px\">" + total + "</td></tr>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Completed So Far (points): </th><td style=\"min-width: 200px\">" + completed + " (" + percentCompleted + "%)</td></tr>");
                    w.WriteLine("<tr><th style=\"padding:8px\">Unplanned (unpointed) Storied: </th><td style=\"min-width: 200px\">" + sprints.ChildNodes[noOfSprints - 1].Attributes["unplanned"].Value + "</td></tr>");
                    w.WriteLine("</table>");


                    w.WriteLine("<h4 style=\"color:purple \"> Software Products Included</h4>");
                    w.WriteLine("<table>");

                    foreach (XmlNode Sxxxx in software.ChildNodes)
                    {
                        string description = "No Description Found";
                        string platform = "Unspecified Platform";

                        foreach (XmlNode softwareProject in SoftwareProjects.ChildNodes)
                        {
                            if (softwareProject.Name == Sxxxx.Name)
                            {
                                description = softwareProject.InnerText;
                                platform = softwareProject.Attributes["platform"].Value;
                                break;
                            }
                        }

                        w.WriteLine("<tr><th style=\"padding:8px\">" + Sxxxx.Name + "</th><td style=\"min-width: 200px\", \"padding:8px\">" + platform + "</td><td style=\"padding:8px\">" + description + "</td></tr>");
                    }
                    w.WriteLine("</table>");


                    w.WriteLine("<h4 style=\"color:purple \">Release History</h4>");

                    total = 0;
                    completed = 0;

                    foreach (XmlNode sprint in sprints.ChildNodes) 
                    {
                        completed += int.Parse(sprint.Attributes["done"].Value);
                        total += int.Parse(sprint.Attributes["done"].Value);
                        total += int.Parse(sprint.Attributes["todo"].Value);
                        total += int.Parse(sprint.Attributes["inProgress"].Value);
                        percentCompleted = (int)(((float)completed / (float)total) * 100);

                        w.WriteLine("<table>");
                        w.WriteLine("<tr><th style=\"padding:8px\">Sprint (Version): </th><td style=\"min-width: 200px\">" + sprint.Name + "</td></tr>");
                        w.WriteLine("<tr><th style=\"padding:8px\">Total Known Scope (points): </th><td style=\"min-width: 200px\">" + total + "</td></tr>");
                        w.WriteLine("<tr><th style=\"padding:8px\">Completed (points): </th><td style=\"min-width: 200px\">" + completed + " (" + percentCompleted + "%)</td></tr>");
                        w.WriteLine("<tr><th style=\"padding:8px\">Unplanned (unpointed) Storied: </th><td style=\"min-width: 200px\">" + sprint.Attributes["unplanned"].Value + "</td></tr>");
                        w.WriteLine("</table>");

                        total -= int.Parse(sprint.Attributes["todo"].Value);
                        total -= int.Parse(sprint.Attributes["inProgress"].Value);

                        w.WriteLine("<br>");
                    }

                    w.WriteLine("");
                    w.WriteLine("<script> var dt = new Date(); let d = dt.toLocaleDateString(); let t = dt.toLocaleTimeString();");
                    w.WriteLine("document.getElementById('date').innerHTML = d; document.getElementById('time').innerHTML = t; </script >");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }

                MessageBox.Show(reportName + ".html generated");
            }
        }
    }
}

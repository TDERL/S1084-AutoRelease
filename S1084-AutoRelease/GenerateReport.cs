﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace S1084_AutoRelease
{
    internal class GenerateReport
    {
        public GenerateReport()
        {
        } 

        public void ProjectProgress(XmlDocument db, string projectName)
        {
            XmlElement project = (XmlElement)db.GetElementsByTagName(projectName)[0];
            XmlElement software = (XmlElement)project.GetElementsByTagName("Software")[0];
            XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            Paths paths = new Paths(db);
            string path = paths.GetProject(projectName);

            int noOfSprints = sprints.ChildNodes.Count;
            string reportName = projectName + "_ProgressReport.html";


            int total = 0;
            int completed = 0;
            foreach (XmlNode node in sprints.ChildNodes)
                total += int.Parse(node.Attributes["done"].Value);

            completed = total;
            total += int.Parse(sprints.ChildNodes[noOfSprints - 1].Attributes["todo"].Value);
            total += int.Parse(sprints.ChildNodes[noOfSprints - 1].Attributes["inProgress"].Value);
            int percentCompleted = (int)(((float)completed / (float)total) * 100);

            using (FileStream fs = new FileStream(path + reportName, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs))
                {
                    XmlNode node = db.SelectSingleNode("Project");
                    w.WriteLine("<!DOCTYPE html>");
                    w.WriteLine("<html>");
                    w.WriteLine("<style>");
                    w.WriteLine("/* Tooltip text */");
                    w.WriteLine(".tooltip .tooltiptext {");
                    w.WriteLine("visibility: hidden;");
                    w.WriteLine("width: 120px;");
                    w.WriteLine("background-color: darkgray;");
                    w.WriteLine("color: #fff;");
                    w.WriteLine("text-align: center;");
                    w.WriteLine("padding: 5px 0;");
                    w.WriteLine("border-radius: 6px;");
                    w.WriteLine("");
                    w.WriteLine("/* Position the tooltip text - see examples below! */");
                    w.WriteLine("position: absolute;");
                    w.WriteLine("z-index: 1;");
                    w.WriteLine("}");
                    w.WriteLine("");
                    w.WriteLine("/* Show the tooltip text when you mouse over the tooltip container */");
                    w.WriteLine(".tooltip:hover .tooltiptext {");
                    w.WriteLine("visibility: visible;");
                    w.WriteLine("}");
                    w.WriteLine("");
                    w.WriteLine("table, th, td {border:1px solid black; border-collapse: collapse; border-color: #96D4D4;}");
                    w.WriteLine("tr:hover {background-color: #D6EEEE;}");
                    w.WriteLine("td {text-align: center;}");
                    w.WriteLine("th {background-color: #D6EEEE;}");
                    w.WriteLine("</style>");
                    w.WriteLine("<body style=\"font-family: verdana\">");
                    w.WriteLine("<h2 style=\"color:orange \">" + projectName + "-" + project.Attributes["desName"].Value + " - Project Report</h2>");
                    w.WriteLine("Generated on: " + DateOnly.FromDateTime(DateTime.Now) + "<br>");
                    w.WriteLine("Generated by: " + Environment.UserName + ", using S1084");


                    w.WriteLine("<h3 style=\"color:purple \">Release and Progress History</h3>");

                    w.WriteLine("<table>");
                    w.WriteLine("<tr>" +
                        "<th style=\"padding:8px\">Version</th>" +
                        "<th style=\"padding:8px\">Date</th>" +
                        "<th style=\"padding:8px\" class=\"tooltip\">Scope<span class=\"tooltiptext\">Total size of project (estimated)</span></th>" +
                        "<th style=\"padding:8px\">Completed</th>" +
                        "<th style=\"padding:8px\" class=\"tooltip\">Unplanned<span class=\"tooltiptext\">Features not yet planned (estimated)</span></th>" +
                        "</tr>");

                    int[] completedPerSprint = new int[sprints.ChildNodes.Count];
                    int[] totalPerSprint = new int[sprints.ChildNodes.Count];
                    int[] percentCompletedPerSprint = new int[sprints.ChildNodes.Count];

                    for (int i = 0; i < sprints.ChildNodes.Count; i++)
                    {
                        completedPerSprint[i] = 0;
                        totalPerSprint[i] = 0;
                        percentCompletedPerSprint[i] = 0;
                    }

                    total = 0;
                    completed = 0;

                    //foreach (XmlNode sprint in sprints.ChildNodes)
                    for (int i = 0; i < sprints.ChildNodes.Count; i++)
                    {
                        total += int.Parse(sprints.ChildNodes[i].Attributes["todo"].Value);
                        total += int.Parse(sprints.ChildNodes[i].Attributes["inProgress"].Value);
                        total += int.Parse(sprints.ChildNodes[i].Attributes["done"].Value);
                        completed += int.Parse(sprints.ChildNodes[i].Attributes["done"].Value);
                        percentCompletedPerSprint[i] = (int)(((float)completed / (float)total) * 100);

                        totalPerSprint[i] = total;
                        completedPerSprint[i] = completed;

                        total -= int.Parse(sprints.ChildNodes[i].Attributes["todo"].Value);
                        total -= int.Parse(sprints.ChildNodes[i].Attributes["inProgress"].Value);
                    }

                    for (int i = (sprints.ChildNodes.Count - 1); i > 0; i--)
                    {
                        string releasePath = paths.GetReleases(projectName) + sprints.ChildNodes[i].Name + "\\ReleasedReport-" + sprints.ChildNodes[i].Name + ".html";

                        if (sprints.ChildNodes[i].Name == "NA")
                            w.WriteLine("<tr><td style=\"min-width: 200px\">-</td>");
                        else
                            w.WriteLine("<tr><td style=\"min-width: 200px\"><a href=\"" + releasePath + "\">" + sprints.ChildNodes[i].Name + "</a></td>");
                        w.WriteLine("<td style=\"min-width: 200px\">" + sprints.ChildNodes[i].Attributes["date"].Value + "</td>");
                        w.WriteLine("<td style=\"min-width: 200px\">" + totalPerSprint[i] + "</td>");
                        w.WriteLine("<td style=\"min-width: 200px\">" + completedPerSprint[i] + " (" + percentCompletedPerSprint[i] + "%)</td>");
                        w.WriteLine("<td style=\"min-width: 200px\">" + sprints.ChildNodes[i].Attributes["unplanned"].Value + "</td></tr>");

                        total -= int.Parse(sprints.ChildNodes[i].Attributes["todo"].Value);
                        total -= int.Parse(sprints.ChildNodes[i].Attributes["inProgress"].Value);
                    }
                    w.WriteLine("</table>");
                    w.WriteLine("<i style=\"color: darkgray\"><sup>*</sup>Scope and Completed measured in points. For simplicity, 1 point is usually 1 hour</i>");

                    w.WriteLine("<h3 style=\"color:purple \">Software Products</h3>");

                    w.WriteLine("<h4 style=\"color:purple \">Active</h4>");
                    w.WriteLine("Software products actively included in formal releases for overall build of " + projectName);
                    w.WriteLine("<br><br>");
                    w.WriteLine("<table>");

                    foreach (XmlNode Sxxxx in software.ChildNodes)
                    {
                        string description = "No Description Found";
                        string platform = "Unspecified Platform";

                        foreach (XmlNode softwareProject in SoftwareProjects.ChildNodes)
                        {
                            if ((softwareProject.Name == Sxxxx.Name) && (softwareProject.Attributes["active"].Value == "active"))
                            {
                                description = softwareProject.InnerText;
                                platform = softwareProject.Attributes["platform"].Value;
                                w.WriteLine("<tr><th style=\"padding:8px\">" + Sxxxx.Name + "</th><td style=\"min-width: 200px\", \"padding:8px\">" + platform + "</td><td style=\"padding:8px\">" + description + "</td></tr>");
                                break;
                            }
                        }
                    }
                    w.WriteLine("</table>");


                    w.WriteLine("<h4 style=\"color:purple \">Inactive</h4>");
                    w.WriteLine("Software products associated with " + projectName + " but no longer (or never were) part of formal releases</h4>");
                    w.WriteLine("<br><br>");
                    w.WriteLine("<table>");

                    foreach (XmlNode Sxxxx in software.ChildNodes)
                    {
                        string description = "No Description Found";
                        string platform = "Unspecified Platform";

                        foreach (XmlNode softwareProject in SoftwareProjects.ChildNodes)
                        {
                            if ((softwareProject.Name == Sxxxx.Name) && (softwareProject.Attributes["active"].Value == "inactive"))
                            {
                                description = softwareProject.InnerText;
                                platform = softwareProject.Attributes["platform"].Value;
                                w.WriteLine("<tr><th style=\"padding:8px\">" + Sxxxx.Name + "</th><td style=\"min-width: 200px\", \"padding:8px\">" + platform + "</td><td style=\"padding:8px\">" + description + "</td></tr>");
                                break;
                            }
                        }
                    }
                    w.WriteLine("</table>");


                    w.WriteLine("");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }

                MessageBox.Show(reportName + " generated");
            }
        }

        public void SoftwareComponents(XmlDocument db)
        {

        }

        public void ReportHomePage(XmlDocument db)
        {
            XmlElement projects = (XmlElement)db.GetElementsByTagName("Projects")[0];
            XmlElement sprints = (XmlElement)projects.GetElementsByTagName("Sprints")[0];
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            Paths paths = new Paths(db);
            string path = paths.GetBase();

            using (FileStream fs = new FileStream(path + "ERL_SW_Projects.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs))
                {
                    //XmlNode node = db.SelectSingleNode("Project");
                    w.WriteLine("<!DOCTYPE html>");
                    w.WriteLine("<html>");
                    w.WriteLine("<style>");
                    w.WriteLine("table, th, td {border:1px solid black; border-collapse: collapse; border-color: #96D4D4;}");
                    w.WriteLine("tr:hover {background-color: #D6EEEE;}");
                    w.WriteLine("td {text-align: center;}");
                    w.WriteLine("th {background-color: #D6EEEE;}");
                    w.WriteLine("</style>");
                    w.WriteLine("<body style=\"font-family: verdana\">");
                    w.WriteLine("<h2 style=\"color:orange \">ERL Projects</h2>");
                    w.WriteLine("Generated on: " + DateTime.Now + "<br>");
                    w.WriteLine("Generated by: " + Environment.UserName + ", using S1084");
                    w.WriteLine("<br><br>");
                    w.WriteLine("<table>");
                    w.WriteLine("<tr>" +
                        "<th style=\"padding:8px\">Name</th>" +
                        "<th style=\"padding:8px\">Description</th>" +
                        "<th style=\"padding:8px\">Stage</th>" +
                        "<th style=\"padding:8px\">Status</th>" +
                        "<th style=\"padding:8px\">Latest Release</th></tr>");

                    foreach (XmlNode project in projects)
                    {
                        string projectName = project.Name;
                        string reportName = projectName + "_ProgressReport";
                        string shortDesc = project.Attributes["desName"].Value;
                        string description = project.Attributes["description"].Value;
                        string stage = project.Attributes["stage"].Value;
                        string status = project.Attributes["status"].Value;
                        string version = sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name;
                        string x = paths.GetProject(projectName);
                        string releasePath = paths.GetProject(projectName) + "\\" + projectName + "_ProgressReport.html";

                        w.WriteLine("<tr>" +
                            "<td style=\"padding:8px\">" + projectName + " - " + shortDesc + "</td>" +
                            "<td style=\"padding:8px\">" + description + "</td>" +
                            "<td style=\"padding:8px\">" + stage + "</td>" +
                            "<td style=\"padding:8px\">" + status + "</td>" +
                            "<td style=\"padding:8px\"><a href =\"" + releasePath + "\">" + version + "</a></td></tr>");
                    }

                    w.WriteLine("</table>");
                }
            }
        }
    }
}

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
            XmlElement hardware = (XmlElement)project.GetElementsByTagName("Hardware")[0];
            XmlElement sprints = (XmlElement)project.GetElementsByTagName("Sprints")[0];
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];
            XmlElement HardwareProjects = (XmlElement)db.GetElementsByTagName("HardwareProjects")[0];

            Paths paths = new Paths(db);
            string path = paths.GetProject(projectName);

            int noOfSprints = sprints.ChildNodes.Count;
            string reportName = projectName + "_ProgressReport.html";


            int total = 0;
            int completed = 0;
            foreach (XmlNode node in sprints.ChildNodes)
                total += int.Parse(node.Attributes["done"].Value);

            completed = total;
            int percentCompleted = 0;

            if (noOfSprints > 0)
            {
                total += int.Parse(sprints.ChildNodes[noOfSprints - 1].Attributes["todo"].Value);
                total += int.Parse(sprints.ChildNodes[noOfSprints - 1].Attributes["inProgress"].Value);
                percentCompleted = (int)(((float)completed / (float)total) * 100);
            }

            Directory.CreateDirectory(path); // Just a little belts 'n' braces

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

                    
                    int noOfComponents = 0;
                    if (software != null)
                        noOfComponents += software.ChildNodes.Count;

                    if (hardware != null)
                        noOfComponents += hardware.ChildNodes.Count;

                    int[] donePerComponent = new int[noOfComponents];

                    for (int i = 0; i < noOfComponents; i++)
                        donePerComponent[i] = 0;

                    total = 0;
                    completed = 0;

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

                        //*****************
                        //
                        // Calculate running total of done points for each component
                        for (int c = 0; c < noOfComponents; c++)
                            if (sprints.ChildNodes[i].ChildNodes[c] != null)
                                donePerComponent[c] += int.Parse(sprints.ChildNodes[i].ChildNodes[c].Attributes["done"].Value);
                    }

                    for (int i = (sprints.ChildNodes.Count - 1); i >= 0; i--)
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
                    }
                    w.WriteLine("</table>");
                    w.WriteLine("<i style=\"color: darkgray\"><sup>*</sup>Scope and Completed measured in points. For simplicity, 1 point is usually 1 hour</i>");

                    w.WriteLine("<h3 style=\"color:purple \">Project Comprises of Following Components:</h3>");

                    w.WriteLine("<table>");

                    w.WriteLine("<tr>" +
                        "<th style=\"padding:8px\">Component</th>" +
                        "<th style=\"padding:8px\">Name</th>" +
                        "<th style=\"padding:8px\">Platform</th>" +
                        "<th style=\"padding:8px\">% Completed</th>" +
                        "<th style=\"padding:8px\">% Of Scope</th>" +
                        "<th style=\"padding:8px\">Description</th>" +
                        "</tr>");


                    if (noOfComponents > 0)
                    {
                        XmlElement components = (XmlElement)sprints.ChildNodes[sprints.ChildNodes.Count - 1]; // Only calculated for the latest Sprint

                        for (int c = 0; c < noOfComponents; c++) // For each component included in the project
                        {
                            double percentOfScope = 0;
                            double percentageOfDone = 0;

                            if (components != null)
                            {
                                int t = int.Parse(components.ChildNodes[c].Attributes["todo"].Value);
                                t += int.Parse(components.ChildNodes[c].Attributes["inProgress"].Value);
                                t += donePerComponent[c];

                                percentOfScope = (((float)t / (float)totalPerSprint[sprints.ChildNodes.Count - 1]) * 100);
                                percentOfScope = Math.Round(percentOfScope, 1);

                                percentageOfDone = (((float)donePerComponent[c] / (float)t) * 100);
                                percentageOfDone = Math.Round(percentageOfDone, 1);
                            }

                            string name = "";
                            string shortName = "";
                            string description = "";
                            string platform = "NA";

                            foreach (XmlNode Sxxxx in SoftwareProjects.ChildNodes)
                            {
                                if (components.ChildNodes[c].Name == Sxxxx.Name)
                                {
                                    name = Sxxxx.Name;
                                    shortName = Sxxxx.Attributes["shortName"].Value;
                                    description = Sxxxx.InnerText;
                                    platform = Sxxxx.Attributes["platform"].Value;
                                }
                            }

                            if ((shortName == "") && (hardware != null))
                            {
                                foreach (XmlNode EDAxxxx in HardwareProjects.ChildNodes)
                                {
                                    if (components.ChildNodes[c].Name == EDAxxxx.Name)
                                    {
                                        name = EDAxxxx.Name;
                                        shortName = EDAxxxx.Attributes["shortName"].Value;
                                        description = EDAxxxx.InnerText;
                                    }
                                }
                            }

                            w.WriteLine("<tr><th style=\"padding:8px\">" + name + "</th>" +
                                "<td style=\"min-width: 200px\", \"padding:8px\">" + shortName + "</td>" +
                                "<td style=\"padding:8px\">" + platform + "</td>" +
                                "<td style=\"padding:8px\">" + percentageOfDone + "</td>" +
                                "<td style=\"padding:8px\">" + percentOfScope + "</td>" +
                                "<td style=\"padding:8px\">" + description + "</td></tr>");
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

 
        public void ReportHomePage(XmlDocument db)
        {
            XmlElement projects = (XmlElement)db.GetElementsByTagName("Projects")[0];
            XmlElement SoftwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];

            Paths paths = new Paths(db);
            string path = paths.GetBase();

            using (FileStream fs = new FileStream(path + "ERL_Software_Projects.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs))
                {
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
                    w.WriteLine("Generated on: " + DateOnly.FromDateTime(DateTime.Now) + "<br>");
                    w.WriteLine("Generated by: " + Environment.UserName + ", using S1084");
                    w.WriteLine("<h3 style=\"color:purple \">ERL Products (System Level Projects)</h3>");
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
                        string version = "None Yet Released";

                        XmlElement p = (XmlElement)project;
                        XmlElement sprints = (XmlElement)p.GetElementsByTagName("Sprints")[0];
                        if (sprints.ChildNodes.Count > 0)
                            if (sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name != "NA")
                                version = sprints.ChildNodes[sprints.ChildNodes.Count - 1].Name;

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


                    w.WriteLine("<h3 style=\"color:purple \">ERL Software Components (Individual Software Projects)</h3>");
                    w.WriteLine("<table>");
                    w.WriteLine("<tr>" +
                        "<th style=\"padding:8px\">Number</th>" +
                        "<th style=\"padding:8px\">Status</th>" +
                        "<th style=\"padding:8px\">Platform</th>" +
                        "<th style=\"padding:8px\">Short Description</th>" +
                        "<th style=\"padding:8px\">Description</th></th>");

                    XmlElement softwareProjects = (XmlElement)db.GetElementsByTagName("SoftwareProjects")[0];
                    foreach (XmlNode Sxxxx in softwareProjects)
                    {
                        if (Sxxxx.Attributes["active"].Value == "inactive")
                            w.WriteLine("<tr style=\"color:gray\">");
                        else
                            w.WriteLine("<tr>");

                        w.WriteLine("<td style=\"min-width: 200px\", \"padding:6px\">" + Sxxxx.Name + "</td>");
                        w.WriteLine("<td style=\"min-width: 200px\", \"padding:6px\">" + Sxxxx.Attributes["active"].Value + "</td>");
                        w.WriteLine("<td style=\"min-width: 200px\", \"padding:6px\">" + Sxxxx.Attributes["platform"].Value + "</td>");
                        w.WriteLine("<td style=\"min-width: 200px\", \"padding:6px\">" + Sxxxx.Attributes["shortName"].Value + "</td>");
                        w.WriteLine("<td style=\"min-width: 200px\", \"padding:6px\">" + Sxxxx.InnerText + "</td>");
                        w.WriteLine("</tr>");
                    }

                    w.WriteLine("</table>");
                    w.WriteLine("");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }
            }
        }
    }
}

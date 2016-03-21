using System;
using System.Collections.Generic;
using PdfDownloaderPO.Classes;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO
{
    public static class Constants
    {
        public static Dictionary<string, string> Departments = new Dictionary<string, string>()
        {
            {"weaii", "Wydział Elektrotechniki, Automatyki i Informatyki" },
            {"wwfif", "Wydział Wychowania Fizycznego i Fizjoterapii" },
            {"sjo", "Studium Języków Obcych" },
            { "wb", "Wydział Budownictwa" },
            {"wetii", "Wydział Inżynierii Produkcji i Logistyki" },
            {"weiz", "Wydział Ekonomii i Zarządzania" }
        }; 



        public static Dictionary<string, Func<IDepartment>> DepartmentFactory = new Dictionary<string, Func<IDepartment>>()
        {
            {"weaii", () => new BasicDepartment()
                {
                    Abbreviation = "weaii",
                    BaseUri = @"http://www.planyzajec.po.opole.pl",
                    DepartmentName = Constants.Departments["weaii"],
                    GroupListUri = @"index1.html",
                    Node = "option",
                    Attribute = "value",
                }
            },
            {"wwfif", () => new BasicDepartment()
                {
                    Abbreviation = "wwfif",
                    BaseUri = @"http://www.planyzajec.po.opole.pl",
                    DepartmentName = Constants.Departments["wwfif"],
                    GroupListUri = @"index1.html",
                    Node = "option",
                    Attribute = "value",
                }
            },
            {"sjo", () => new BasicDepartment()
                {
                    Abbreviation = "sjo",
                    BaseUri = @"http://www.planyzajec.po.opole.pl",
                    DepartmentName = Constants.Departments["sjo"],
                    GroupListUri = @"index1.html",
                    Node = "option",
                    Attribute = "value",
                }
            },
            {"wetii", () => new BasicDepartment()
                {
                    Abbreviation = "wetii",
                    BaseUri = @"http://www.planyzajec.po.opole.pl",
                    DepartmentName = Constants.Departments["wetii"],
                    GroupListUri = @"index1.html",
                    Node = "option",
                    Attribute = "value",
                }

            },
            {"wb", () => new BasicDepartment()
                {
                    Abbreviation = "plan",
                    BaseUri = @"http://www.planywb.po.opole.pl/",
                    DepartmentName = Constants.Departments["wb"],
                    GroupListUri = @"index1.html",
                    Node = "option",
                    Attribute = "value"
                }
            },
            {"weiz", () => new WeizDepartment()
                {
                    Abbreviation = "plan",
                    BaseUri = @"http://weiz.po.opole.pl/",
                    DepartmentName = Constants.Departments["weiz"],
                    GroupListUri = @"",
                    Node = "a",
                    Attribute = "href"
                }
            }
        }; 
    }
}
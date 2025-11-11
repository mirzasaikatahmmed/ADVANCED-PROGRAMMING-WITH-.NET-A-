using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            var bio = new Bio
            {
                Name = "Mirza Saikat Ahmmed",
                Title = "Web & Database Enthusiast",
                Email = "contact@saikat.com.bd",
                Phone = "+8801571195489",
                LinkedIn = "https://linkedin.com/in/mirzasaikatahmmed",
                Summary = "A dedicated Computer Science student with a strong academic background, specializing in Web Development, Database Management, and Algorithmic Problem Solving. Experienced in front-end development (HTML/CSS/JavaScript) and relational database systems (MySQL).",
                Skills = new List<string> { "HTML", "CSS", "JavaScript", "MySQL", "C#", "ASP.NET MVC" }
            };

            return View(bio);
        }

        public ActionResult Education()
        {
            var educationList = new List<Education>
            {
                new Education
                {
                    Degree = "Higher Secondary School Certificate (HSC)",
                    InstitutionName = "Willes Little Flower School and College",
                    Group = "Science",
                    PassingYear = 2021,
                    Result = 4.75,
                    Board = "Dhaka Education Board"
                },
                new Education
                {
                    Degree = "Secondary School Certificate (SSC)",
                    InstitutionName = "Adarsha High School, Kaitola",
                    Group = "Science",
                    PassingYear = 2019,
                    Result = 4.00,
                    Board = "Rajshahi Education Board"
                }
            };

            return View(educationList);
        }

        public ActionResult Projects()
        {
            var projectList = new List<Project>
            {
                new Project
                {
                    Title = "E-commerce Platform Redesign",
                    Course = "Web Development (CSE 410)",
                    Description = new List<string>
                    {
                        "Developed a responsive front-end using Bootstrap, HTML5, and CSS3.",
                        "Implemented a shopping cart using JavaScript DOM manipulation and LocalStorage."
                    },
                    LiveDemo = "#",
                    GitHub = "#"
                },
                new Project
                {
                    Title = "Student Management System (SMS)",
                    Course = "Database Management Systems (CSE 301)",
                    Description = new List<string>
                    {
                        "Designed a relational database in MySQL to manage student records, enrollment, and grades.",
                        "Created SQL queries for efficient data retrieval and reporting."
                    }
                },
                new Project
                {
                    Title = "Simple Image Compression Algorithm",
                    Course = "Digital Image Processing (CSE 425)",
                    Description = new List<string>
                    {
                        "Implemented a Run-Length Encoding (RLE) algorithm in Python for grayscale image compression.",
                        "Analyzed compression ratio and time complexity."
                    }
                },
                new Project
                {
                    Title = "AI Tic-Tac-Toe Solver",
                    Course = "Introduction to AI (CSE 403)",
                    Description = new List<string>
                    {
                        "Developed an unbeatable Tic-Tac-Toe AI using the Minimax algorithm in C++.",
                        "Demonstrated decision-making under uncertainty."
                    }
                }
            };

            return View(projectList);
        }

        public ActionResult Reference()
        {
            var referenceList = new List<Reference>
            {
                new Reference
                {
                    Name = "TANVIR AHMED",
                    Title = "Assistant Professor, Department of Computer Science",
                    Institution = "American International University - Bangladesh (AIUB)",
                    Email = "tanvir.ahmed@aiub.edu",
                    Relationship = "Course Instructor (Advanced Programming with .NET)"
                }
            };

            return View(referenceList);
        }
    }
}
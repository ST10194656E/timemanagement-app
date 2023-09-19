using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeManagementApp
{
    public class Module
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public List<int> StudyHoursPerWeek { get; set; }

        public Module(string code, string name, int credits, int classHoursPerWeek)
        {
            Code = code;
            Name = name;
            Credits = credits;
            ClassHoursPerWeek = classHoursPerWeek;
            StudyHoursPerWeek = new List<int>();
        }

        public int CalculateSelfStudyHours(int numberOfWeeks)
        {
            int totalClassHours = ClassHoursPerWeek * numberOfWeeks;
            int totalStudyHours = Credits * 10 * numberOfWeeks - totalClassHours;
            return totalStudyHours;
        }

        public int CalculateRemainingSelfStudyHours(int currentWeek)
        {
            int totalClassHours = ClassHoursPerWeek * currentWeek;
            int totalStudyHours = Credits * 10 * currentWeek - totalClassHours;
            int recordedStudyHours = StudyHoursPerWeek.Take(currentWeek).Sum();
            int remainingStudyHours = totalStudyHours - recordedStudyHours;
            return remainingStudyHours;
        }
    }

    public class TimeManagementApp
    {
        private List<Module> modules;
        private int numberOfWeeks;
        private DateTime startDate;

        public TimeManagementApp()
        {
            modules = new List<Module>();
        }

        public void AddModule(string code, string name, int credits, int classHoursPerWeek)
        {
            Module module = new Module(code, name, credits, classHoursPerWeek);
            modules.Add(module);
        }

        public void SetSemesterDetails(int numberOfWeeks, DateTime startDate)
        {
            this.numberOfWeeks = numberOfWeeks;
            this.startDate = startDate;
        }

        public void RecordStudyHours(string moduleCode, int hours, DateTime date)
        {
            Module module = modules.FirstOrDefault(m => m.Code == moduleCode);
            if (module != null)
            {
                int weekNumber = (date - startDate).Days / 7 + 1;
                if (weekNumber >= 1 && weekNumber <= numberOfWeeks)
                {
                    if (module.StudyHoursPerWeek.Count >= weekNumber)
                    {
                        module.StudyHoursPerWeek[weekNumber - 1] = hours;
                    }
                    else
                    {
                        module.StudyHoursPerWeek.Add(hours);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a date within the semester.");
                }
            }
            else
            {
                Console.WriteLine("Module not found. Please enter a valid module code.");
            }
        }

        public void DisplayModuleList()
        {
            Console.WriteLine("Module List:");
            foreach (Module module in modules)
            {
                int remainingStudyHours = module.CalculateRemainingSelfStudyHours(numberOfWeeks);
                Console.WriteLine($"Module Code: {module.Code}");
                Console.WriteLine($"Module Name: {module.Name}");
                Console.WriteLine($"Remaining Self-Study Hours: {remainingStudyHours}");
                Console.WriteLine();
            }
        }
    }
}
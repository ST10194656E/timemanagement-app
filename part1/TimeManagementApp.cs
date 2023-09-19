using System;
using System.Collections.Generic;
using System.Linq;

namespace part1
{
    class TimeManagementApp
    {
        private string code;
        private string name;
        private int credits;
        private int classHours;

        public TimeManagementApp(string code, string name, int credits, int classHours)
        {
            this.code = code;
            this.name = name;
            this.credits = credits;
            this.classHours = classHours;
        }

        public TimeManagementApp()
        {
        }

        static void Main(string[] args)
        {
            TimeManagementApp app = new TimeManagementApp();

            // Add modules
            app.AddModule("PROG6212", "Programming 2B", 15, 5);
            app.AddModule("MATH1234", "Mathematics", 10, 4);

            // Set semester details
            app.SetSemesterDetails(14, new DateTime(2022, 9, 1));

        }

        private void SetSemesterDetails(int v, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        private void AddModule(string v1, string v2, int v3, int v4)
        {
            throw new NotImplementedException();
        }
    }
}
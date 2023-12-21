﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLib
{
    public class HRLib
    {
        public struct Employee
        {
            public string Name;
            public string HomePhone;
            public string MobilePhone;
            public DateTime Birthday;
            public DateTime HiringDate;

            public Employee(string name, string homePhone, string mobilePhone, DateTime birthday, DateTime hiringDate)
            {
                Name = name;
                HomePhone = homePhone;
                MobilePhone = mobilePhone;
                Birthday = birthday;
                HiringDate = hiringDate;
            }

            public Employee(string homePhone)
            {
                HomePhone = homePhone;
                Name = null;
                MobilePhone = null;
                Birthday = default;
                HiringDate = default;
            }
        }

        private Employee[] Employees;

        public HRLib()
        {

        }

        public HRLib(Employee[] employees)
        {
            Employees = employees;
        }

        public bool ValidName(string Name)
        {
            bool found = false;

            if (Employees != null)
            {
                foreach (Employee employee in Employees)
                {
                    if (employee.Name == Name)
                    {
                        found = true;
                    }
                }
            }

            return found;
        }

        public void InfoEmployee(Employee EmpIX, ref int Age, ref int YearsOfExperience)
        {
            Age = DateTime.Now.Year - EmpIX.Birthday.Year;
            YearsOfExperience = DateTime.Now.Year - EmpIX.HiringDate.Year;
        }

        private void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone)
        {
            if (Phone.Substring(0, 2) == "21")
            {
                TypePhone = 0;
                InfoPhone = "21";
            }
            else
            {
                TypePhone = -1;
                InfoPhone = null;
            }
        }

        public int LiveInAthens(Employee[] Empls)
        {
            int totalInAthens = 0;

            foreach (Employee employee in Empls)
            {
                int typePhone = 0;
                string infoPhone = "";

                CheckPhone(employee.HomePhone, ref typePhone, ref infoPhone);

                if (typePhone == 0 && infoPhone == "21")
                {
                    totalInAthens++;
                }
            }

            return totalInAthens;
        }
    }
}
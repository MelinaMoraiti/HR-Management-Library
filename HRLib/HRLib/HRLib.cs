using System;
using System.Text.RegularExpressions;

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

            public Employee(string homePhone) : this()
            {
                HomePhone = homePhone;
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
        public bool ValidPassword(string password)
        {
            //Check that the password has at least 12 characters
            if (password.Length < 12)
                return false;
            // Check for at least one lowercase letter 
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;
            // Check for at least one symbol
            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]"))
                return false;
            // Check that all characters are Latin characters
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9!@#$%^&*()_+{}\[\]:;<>,.?~\\-]+$"))
                return false;
            // Check that it starts with a capital letter
            if (!char.IsUpper(password[0]))
                return false;
            // Check that it ends with a number
            if (!char.IsDigit(password,password.Length-1))
                return false;
            return true;
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

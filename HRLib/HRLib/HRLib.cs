using System;
using System.Linq;
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
            if (!password.Any(char.IsLower))
                return false;
            // Check for at least one symbol
            if (!password.Any(c => char.IsSymbol(c) || char.IsPunctuation(c)))
                return false;
            // Check that all characters are Latin characters
            if (!password.All(c => char.IsLetterOrDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c)))
                return false;
            // Check that it starts with a capital letter
            if (!char.IsUpper(password[0]))
                return false;
            // Check that it ends with a number
            if (!char.IsDigit(password[password.Length - 1]))
                return false;
            return true;
        }
        //Assuming for simlpicity that greek Landline and Mobile phones start with 2 and 6 accordingly
        private bool IsLandlineGR(string phone)
        {
            return phone.Length == 10 && phone.StartsWith("2");
        }
        private string GetLandlineZone(string phone)
        {
            // assume the first two digits represent the zone.
            string zonePrefix = phone.Substring(0, 2);
            switch (zonePrefix)
            {
                case "21": return "Metropolitan Area of Athens - Piraeus";
                case "22": return "Eastern Central Greece, Attica, Aegean Islands";
                case "23": return "Central Macedonia";
                case "24": return "Thessaly, Western Macedonia";
                case "25": return "Thrace, Eastern Macedonia";
                case "26": return "Epirus, Western Central Greece, Western Peloponnese, Ionian Islands";
                case "27": return "Eastern Peloponnese, Kythira";
                case "28": return "Crete";
                default: return "Unknown Zone";
            }
        }
        private bool IsMobileGR(string phone)
        {
            return phone.Length == 10 && phone.StartsWith("6");
        }
        private string GetMobileCompany(string phone)
        {
            // assume the first three digits represent the mobile company.
            string companyPrefix = phone.Substring(0, 3);
            switch (companyPrefix)
            {
                case "693": return "Nova";
                case "695": return "Vodafone Greece";
                case "697": return "Cosmote";
                case "698": return "Cosmote";
                default: return "Unknown Mobile Company";
            }
        }
        public void CheckPhone(string Phone,ref int TypePhone, ref string InfoPhone)
        {
            // Remove any non-digit characters from the phone number
            string cleanedPhone = new string(Phone.Where(char.IsDigit).ToArray());
            // Check if the cleaned phone number is empty or null
            if (string.IsNullOrEmpty(cleanedPhone))
            {
                TypePhone = -1; // Invalid phone number
                InfoPhone = null;
                return;
            }
            if(IsLandlineGR(cleanedPhone))
            {
                TypePhone = 0;
                InfoPhone = GetLandlineZone(cleanedPhone);
            }
            else if(IsMobileGR(cleanedPhone))
            {
                TypePhone = 1;
                InfoPhone = GetMobileCompany(cleanedPhone);
            }
            else
            {
                TypePhone = -1;
                InfoPhone = null;
            }
        }
        public void InfoEmployee(Employee EmpIX, ref int Age, ref int YearsOfExperience)
        {
            Age = DateTime.Now.Year - EmpIX.Birthday.Year;
            YearsOfExperience = DateTime.Now.Year - EmpIX.HiringDate.Year;
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

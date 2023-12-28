using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HRLibTest
{
    [TestClass]
    public class HRLibTest
    {
        [TestMethod]
        public void TestValidName()
        {

            HRLib.HRLib.Employee[] employees =
            {
                new HRLib.HRLib.Employee("Joe Jonas", "210", "69", new DateTime(), new DateTime()),
                new HRLib.HRLib.Employee("Konstantinos Prasinos", "210", "69", new DateTime(), new DateTime()),
                new HRLib.HRLib.Employee("Nick Jonas", "210", "69", new DateTime(), new DateTime())
            };

            HRLib.HRLib hrLib = new HRLib.HRLib(employees);

            object[,] testCases =
            {
                {1, "Joe Jonas", true, "Name is an employee" },
                {2, "Konstantinos Prasinos", true, "Name is an employee"},
                {3, "Melina Moraiti", false, "This name is not an employee"}
            };

            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    bool nameIsValid = hrLib.ValidName((string)testCases[i, 1]);

                    Assert.AreEqual((bool)testCases[i, 2], nameIsValid);
                }
                catch (Exception e)
                {
                    failed = true;

                    Console.WriteLine("Failed Test Case {0}: {1} - {2}. \n \t Reason: {3} ", (int)testCases[i, 0], (string)testCases[i, 1], (bool)testCases[i, 2], e.Message);
                }
            }

            if (failed) Assert.Fail();
        }
        [TestMethod]
        public void TestValidPassword()
        {
            HRLib.HRLib hrLib = new HRLib.HRLib();

            object[,] testCases =
            {
                {1, "ValidPa$$word123", true, "Valid password with all requirements" },
                {2, "Short*123", false, "Password is too short" },
                {3, "noupperc@se123", false, "Missing uppercase letter" },
                {4, "NOLOWERCASE!567", false, "Missing lowercase letter" },
                {5, "NoSymbol1234", false, "Missing symbol" },
                {6, "NoooNuuumb3r!", false, "Missing number at the end" },
                {7, "PΚωδ!κ0ςςςςςςς1", false, "Contains non-Latin characters" },
                {8, "1StartsWithNumber", false, "Starts with a number" },
                {8, null, false, "Null password..." },
                {9, "St@rtsW1thC4pitalEndsWithNumb3r5", true, "Valid password with all requirements" }
            };

            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    bool passwordIsValid = hrLib.ValidPassword((string)testCases[i, 1]);

                    Assert.AreEqual((bool)testCases[i, 2], passwordIsValid);
                }
                catch (Exception e)
                {
                    failed = true;

                    Console.WriteLine("Failed Test Case {0}: {1} - {2}. \n \t Reason: {3} ", (int)testCases[i, 0], (string)testCases[i, 1], (bool)testCases[i, 2], (string)testCases[i, 3], e.Message);
                }
            }

            if (failed) Assert.Fail();
        }
        [TestMethod]
        public void TestEncryptPassword()
        {
            HRLib.HRLib hrLib = new HRLib.HRLib();
            object[,] testCases =
            {
               {1, "ValidPa$$word123", "[fqniUf))|twi678" ,"Correct Encryption"},                       
               {2, "St@rtsw1thC4pitalEndswithNumb3r5", "XyEwyx|6ymH9unyfqJsix|nymSzrg8w:","Correct Encryption" },  
               {3, "Secur3tP4ssword!1", "Xjhzw8yU9xx|twi&6","Correct Encryption" },
            };
            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                string encryptedPassword = null;
                try
                {
                    hrLib.EncryptPassword((string)testCases[i, 1], ref encryptedPassword);
                    Assert.AreEqual((string)testCases[i, 2], encryptedPassword, $"Test Case {i + 1} failed - {(string)testCases[i, 3]}");
                }
                catch (AssertFailedException e)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case {i + 1}: {(string)testCases[i, 3]} - {e.Message}");
                }
            }

            if (failed) Assert.Fail();
        }
        [TestMethod]
        public void TestCheckPhone()
        {
            HRLib.HRLib hrLib = new HRLib.HRLib();

            object[,] testCases =
            {
                { "2101234567", 0, "Metropolitan Area of Athens - Piraeus", "Valid Landline" },
                { "2900000000", 0, "Unknown Zone", "Valid Landline" },
                { "6949876543", 1, "Unknown Mobile Company", "Valid Mobile" },
                { "6971129873", 1, "Cosmote", "Valid Mobile" },
                { "InvalidPhone", -1, null, "No Digits..." },
                { "0123456789", -1, null, "Not valid phone" },
                { "12345", -1, null, "Not 10 digits" },

            };
            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                int typePhone = 0;
                string infoPhone = null;

                try
                {
                    hrLib.CheckPhone((string)testCases[i, 0], ref typePhone, ref infoPhone);
                    Assert.AreEqual((int)testCases[i, 1], typePhone, $"{testCases[i, 3]} - TypePhone mismatch");
                    Assert.AreEqual(testCases[i, 2], infoPhone, $"{testCases[i, 3]} - InfoPhone mismatch");
                }
                catch (AssertFailedException e)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case {i + 1}: {testCases[i, 3]}. \n \t Reason: {e.Message}");
                }
            }

            if (failed) Assert.Fail();
        }
        [TestMethod]
        public void TestInfoEmployee()
        {
            HRLib.HRLib hrLib = new HRLib.HRLib();

            object[,] testCases =
            {
                {1, new HRLib.HRLib.Employee("Joe Jonas", "210", "69", new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2011, 1, 1, 1, 1, 1)), 15, 12, "Experience and alive years both correct" },
                {2, new HRLib.HRLib.Employee("Konstantinos Prasinos", "210", "69", new DateTime(2005, 5, 1, 8, 30, 52), new DateTime(2012, 1, 1, 1, 1, 1)), 18, 11, "Experience and alive years both correct"},
                {3, new HRLib.HRLib.Employee("Brother#2 Jonas", "210", "69", new DateTime(2002, 5, 1, 8, 30, 52), new DateTime(2010, 1, 1, 1, 1, 1)), 21, 13, "Experience and alive years both correct"}
            };

            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    int age = 0;
                    int years = 0;

                    hrLib.InfoEmployee((HRLib.HRLib.Employee)testCases[i, 1], ref age, ref years);

                    Assert.AreEqual((int)testCases[i, 2], age);
                    Assert.AreEqual((int)testCases[i, 3], years);
                }
                catch (Exception e)
                {
                    failed = true;

                    Console.WriteLine("Failed Test Case {0}: {1} - {2}. \n \t Reason: {3} ", (int)testCases[i, 0], (string)testCases[i, 1], (bool)testCases[i, 2], e.Message);
                }
            }

            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestLiveInAthens()
        {
            HRLib.HRLib hrLib = new HRLib.HRLib();



            object[,] testCases =
            {
                {
                    1,
                    new[] {new HRLib.HRLib.Employee("210"), new HRLib.HRLib.Employee("220"), new HRLib.HRLib.Employee("210"), new HRLib.HRLib.Employee("220")},
                    2, "Experience and alive years both correct"
                },
                {
                    2,
                    new[] {new HRLib.HRLib.Employee("210"), new HRLib.HRLib.Employee("210"), new HRLib.HRLib.Employee("210"), new HRLib.HRLib.Employee("220")},
                    3, "Experience and alive years both correct"
                },
                {
                    3,
                    new[] {new HRLib.HRLib.Employee("220"), new HRLib.HRLib.Employee("220"), new HRLib.HRLib.Employee("220"), new HRLib.HRLib.Employee("220")},
                    0, "Experience and alive years both correct"
                },
            };

            bool failed = false;

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    int n = hrLib.LiveInAthens((HRLib.HRLib.Employee[])testCases[i, 1]);

                    Assert.AreEqual((int)testCases[i, 2], n);
                }
                catch (Exception e)
                {
                    failed = true;

                    Console.WriteLine("Failed Test Case {0}: {1} - {2}. \n \t Reason: {3} ", (int)testCases[i, 0], (string)testCases[i, 1], (bool)testCases[i, 2], e.Message);
                }
            }

            if (failed) Assert.Fail();
        }
    }
}

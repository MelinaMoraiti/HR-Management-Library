﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
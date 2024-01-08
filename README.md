# HRLib - HR Management Library for Company Personnel
This repository contains the development of a C# DLL (Dynamic Link Library) named HRLib, designed for managing personnel within a company's Human Resources Information System. The library includes a set of functions and methods to handle various aspects of employee data.

## Table of Contents
- [Key Features](#key-features)
- [Testing Focus](#testing-focus)
- [Getting Started](#getting-started)

## DLL Key Features 🚀
1. **ValidName:**
   - Validates whether a given text corresponds to an employee's name.

2. **ValidPassword:**
   - Validates if a text is an acceptable password based on specified criteria.

3. **EncryptPassword:**
   - Encrypts a password using Caesar's Cipher with a sliding shift of 5 positions.

4. **CheckPhone:**
   - Validates and provides information about a given phone number.

5. **InfoEmployee:**
   - Retrieves age and years of experience for a given employee.

6. **LiveInAthens:**
   - Counts the number of employees living in Athens, utilizing the CheckPhone function.

## Testing Focus 🔍

- **Comprehensive Test Cases:**
  - Extensive test cases have been meticulously crafted for each function and method to ensure accurate and reliable performance.

- **Unit Tests:**
  - Robust unit tests have been implemented for every method and function within the library, emphasizing correctness and reliability.
  
## Getting Started 🚀
To use HRLib in your C# project, follow these steps:

1. Clone the repository: `git clone https://github.com/MelinaMoraiti/HRLib.git`
2. Reference the HRLib.dll in your project.
3. Explore the functions and methods provided in the library.

## Running Tests
Open the terminal and run:
```bash
dotnet test
```
OR Open the Test Explorer if using Visual Studio and run the tests.
## License 📄
This project is licensed under the MIT License - see the LICENSE file for details.

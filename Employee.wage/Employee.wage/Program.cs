﻿// See https://aka.ms/new-console-template for more information
using Employee.wage;

Console.WriteLine("Welcome to Employee Wage!");
EmployeewageBuilder Infosys = new EmployeewageBuilder("Infosys", 20, 2, 10);
EmployeewageBuilder TCS = new EmployeewageBuilder("TCS", 10, 4, 20);
Infosys.salary();
Console.WriteLine(Infosys.ToString());
TCS.salary();
Console.WriteLine(TCS.ToString());

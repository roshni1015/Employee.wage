﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.wage
{
    public class EmployeewageBuilder: IcomputeEmpWage
    {

        public const int isPartTime = 1;
        public const int isFullTime = 2;

        private LinkedList<CompanyEmpWage> companyEmpWageList;
        private Dictionary<String, CompanyEmpWage> companyToEmpWageMap;

        int numofcompany = 0;
        private CompanyEmpWage[] companyEmpWageArray;

        public EmployeewageBuilder()
        {
            this.companyEmpWageList = new LinkedList<CompanyEmpWage>();
            this.companyToEmpWageMap = new Dictionary<String, CompanyEmpWage>();

        }
        public void AddcompanyEmpWage(string company, int empRatePerHour, int numofWorkingDays, int maxHourPerMonth)
        {
            CompanyEmpWage CompanyEmpWage= new CompanyEmpWage(company, empRatePerHour, numofWorkingDays, maxHourPerMonth);
            this.companyEmpWageList.AddLast(CompanyEmpWage);
            this.companyToEmpWageMap.Add(company, CompanyEmpWage);
        }
        public void computeEmpWage()
        {
            foreach (CompanyEmpWage companyEmpWage in this.companyEmpWageList)
            {
                companyEmpWage.SetTotalEmpWage(this.computeEmpWage(companyEmpWage));
                Console.WriteLine(companyEmpWage.ToString());

            }
        }
        private int computeEmpWage(CompanyEmpWage CompanyEmpWage)
        {
            int empHrs = 0, totalEmpHrs = 0, totalworkingDays = 0, dailywage = 0;
            while (totalEmpHrs <= CompanyEmpWage.maxHourPerMonth && totalworkingDays < CompanyEmpWage.numofWorkingDays)
            {
                totalworkingDays++;
                Random random = new Random();
                int EmpCheck = random.Next(0, 3);
                switch (EmpCheck)
                {
                    case isPartTime:
                        empHrs = 4;
                        break;
                    case isFullTime:
                        empHrs = 8;
                        break;
                    default:
                        empHrs = 0;
                        break;

                }
                totalEmpHrs += empHrs;
                Console.WriteLine("Day#:" + totalworkingDays + "Employee Hours: " + empHrs);
                dailywage = empHrs * CompanyEmpWage.empRatePerHour;
                Console.WriteLine("Daily wage : " + dailywage);

            }
            int amount = totalEmpHrs * CompanyEmpWage.empRatePerHour;
            Console.WriteLine(amount);
            return amount;
        }
        public void getTotalWage(string company)
        {
            Console.WriteLine(this.companyToEmpWageMap[company].totalEmpWage);
        }

    }
}

       

     
using System;
using ApiEmployee.Models;
using ApiEmployee.DAL;
namespace ApiEmployee.BAL

{
    public class Employee_BALBase
    {
        public List<Employee> PR_SELECT_ALL_EMPLOYEE()
        {
            try
            {
                Employee_DALBase employee_DALBase = new Employee_DALBase();
                List<Employee> employee = employee_DALBase.PR_SELECT_ALL_EMPLOYEE();
                return employee;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null;
            }
        }


        public List<Employee> PR_SELECT_EMPLOYEE_BY_PK(int EmpId)
        {
            try
            {
                Employee_DALBase employee_DALBase = new Employee_DALBase();
                List<Employee> employee = employee_DALBase.PR_SELECT_EMPLOYEE_BY_PK(EmpId);
                return employee;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null;
            }
        }



        public bool PR_INSERT_EMPLOYEE(Employee employee)
        {
            try
            {
                Employee_DALBase employee_DALBase = new Employee_DALBase();
                if (employee_DALBase.PR_INSERT_EMPLOYEE(employee))
                
                    return true;
                
                else

                    return false;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }




        public bool PR_UPDATE_EMPLOYEE(int EmpID,Employee employee)
        {
            try
            {
                Employee_DALBase employee_DALBase = new Employee_DALBase();
                if (employee_DALBase.PR_UPDATE_EMPLOYEE(EmpID,employee))

                    return true;

                else

                    return false;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }


        public bool PR_DELETE_EMPLOYEE(int EmpId)
        {
            try
            {
                Employee_DALBase employee_DALBase = new Employee_DALBase();
                if (employee_DALBase.PR_DELETE_EMPLOYEE(EmpId))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }





    }
}


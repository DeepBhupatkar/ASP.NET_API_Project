using System;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using ApiEmployee.Models;

namespace ApiEmployee.DAL
{
    public class Employee_DALBase
    {



        public String ConnString = "Data Source=localhost;Initial Catalog=APIConsume;User id=SA ; password=Password123";

        public List<Employee> PR_SELECT_ALL_EMPLOYEE()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_EMPLOYEE");
                List<Employee> Employee = new List<Employee>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmpId = Convert.ToInt32(dr["EmpId"].ToString());
                        employee.EmpName = dr["EmpName"].ToString();
                        employee.EmpCode = dr["EmpCode"].ToString();
                        employee.Email = dr["Email"].ToString();
                        employee.Contact = dr["Contact"].ToString();
                        employee.Salary = dr["Salary"].ToString();
                        Employee.Add(employee);

                    }


                }
                return Employee;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public List<Employee> PR_SELECT_EMPLOYEE_BY_PK(int EmpId)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_EMPLOYEE_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@EmpId", SqlDbType.Int,EmpId);
                List<Employee> Employee = new List<Employee>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmpId = Convert.ToInt32(dr["EmpId"].ToString());
                        employee.EmpName = dr["EmpName"].ToString();
                        employee.EmpCode = dr["EmpCode"].ToString();
                        employee.Email = dr["Email"].ToString();
                        employee.Contact = dr["Contact"].ToString();
                        employee.Salary = dr["Salary"].ToString();
                        Employee.Add(employee);

                    }


                }
                return Employee;
            }

            catch (Exception e)
            {
                return null;
            }

        }



        public bool PR_INSERT_EMPLOYEE(Employee employee)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_INSERT_EMPLOYEE");
               
                sqlDatabase.AddInParameter(dbCommand, "@EmpName", SqlDbType.VarChar, employee.EmpName);
                sqlDatabase.AddInParameter(dbCommand, "@EmpCode", SqlDbType.VarChar, employee.EmpCode);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, employee.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, employee.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Salary", SqlDbType.VarChar, employee.Salary);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool PR_UPDATE_EMPLOYEE(int EmpID,Employee employee)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_UPDATE_EMPLOYEE");
                sqlDatabase.AddInParameter(dbCommand, "@EmpID", SqlDbType.Int, employee.EmpId);
                sqlDatabase.AddInParameter(dbCommand, "@EmpName", SqlDbType.VarChar, employee.EmpName);
                sqlDatabase.AddInParameter(dbCommand, "@EmpCode", SqlDbType.VarChar, employee.EmpCode);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, employee.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, employee.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Salary", SqlDbType.VarChar, employee.Salary);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public bool PR_DELETE_EMPLOYEE(int EmpID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_DELETE_EMPLOYEE");
                sqlDatabase.AddInParameter(dbCommand, "@EmpID", SqlDbType.Int, EmpID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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





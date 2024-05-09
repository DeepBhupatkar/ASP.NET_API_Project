using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiEmployee.BAL;
using ApiEmployee.Models;
using System;


namespace ApiEmployee.Controllers
{ 

 [ApiController]
 [Route("api/[controller]/[action]")]

    public class EmployeeController : Controller
{
 
        [HttpGet]

        public IActionResult Get()
        {
            Employee_BALBase bal = new Employee_BALBase();
            List<Employee> employee = bal.PR_SELECT_ALL_EMPLOYEE();
            //make the response in key value pair
            Dictionary<String, dynamic> response = new Dictionary<string, dynamic>();
            if (employee != null && employee.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", employee);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }


        [HttpGet("EmpID")]
        public IActionResult Get(int EmpId)
        {
            Employee_BALBase bal = new Employee_BALBase();
            List<Employee> employee = bal.PR_SELECT_EMPLOYEE_BY_PK(EmpId);
            //make the response in key value pair
            Dictionary<String, dynamic> response = new Dictionary<string, dynamic>();
            if (employee != null && employee.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", employee);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpPost]
        public IActionResult Post ([FromForm] Employee employee)
        {
            Employee_BALBase bal = new Employee_BALBase();
            bool IsSuccess = bal.PR_INSERT_EMPLOYEE(employee);
            //make the response in key value pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return Ok(response);
            }

        }


        [HttpPut]

        public IActionResult Put(int EmpID,[FromForm] Employee employee)
        {
            Employee_BALBase bal = new Employee_BALBase();
            employee.EmpId = EmpID;
            bool IsSuccess = bal.PR_UPDATE_EMPLOYEE(EmpID,employee);
            //make the response in key value pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return Ok(response);
            }
        }


        [HttpDelete]
        public IActionResult Delete (int EmpId)
        {
            Employee_BALBase bal = new Employee_BALBase();
            bool IsSuccess = bal.PR_DELETE_EMPLOYEE(EmpId);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error has been occured.");
                return Ok(response);
            }
        }




    }


}





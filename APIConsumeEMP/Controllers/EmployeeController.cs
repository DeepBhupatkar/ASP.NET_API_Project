using Microsoft.AspNetCore.Mvc;
using APIConsumeEMP.Models;
using APIConsumeEMP;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using System.Text.Json.Nodes;
using System;
using System.Net.Http;

namespace APIConsumeEMP.Controllers
{

    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7225");
       
        string uri = "https://localhost:7225/api/Employee/Delete?EmpId=";
        string uried = "https://localhost:7225/api/Employee/Put?EmpID=";



        private readonly HttpClient _client;

        public EmployeeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GET()
        {
            List<Employee> employee = new List<Employee>();
            HttpResponseMessage response = _client.GetAsync
               ($"{_client.BaseAddress}api/Employee/Get").Result;
            if (response.IsSuccessStatusCode)
            {

                string data = response.Content.ReadAsStringAsync().Result;
                dynamic jsonobject = JsonConvert.DeserializeObject(data);
                var dataofObject = jsonobject.data;
                var extractedDataJson = JsonConvert.SerializeObject
                    (dataofObject, Formatting.Indented);
                employee = JsonConvert.DeserializeObject<List<Employee>>(extractedDataJson);

            }
            return View("EmployeeList", employee);

        }

        [HttpGet]
        public IActionResult Delete(int EmpId)
        {
            HttpResponseMessage response = _client.DeleteAsync
             (uri+EmpId).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Employee Data Is Deleted";

            }

            return RedirectToAction("GET");
        }



       [HttpGet]
        public IActionResult Edit(int EmpId)
        {
            Employee employee = new Employee();
            HttpResponseMessage response = _client.GetAsync
             ($"{_client.BaseAddress}api/Employee/Get/"+ EmpId).Result;
            if (response.IsSuccessStatusCode)
            {

                string data = response.Content.ReadAsStringAsync().Result;
                dynamic jsonobject = JsonConvert.DeserializeObject(data);
                var dataofObject = jsonobject.data;
                var extractedDataJson = JsonConvert.SerializeObject
                    (dataofObject, Formatting.Indented);
                employee = JsonConvert.DeserializeObject<Employee>(extractedDataJson);
            }
            return View("Create", employee);


        }



        [HttpPost]

        public async Task<IActionResult> Save(Employee employee)

        {
            try
            {
                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StringContent(employee.EmpName), "EmpName");
                formData.Add(new StringContent(employee.EmpCode), "EmpCode");
                formData.Add(new StringContent(employee.Email),"Email");
                formData.Add(new StringContent(employee.Contact),"Contact");
                formData.Add(new StringContent(employee.Salary), "Salary");

                if (employee.EmpId == 0)
                {
                    HttpResponseMessage response = await _client.PostAsync
                    ($"{_client.BaseAddress}api/Employee/Post", formData);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Emloyee Inserted";
                        return RedirectToAction("GET");
                    }
                }

                else
                {
                    HttpResponseMessage response = await _client.PutAsync
                   ($"{_client.BaseAddress}/api/Employee/Put/{employee.EmpId}", formData);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Emloyee Updated";
                        return RedirectToAction("GET");
                    }

                }
            }

            catch (Exception ex)
            {
                TempData["Error"] = "An Error Occured"+ex.Message;
                    /// code is incomplete 
            }
            return RedirectToAction("GET");


        }



       
    }
}



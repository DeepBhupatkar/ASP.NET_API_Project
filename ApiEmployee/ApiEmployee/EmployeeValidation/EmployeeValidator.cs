using ApiEmployee.Models;
using FluentValidation;
using Microsoft.SqlServer.Server;

namespace ApiEmployee.EmployeeValidation
{
	public class EmployeeValidator : AbstractValidator<Employee>
	{

        // Implemented Fluent Validations technique to validate data in API.

		public EmployeeValidator()

		{
			RuleFor(employee => employee.EmpName).NotEmpty().WithMessage("Employee Name Can not be emapty");
			RuleFor(employee => employee.Email).NotEmpty().WithMessage("Email is required")
				.EmailAddress().WithMessage("Invalid EmailFormat")
				.NotEqual("Emp123@gmail.com").WithMessage("This Email is Not Allowed");
			RuleFor(employee => employee.Contact).Must(employee => employee.StartsWith("+91")).WithMessage("Contact Number must start with +91");
			RuleFor(employee => employee.EmpCode).Matches(@"^[a-zA-Z\s]+$").WithMessage("EmpCode can only contains letter");




        }


    }

	
}


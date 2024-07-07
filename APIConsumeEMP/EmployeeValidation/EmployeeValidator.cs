using APIConsumeEMP.Models;
using FluentValidation;
namespace APIConsumeEMP.EmployeeValidation
{
	public class EmployeeValidator : AbstractValidator<Employee>
	{


		public EmployeeValidator()

		{
			RuleFor(employee => employee.EmpName).NotEmpty();

		}


    }

	
}


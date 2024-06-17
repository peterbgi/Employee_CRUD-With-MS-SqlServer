using EmployeeCRUDPortal.Data;
using EmployeeCRUDPortal.Models;
using EmployeeCRUDPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public EmployeesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(dbContext.Empolyess.ToList());
        }

        [HttpPost]
        public IActionResult AllEmployee(AddEmployDTO addEmployeeDTO)
        {
            var employeeEntity = new Employee()
            {
                Email = addEmployeeDTO.Email,
                Name = addEmployeeDTO.Name,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary,
            };

            dbContext.Empolyess.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmploymentId(Guid id)
        {
           var emplyeeId =  dbContext.Empolyess.Find(id);

            if (emplyeeId is null)
            { 
                return NotFound("Nincs ilyen atonosító.");
            }

            return Ok(emplyeeId);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult EditEmployee(Guid id, EditEmployDTO editEmployDTO)
        {
            var editEmployee = dbContext.Empolyess.Find(id);

            if (editEmployee is null)
            {
                return NotFound("Nem sikeres a frissítés.");
            }

            editEmployee.Name = editEmployDTO.Name;
            editEmployee.Phone = editEmployDTO.Phone;
            editEmployee.Salary = editEmployDTO.Salary; 
            editEmployee.Email = editEmployDTO.Email;

            dbContext.SaveChanges();

            return Ok(editEmployee);


        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var deleteEmployee = dbContext.Empolyess.Find(id);

            if (deleteEmployee is null)
            {
                return NotFound("Sikertelen törlés..");
            }

            dbContext.Empolyess.Remove(deleteEmployee);
            dbContext.SaveChanges();  
            
            return Ok(deleteEmployee);  
        }




    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Psh.Model;
using Project_Psh.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project_Psh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(employeeRepo.GetAllEmployee());
        }

        [HttpGet("{id:int}", Name = "GetOneEmpRoute")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(employeeRepo.GetEmployeeById(id));
        }

        [HttpPost]
        public IActionResult PostEmployeeById(Employee Employee)
        {
            try
            {
                employeeRepo.AddEmployee(Employee);
                string url = Url.Link("GetOneEmpRoute", new { id = Employee.Id });
                return Created(url, Employee);
            }
            catch
            {
                return BadRequest("Id Not Found");
            }
        }
        [HttpPut("{id}")]

        public IActionResult PutEmployeeById(int id, Employee Employee)
        {
            if (ModelState.IsValid == true)
            {
                var returnedEmployee = employeeRepo.EditEmployee(id, Employee);
                return StatusCode(204, returnedEmployee);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                employeeRepo.DeleteEmployee(id);
                return StatusCode(204, "Record Remove Success");
            }
            catch
            {
                return BadRequest("Id Not Found");
            }
        }
        [HttpPost("uploadImage"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                //everything else is the same
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}

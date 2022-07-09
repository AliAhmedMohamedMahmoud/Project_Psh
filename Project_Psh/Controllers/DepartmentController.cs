using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Psh.Repositories;

namespace Project_Psh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            
            departmentRepo = _departmentRepo;
        }

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            return Ok(departmentRepo.GetAllDepartment());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDepartmentById(int id)
        {
            return Ok(departmentRepo.GetDepartmentById(id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_rpg.Dtos.Student;
using Student_rpg.Models;
using Student_rpg.Services.StudentService;
using System.Security.Claims;

namespace Student_rpg.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        private User GetCurrentUser(){
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null){
                var userClaims = identity.Claims;

                return new User{
                    Username = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> GetAll(){
            return Ok(await _studentService.GetAllStudents());
        }
        [Authorize(Roles ="Student")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> GetSingle(int id){
            return Ok(await _studentService.GetStudentById(id));
        }
        [Authorize(Roles ="Student")]
        [HttpPost]//create
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> CreateStudent(AddStudentDto newStudent){
            return Ok(await _studentService.AddStudent(newStudent));
        }
        [Authorize(Roles ="Student")]
        [HttpPut]//update
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> UpdateStudent(UpdateStudentDto updateStudent){
            var response = await _studentService.UpdateStudent(updateStudent);
            if (response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
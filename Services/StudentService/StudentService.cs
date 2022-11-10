using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Student_rpg.Data;
using Student_rpg.Dtos.Student;
using Student_rpg.Models;

namespace Student_rpg.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>{
            new Student(),
            new Student {Id = 1,Fname = "Sara", Lname = "Al Ali"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents(){
            var response = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = await _context.Students.ToListAsync();
            response.Data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            return response;
        }
        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var dbStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            serviceResponse.Data = _mapper.Map<GetStudentDto>(dbStudent);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            Student student = _mapper.Map<Student>(newStudent);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Students
            .Select(s => _mapper.Map<GetStudentDto>(s))
            .ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();

            try{
            var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);

            _mapper.Map(updatedStudent, student);

            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetStudentDto>(student);
            } catch(Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
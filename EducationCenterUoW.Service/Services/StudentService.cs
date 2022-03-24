using EducationCenterUoW.Data.IRepositories;
using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Configurations;
using EducationCenterUoW.Domain.Entities.Students;
using EducationCenterUoW.Service.DTOs.Students;
using EducationCenterUoW.Service.Extensions;
using EducationCenterUoW.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IGroupRepository groupRepository;
        public StudentService(IStudentRepository studentRepository, IGroupRepository groupRepository)
        {
            this.studentRepository = studentRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<BaseResponse<Student>> CreateAsync(StudentForCreationDto studentDto)
        {
            var response = new BaseResponse<Student>();
            
            // check for student
            var existStudent = await studentRepository.GetAsync(p => p.Phone == studentDto.Phone);
            if(existStudent is not null)
            {
                response.Error = new ErrorResponse(400, "User is exist");
                return response;
            }

            // check for group
            var existGroup = await groupRepository.GetAsync(p => p.Id == studentDto.GroupId);
            if(existGroup is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            // create after checking success
            var mappedStudent = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Phone = studentDto.Phone,
                GroupId = studentDto.GroupId
            };

            var result = await studentRepository.CreateAsync(mappedStudent);

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist student
            var existStudent = await studentRepository.GetAsync(expression);
            if (existStudent is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            var result = await studentRepository.UpdateAsync(existStudent);

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Student>>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Student>>();

            var students = await studentRepository.GetAllAsync(expression);

            response.Data = students.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression)
        {
            var response = new BaseResponse<Student>();

            var student = await studentRepository.GetAsync(expression);
            if(student is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = student;

            return response;
        }

        public async Task<BaseResponse<Student>> UpdateAsync(Guid id, StudentForCreationDto studentDto)
        {
            var response = new BaseResponse<Student>();

            // check for exist student
            var student = await studentRepository.GetAsync(p => p.Id == id);
            if(student is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            // check for exist group
            var group = await groupRepository.GetAsync(p => p.Id == studentDto.GroupId);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            var mappedStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Phone = student.Phone,
                GroupId = student.GroupId
            };
            mappedStudent.Update();

            var result = await studentRepository.UpdateAsync(mappedStudent);

            response.Data = result;

            return response;
        }
    }
}

using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Configurations;
using EducationCenterUoW.Domain.Entities.Students;
using EducationCenterUoW.Service.DTOs.Students;
using EducationCenterUoW.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterUoW.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Student>>> Create(StudentForCreationDto studentDto)
        {
            var result = await studentService.CreateAsync(studentDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Student>>>> GetAll([FromHeader]string muhammadabulloh, [FromQuery]PaginationParams @params)
        {
            HttpContext.Response.Headers.Add("muhammadabdulloh", "pecheniy olib keling");

            var result = await studentService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Get(Guid id)
        {
            var result = await studentService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Update(Guid id, StudentForCreationDto studentDto) 
        {
            var result = await studentService.UpdateAsync(id, studentDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await studentService.DeleteAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}

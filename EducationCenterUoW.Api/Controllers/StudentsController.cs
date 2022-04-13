using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Configurations;
using EducationCenterUoW.Domain.Entities.Students;
using EducationCenterUoW.Domain.Enums;
using EducationCenterUoW.Service.DTOs.Students;
using EducationCenterUoW.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using shef = System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using EducationCenterUoW.Service.Helpers;

namespace EducationCenterUoW.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;
        public StudentsController(IStudentService studentService, IWebHostEnvironment env, IConfiguration config)
        {
            this.studentService = studentService;
            this.env = env;
            this.config = config;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Student>>> Create([FromForm]StudentForCreationDto studentDto)
        {
            var result = await studentService.CreateAsync(studentDto);
            
            return StatusCode(result.Error is null ? result.Code : result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Student>>>> GetAll([FromQuery] PaginationParams @params)
        {
            string username = config.GetSection("Authentication:Basic:Username").Value;
            string password = config.GetSection("Authentication:Basic:Password").Value;
            if (username == HttpContextHelper.BasicUsername && password == HttpContextHelper.BasicPassword)
            {
                var result = await studentService.GetAllAsync(@params);

                return StatusCode(result.Error is null ? result.Code : result.Error.Code.Value, result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Get([FromRoute]Guid id)
        {
            var result = await studentService.GetAsync(p => p.Id == id);

            return StatusCode(result.Error is null ? result.Code : result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Update(Guid id, StudentForCreationDto studentDto)
        {
            var result = await studentService.UpdateAsync(id, studentDto);
            
            return StatusCode(result.Error is null ? result.Code : result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await studentService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Error is null ? result.Code : result.Error.Code.Value, result);
        }
    }
}

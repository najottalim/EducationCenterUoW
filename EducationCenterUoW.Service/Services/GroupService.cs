using AutoMapper;
using EducationCenterUoW.Data.IRepositories;
using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Configurations;
using EducationCenterUoW.Domain.Entities.Groups;
using EducationCenterUoW.Service.DTOs.Groups;
using EducationCenterUoW.Service.Extensions;
using EducationCenterUoW.Service.Helpers;
using EducationCenterUoW.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        public async Task<BaseResponse<Group>> CreateAsync(GroupForCreationDto groupDto)
        {
            var response = new BaseResponse<Group>();

            var teacher = await unitOfWork.Teachers.GetAsync(p => p.Id == groupDto.TeacherId);
            if(teacher is null)
            {
                response.Error = new ErrorResponse(404, "Teacher not found");
                return response;
            }

            var course = await unitOfWork.Courses.GetAsync(p => p.Id == groupDto.CourseId);
            if (course is null)
            {
                response.Error = new ErrorResponse(404, "Course not found");
                return response;
            }

            var group = mapper.Map<Group>(groupDto);
            var result = await unitOfWork.Groups.CreateAsync(group);

            await unitOfWork.SaveChangesAsync();
            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Group>>();
            
            var groups = await unitOfWork.Groups.GetAllAsync(expression);
            
            response.Data = groups.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression)
        {
            var response = new BaseResponse<Group>();

            var group = await unitOfWork.Groups.GetAsync(expression);

            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            // Language init
            string lang = HttpContextHelper.Language;
            group.Name = lang == "en" ? group.NameEn : lang == "ru" ? group.NameRu : group.NameUz;

            response.Data = group;

            return response;
        }
    }
}

using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Configurations;
using EducationCenterUoW.Domain.Entities.Groups;
using EducationCenterUoW.Service.DTOs.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Service.Interfaces
{
    public interface IGroupService
    {
        Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression);
        Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null);
        Task<BaseResponse<Group>> CreateAsync(GroupForCreationDto groupDto);
    }
}

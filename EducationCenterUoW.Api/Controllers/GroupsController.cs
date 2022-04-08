using EducationCenterUoW.Domain.Configurations;
using EducationCenterUoW.Service.DTOs.Groups;
using EducationCenterUoW.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationCenterUoW.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PaginationParams @params)
        {
            var result = await groupService.GetAllAsync(@params);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupForCreationDto groupDto)
        {
            var result = await groupService.CreateAsync(groupDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

    }
}

using EducationCenterUoW.Data.Contexts;
using EducationCenterUoW.Data.IRepositories;
using EducationCenterUoW.Domain.Entities.Groups;

namespace EducationCenterUoW.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(EducationCenterDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using EducationCenterUoW.Data.Contexts;
using EducationCenterUoW.Data.IRepositories;
using EducationCenterUoW.Domain.Entities.Teachers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EducationCenterDbContext dbContext) : base(dbContext)
        {
        }
    }
}

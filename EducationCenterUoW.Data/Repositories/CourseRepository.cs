using EducationCenterUoW.Data.Contexts;
using EducationCenterUoW.Data.IRepositories;
using EducationCenterUoW.Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(EducationCenterDbContext dbContext) : base(dbContext)
        {
        }
    }
}

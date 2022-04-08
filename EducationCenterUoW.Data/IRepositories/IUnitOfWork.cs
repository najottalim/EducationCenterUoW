using System;
using System.Threading.Tasks;

namespace EducationCenterUoW.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITeacherRepository Teachers { get; }
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        IGroupRepository Groups { get; }
        Task SaveChangesAsync();
    }
}

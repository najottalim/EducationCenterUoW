using EducationCenterUoW.Data.Contexts;
using EducationCenterUoW.Data.IRepositories;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace EducationCenterUoW.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationCenterDbContext context;
        private readonly IConfiguration config;

        /// <summary>
        /// Repositories
        /// </summary>
        public IStudentRepository Students { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public ITeacherRepository Teachers { get; private set; }

        public ICourseRepository Courses { get; private set; }

        public UnitOfWork(EducationCenterDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;            

            // Object initializing for repositories
            Students = new StudentRepository(context);
            Groups = new GroupRepository(context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

using EducationCenterUoW.Data.Contexts;
using EducationCenterUoW.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationCenterDbContext context;

        public IStudentRepository Students { get; private set; }

        public IGroupRepository Groups { get; private set; }

        public UnitOfWork(EducationCenterDbContext context)
        {
            this.context = context;

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

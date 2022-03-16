using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Domain.Entities.Departments
{
    public class EmployeeSalary : IAuditable
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}

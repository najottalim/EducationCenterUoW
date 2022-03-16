using EducationCenterUoW.Domain.Commons;
using EducationCenterUoW.Domain.Enums;
using EducationCenterUoW.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Domain.Entities.Courses
{
    public class Course : IAuditable, ILocalizationName
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Multilanguage names
        /// </summary>
        public string NameUz { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }

        public decimal Price { get; set; }
        public ushort Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Service.DTOs.Groups
{
    public class GroupForCreationDto
    {
        /// <summary>
        /// Multilanguage names
        /// </summary>
        public string NameUz { get; set; }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public Guid TeacherId { get; set; }

        public Guid CourseId { get; set; }
    }
}

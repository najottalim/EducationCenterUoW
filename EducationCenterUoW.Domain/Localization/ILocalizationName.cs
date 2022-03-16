using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Domain.Localization
{
    public interface ILocalizationName
    {
        string NameUz { get; set; }
        string NameRu { get; set; }
        string NameEn { get; set; }
    }
}

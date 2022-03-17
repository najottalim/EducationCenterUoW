using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Domain.Commons
{
    public class BaseResponse<TSource>
    {
        [JsonIgnore]
        public int? Code { get; set; }

        public TSource Data { get; set; }

        public ErrorResponse Error { get; set; }
    }
}

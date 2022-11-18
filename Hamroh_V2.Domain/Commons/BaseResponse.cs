using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hamroh_V2.Domain.Commons
{
    public class BaseResponse<TSourse>
    {
        [JsonIgnore]
        public int? Code { get; set; } = 200;

        public TSourse Data { get; set; }

        public ErrorResponse Error { get; set; }
    }
}

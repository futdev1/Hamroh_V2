using System.Text.Json.Serialization;

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

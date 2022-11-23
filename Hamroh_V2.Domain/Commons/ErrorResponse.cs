using System.Text.Json.Serialization;

namespace Hamroh_V2.Domain.Commons
{
    public class ErrorResponse
    {
        [JsonIgnore]
        public int? Code { get; set; }

        public string Message { get; set; }

        public ErrorResponse(int? code = null, string message = null)
        {
            Code = code;
            Message = message;
        }
    }
}

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DGII.Common
{

    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status { get; set; }

        public ApiResponse()
        {
            Status = (int)ApiStatus.TransactionSuccess;
            Message = "Success";
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public ApiResponse(string message)
        {
            Message = message;
        }

        public ApiResponse(string message, int status)
        {
            Message = message;
            Status = status;
        }
    }

    [DataContract]
    public class ApiResponse<T> : ApiResponse
    {
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
            Status = (int)ApiStatus.TransactionSuccess;
            Message = "Success";
        }

        public ApiResponse(string message) : base(message)
        {

        }

        public ApiResponse(string message, T data) : this(message)
        {
            Data = data;
        }

    }

}
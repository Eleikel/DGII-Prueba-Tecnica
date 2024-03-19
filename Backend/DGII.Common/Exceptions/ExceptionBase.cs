using System.Net;
using Newtonsoft.Json;

namespace DGII.Common.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        private HttpStatusCode internalServerError;

        public HttpStatusCode ErrorCode { get; }

        protected ExceptionBase(HttpStatusCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        protected ExceptionBase(HttpStatusCode internalServerError)
        {
            this.internalServerError = internalServerError;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

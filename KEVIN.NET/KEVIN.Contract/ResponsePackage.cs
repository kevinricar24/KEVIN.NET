using System.Text.Json.Serialization;
using KEVIN.Contract.Interfaces;
using Microsoft.AspNetCore.Http;

namespace KEVIN.Contract
{
    public class ResponsePackage<T> : IResponsePackage<T>
    {
        public ResponsePackage()
        {

        }

        public ResponsePackage(int myStatusCode, bool mySuccess, string message, T payload, object errors, int id)
        {
            statusCode = myStatusCode;
            success = mySuccess;
            Message = message;
            Payload = payload;
            Errors = errors;
            Id = id;
        }

        private int statusCode;

        [JsonIgnore]
        public int StatusCode
        {
            get { return statusCode == 0 ? StatusCodes.Status200OK : statusCode; }
            set { statusCode = value; }
        }

        private bool success;

        public bool Success
        {
            get { return Errors is null ? true : false; }
            set { success = value; }
        }

        public string Message { get; set; }
        public T Payload { get; set; }
        public object Errors { get; set; }
        public int Id { get; set; }
    }
}

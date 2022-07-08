namespace KEVIN.Contract.Interfaces
{
    public interface IResponsePackage<T>
    {
        int StatusCode { get; set; }
        bool Success { get; set; }
        T Payload { get; set; }
        string Message { get; set; }
        object Errors { get; set; }
        int Id { get; set; }
    }
}

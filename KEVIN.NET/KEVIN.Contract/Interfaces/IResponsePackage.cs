namespace KEVIN.Contract.Interfaces
{
    public interface IResponsePackage<T>
    {
        string Message { get; set; }
        T Result { get; set; }
        object Errors { get; set; }
    }
}

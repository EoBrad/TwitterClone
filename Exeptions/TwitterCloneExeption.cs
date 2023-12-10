namespace TwitterClone.Exeptions;

public class TwitterCloneExeption : BaseException
{
    public string ExceptionMessage { get; set; }

    public int StatusCode { get; set; }

    public TwitterCloneExeption(string message, int code)
    {
        ExceptionMessage = message;
        StatusCode = code;
    }
}

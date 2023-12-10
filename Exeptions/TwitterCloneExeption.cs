namespace TwitterClone.Exeptions;

public class TwitterCloneExeption : BaseException
{
    public string ExceptionMessage { get; set; }

    public int StatusCode { get; set; }
}

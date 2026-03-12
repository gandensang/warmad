namespace Commons;

public class ServiceResponse<T>
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "OK";
    public T Data { get; set; } = default!;
    public int Total { get; set; } // total seluruh data dari DB
    public decimal ValueTransaction { get; set; }
}
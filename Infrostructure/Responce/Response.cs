using System.Diagnostics;
using System.Net;

namespace Infrostructure.Responce;

public class Response<T>
{
    public int StatusCode  { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }

    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
    public Response(HttpStatusCode statusCode, string message)
    {
        Data = default;
        StatusCode = (int)statusCode;
        Message = message;
    }
}
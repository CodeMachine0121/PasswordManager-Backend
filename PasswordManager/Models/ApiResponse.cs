using PasswordManager.Controllers;
using PasswordManager.Enums;

namespace PasswordManager.Models;

public class ApiResponse
{
    public ApiStatus Status { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public static ApiResponse SuccessWithData(object data)
    {
        return new ApiResponse
        {
            Status = ApiStatus.Success,
            Data = data
        };
    }

    public static ApiResponse Success()
    {
        return new ApiResponse()
        {
            Status = ApiStatus.Success
        };
    }
}
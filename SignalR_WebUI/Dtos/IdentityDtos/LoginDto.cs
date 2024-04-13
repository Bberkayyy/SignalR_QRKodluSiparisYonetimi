namespace SignalR_WebUI.Dtos.IdentityDtos;

public class LoginDto
{
    private string? _returnUrl;
    public string ReturnUrl
    {
        get
        {
            if (_returnUrl is null)
                return "/";
            return _returnUrl;
        }
        set
        {
            _returnUrl = value;
        }
    }
    public string Username { get; set; }
    public string Password { get; set; }
}

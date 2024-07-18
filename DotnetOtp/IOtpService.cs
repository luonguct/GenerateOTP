namespace DotnetOtp
{
    public interface IOtpService
    {
        Task SendOtpAsync(string phoneNumber, string otp);
    }
}

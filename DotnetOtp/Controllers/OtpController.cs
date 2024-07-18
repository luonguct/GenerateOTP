using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vonage.Messaging;
using Vonage.Request;
using Vonage;

namespace DotnetOtp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOtp([FromQuery] string phoneNumber)
        {
            // Generate an OTP (this is just an example, implement your own logic)
            var otp = new Random().Next(100000, 999999).ToString();
            await _otpService.SendOtpAsync(phoneNumber, otp);
            return Ok(new { Message = "OTP sent successfully" });
        }
    }
}
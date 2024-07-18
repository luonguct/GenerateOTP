using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Vonage.Messaging;
using Vonage.Request;
using Vonage;
using Microsoft.Extensions.Options;

namespace DotnetOtp
{
    public class OtpService : IOtpService
    {

        private readonly string apiKey;
        private readonly string apiSecret;

        public OtpService(IOptions<VonageSettings> vonageSettings)
        {
            apiKey = vonageSettings.Value.ApiKey;
            apiSecret = vonageSettings.Value.ApiSecret;
        }

        public async Task SendOtpAsync(string phoneNumber, string otp)
        {
            var credentials = Credentials.FromApiKeyAndSecret(apiKey, apiSecret);
            var client = new VonageClient(credentials);

            var response = await client.SmsClient.SendAnSmsAsync(new SendSmsRequest
            {
                To = phoneNumber,
                From = "Vonage",
                Text = $"Your OTP is: {otp}"
            });

            Console.WriteLine(response.Messages[0].Status);
        }
    }
}

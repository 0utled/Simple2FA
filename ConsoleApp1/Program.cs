using EmailLib;
using System.Security.Cryptography;

var i = new EmailSettings()
{
    Username = "Botmailer@gmail.com",
    Password = "Password",
    Host = "smtp.gmail.com",
    Port = 587,
    FromEmail = "Botmailer@gmail.com"
};
byte[] randomBytes = new byte[5];
RandomNumberGenerator.Create().GetBytes(randomBytes, 0, 5);
string ConfirmToken = Convert.ToHexString(randomBytes);
string CompanyName = "The Company";
string EmailToUser = "UserEmail@gmail.com";
EmailService asd = new EmailService(i);
string HtmlBody = $"""
<div style="width: 100%; max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);">
    <div style="text-align: center; padding: 20px 0;">
        <h1 style="font-size: 24px; color: #333333;">{CompanyName}</h1>
    </div>
    <div style="text-align: center; padding: 20px; color: #555555;">
        <p>Beste Klant,</p>
        <p>Your verification code for logging into your account is:</p>
        <div style="font-size: 36px; color: #000000; letter-spacing: 5px; margin: 20px 0;">{ConfirmToken}</div> <!-- Replace with your actual code -->
        <p>This code will expire in 10 minutes.</p>
        <p>If you did not request this, please ignore this email or contact support.</p>
    </div>
</div>
""";

await asd.SendEmailAsync(EmailToUser, "Verification", HtmlBody);
Console.WriteLine("Succes");
Console.ReadLine();

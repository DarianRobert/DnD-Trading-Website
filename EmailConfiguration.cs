using System;
using System.Net;
using System.Net.Mail;

namespace DNDWebsite
{
    internal static class EmailConfiguration
    {
        public static string SenderAddress
        {
            get {
                return RequiredEnvironment("DND_SMTP_USERNAME");
            }
        }

        public static SmtpClient CreateClient()
        {
            string username = SenderAddress;
            string password = RequiredEnvironment("DND_SMTP_PASSWORD");
            return new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true, UseDefaultCredentials = false,
                                                           Credentials = new NetworkCredential(username, password) };
        }

        private static string RequiredEnvironment(string name)
        {
            string value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException("Set " + name + " before sending email.");
            return value;
        }
    }
}

using System;
using System.Net.Mail;

namespace DNDWebsite
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = Session["UserType"] as string;
            if (userType == "Sales Representative" || userType == "Manager")
            {
                Response.Redirect("Default.aspx");
                return;
            }

            if (IsPostBack)
                return;

            if (Session["UserName"] != null)
                txtName.Text = Session["UserName"].ToString();
            if (Session["UserEmail"] != null)
                txtEmail.Text = Session["UserEmail"].ToString();
            if (userType == "Client")
            {
                txtName.ReadOnly = true;
                txtEmail.ReadOnly = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(message))
            {
                SetStatus("Please fill in all fields.", false);
                return;
            }
            if (name.Contains("\r") || name.Contains("\n"))
            {
                SetStatus("Please enter your name on one line.", false);
                return;
            }

            MailAddress replyTo;
            try
            {
                replyTo = new MailAddress(email);
                if (!string.Equals(replyTo.Address, email, StringComparison.OrdinalIgnoreCase))
                    throw new FormatException();
            }
            catch (FormatException)
            {
                SetStatus("Please enter a valid email address.", false);
                return;
            }

            try
            {
                // Set credentials on the host; never keep an app password in source.
                string username = EmailConfiguration.SenderAddress;
                string inbox = Environment.GetEnvironmentVariable("DND_CONTACT_INBOX");
                if (string.IsNullOrWhiteSpace(inbox))
                    inbox = username;

                DateTime saTime = TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time"));
                using (MailMessage mail = new MailMessage()) using (SmtpClient smtp = EmailConfiguration.CreateClient())
                {
                    mail.From = new MailAddress(username, "DND Website Contact");
                    mail.To.Add(inbox);
                    // Authenticate as the site mailbox and let replies reach the visitor.
                    mail.ReplyToList.Add(replyTo);
                    mail.Subject = "Website Contact Form: " + name;
                    mail.Body = $"Name: {name}\nEmail: {email}\n\nMessage:\n{message}\n\n" +
                                $"Sent on: {saTime:dd MMM yyyy HH:mm} (SAST)";
                    smtp.Send(mail);
                }

                SetStatus("Thank you! Your message has been sent successfully.", true);
                txtMessage.Text = "";
                if (Session["UserType"] as string != "Client")
                {
                    txtName.Text = "";
                    txtEmail.Text = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Contact form mail failed: {0}", ex.GetType().Name);
                SetStatus("Sorry, there was an error sending your message. Please try again later.", false);
            }
        }

        private void SetStatus(string message, bool success)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = success ? System.Drawing.Color.Green : System.Drawing.Color.OrangeRed;
        }
    }
}

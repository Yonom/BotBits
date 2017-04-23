namespace BotBits
{
    public class Mail
    {
        public string Id { get; }
        public string Username { get; }
        public string Subject { get; }
        public string Body { get; }

        public Mail(string id, string username, string subject, string body)
        {
            this.Id = id;
            this.Username = username;
            this.Subject = subject;
            this.Body = body;
        }
    }
}
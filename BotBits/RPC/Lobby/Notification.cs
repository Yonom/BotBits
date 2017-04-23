using System;

namespace BotBits
{
    public class Notification
    {
        public string Channel { get;}
        public string Id { get; }
        public string Body { get; }
        public string Title { get; }
        public DateTime PublishDate { get; }
        public string RoomId { get;  }
        public string ImageUrl { get;}

        public Notification(string id, string channel, string title, string body, DateTime publishDate, string roomId, string imageUrl)
        {
            this.Id = id;
            this.Channel = channel;
            this.Title = title;
            this.Body = body;
            this.PublishDate = publishDate;
            this.RoomId = roomId;
            this.ImageUrl = imageUrl;
        }
    }
}
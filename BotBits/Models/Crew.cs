using System.Text.RegularExpressions;

namespace BotBits
{
    public class Crew
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Crew(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static Crew FromName(string name)
        {
            return new Crew(Regex.Replace(name, @"\s+", "").ToLower(), name);
        }
    }
}

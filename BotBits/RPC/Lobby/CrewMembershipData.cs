namespace BotBits
{
    public class CrewMembershipData
    {
        public string Id { get; }
        public string Name { get; }
        public string LogoWorld { get; }

        public CrewMembershipData(string id, string name, string logoWorld)
        {
            this.Id = id;
            this.Name = name;
            this.LogoWorld = logoWorld;
        }
    }
}
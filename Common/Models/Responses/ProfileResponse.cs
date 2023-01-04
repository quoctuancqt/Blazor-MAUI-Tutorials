namespace Common.Models.Responses
{
    public class ProfileResponse
    {
        public string UserId { get; set; }
        public string ShortName { get; set; }
        public string UserRole { get; set; }
        public string ClientId { get; set; }
        public string[] DealerIds { get; set; }
        public Permission[] Permissions { get; set; }
        public Deviceofbuilding[] DeviceOfBuildings { get; set; }
    }
}

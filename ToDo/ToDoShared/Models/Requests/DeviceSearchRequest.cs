using ToDoShared.Models.Common;

namespace ToDoShared.Models.Requests
{
    public class DeviceSearchRequest : DefaultSearchResponse
    {
        public string ClientId { get; set; }
        public string[] EquipmentTypeIds { get; set; }
        public string[] BuildingIds { get; set; }
        public string[] FloorIds { get; set; }
        public string[] RoomIds { get; set; }
        public string[] GatewayNos { get; set; }
        public string DeviceModel { get; set; }
    }
}

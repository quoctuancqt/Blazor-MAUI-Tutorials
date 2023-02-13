using ToDoShared.Extensions;
using ToDoShared.Models.Common;
using ToDoShared.Models.Requests;
using ToDoShared.Models.Responses;
using ToDoShared.Providers;

namespace ToDoShared.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<GroupItemResponse<DeviceResponse>>> SearchAsync(DeviceSearchRequest query);
    }

    public class DeviceService : IDeviceService
    {
        private readonly BmsApiClient _bmsApiClient;

        public DeviceService(BmsApiClient bmsApiClient)
        {
            _bmsApiClient = bmsApiClient;
        }

        public async Task<IEnumerable<GroupItemResponse<DeviceResponse>>> SearchAsync(DeviceSearchRequest query)
            => await _bmsApiClient.GetAsync<IEnumerable<GroupItemResponse<DeviceResponse>>>($"api/v1/Devices?{query.GetQueryString()}");
    }
}

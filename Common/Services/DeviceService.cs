using Common.Extensions;
using Common.Models.Common;
using Common.Models.Requests;
using Common.Models.Responses;
using Common.Providers;

namespace Common.Services
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

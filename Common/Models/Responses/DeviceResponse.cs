using Common.Models.Common;

namespace Common.Models.Responses
{
    public class DeviceResponse : BaseModelResponse
    {
        public string DeviceName { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
        public string EquipmentTypeId { get; set; }
        public string EquipmentTypeName { get; set; }
        public string DeviceImgUrl { get; set; }
        public int KeepAliveAlarmTimeOut { get; set; }
        public DateTime? LastDataReceviedAt { get; set; }
        public string SerialNumber { get; set; }
        public string SerialNo { get; set; }
        public string ModelNumber { get; set; }
        public string IDUNo { get; set; }
        public string IDNo { get; set; }
        public string Motor { get; set; }
        public string CUNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoolingCapacity { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuspend { get; set; }
        public bool IsNotification { get; set; }
        public bool IsAlarmError { get; set; }
        public bool IsAlarmSetting { get; set; }
        public bool IsAutomationSetting { get; set; }
        public object DeviceTelemetry { get; set; }
        public double TotalOperation { get; set; }
        public ICollection<DeviceAlarmSettingResponse> AlarmSettings { get; set; }
        public DetailDeviceModelResponse DetailDeviceModel { get; set; }
    }
}

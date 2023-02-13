namespace ToDoShared.Models.Common
{
    public class GroupItemResponse<T>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}

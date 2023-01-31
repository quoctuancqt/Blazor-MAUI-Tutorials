namespace ToDoApp.Models.Common
{
    public class BaseResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }
    }
}

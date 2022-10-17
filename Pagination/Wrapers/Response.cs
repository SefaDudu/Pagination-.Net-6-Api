namespace Pagination.Wrapers
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data)
        {

        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errorrs { get; set; }
        public string Message { get; set; }
    }
}

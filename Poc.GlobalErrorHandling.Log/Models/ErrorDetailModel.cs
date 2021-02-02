using Newtonsoft.Json;

namespace Poc.GlobalErrorHandling.Log.Models
{
    public class ErrorDetailModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

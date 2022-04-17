namespace Contrato.Models
{
    public class Integration
    {
        public string api_key { get; set; }
        public int integration_id { get; set; }
    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

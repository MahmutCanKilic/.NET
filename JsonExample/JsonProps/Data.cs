using Newtonsoft.Json;

namespace JsonProps
{

    /// <summary>
    /// Properties
    /// </summary>
    public class Product
    {
        #region Properties
        public string Name { get; set; }
        public int Id { get; set; }
        public int StockNumber { get; set; }
        public bool HasStock { get; set; }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"{Name} {Id} {StockNumber} {HasStock}";
        }
        #endregion
    }

    public class Category
    {
        #region Properties
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        #endregion
        #region Constructor
        public Category()
        {
            Products = new List<Product>();
        }
        #endregion
        #region Methods
        public override string ToString()
        {

            return $"{Name}  {Id}";
        }
        #endregion
    }

    public class Service
    {
        #region Properties
        [JsonProperty("isUtnDevice")]
        public bool IsUtnDevice { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("port")]
        public int Port { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("certificateName")]
        public string CertificateName { get; set; }
        [JsonProperty("serial")]
        public string Serial { get; set; }
        [JsonProperty("certificateStartDate")]
        public string CertificateStartDate { get; set; }
        [JsonProperty("certificateEndDate")]
        public string CertificateEndDate { get; set; }
        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
        [JsonProperty("isRunning")]
        public bool IsRunning { get; set; }
        [JsonProperty("runningMessage")]
        public string RunningMessage { get; set; }
        [JsonProperty("memory")]
        public string Memory { get; set; }

        #endregion
        #region Methods
        public override string ToString()
        {
            return $"{IsUtnDevice} {Ip} {Port} {Key} {CertificateName} {Serial}" +
                $" {CertificateStartDate} {CertificateEndDate} {IsEnabled} {IsRunning} {RunningMessage} {Memory}";
        }
        #endregion
    }
    public class ServiceList
    {
       public List<Service> Services { get; set; }
    }
}
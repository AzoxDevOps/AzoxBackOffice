namespace Azox.XQR.Business
{
    using System.Text.Json.Serialization;

    public class Address
    {
        #region Ctor

        public Address() { }

        [JsonConstructor]
        public Address(string city, string district, string addressLine)
        {
            City = city;
            District = district;
            AddressLine = addressLine;
        }

        [JsonConstructor]
        public Address(string city, string district, string addressLine, double latitude, double longitude) :
            this(city, district, addressLine)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion Ctor

        #region Properties

        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }

        #endregion Properties
    }
}
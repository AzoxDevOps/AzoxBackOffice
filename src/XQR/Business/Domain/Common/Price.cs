namespace Azox.XQR.Business
{
    using Azox.Core;

    using System.Globalization;
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public class Price
    {
        #region Ctor

        public Price()
        {
            Currency = Currency.Lira;
        }

        [JsonConstructor]
        public Price(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        #endregion Ctor

        #region Methods

        public override string ToString()
        {
            CultureInfo culture = Currency switch
            {
                Currency.Dollar => CultureInfo.GetCultureInfo("en-US"),
                Currency.Lira => CultureInfo.GetCultureInfo("tr-TR"),
                Currency.Pound => CultureInfo.GetCultureInfo("en-EN"),
                _ => throw new AzoxBugException()
            };

            return Amount.ToString("c", culture);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Currency Currency { get; set; }

        #endregion Properties
    }
}

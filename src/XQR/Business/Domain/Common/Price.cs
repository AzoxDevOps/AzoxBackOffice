namespace Azox.XQR.Business.Domain.Common
{
    using Azox.Core;
    using System.Globalization;

    /// <summary>
    /// 
    /// </summary>
    public readonly struct Price
    {
        #region Ctor

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
        public decimal Amount { get; }

        /// <summary>
        /// 
        /// </summary>
        public Currency Currency { get; }

        #endregion Properties
    }
}

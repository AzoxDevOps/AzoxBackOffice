namespace Azox.XQR.Business
{
    using System.ComponentModel;

    /// <summary>
    /// 
    /// </summary>
    public enum MerchantServeType
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Restorant")]
        Restaurant = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oda Servisi")]
        RoomService = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spa")]
        Spa = 30,
    }
}
namespace Azox.XQR.Business
{
    using System.ComponentModel;

    /// <summary>
    /// 
    /// </summary>
    public enum UserGroupType
    {
        /// <summary>
        /// Admin
        /// </summary>
        [Description("Sistem Yöneticisi")]
        Admin = 10,

        /// <summary>
        /// Bağlı olduğu tüm servislerde tanımlamaları yapabilen kullanıcılar
        /// </summary>
        [Description("İşletme Yöneticisi")]
        MerchantAdmin = 20,

        /// <summary>
        /// Servis içerisinde tanımlamaları yapabilen kullanıcılar
        /// </summary>
        [Description("Hizmet Yöneticisi")]
        ServiceAdmin = 30,

        /// <summary>
        /// Çalışan kullanıcılar için FE: Garson vb
        /// </summary>
        [Description("Hizmet Kullanıcısı")]
        ServiceUser = 40
    }
}

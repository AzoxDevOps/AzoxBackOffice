namespace Azox.XQR.Business
{
    /// <summary>
    /// 
    /// </summary>
    public enum UserGroupType
    {
        /// <summary>
        /// Admin
        /// </summary>
        Admin = 10,

        /// <summary>
        /// Bağlı olduğu tüm servislerde tanımlamaları yapabilen kullanıcılar
        /// </summary>
        MerchantAdmin = 20,

        /// <summary>
        /// Servis içerisinde tanımlamaları yapabilen kullanıcılar
        /// </summary>
        ServiceAdmin = 30,

        /// <summary>
        /// Çalışan kullanıcılar için FE: Garson vb
        /// </summary>
        ServiceUser = 40
    }
}

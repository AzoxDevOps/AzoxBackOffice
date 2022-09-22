namespace Azox.XQR.Presentation.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public record LoginModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez")]

        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
    }
}

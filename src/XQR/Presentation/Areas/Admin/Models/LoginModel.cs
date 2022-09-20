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
        [Required]

        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}

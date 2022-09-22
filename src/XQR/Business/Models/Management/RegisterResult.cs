namespace Azox.XQR.Business.Models.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RegisterResult
    {
        #region Static Methods

        public static RegisterResult InvalidUsernameOrPassword()
        {
            return new RegisterResult
            {
                Success = false
            };
        }

        public static RegisterResult UserExists()
        {
            return new RegisterResult
            {
                Success = false
            };
        }

        public static RegisterResult Succeeded()
        {
            return new RegisterResult
            {
                Success = true
            };
        }

        #endregion Static Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; internal set; }

        #endregion Properties
    }
}

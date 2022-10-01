namespace Azox.XQR.Business
{
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

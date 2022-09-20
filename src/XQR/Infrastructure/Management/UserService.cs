namespace Azox.XQR.Infrastructure
{
    using Azox.Core.Extensions;
    using Azox.Infrastructure.Core;
    using Azox.XQR.Business;
    using Azox.XQR.Business.Domain.Management;
    using Azox.XQR.Business.Models.Management;
    using System.Security.Cryptography;
    using System.Text;

    internal class UserService :
        EntityServiceBase<User>,
        IUserService
    {
        #region Ctor

        public UserService(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
        }

        #endregion Ctor

        #region Utils

        private string GeneratePasswordHash(string password, string passwordSalt)
        {
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            byte[] passwordSaltBytes = Convert.FromBase64String(passwordSalt);
            byte[] buffer = new byte[passwordBytes.Length + passwordSaltBytes.Length];

            Buffer.BlockCopy(passwordSaltBytes, 0, buffer, 0, passwordSaltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, buffer, passwordSaltBytes.Length, passwordBytes.Length);

            byte[] passwordHashBytes;
            using (SHA1 sha = SHA1.Create())
            {
                passwordHashBytes = sha.ComputeHash(buffer);
            }

            return Convert.ToBase64String(passwordHashBytes);
        }

        private (string PasswordSalt, string PasswordHash) PasswordEncrypt(string password)
        {
            byte[] passwordSaltBytes = RandomNumberGenerator.GetBytes(16);
            string passwordSalt = Convert.ToBase64String(passwordSaltBytes);

            return (passwordSalt, GeneratePasswordHash(password, passwordSalt));
        }

        #endregion Utils

        #region Methods

        public virtual async Task<User> GetByUsernameAsync(string username)
        {
            if (username.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(username));
            }

            username = username.Trim().ToLowerInvariant();
            return await Repository.SingleOrDefaultAsync(x => x.Username == username);
        }

        public virtual async Task<ValidateCredentialsResult> ValidateCredentials(string username, string password)
        {
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return ValidateCredentialsResult.InvalidUsernameOrPassword();
            }

            username = username.Trim().ToLowerInvariant();
            User user = await GetByUsernameAsync(username);

            if (user == null)
            {
                return ValidateCredentialsResult.InvalidUsernameOrPassword();
            }

            if (!user.IsActive)
            {
                return ValidateCredentialsResult.InactiveUser();
            }

            if (user.IsLocked)
            {
                return ValidateCredentialsResult.LockedUser();
            }

            if (user.PasswordHash != GeneratePasswordHash(password, user.PasswordSalt))
            {
                return ValidateCredentialsResult.InvalidUsernameOrPassword();
            }

            return ValidateCredentialsResult.Succeeded();
        }

        #endregion Methods
    }
}

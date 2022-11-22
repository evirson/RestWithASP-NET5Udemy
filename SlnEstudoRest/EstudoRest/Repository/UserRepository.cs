using EstudoRest.Data.VO;
using EstudoRest.Model;
using EstudoRest.Model.Context;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace EstudoRest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();

                    return result;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;

        }

        public bool Exists(long id)
        {
            return _context.Users.Any(p => p.Id.Equals(id));   
        }
        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public User ValidateCredentials(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Id.Equals(User.UserName == username));
        }
    }
}

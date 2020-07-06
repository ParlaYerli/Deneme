using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserDal userDal;
        public AuthService(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public void CreateCallCenter(User user)
        {
            userDal.CreateUser(user);
        }

        public List<User> GetAllCallCenterUser()
        {
            return userDal.GetAll(x => x.RoleId == 4).ToList();
        }

        public List<User> GetAllDealerUser()
        {
            return userDal.GetAll(x => x.RoleId == 1).ToList();
        }

        public User GetUserByDealerId(int dealerId)
        {
            return userDal.GetUser(x=>x.DealerId == dealerId);
        }

        public User GetUserById(int userId)
        {
            return userDal.GetUser(x => x.Id == userId);
        }

        public User LoginCallCenter(int userId, string password)
        {
            return userDal.Login(x => x.IsActive && (x.RoleId == 2 || x.RoleId == 4) && x.Id == userId && x.Password == PasswordHasher(password)); //Role : CallCenter & CallCenterAdmin
        }

        public User LoginDealer(int dealerId, string password)
        {
            return userDal.Login(x => x.IsActive && x.DealerId == dealerId && x.Password == PasswordHasher(password) && (x.RoleId == 1 || x.RoleId == 3)); // Dealer & Bayi
        }
        string serverKey = "demiroren";
        public string PasswordHasher(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {

                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData + serverKey));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string RandomPassword(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void UpdateUser(User user)
        {
            userDal.UpdateUser(user);
        }

        public PagedResult<User> GetUser(int? userId, int currentPage, int pageSize)
        {
            using (UserContext db = new UserContext())
            {
                if (userId == null || userId == 0)
                {
                    return db.Users.OrderByDescending(x => x.FullName).GetPaged(currentPage, pageSize);
                }
                else
                {
                    return db.Users.Where(x => x.Id == userId).OrderByDescending(x => x.FullName).GetPaged(currentPage, pageSize);
                }
            }
        }
    }
}


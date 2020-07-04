using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        User LoginDealer(int dealerId, string password);
        User LoginCallCenter(int userId, string password);
        User GetUserByDealerId(int dealerId);
        User GetUserById(int userId);
        List<User> GetAllCallCenterUser();
        List<User> GetAllDealerUser();
        void CreateCallCenter(User user);
        void UpdateUser(User user);
        string PasswordHasher(string password);
        string RandomPassword(int length);
    }
}

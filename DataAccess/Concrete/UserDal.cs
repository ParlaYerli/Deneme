using Core.Business.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User,UserContext>
    {
    }
}

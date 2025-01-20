using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research.DAL.Data;

namespace Research.DAL.Repository.Interface
{
    public interface IUsers
    {
        Partial.UserInfoMetadata.mvLoginUser SignIn(TblUser Obj_User);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research.DAL.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Research.DAL.Repository
{
    public class Users:Interface.IUsers
    {
        Functions.GeneralFunctions obj_generalfunc = new Functions.GeneralFunctions();
        private DbResearchPortalContext _context = new DbResearchPortalContext();
        public Users(DbResearchPortalContext context) { this._context = context; }
        public Partial.UserInfoMetadata.mvLoginUser SignIn(TblUser Obj_User)
        {
            
            string email = Obj_User.EmailId;
            string D_Password = obj_generalfunc.Encrypt(Obj_User.SPassword.ToString());
            var result = (from u in _context.TblUsers
                          where u.EmailId == email && u.SPassword == D_Password
                          select new Partial.UserInfoMetadata.mvLoginUser
                          {
                              UserId = u.UserId,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                               
                          }).FirstOrDefault();

            return result;
        }
    }
}

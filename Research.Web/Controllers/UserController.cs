using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Research.DAL.Data;

namespace Research.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DAL.Repository.Interface.IUsers _userRep;
        private IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _userRep = new DAL.Repository.Users(new DbResearchPortalContext());
            _config = config;
        }
        [HttpGet("login")]
        public IActionResult Login(string userEmail, string password)
        {   
            TblUser _usr = new TblUser();
            IActionResult response = Unauthorized();
            _usr.EmailId = userEmail;
            _usr.SPassword = password;
            var b=_userRep.SignIn(_usr);
            DAL.Partial.UserInfoMetadata.mvLoginUser mvLogin = new DAL.Partial.UserInfoMetadata.mvLoginUser();
            
            if (b != null) {
                mvLogin.EmailId = userEmail;
                mvLogin.FirstName = b.FirstName;
                mvLogin.UserId = b.UserId;
                var tkn = GenerateJWToken(mvLogin);
                response=Ok(new {token=tkn, user=b});
            }
            //var record = _userRep.SignIn(_usr);
            //var mytask = Task.Run(() => _userRep.SignIn(_usr));
            //DAL.Partial.UserInfoMetadata.mvLoginUser a = await mytask;


            return response;
        }
        private string GenerateJWToken(DAL.Partial.UserInfoMetadata.mvLoginUser usr)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usr.FirstName),
                new Claim(JwtRegisteredClaimNames.Email,usr.EmailId),
                new Claim("userid",usr.UserId.ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet("Getshirts")]
        public string GetShirts() { return "my shirts"; }

        [HttpGet("GetAllUser")]
        [Authorize]
        public List<DAL.Partial.UserInfoMetadata.mvLoginUser> GetAll()
        {
            List<DAL.Partial.UserInfoMetadata.mvLoginUser> lgnU = new List<DAL.Partial.UserInfoMetadata.mvLoginUser>();
            using (var ab =new DbResearchPortalContext()) { lgnU = (from u in ab.TblUsers select new DAL.Partial.UserInfoMetadata.mvLoginUser { FirstName = u.FirstName, EmailId = u.EmailId }).ToList(); }

            return lgnU;
        }
        public int TestFunc() {  return 0; }
    }
}

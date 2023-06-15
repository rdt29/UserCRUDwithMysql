using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTrailWithMysql.Entites;

namespace UserTrailWithMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _db;

        public UserController(UserDbContext db)
        {
            _db = db;
        }

        [HttpPost("Add-user")]
        public async Task<IActionResult> AddUser(string name, string email, int Roleid)
        {
            User user = new User()
            {
                name = name,
                email = email,
                Roleid = Roleid
            };

            _db.users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("Add-Role")]
        public async Task<IActionResult> AddRole(string Rolename)
        {
            Role role = new Role()
            {
                RoleName = Rolename,
            };

            _db.role.Add(role);
            await _db.SaveChangesAsync();
            return Ok(role);
        }

        [HttpPost("Add-Account")]
        public async Task<IActionResult> AddAccount(int userid)
        {
            Account acc = new Account()
            {
                userId = userid
            };

            await _db.account.AddAsync(acc);

            _db.SaveChanges();

            return Ok(acc);
        }

        [HttpGet("Get-user")]
        public async Task<IActionResult> getUser()
        {
            var res = await _db.users.ToListAsync();

            return Ok(res);
        }

        [HttpGet("Get-role")]
        public async Task<IActionResult> getRole()
        {
            var res = await _db.role.Include(x => x.Users).ToListAsync();

            return Ok(res);
        }

        [HttpGet("Get-account-details")]
        public async Task<IActionResult> getaccount()
        {
            var res = await _db.account.Include(x => x.user).ToListAsync();

            return Ok(res);
        }
    }
}
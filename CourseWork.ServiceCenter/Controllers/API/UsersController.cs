using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using CourseWork.ServiceCenter.ViewModels;

namespace CourseWork.ServiceCenter.Controllers.API
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in _context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UsersWithRolesViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            return Ok(usersWithRoles);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {
            var userInDb = _context.Users.Find(id);

            if (userInDb == null)
                return NotFound();

            _context.Users.Remove(userInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

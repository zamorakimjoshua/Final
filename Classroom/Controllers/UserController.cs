using Microsoft.AspNetCore.Mvc;
using ClassroomServices;
using ClassroomModel;
namespace Classroom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        UserGetServices _userGetServices;
        UserTransactionServices _userTransactionServices;

        public UserController()
        {
            _userGetServices = new UserGetServices();
            _userTransactionServices = new UserTransactionServices();
        }

        [HttpGet]

        public IEnumerable<User> GetUsers()
        {
            var user = _userGetServices.GetAllUsers();

            List<User> users = new List<User>();

            foreach (var Users in user)
            {
                users.Add(new Classroom.User { prof = Users.prof, roomNum = Users.roomNum, status = Users.status });
            }
            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = _userTransactionServices.CreateUser(request.prof, request.roomNum, request.status);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUSer(User request)
        {
            var result = _userTransactionServices.UpdateUser(request.prof, request.roomNum, request.status);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(User request)
        {
            var deleteCustomer = new ClassroomModel.User
            {
                prof = request.prof
            };

            var result = _userTransactionServices.DeleteUser(deleteCustomer);

            return new JsonResult(result);
        }


    }
}
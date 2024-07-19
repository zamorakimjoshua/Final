using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomData;
using ClassroomModel;

namespace ClassroomServices
{
    public class UserTransactionServices
  {
        UserValidationServices validationServices = new UserValidationServices();
        UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserExists(user.prof, user.roomNum, user.status))
            {
                userData.AddUser(user);
            }

            return result;
        }

        public bool CreateUser(string prof, string roomNum, string status)
        {
            User user = new User { prof = prof, roomNum = roomNum, status = status };

            return CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            bool result = validationServices.CheckIfNameExists(user.prof);

            if (validationServices.CheckIfNameExists(user.prof))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string prof, string roomNum, string status)
        {
            User user = new User { prof = prof, roomNum = roomNum, status = status };

            return UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            bool result = true;

            if (validationServices.CheckIfNameExists(user.prof))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }
    }
} 
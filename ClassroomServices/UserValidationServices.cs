using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomServices
{
    public class UserValidationServices
    {

        UserGetServices getservices = new UserGetServices();

        public bool CheckIfNameExists(string prof)
        {
            bool result = getservices.GetUsers(prof) != null;
            return result;
        }

        public bool CheckIfUserExists(string prof, string roomNum, string status)
        {
            bool result = getservices.GetUsers(prof, roomNum, status) != null;
            return result;
        }

    }
}

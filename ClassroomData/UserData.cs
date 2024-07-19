﻿using ClassroomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomData
{
    public class UserData
  
    {
        List<User> users;
    SqlDbData sqlData;

    public UserData()
    {
        users = new List<User>();
        sqlData = new SqlDbData();
    }
    public List<User> GetUsers()
    {
        users = sqlData.GetUsers();
        return users;
    }

    public int AddUser(User user)
    {
        return sqlData.AddUser(user.prof, user.roomNum, user.status);
    }

    public int UpdateUser(User user)
    {
        return sqlData.UpdateUser(user.prof, user.roomNum, user.status);
    }

    public int DeleteUser(User user)
    {
        return sqlData.DeleteUser(user.prof);
    }
}
}
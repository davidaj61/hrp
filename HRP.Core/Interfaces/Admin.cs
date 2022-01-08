using System;
using System.Collections.Generic;
using System.Text;
using HRP.DAL.Entities;

namespace HRP.Core.Interfaces
{
    public interface IAdmin
    {
        List<Person> GetAllUser();
        void AddUser(Person person,User user);
        void UpdateUser(Person person, User user);

    }
}

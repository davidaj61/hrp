using System;
using System.Collections.Generic;
using System.Text;
using HRP.DAL.Entities;

namespace HRP.Core.Interfaces
{
    public interface IAdmin
    {
        #region Peson

        List<Person> GetAllPerson();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);

        #endregion

        #region Role

        List<Role> GetAllRoles();
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);

        #endregion

        #region User
        List<User> GetAllUsers();
        void AddUser(User role);
        void UpdateUsere(User role);
        void DeleteUser(User role);


        #endregion


    }
}

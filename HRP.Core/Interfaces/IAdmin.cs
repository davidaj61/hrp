using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRP.Core.ViewModels.AdminPanel;
using HRP.DAL.Entities;

namespace HRP.Core.Interfaces
{
    public interface IAdmin:IDisposable
    {
        #region Peson

        Task<List<Person>> GetAllPerson();
        Task<Person> GetPersonByID(int Id);
        void DeletePerson(int Id);

        #endregion
        #region User

        Task<List<Person>> GetAllUser();
        Task<User> GetUserByID(Guid Id);
        void AddUser(UserViewModel viewModel);
        void UpdateUser(UserViewModel viewModel);
        void DeleteUser(Guid Id);

        #endregion

        #region Role

        Task<List<Role>> GetAllRoles();
        void AddRole(RoleViewModel viewModel);
        void UpdateRole(RoleViewModel viewModel,Guid id);
        void DeleteRole(Guid id);

        #endregion

        #region Gynecologist
        Task<List<Gynecologist>> GetAllGynecologist();
        void AddGynecologist(GynecologistViewModel viewModel);
        void UpdateGynecologist(GynecologistViewModel viewModel, byte id);
        void DeleteGynecologist(byte id);


        #endregion


    }
}

using HRP.Core.Interfaces;
using HRP.Core.Securities;
using HRP.Core.ViewModels.AdminPanel;
using HRP.DAL.Context;
using HRP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HRP.Core.Services
{
    class AdminService : IAdmin
    {
        private readonly DatabaseContext _context;

        public AdminService(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public void Dispose()
        {
            if (_context!=null)
            {
                _context.Dispose();
            }
        }

        #region User
        public Task<List<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }
        public Task<User> GetUserByID(Guid Id)
        {
            throw new NotImplementedException();
        }
        public void AddUser(UserViewModel viewModel)
        {
            Person person= new Person
            {
                Name = viewModel.Name,
                Family = viewModel.Family,
                Mobile = viewModel.Mobile,
                NationalId = viewModel.NationalCode,

            };
            _context.tbl_Persons.Add(person);
            User user = new User
            {
                UserName = viewModel.NationalCode.ToString("0000000000"),
                PasswordHash = viewModel.Password.ToGetHashCode(),
                LockoutEnabled=false,
                TwoFactorEnabled=false,
                PersonID = person.ID,
                IsActive = null,
            };

            _context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateUser(Guid id, UserViewModel viewModel)
        {
            var user = _context.Users.Find(id);
            
            if(user!=null)
            {
                var person = _context.tbl_Persons.Find(user.PersonID);
                person.Name = viewModel.Name;
                person.Family = viewModel.Family;
                person.Mobile = viewModel.Mobile;
                person.NationalId = viewModel.NationalCode;

                user.UserName = viewModel.NationalCode.ToString("0000000000");
                user.IsActive = viewModel.IsActive.Value;
            }
        }
        public void DeleteUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Role
        public async Task<List<Role>> GetAllRoles()
        {
           return await _context.Roles.ToListAsync();
        }
        public void AddRole(RoleViewModel viewModel)
        {
            Role role = new Role
            {
                Name = viewModel.Name,
                Title = viewModel.Title,
            };
            _context.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
        }
        public void UpdateRole(RoleViewModel viewModel)
        {
            Role role = new Role
            {
                Name = viewModel.Name,
                Title = viewModel.Title,
            };
            _context.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteRole(Guid Id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Person
        public async Task<List<Person>> GetAllPerson()
        {
            return await _context.tbl_Persons.ToListAsync();
        }
        public async Task<Person> GetPersonByID(int Id)
        {
            return await _context.tbl_Persons.FindAsync(Id);
        }
        public void DeletePerson(int Id)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Gynecologist
        public async Task<List<DAL.Entities.Gynecologist>> GetAllGynecologist()
        {
            return await _context.tbl_Gynecologists.ToListAsync();
        }
        public void AddGynecologist(GynecologistViewModel viewModel)
        {
            Gynecologist gynecologist = new Gynecologist
            {
                Name = viewModel.Name,
                IsActive = viewModel.IsActive.Value,
            };
            _context.Entry(gynecologist).State = EntityState.Added;
        }
        public void UpdateGynecologist(byte id, GynecologistViewModel viewModel)
        {
            var gynecologist = _context.tbl_Gynecologists.Find(id);
            if (gynecologist != null)
            {
                gynecologist.Name = viewModel.Name;
                gynecologist.IsActive = viewModel.IsActive.Value;

            }
        }
        public void DeleteGynecologist(byte Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateGynecologist(GynecologistViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserViewModel viewModel)
        {
            throw new NotImplementedException();
        }
        #endregion












    }
}

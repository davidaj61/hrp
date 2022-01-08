using System;
using System.Collections.Generic;
using System.Text;
using HRP.DAL.Entities;

namespace HRP.Core.Interfaces
{
    public interface IGynecologist : IDisposable
    {
        IList<Gynecologist> GetAll();

        bool Add(Gynecologist gynecologist);


        bool Update(Gynecologist gynecologist);



    }
}

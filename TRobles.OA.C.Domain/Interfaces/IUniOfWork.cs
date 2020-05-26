using System;
using System.Collections.Generic;
using System.Text;

namespace TRobles.OA.C.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}

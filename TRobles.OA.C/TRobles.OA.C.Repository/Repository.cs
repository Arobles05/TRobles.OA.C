using System;
using System.Collections.Generic;
using System.Text;
using TRobles.OA.C.Common.ImplementRepos;
using TRobles.OA.C.Common.Interfaces;

namespace TRobles.OA.C.Repository
{
    public class Repository<T> : ManageBaseRepository<T, ApplicationContext> where T : class, new() 
    {
        public Repository(IUnitOfWork unitOfWork, ApplicationContext context) : base(unitOfWork, context)
        {
        }
}
}

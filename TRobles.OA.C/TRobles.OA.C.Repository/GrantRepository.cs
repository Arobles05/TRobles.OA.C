using System;
using System.Collections.Generic;
using System.Text;
using TRobles.OA.C.Common.ImplementRepos;
using TRobles.OA.C.Common.Interfaces;

namespace TRobles.OA.C.Repository
{
    public class GrantRepository<T> : ManageBaseRepository<T, ApplicationContext> where T : class, new()
    {
        public GrantRepository(IUnitOfWork unitOfWork, ApplicationContext context) : base(unitOfWork, context)
        {
        }
}
}

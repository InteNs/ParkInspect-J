using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace ParkInspectPortal.Repositories
{
    public class AccessRepo:IAccessRepo
    {
        public bool IsAuthorized(Guid guid)
        {
            using (var ctx = new ParkInspectEntities())
            {
                var user = ctx.Employee.Where(q => q.Guid == guid).FirstOrDefault();
                return user != null;
            }
        }
    }
}
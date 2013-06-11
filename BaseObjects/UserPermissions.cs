using System;
using System.Collections.Generic;

namespace SharpUtils.BaseObjects
{
    public class UserPermissions
    {
        public string UserId { get; set; }
        public List<Permissions> Permission { get; set; }

        public class Permissions
        {
            public string PermissionId { get; set; }
            public bool Admin { get; set; }

            public Permissions()
            {
                Admin = false;
            }
        }
    }
}

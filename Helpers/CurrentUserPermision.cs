using System;
using System.Linq;
using System.Collections.Generic;

namespace SharpUtils.Helpers
{
    public class CurrentUserPermision
    {

        bool? _getAllUsers = null;

        List<SharpUtils.BaseObjects.UserPermissions.Permissions> _permissions;

        public CurrentUserPermision()
        {
            CurrentClaimsPrincipal currentClaimsPrincipal = new CurrentClaimsPrincipal();
            this._permissions = currentClaimsPrincipal.Permissions;
        }

        public bool HasPermission(string permission)
        {
            int hasPermission = (from p in _permissions where p.PermissionId == permission.ToLower() select new { }).Count();
            return hasPermission > 0;
        }

        public bool? GetAllUsers
        {
            get
            {
                if (_getAllUsers == null)
                {
                    _getAllUsers = HasPermission(Consts.Permissions.GetAllUsers);
                }
                return _getAllUsers;
            }
        }

    }
}

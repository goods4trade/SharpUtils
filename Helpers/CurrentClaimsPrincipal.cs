using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace SharpUtils.Helpers
{
    public class CurrentClaimsPrincipal
    {
        string _userName;
        string _userId;
        string _email;
        string _mobilePhone;
        string _claimStart;
        List<SharpUtils.BaseObjects.UserPermissions.Permissions> _permissions = null;
        ClaimsPrincipal _currentClaimsPrincipal;

        private string GetClaim(string key)
        {
            Claim nameClaim = _currentClaimsPrincipal.FindFirst(key);
            return nameClaim == null ? string.Empty : nameClaim.Value;
        }

        public CurrentClaimsPrincipal()
        {
            this._currentClaimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
        }

        public string UserName
        {
            get
            {
                if (_userName == null)
                {
                    _userName = GetClaim(Consts.ClaimKeys.UserName);
                }
                return _userName;
            }
        }

        public string UserId
        {
            get
            {
                if (_userId == null)
                {
                    _userId = GetClaim(Consts.ClaimKeys.UserId);
                }
                return _userId;
            }
        }

        public string Email
        {
            get
            {
                if (_email == null)
                {
                    _email = GetClaim(Consts.ClaimKeys.Email);
                }
                return _email;
            }
        }

        public string MobilePhone
        {
            get
            {
                if (_mobilePhone == null)
                {
                    _mobilePhone = GetClaim(Consts.ClaimKeys.MobilePhone);
                }
                return _mobilePhone;
            }
        }

        public DateTime? ClaimStart
        {
            get
            {
                if (_claimStart == null)
                {
                    _claimStart = GetClaim(Consts.ClaimKeys.ClaimStart);
                }
                return string.IsNullOrEmpty(_claimStart) ? (DateTime?)null : Convert.ToDateTime(_claimStart);
            }
        }

        public List<SharpUtils.BaseObjects.UserPermissions.Permissions> Permissions
        {
            get
            {
                if (_permissions ==  null)
                {
                    string permission;
                    SharpUtils.BaseObjects.UserPermissions userPermission;

                    _permissions = new List<BaseObjects.UserPermissions.Permissions>();
                    permission = GetClaim(Consts.ClaimKeys.UserPermission);
                    if (!string.IsNullOrEmpty(permission))
                    {
                        userPermission = permission.JsonToItem<SharpUtils.BaseObjects.UserPermissions>();
                        _permissions = userPermission.Permission;
                    }
                }
                return _permissions;
            }
        }

    }
}

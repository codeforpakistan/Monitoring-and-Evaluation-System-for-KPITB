using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class RoleManagementBL
    {
        //CreateRole
        public StatusModel roleCreateBL(CreateRoleVM m)
        {
            return RoleManagementDL.roleCreateDL(m);
        }
        //RoleEdit
        public StatusModel roleEditBL(EditRoleVM m)
        {
            return RoleManagementDL.roleEditDL(m);
        }
        //GetAllRole
        public List<GetAllRoleVM> getAllroleBL()
        {
            return RoleManagementDL.getRoleDL();
        }
        //RoleBasePermissionCombo
        public List<RolePermissionVM> getRoleBasePermissionComboBL(int RoleID)
        {
            return RoleManagementDL.getRoleBasePermissionComboDL(RoleID);
        }

        //RolePermission
        public List<RolePermissionVM> getRolePermissionBL()
        {
            return RoleManagementDL.getRolePermissionDL();
        }

        //AddUpateRolePermission
        public StatusModel addUpdateRolePermissionBL(RolePermissionWithRolVM rolePermission)
        {
            foreach (var item in rolePermission.LstRolePermission)
            {
                if(item.HasSubChild== true)
                {
                    item.HasChild = true;
                    item.HasParent = true;
                }
                else
                {
                    item.HasChild = false;
                    item.HasParent = false;
                }
            }
            return RoleManagementDL.addUpdateRolePermissionDL(rolePermission);
        }
        public EditRoleVM getSignleRoleBL(int RoleID)
        {
            EditRoleVM m = RoleManagementDL.getSignleRoleDL(RoleID);
            return m;
        }

    }
}

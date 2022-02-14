using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class RoleManagementBL
    {
        //CreateRole
        public ClsUserRole getUserRolePagesByIDBL(int RoleID)
        {
            ClsUserRole mdl = RoleManagementDL.getUserRolePagesByIDDL(RoleID);
            List<ClsWebPages> Parents = mdl.AllWebPages.Where(x => x.Parent_ID == 0).OrderBy(s=>s.OrderSeq).ToList();
            List<ClsWebPages> menus = new List<ClsWebPages>();
            //PARENT
            foreach (var item in Parents)
            {
                ClsWebPages p = new ClsWebPages();
                p.WebPageID = item.WebPageID;
                p.MainTitle = item.MainTitle;
                p.OrderSeq = item.OrderSeq;
                p.PageTitle = item.PageTitle;
                p.IsChecked = item.IsChecked;
                p.Url = item.Url;
                p.NormalIcon = item.NormalIcon;
                menus.Add(p);

                //CHILD
                List<ClsWebPages> Childs = mdl.AllWebPages.Where(x => x.Parent_ID == p.WebPageID).ToList();
                p.Childs = new List<ClsWebPages>();
                foreach (var subItem in Childs)
                {
                    ClsWebPages ch = new ClsWebPages();
                    ch.WebPageID = subItem.WebPageID;
                    ch.PageTitle = subItem.PageTitle;
                    ch.IsChecked = subItem.IsChecked;
                    ch.Url = subItem.Url;
                    ch.Controller = subItem.Controller;
                    ch.Action = subItem.Action;
                    ch.NormalIcon = subItem.NormalIcon;
                    p.Childs.Add(ch);
                }
            }
            mdl.AllWebPages = menus;
            return mdl;
        }

        public StatusModel SaveRoleBL(List<ClsWebPages> ActivePages, ClsUserRole Role, int LoginUserID)
        {
            StatusModel statusModel = new StatusModel();
            statusModel = RoleManagementDL.InsertRoleOnlyDL(Role, out int RoleID);
            if (statusModel.status)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RoleID", typeof(int));
                dt.Columns.Add("WebPage_ID", typeof(int));
                for (int i = 0; i < ActivePages.Count; i++)
                {
                    dt.Rows.Add(RoleID, ActivePages[i].WebPageID);
                }
                statusModel = RoleManagementDL.SaveRoleDL(dt);
            }
            return statusModel;
        }
        public StatusModel UpdateRoleBL(List<ClsWebPages> ActivePages, ClsUserRole Role)
        {
            StatusModel statusModel = new StatusModel();
            statusModel = RoleManagementDL.UpdateRoleOnlyDL(Role);
            if (statusModel.status)
            {
                if(ActivePages == null) 
                    ActivePages = new List<ClsWebPages>();
                DataTable dt = new DataTable();
                dt.Columns.Add("RoleID", typeof(int));
                dt.Columns.Add("WebPage_ID", typeof(int));
                for (int i = 0; i < ActivePages.Count; i++)
                {
                    dt.Rows.Add(Role.RoleID, ActivePages[i].WebPageID);
                }
                statusModel = RoleManagementDL.UpdateRoleDL(dt, Convert.ToInt32(Role.RoleID));
                }
           
            return statusModel;
        }



















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
                if (item.HasSubChild == true)
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

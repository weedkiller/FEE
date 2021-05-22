using Dapper;
using FEE.Library;
using FEE.Models;
using FEE.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTEHY.Model.Constants;

namespace FEE.Areas.Admin.Controllers
{
    public class PermissionController : Controller
    {
        private FEEDbContext db = new FEEDbContext();
        public ActionResult GetCommandViews()
        {
            var sql = @"select f.FunctionId as FunctionId,f.Name as Name,f.ParentId as ParentId,
		                        sum((case when c.CommandId = 'CREATE' then 1 else 0 end)) as HasCreate,
		                        sum((case when c.CommandId = 'VIEW' then 1 else 0 end)) as HasView,
		                        sum((case when c.CommandId = 'UPDATE' then 1 else 0 end)) as HasUpdate,
		                        sum((case when c.CommandId = 'DELETE' then 1 else 0 end)) as HasDelete,
		                        sum((case when c.CommandId = 'APPROVE' then 1 else 0 end)) as HasApprove,
                                sum((case when c.CommandId = 'REPLY' then 1 else 0 end)) as HasReply,
                                sum((case when c.CommandId = 'TRASH' then 1 else 0 end)) as HasTrash
	                    from Functions as f inner join CommandInFunctions as cif on f.FunctionId = cif.FunctionId 
			                    inner join Commands as c on cif.CommandId = c.CommandId
			                    group by f.FunctionId,f.Name,f.ParentId order by f.ParentId";
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G6EPV8T\SQLEXPRESS;Initial Catalog=FEE;Integrated Security=True;"))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var result = conn.Query<PermissionScreenViewModel>(sql, null, null, true, 120, CommandType.Text);

                List<PermissionScreenViewModel> listResult = new List<PermissionScreenViewModel>();

                foreach (var item in result)
                {
                    if (String.IsNullOrEmpty(item.ParentId))
                    {
                        foreach (var sub in result)
                        {
                            if (sub.ParentId == item.FunctionId)
                            {
                                item.Childrens.Add(sub);
                            }

                        }
                        listResult.Add(item);
                    }
                    else
                    {
                        foreach (var sub in result)
                        {
                            if (sub.ParentId == item.FunctionId)
                            {
                                item.Childrens.Add(sub);
                            }
                        }
                    }
                }
                return View(listResult);
            }
        }
        public JsonResult GetPermissions(int roleId)
        {
            var listModels = from p in db.Permissions
                             join r in db.Roles
                             on p.RoleId equals r.RoleId
                             where r.RoleId == roleId
                             select new PermissionViewModel()
                             {
                                 CommandId = p.CommandId,
                                 FunctionId = p.FunctionId,
                                 RoleId = p.RoleId
                             };
            var result = listModels.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SavePermission(int roleId, List<string> listPermissions)
        {
            if(roleId == 0)
            {
                Notification.set_flash("Vui lòng chọn nhóm quyền!", "warning");
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var item in db.Permissions.Where(x => x.RoleId == roleId).ToList())
                {
                    db.Permissions.Remove(item);
                }
                foreach (var item in listPermissions.Distinct())
                {
                    string[] arrListStr = item.Split('_');
                    var model = new Permission();
                    model.RoleId = roleId;
                    model.CommandId = arrListStr[arrListStr.Length - 1];
                    model.FunctionId = item.Substring(0, item.Length - arrListStr[arrListStr.Length - 1].Length - 1);

                    db.Permissions.Add(model);
                }
                Notification.set_flash("Cập nhật quyền thành công!", "success");
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
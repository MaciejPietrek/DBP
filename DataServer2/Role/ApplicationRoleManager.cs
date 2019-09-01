using DataServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DataServer.Role
{
	public class ApplicationRoleManager : RoleManager<IdentityRole>
	{
		public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
		{
		}

		public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext owinContext)
		{
			var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(owinContext.Get<ApplicationDbContext>()));
			roleManager.Setup();
			return roleManager;
		}

		public static List<string> DefinedRoles { get; } = new List<string> { "admin", "overseer", "janitor", "treasurer" };

		private void Setup()
		{
			int roleCount = this.Roles.Count();
			if (roleCount != DefinedRoles.Count)
			{
				foreach(string roleName in DefinedRoles)
				{
					IdentityRole role;
					role = this.FindByName(roleName);
					if(role == null)
					{
						role = new IdentityRole(roleName);
						this.Create(role);
					}
				}
			}
		}
	}
}
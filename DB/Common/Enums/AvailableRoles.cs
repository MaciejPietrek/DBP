using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Common.Enums
{
    public enum AvailableRoles
    {
        [Display(Name = "Administrator")]
        Administrator,
        //[Display(Name = "UserManagement")]
        UserManagement,
        [Display(Name = "Janitor")]
        Janitor,
        [Display(Name = "Overseer")]
        Overseer,
        [Display(Name = "Treasurer")]
        Treasurer,
        [Display(Name = "The one and only Jojo")]
        Jojo
    }
}

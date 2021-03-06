﻿using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Concrete.SerializeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace sRecipe.WebUI.Infrastructures.Concrete
{
    /// <summary>
    /// hold Principal
    /// </summary>
    public class sRecipePrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }


        public sRecipePrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public sRecipePrincipal()
        {
        }

        public bool IsInRole(string roleName)
        {
            Role role;
            bool success = Enum.TryParse(roleName, out role);
            if (success)
                return role == Role;
            else
                return false;
        }

        public int UserId { get; set; }
        public string NickName { get; set; }
        public Role Role { get; set; }
        public ProfileSerializeModel Profile { get; set; }

    }
}
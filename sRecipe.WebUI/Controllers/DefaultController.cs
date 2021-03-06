﻿using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Filters;
using sRecipe.WebUI.Infrastructures.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xunit;

namespace sRecipe.WebUI.Controllers
{
    public class DefaultController : ThemeControllerBase
    {
        public DefaultController(IsRecipeEFRepository repo) : base(repo)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        #region "JUST SAMPLE"

        /// <summary>
        /// Sample action for a membership use
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public string Member()
        {
            return "This is the List action on the Home controller Member:" + User.NickName;
        }

        /// <summary>
        /// Sample action for only Administrator
        /// </summary>
        /// <returns></returns>
        [AdminAuth]
        public string Admin()
        {
            return "This is the List action on the Home controller Admin:" + User.NickName;
        }

        [Authorize(Roles ="Administrator")]
        public string Role()
        {
            return "This is the List action on the Home controller Role Administrator:" + User.NickName;
        }

        public ActionResult Error()
        {
            var test = int.Parse("test");
            return View();
        }
        #endregion
    }
}
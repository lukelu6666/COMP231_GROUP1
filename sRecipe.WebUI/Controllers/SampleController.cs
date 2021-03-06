﻿using AutoMapper;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.ActionResults;
using sRecipe.WebUI.Infrastructures.Filters;
using sRecipe.WebUI.Infrastructures.Themes;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Controllers
{
    public class SampleController : ThemeControllerBase
    {
        private sRecipeContext _context;

        public SampleController(IsRecipeEFRepository repo) : base(repo)
        {
            _context = new sRecipeContext();
        }

        [AdminAuth]
        public ActionResult RecipeXML()
        {
            var recipes = _repo.GetRecipes().ToList();
            return new XMLResult(Mapper.Map<List<Recipe>, List<RecipeViewModel>>(recipes));
        }

        /// <summary>
        /// try add a mealtype through post a xml
        /// </summary>
        /// <param name="mtype"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMealType(MealTypeViewModel mtype)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<MealTypeViewModel, MealType>(mtype);
                _context.MealTypes.Add(data);
                _context.SaveChanges();
                return Content("OK");
            }
            return Content("Error");
        }

        /// <summary>
        /// testing whether IsRecipeMobile works
        /// </summary>
        /// <returns></returns>
        [IsRecipeMobile]
        public string getMobile()
        {
            return "This method only use for mobile.";
        }
        public ActionResult RecipeCSV()
        {
            var recipes = _repo.GetRecipes().ToList();
            return new CSVResult(Mapper.Map<List<Recipe>, List<RecipeViewModel>>(recipes), "TestCSV");
        }
    }
}
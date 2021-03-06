﻿using sRecipe.Repository.Abstract;
using System;
using System.Linq;
using sRecipe.Repository.ActionResults;
using sRecipe.Repository.Entities;
using sRecipe.Repository.Helpers;

namespace sRecipe.Repository.Concrete
{
    public partial class sRecipeEFRepository : IsRecipeEFRepository
    {

        #region Ingredient CRUD
        public RepositoryActionResult<Ingredient> InsertIngredient(Ingredient entity)
        {
            return RepositoryActionResultExtensions<Ingredient, sRecipeContext>
                        .Insert(_ctx,
                                entity
                                );
        }

        public IQueryable<Ingredient> GetIngredients()
        {
            return _ctx.Ingredients;
        }

        public Ingredient GetIngredient(int id)
        {
            return _ctx.Ingredients.Where(s => s.Id == id).FirstOrDefault();
        }

        public RepositoryActionResult<Ingredient> UpdateIngredient(Ingredient entity)
        {
            return RepositoryActionResultExtensions<Ingredient, sRecipeContext>
                 .Update(_ctx,
                         _ctx.Ingredients
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }
        public RepositoryActionResult<Ingredient> DeleteIngredient(int id)
        {
            return RepositoryActionResultExtensions<Ingredient, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Ingredients
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }
        #endregion
    }
}

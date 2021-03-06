﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class MadeItProcess
    {
       
        public int Id { get; set; }
        public int MadeItId { get; set; }
        public string Description { get; set; }
        public int PictureId { get; set; }
        [DefaultValue(10)]
        public int Order { get; set; }

        //public virtual MadeIt MadeIt { get; set; }
        public virtual Picture Picture { get; set; }

    }
}

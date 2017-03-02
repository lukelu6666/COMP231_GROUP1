﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.ActionResults
{
    public enum RepositoryActionStatus
    {
        Ok,
        Created,
        Updated,
        NotFound,
        Deleted,
        NothingModified,
        Error
    }
}

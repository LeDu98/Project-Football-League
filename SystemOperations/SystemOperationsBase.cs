﻿using Repositories;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public abstract class SystemOperationsBase
    {
        protected IRepositoryGeneric repository;
        public object Result { get; protected set; }
        public List<object> ResultList { get; protected set; }
        public bool Uspelo { get; protected set; }
        public SystemOperationsBase()
        {
            repository = new GenericRepository();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExample.data
{
    public class ResultRepository
    {
        private WhateverEntities _entities = new WhateverEntities();

        public void Add(Result result)
        {
            _entities.Results.Add(result);
            _entities.SaveChanges();
        }
    }
}

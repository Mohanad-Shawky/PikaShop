﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Contracts.Partial
{
    public interface IUpdate<TEntity, TKey>
    {
        public void Update(TEntity entity, TEntity other, string username = "system");

        public void UpdateById(TKey key, TEntity other,string username="system");
    }
}

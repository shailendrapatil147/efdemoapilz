﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZ.Common.efdemo
{
    public class CompositeModelBuilder
    {
        private List<IEntityModel> models = new List<IEntityModel>();
        public void Build(ModelBuilder modelBuilder)
        {
            foreach (var model in models)
            {
                model.BuildModel(modelBuilder);
            }

            models = new List<IEntityModel>();
        }

        public void Add(IEntityModel entityModel)
        {
            models.Add(entityModel);
        }

        public void AddRange(IEnumerable<IEntityModel> newModels)
        {
            models.AddRange(newModels);
        }
    }
}

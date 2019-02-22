using System.Collections.Generic;

namespace LZ.Common.efdemo
{
    public static class ModelBuilderExtension
    {
        public static CompositeModelBuilder AddModel(this CompositeModelBuilder compositeBuilder, IEntityModel entityModel)
        {
            compositeBuilder.Add(entityModel);
            return compositeBuilder;
        }

        public static CompositeModelBuilder AddModelRange(this CompositeModelBuilder compositeBuilder, IEnumerable<IEntityModel> newModels)
        {
            compositeBuilder.AddRange(newModels);
            return compositeBuilder;
        }
    }
}


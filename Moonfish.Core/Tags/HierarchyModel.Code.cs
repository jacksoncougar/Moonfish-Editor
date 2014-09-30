using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Tags
{
    public partial class HierarchyModel
    {
        public void Initialize()
        {
            SelectedVariationIndex = 0;
        }

        public object[] RenderObjects()
        {
            // draw selected variation with selected permutation
            var variantQuery = (from variant in this.variants
                          where variant.name == SelectedVariation
                          select variant.regions).Single();

            //var permutationQuery = from region in variantQuery;
                                   //where region.regionNameMustMatchRegionNameInRenderModel


            // call draw on children objects

            // draw nodes

            // draw markers

            // draw extras
            return null;
        }

        public RenderModelBlock RenderModel
        {
            get { return Halo2.GetReferenceObject(this.renderModel); }
        }

        public List<StringID> Variations
        {
            get
            {
                return (from variant in this.variants
                       select variant.name
                       ).ToList();
            }
            set
            {
                var query = (from variant in this.variants
                            select variant.name).ToList();
                for(int i = 0; i < query.Count() && i < value.Count; ++i)
                {
                    query[i] = value[i];
                }
                
            }
        }

        public int SelectedVariationIndex
        {
            get;
            set;
        }
        
        public StringID SelectedVariation
        {
            get { return Variations[SelectedVariationIndex]; }

            set
            {
                var index = Variations.IndexOf(value);
                Variations[index] = value;
            }
        }
    }
    public partial class ModelVariantObjectBlock
    {
        public object ChildObject { get { return Halo2.GetReferenceObject(this.childObject); } }
    }
}

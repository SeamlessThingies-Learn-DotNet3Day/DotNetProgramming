using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.NH.E01.CompleteEX.Entities;
using FluentNHibernate.Mapping;

namespace bSeamless.DotNetProg.NH.E01.CompleteEX.Maps
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}

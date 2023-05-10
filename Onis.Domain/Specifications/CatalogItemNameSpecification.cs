using Onis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;

namespace Onis.Domain.Specifications
{
    public class CatalogItemNameSpecification : Specification<CatalogItem>
    {
        public CatalogItemNameSpecification(string catalogItemName)
        {
            Query.Where(item => catalogItemName == item.Name);
        }
    }

}

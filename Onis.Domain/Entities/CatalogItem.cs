using Onis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Onis.Domain.Entities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public int CatalogTypeId { get; set; }
    public CatalogType? CatalogType { get; set; }
    public int CatalogBrandId { get; set; }
    public CatalogBrand? CatalogBrand { get; set; }
    public int? AvailableStock { get; set; }
    public int? RestockThreshold { get; set; }
    public int? MaxStockThreshold { get; set; }
    public bool OnReorder { get; set; }


           public CatalogItem(string name,
            string description,
            decimal price,
            string pictureUri,
            int catalogTypeId,
            int catalogBrandId,
            int? availableStock,
            int? restockThreshold,
            int? maxStockThreshold,
            bool onReorder = false)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            AvailableStock = availableStock;
            RestockThreshold = restockThreshold;
            MaxStockThreshold = maxStockThreshold;
            OnReorder = onReorder;
        }

        public void UpdateDetails(CatalogItemDetails details)
        {
            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }
    }
    /// <summary>
    /// Immutable object to modify the entity
    /// </summary>
    public readonly record struct CatalogItemDetails
    {
        public string? Name { get; }
        public string? Description { get; }
        public decimal Price { get; }

        public CatalogItemDetails(string? name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}

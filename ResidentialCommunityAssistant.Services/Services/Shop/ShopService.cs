namespace ResidentialCommunityAssistant.Services.Services.Shop
{
    using Microsoft.EntityFrameworkCore;
    using ResidentialCommunityAssistant.Data;
    using ResidentialCommunityAssistant.Data.Models;
    using ResidentialCommunityAssistant.Services.Contracts.Shop;
    using ResidentialCommunityAssistant.Services.Models.Shop;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShopService : IShopService
    {
        private readonly CommunityAssistantDBContext data;

        public ShopService(CommunityAssistantDBContext data)
        {
            this.data = data;
        }

        public async Task AddProductToShoppingCard(int productId, string userId)
        {
            OrderCache? oc = await FindOrderCacheAsync(productId, userId);
            if (oc == null)
            {
                oc = new OrderCache()
                {
                    ProductId = productId,
                    UserId = userId                
                };

                await this.data.OrdersCaches.AddAsync(oc);
            }
            oc.Quantity++;

            int totalAmountOfGivenItem = this.data.Products.Where(p => p.Id == productId).Select(pq => pq.Quantity).FirstOrDefault();
            if (totalAmountOfGivenItem == 0 || oc.Quantity > totalAmountOfGivenItem)
            {
                return;
            }

            await this.data.SaveChangesAsync();
        }

        public async Task<int> ApprovedOrder(string userId)
        {            
            var oc = await this.data.OrdersCaches.Where(u => u.UserId == userId).ToListAsync();
            Order order = new Order();
            order.UserId = userId;
            order.CreatedOn = DateTime.Now;

            await this.data.Orders.AddAsync(order);
            await this.data.SaveChangesAsync();

            int newOrderId = order.Id;

            foreach (var orderedProduct in oc)
            {
                int orderedProductId = orderedProduct.ProductId;
                Product? currentProduct = await this.data.Products.FindAsync(orderedProductId);
                if (currentProduct != null)
                {
                    await SaveProductsToOrder(newOrderId, currentProduct.Id, orderedProduct.Quantity);
                    currentProduct.Quantity -= orderedProduct.Quantity;
                    this.data.OrdersCaches.Remove(orderedProduct);
                }
            }

            await this.data.SaveChangesAsync();

            return order.Id;
        }

        public async Task<IEnumerable<OrderNumberViewModel>> GetAllOrdersByUserIdAsync(string userId)
        {
            return await this.data.Orders
                                  .Where(u => u.UserId == userId)
                                  .Select(o => new OrderNumberViewModel(o.Id)
                                  {
                                      RegularId = o.Id
                                  })
                                  .ToListAsync();
        }

        public async Task<ICollection<ProductViewModel>> GetAllProductsAsync()
        {
            return await this.data.Products
                                  .Where(pq => pq.Quantity > 0)
                                  .Select(p => new ProductViewModel()
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Description = p.Description,
                                      ImgURL = p.ImgURL,
                                      Price = p.Price,
                                      Quantity = p.Quantity
                                  })
                                  .ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCardViewModel>> GetAllProductsInShoppingCardAsync(string userId)
        {
            return await this.data.OrdersCaches
                            .Where(u => u.UserId == userId)
                            .Select(o => new ShoppingCardViewModel()
                            {
                                Id = o.ProductId,
                                Name = o.Product.Name,
                                ImgURL = o.Product.ImgURL,
                                Quantity = o.Quantity,
                                PricePerQuantity = o.Product.Price
                            })
                            .ToListAsync();
        }

        public async Task<OrderHistoryViewModel> GetShopHistoryDetails(int orderId)
        {
           
            return await this.data.Orders
                                  .Where(o => o.Id == orderId)
                                  .Select(o => new OrderHistoryViewModel()
                                  {
                                      OrderNumber = new OrderNumberViewModel(o.Id),
                                      CreatedOn = o.CreatedOn.ToString("dd/MM/yyyy"),
                                      OrderItems = o.OrdersProducts.Select(p => new ShoppingCardViewModel()
                                      {
                                          ImgURL = p.Product.ImgURL,
                                          Name = p.Product.Name,
                                          PricePerQuantity = p.Product.Price,
                                          Quantity = o.OrdersProducts.Where(q => q.ProductId == p.ProductId).Select(a=> a.Quantity).FirstOrDefault()
                                      }).ToList()
                                  })
                                  .FirstOrDefaultAsync();
            //return await this.data.OrdersProducts
            //                      .Where(o => o.OrderId == orderId)
            //                      .Select(o => new ShoppingCardViewModel()
            //                      {
            //                         Name = o.Product.Name,
            //                         ImgURL = o.Product.ImgURL,
            //                         PricePerQuantity = o.Product.Price,
            //                         Quantity = o.Quantity
            //                      })
            //                      .ToListAsync();
        }

        public void RemoveProductToShoppingCard(int productId, string userId)
        {
            OrderCache? oc = this.data.OrdersCaches
                                  .Where(oc => oc.UserId == userId && oc.ProductId == productId)
                                  .FirstOrDefault();
            if (oc == null)
            {
                return;
            }
            oc.Quantity--;
            if (oc.Quantity == 0)
            {
                this.data.OrdersCaches.Remove(oc);
            }

            this.data.SaveChanges();
        }

        private async Task<OrderCache?> FindOrderCacheAsync(int productId, string userId)
        {
            return await this.data.OrdersCaches
                                  .Where(oc => oc.UserId == userId && oc.ProductId == productId)
                                  .FirstOrDefaultAsync();
        }

        private async Task SaveProductsToOrder(int orderId, int productId, int quantity)
        {
            OrderProduct op = new OrderProduct()
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity
            };

            await this.data.OrdersProducts.AddAsync(op);
        }
    }
}

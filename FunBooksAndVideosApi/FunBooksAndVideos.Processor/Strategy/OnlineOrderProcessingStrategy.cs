﻿using FunBooksAndVideos.Data.Entities;
using FunBooksAndVideos.Data.Repositories.Interfaces;
using FunBooksAndVideos.Processor.Model;

namespace FunBooksAndVideos.Processor.Strategy
{
    public class OnlineOrderProcessingStrategy : IPurchaseOrderProcessingStrategy
    {
        public List<string> ProductType { get => new() { "eBook", "Video" }; }

        private readonly ICustomerProductRepository customerProductRepository;
        public OnlineOrderProcessingStrategy(ICustomerProductRepository customerProductRepository)
        {
             this.customerProductRepository = customerProductRepository;
        }

        public async Task Process(CreatePurchaseOrderRequest request, int purchaseOrderId, Product product)
        {
            await customerProductRepository.Add(request.CustomerId, product.Id);
        }
    }
}

﻿namespace FunBooksAndVideos.Service.Model
{
    public class CreatePurchaseOrderRequestDto
    {
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> ItemLines { get; set; }
    }
}

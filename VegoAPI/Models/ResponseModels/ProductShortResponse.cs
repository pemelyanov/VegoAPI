﻿namespace VegoAPI.Models.ResponseModels
{
    public class ProductShortResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
    }
}

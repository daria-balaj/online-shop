using System;
using System.ComponentModel.DataAnnotations;


namespace API.Models{
    public class Product {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        // public Product(int productID, string title, string description, float price, string imageURL) 
        // {
        //     ProductID = productID;
        //     Title = title;
        //     Description = description;
        //     Price = price;
        //     Image = imageURL;
        // }
        
    }
}
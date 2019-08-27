﻿using System;
using System.ComponentModel.DataAnnotations;


namespace Shop.Web.Data.Entities
{
    public class Product : IEntity
    {

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage ="The field {0} only can contain {1} characters leng.")]
        [Required]
        public string Name { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }


        [Display(Name= "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Last Purchas")]
        public DateTime? LasPurchase { get; set; }


        [Display(Name= "Last Sale")]
        public DateTime? LastSale { get; set; }


        [Display(Name ="Is Availabe?")]
        public bool IsAvailabe { get; set; }


        [DisplayFormat(DataFormatString ="{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        public User User { get; set; }


    }
}

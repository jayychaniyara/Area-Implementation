using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.DomainModels
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name can't be blank")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Alphabets only")]
        [MaxLength(20, ErrorMessage = "Product name can be maximum 20 characters long")]
        [MinLength(2, ErrorMessage = "Product name should contain at least 2 characters")]
        public string ProductName { get; set; }

        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date Of Purchase")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Price (USD)")]
        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0, 10000, ErrorMessage = "Price should be between $0-10,000")]
        public Nullable<decimal> Price { get; set; }


        [Display(Name = "Availablity Status")]
        public string AvailablityStatus { get; set; }

        [Display(Name = "Category Id")]
        [Required]
        public Nullable<long> CategoryId { get; set; }

        [Display(Name = "Brand Id")]
        [Required]
        public Nullable<long> BrandId { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Image")]
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}

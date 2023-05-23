using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.DomainModels
{
    public class Brand
    {
        [Key]
        public long BrandId { get; set; }

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Brand Name can't be blank")]
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Alphabets only")]
        [MaxLength(20, ErrorMessage = "Brand name can be maximum 20 characters long")]
        [MinLength(2, ErrorMessage = "Brand name should contain at least 2 characters")]
        public string BrandName { get; set; }
    }
}

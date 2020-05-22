using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace market
{
    public partial class Markets
    {
        public Markets()
        {
            Departments = new HashSet<Departments>();
            OwnerMarket = new HashSet<OwnerMarket>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнiм")]
        [Display(Name = "Магазин")]
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<OwnerMarket> OwnerMarket { get; set; }
    }
}

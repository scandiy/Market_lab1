using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace market
{
    public partial class Owners
    {
        public Owners()
        {
            OwnerMarket = new HashSet<OwnerMarket>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнiм")]
        [Display(Name = "Власник")]

        public string Name { get; set; }

        public virtual ICollection<OwnerMarket> OwnerMarket { get; set; }
    }
}

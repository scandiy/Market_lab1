using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace market
{
    public partial class Categories
    {
        public Categories()
        {
            Markets = new HashSet<Markets>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнiм")]
        [Display(Name = "Категорiя")]
        public string Name { get; set; }
        public virtual ICollection<Markets> Markets { get; set; }
    }
}

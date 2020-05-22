using System;
using System.Collections.Generic;

namespace market
{
    public partial class Workers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
    }
}

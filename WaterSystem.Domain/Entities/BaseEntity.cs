using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSystem.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int EditUser { get; set; }
        public DateTime EditDate { get; set; }

    }
}

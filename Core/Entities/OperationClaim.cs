using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}

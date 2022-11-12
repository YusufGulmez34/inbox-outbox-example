using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBoxOutBoxExample.Domain.Write.Entities.Outbox
{
    public class Outbox
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string Payload { get; set; }
        public string Type { get; set; }

    }
}

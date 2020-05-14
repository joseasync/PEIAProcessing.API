using System;
using System.Collections.Generic;
using System.Text;

namespace PEIAProcessing.Domain.Entities
{
    public class DistributorAccount : BaseEntity
    {
        public int DistributorAccountId { get; set; }
        public int DistributorId { get; set; }
        public int DataSourceId { get; set; }
    }
}

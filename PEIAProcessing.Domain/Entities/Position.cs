using System;
using System.Collections.Generic;
using System.Text;

namespace PEIAProcessing.Domain.Entities
{
    public class Position : BaseEntity
    {
        public int PositionId { get; set; }
        public int DistributorAccountId { get; set; }
        public string ISIN { get; set; }
        public DateTime PositionDate { get; set; }
        public string PositionType { get; set; }
        public decimal Quantity { get; set; }
        public decimal MarketValue { get; set; }
        public string Currency { get; set; }
        public string TransferAgentName { get; set; }
        public string TransferAgentAccountNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedByUser { get; set; }
        public decimal? NAV { get; set; }
        public DateTime? PriceDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DTO
{
	public class DashBoardClientDTO
	{
		public int CancelTotal { get;set; }
        public decimal CancelAmt { get; set; }
        public decimal CancelPercent { get; set; }


        public int DeclinedTotal { get; set; }
        public decimal DeclinedAmt { get; set; }
        public decimal DeclinedPercent { get; set; }


        public int PendingTotal { get; set; }
        public decimal PendingAmt { get; set; }
        public decimal PendingPercent { get; set; }


        public int ApprovedTotal { get; set; }
        public decimal ApprovedAmt { get; set; }
        public decimal ApprovedPercent { get; set; }

        public int Total { get; set; }
        public decimal Amt { get; set; }
    }
}

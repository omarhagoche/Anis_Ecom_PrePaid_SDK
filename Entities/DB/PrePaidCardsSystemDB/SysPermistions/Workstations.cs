using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.SysPermistions
{
	public class Workstations
	{
		public int WorkstationID_PK { get; set; }
		public string Workstation_MAC { get; set; }
		public string ReceiptPrinterName { get; set; }
		public int? ReceiptPrinterSize{ get; set; }
	}
}

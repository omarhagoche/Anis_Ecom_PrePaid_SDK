using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.SysPermistions
{
	public class Data_UserSessions
	{
		public long SessionID_PK { get; set; }
		public int UserID_FK { get; set; }
		public string LoginPC { get; set; }
		public DateTime? SessionLoginTime { get; set; }
		public DateTime? SessionLogoutTime { get; set; }
	}
}

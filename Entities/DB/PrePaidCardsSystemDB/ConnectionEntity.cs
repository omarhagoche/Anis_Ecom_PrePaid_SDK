using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB
{
    public class ConnectionEntity
    {
        public static string DBServerName { get; set; }
        public static string DBName { get; set; }
        public static bool IsWinAuth { get; set; }
        public static string DBUserName { get; set; }
        public static string DBPassword { get; set; }

        public static string SqlConnection { get; set; }
    }
}

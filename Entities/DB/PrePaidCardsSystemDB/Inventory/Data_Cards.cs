using System;
using System.Collections.Generic;
using System.Text;

namespace PrePaid_SDK.Entities.DB.PrePaidCardsSystemDB.Inventory
{
	public class Data_Cards
	{
		public long CardID_PK { get; set; }
		public string CardCode { get; set; }
		public string CardName { get; set; }
		public string CardArabicName { get; set; }
		public string CardEnglishName { get; set; }
		public long SubCategoryID_FK { get; set; }
		public int CurrencyTypeID_FK { get; set; }
		public decimal CardCost { get; set; }
		public decimal CardFaceValue { get; set; }
		public string CardPrintName { get; set; }
		public string CardNote { get; set; }
		public bool Card_Available { get; set; }
	}
}

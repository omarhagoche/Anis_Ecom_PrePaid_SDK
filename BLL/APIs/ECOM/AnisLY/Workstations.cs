using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PrePaid_SDK.BLL.APIs.ECOM.AnisLY
{
    public class Workstations
    {
        public Workstations()
        {

        }

        public List<Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations> GET()
        {
            try
            {
                List<Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations> workstationsList = new List<Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations>();
                DAL.SysPermistions.Workstations DAL = new DAL.SysPermistions.Workstations();
                var DT = DAL.Select();
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow workstation in DT.Rows)
                    {
                        workstationsList.Add(
                            new Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations()
                            {
                                WorkstationID_PK = int.Parse(workstation["WorkstationID_PK"].ToString()),
                                Workstation_MAC = workstation["Workstation_MAC"].ToString(),
                                ReceiptPrinterName = (!String.IsNullOrEmpty(workstation["ReceiptPrinterName"].ToString()) ? workstation["ReceiptPrinterName"].ToString() : null),
                                ReceiptPrinterSize = (!String.IsNullOrEmpty(workstation["ReceiptPrinterName"].ToString()) ? int.Parse(workstation["ReceiptPrinterSize"].ToString()) :  0)
                            }
                        );
                    }

                    return workstationsList;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations GET(string MAC)
        {
            try
            {
                Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations workstation = new Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations();
                DAL.SysPermistions.Workstations DAL = new DAL.SysPermistions.Workstations();
                var DT = DAL.Select(MAC);
                if (DT.Rows.Count > 0)
                {
                    workstation.WorkstationID_PK = int.Parse(DT.Rows[0]["WorkstationID_PK"].ToString());
                    workstation.Workstation_MAC = DT.Rows[0]["Workstation_MAC"].ToString();
                    workstation.ReceiptPrinterName = DT.Rows[0]["ReceiptPrinterName"].ToString();
                    workstation.ReceiptPrinterSize = int.Parse(DT.Rows[0]["ReceiptPrinterSize"].ToString());
                    
                    return workstation;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations workstation)
        {
            try
            {
                DAL.SysPermistions.Workstations DAL = new DAL.SysPermistions.Workstations();
                DAL.Insert(workstation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations workstation)
        {
            try
            {
                DAL.SysPermistions.Workstations DAL = new DAL.SysPermistions.Workstations();
                DAL.Update(workstation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

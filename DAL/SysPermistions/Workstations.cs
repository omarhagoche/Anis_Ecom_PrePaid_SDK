using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.SysPermistions
{
    public class Workstations
    {
        SQL_Maneger sql = new SQL_Maneger();

        public DataTable Select()
        {
            try
            {
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                return SQL_Maneger.GetDatatable($@"
                SELECT * FROM [SysPermisions].[Workstations]", sql.ServerConnectionString);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                SQL_Maneger.DisconnectToServer(sql.ServerConnectionString);
            }
        }

        public DataTable Select(string MAC)
        {
            try
            {
                SQL_Maneger.ConnectToServer(sql.ServerConnectionString);
                return SQL_Maneger.GetDatatable($@"
                SELECT * FROM [SysPermisions].[Workstations] where [Workstation_MAC]=N'{MAC}'", sql.ServerConnectionString);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                SQL_Maneger.DisconnectToServer(sql.ServerConnectionString);
            }
        }

        public void Insert(Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations workstation)
        {
            try
            {
                sql.ExcuteQuery($@"INSERT INTO [SysPermisions].[Workstations]
               ([Workstation_MAC]
               ,[ReceiptPrinterName]
               ,[ReceiptPrinterSize])
                VALUES
               (N'{workstation.Workstation_MAC}'
               ,N'{workstation.ReceiptPrinterName}'
               ,{workstation.ReceiptPrinterSize})");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(Entities.DB.PrePaidCardsSystemDB.SysPermistions.Workstations workstation)
        {
            try
            {
                sql.ExcuteQuery($@"UPDATE [SysPermisions].[Workstations]
               SET [ReceiptPrinterName] = N'{workstation.ReceiptPrinterName}'
                  ,[ReceiptPrinterSize] = {workstation.ReceiptPrinterSize}
             WHERE Workstation_MAC = N'{workstation.Workstation_MAC}'");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

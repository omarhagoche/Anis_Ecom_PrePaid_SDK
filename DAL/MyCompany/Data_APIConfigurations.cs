using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL.MyCompany
{
    public class Data_APIConfigurations
    {
        SQL_Maneger sql = new SQL_Maneger();

        public void Insert(Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations configurations)
        {
            try
            {
                sql.ExcuteQuery($@"
                if exists(SELECT * from [MyCompany].[Data_APIConfigurations] where [CompanyID_FK]={configurations.CompanyID_FK})            
                BEGIN            
                    update [MyCompany].[Data_APIConfigurations] 
                    set [Configuration_Value]=N'{configurations.Configuration_Value}' 
                    , [ServiceLanguage] = N'{configurations.ServiceLanguage}'
                    , [PINnumber_IsEnabled] = N'{configurations.PINnumber_IsEnabled}'
                    , [PINnumber_Amount] = {configurations.PINnumber_Amount}
                    , [PINnumber] = {configurations.PINnumber}
                    , [BuyingPrice_IsEnabled] = N'{configurations.BuyingPrice_IsEnabled}'
                    where [CompanyID_FK]={configurations.CompanyID_FK}
                End                    
                else            
                begin  
                    INSERT INTO [MyCompany].[Data_APIConfigurations]
                    ([CompanyID_FK]
                    ,[Configuration_Value]
                    ,[ServiceLanguage]
                    ,[PINnumber_IsEnabled]
                    ,[PINnumber_Amount]
                    ,[PINnumber]
                    ,[BuyingPrice_IsEnabled])
                    VALUES
                    ({configurations.CompanyID_FK}
                    ,N'{configurations.Configuration_Value}'
                    ,N'{configurations.ServiceLanguage}'
                    ,N'{configurations.PINnumber_IsEnabled}'
                    ,{configurations.PINnumber_Amount}
                    ,{configurations.PINnumber}
                    ,N'{configurations.BuyingPrice_IsEnabled}')  
                end 
                ");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable Select(int CompanyID_FK)
        {
            try
            {
                return SQL_Maneger.GetDatatable($@"
                SELECT ConfigurationID_PK,CompanyID_FK,Configuration_Value,ServiceLanguage,PINnumber_IsEnabled,PINnumber_Amount,PINnumber,BuyingPrice_IsEnabled
                FROM MyCompany.Data_APIConfigurations
                WHERE (CompanyID_FK = {CompanyID_FK})
                ",sql.ServerConnectionString);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(Entities.DB.PrePaidCardsSystemDB.MyCompany.Data_APIConfigurations configurations)
        {
            try
            {
                sql.ExcuteQuery($@"
                UPDATE [MyCompany].[Data_APIConfigurations]
                SET [Configuration_Value] = N'{configurations.Configuration_Value}'
                , [ServiceLanguage] = N'{configurations.ServiceLanguage}' 
                , [PINnumber_IsEnabled] = N'{configurations.PINnumber_IsEnabled}' 
                , [PINnumber_Amount] = {configurations.PINnumber_Amount}
                , [PINnumber] = {configurations.PINnumber}
                , [BuyingPrice_IsEnabled] = N'{configurations.BuyingPrice_IsEnabled}'
                WHERE CompanyID_FK = {configurations.CompanyID_FK})
                ");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(string ServiceLanguageCode)
        {
            try
            {
                sql.ExcuteQuery($@"
                UPDATE [MyCompany].[Data_APIConfigurations]
                SET [ServiceLanguage] = N'{ServiceLanguageCode}'
                WHERE CompanyID_FK = 1
                ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

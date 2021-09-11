using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PrePaid_SDK.DAL
{
    public class SQL_Maneger
    {
        public SqlConnection ServerConnectionString = new SqlConnection(Entities.DB.PrePaidCardsSystemDB.ConnectionEntity.SqlConnection);

        public static SqlTransaction ServerConnectionStringTransAction;

        public static DataTable GetDatatable(string SQLQuery, SqlConnection SqlConnectionString)
        {
            try
            {
                SqlCommand CMD = new SqlCommand(SQLQuery, SqlConnectionString);
                CMD.Transaction = ServerConnectionStringTransAction;
                DataTable DataTable = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(CMD);
                DA.Fill(DataTable);

                return DataTable;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ConnectToServer(SqlConnection SqlConnectionString)
        {
            try
            {
                if (SqlConnectionString.State == ConnectionState.Closed)
                {
                    SqlConnectionString.Open();

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void DisconnectToServer(SqlConnection SqlConnectionString)
        {
            try
            {
                if (SqlConnectionString.State == ConnectionState.Open)
                {
                    SqlConnectionString.Close();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void SQLBeginTransaction()
        {
            try
            {
                ConnectToServer(ServerConnectionString);
                ServerConnectionStringTransAction = ServerConnectionString.BeginTransaction();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SQLCommitTransaction()
        {
            try
            {
                ServerConnectionStringTransAction.Commit();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SQLTransactionRollback()
        {
            try
            {

                if (ServerConnectionStringTransAction != null) ServerConnectionStringTransAction.Rollback();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.DB.Entitie_StoredProcedure StoredProcedure(string SP_Name, List<SqlParameter> Parameters, bool NewID = false)
        {
            try
            {
                Entities.DB.Entitie_StoredProcedure entitie = new Entities.DB.Entitie_StoredProcedure();

                using (SqlCommand cmd = new SqlCommand(SP_Name, ServerConnectionString))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(Parameters.ToArray());
                    if (NewID)
                    {
                        cmd.Parameters.Add("@NewID", SqlDbType.Int);
                        cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                    }
                    cmd.Parameters.Add("@Result", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@ResultMessage"].Direction = ParameterDirection.Output;
                    ServerConnectionString.Open();
                    cmd.ExecuteNonQuery();

                    entitie.NewID = Convert.ToInt32(cmd.Parameters["@NewID"].Value);
                    entitie.Result = Convert.ToString(cmd.Parameters["@Result"].Value);
                    entitie.ResultMessage = Convert.ToString(cmd.Parameters["@ResultMessage"].Value);

                    if (entitie.ResultMessage.ToLower().Contains("done"))
                    {
                        return entitie;
                    }
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ServerConnectionString.Close();
            }
        }

        public void ExcuteTransactionQuery(string query)
        {
            try
            {
                SQLBeginTransaction();
                SqlCommand cmd = new SqlCommand(query, ServerConnectionString);
                cmd.Transaction = ServerConnectionStringTransAction;
                cmd.ExecuteNonQuery();
                SQLCommitTransaction();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                SQLTransactionRollback();
                throw e;
            }
            finally
            {
                DisconnectToServer(ServerConnectionString);
            }
        }

        public void ExcuteQuery(string query)
        {
            try
            {
                ConnectToServer(ServerConnectionString);
                SqlCommand cmd = new SqlCommand(query, ServerConnectionString);
                cmd.ExecuteNonQuery();
                DisconnectToServer(ServerConnectionString);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

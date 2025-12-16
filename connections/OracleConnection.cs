using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using runnerDotNet;

namespace runnerDotNet
{
	public class OracleConnection : Connection
	{
		public OracleConnection(XVar parameters) : base(parameters)
		{ }

		protected override DBFunctions GetDbFunctions( XVar extraParams)
		{
			return new OracleFunctions(  extraParams );
		}

		protected override DBInfo GetDbInfo()
		{
			return new OracleInfo(this);
		}

		protected override ConnectionsPool GetConnectionsPool(string connStr)
		{
			return new OracleConnectionPool(connStr);
		}

		protected override void CalculateLastInsertedId( DbConnection connection )
		{
			// do nothing
		}

		protected override DbCommand GetCommand()
		{
			return new Oracle.ManagedDataAccess.Client.OracleCommand();
		}


		public override XVar execWithBlobProcessing(XVar strSQL, XVar blobs, XVar blobTypes = null, XVar autoincField = null )
		{
			var idx = 1;
			var lastIdValue = 0;
			if( MVCFunctions.count(blobs) != 0 || autoincField != null)
			{
				XVar blobvars;
				strSQL = MVCFunctions.Concat(strSQL, " returning ");
				XVar blobfields = "";
				blobvars = "";
				foreach (KeyValuePair<XVar, dynamic> value in blobs.GetEnumerator())
				{
					if(idx > 1)
					{
						blobfields = MVCFunctions.Concat(blobfields, ",");
						blobvars = MVCFunctions.Concat(blobvars, ",");
					}
					blobfields = MVCFunctions.Concat( blobfields, addFieldWrappers( value.Key ) );
					blobvars = MVCFunctions.Concat(blobvars, ":bnd", idx);
					idx++;
				}

				if(autoincField != null)
				{
					if( idx > 1)
					{
						blobfields = MVCFunctions.Concat(blobfields, ",");
						blobvars = MVCFunctions.Concat(blobvars, ",");
					}
					blobfields = MVCFunctions.Concat(blobfields, addFieldWrappers(autoincField));
					blobvars = MVCFunctions.Concat(blobvars, ":lastId");
				}

				strSQL = MVCFunctions.Concat(strSQL, MVCFunctions.Concat(" ", blobfields, " into ", blobvars).ToString());
			}

			try
			{
				Oracle.ManagedDataAccess.Client.OracleConnection connection = (Oracle.ManagedDataAccess.Client.OracleConnection) connectionsPool.FreeConnection;
				Oracle.ManagedDataAccess.Client.OracleCommand dbCommand = new Oracle.ManagedDataAccess.Client.OracleCommand(strSQL, connection);
				dbCommand.BindByName = true;
				dbCommand.CommandType = System.Data.CommandType.Text;
				if(MVCFunctions.count(blobs) != 0)
				{
					idx = 1;
					foreach (KeyValuePair<XVar, dynamic> value in blobs.GetEnumerator())
					{
						Oracle.ManagedDataAccess.Client.OracleParameter oracleParameter = new Oracle.ManagedDataAccess.Client.OracleParameter();
						oracleParameter.ParameterName = MVCFunctions.Concat(":bnd", idx);
						oracleParameter.OracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Blob;
						oracleParameter.Direction = System.Data.ParameterDirection.InputOutput;
						oracleParameter.Size = (value.Value.Value as byte[]).Length;
						oracleParameter.Value = value.Value.Value;
						dbCommand.Parameters.Add(oracleParameter);

						idx++;
					}
				}

                if (autoincField != null)
                {
                    Oracle.ManagedDataAccess.Client.OracleParameter oracleParameter = new Oracle.ManagedDataAccess.Client.OracleParameter();
                    oracleParameter.ParameterName = ":lastId";
                    oracleParameter.OracleDbType = Oracle.ManagedDataAccess.Client.OracleDbType.Int32;
                    oracleParameter.Direction = System.Data.ParameterDirection.Output;
                    dbCommand.Parameters.Add(oracleParameter);
                }

				CommonFunctions.LogInfo(strSQL);

				dbCommand.ExecuteNonQuery();

				if (autoincField != null)
                {
					lastInsertedID = Convert.ToInt32(dbCommand.Parameters[":lastId"].Value.ToString());
				}

				dbCommand.Dispose();
				dbCommand = null;
				connection.Close();
			}
			catch(Exception e)
			{
				GlobalVars.LastDBError = e.Message;
				if( !silentMode )
				{
					throw e;
				}
				return false;
			}
			return true;
		}
	}
}
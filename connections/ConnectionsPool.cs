using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data.OleDb;
using System.Data.Odbc;

namespace runnerDotNet
{
    abstract public class ConnectionsPool
    {
        protected List<DbConnection> m_connections = new List<DbConnection>();
        protected string m_connectionString = "";

        public ConnectionsPool(string connectionString)
        {
            m_connectionString = connectionString;
        }

        public virtual DbConnection FreeConnection
        {
            get
            {
                foreach (var connection in m_connections)
                {
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        return connection;
                    }
                }
				
				DbConnection newConnection = GetConnection();
				m_connections.Add(newConnection);
                return newConnection;
			}
		}
		
		abstract protected DbConnection GetConnection();

		public void CloseConnections()
		{
			foreach (var connection in m_connections)
			{
				if (connection.State != System.Data.ConnectionState.Closed)
				{
					connection.Close();
				}
			}
		}
    }
	
	public class OracleConnectionPool : ConnectionsPool
	{
		public OracleConnectionPool(string connectionString) : base(connectionString) { }

        public override DbConnection FreeConnection
        {
            get
            {
				//	let Oracle driver pool connections
				DbConnection newConnection = GetConnection();
				m_connections.Add(newConnection);
                return newConnection;
			}
		}
		
		protected override DbConnection GetConnection()
		{
			Oracle.ManagedDataAccess.Client.OracleConnection newConnection = new Oracle.ManagedDataAccess.Client.OracleConnection(m_connectionString);

			newConnection.Open();

			OracleGlobalization info = newConnection.GetSessionInfo();
			info.DateFormat = "YYYY-MM-DD HH24:MI:SS";
            info.TimeStampFormat = "YYYY-MM-DD HH24:MI:SS";

			newConnection.SetSessionInfo(info);
			return newConnection;
		}
	}
	public class ODBCConnectionPool : ConnectionsPool
	{
		public ODBCConnectionPool(string connectionString) : base(connectionString) { }
		
		protected override DbConnection GetConnection()
		{
			return new System.Data.Odbc.OdbcConnection(m_connectionString);
		}
	}
	public class OLEDBConnectionPool : ConnectionsPool
	{
		public OLEDBConnectionPool(string connectionString) : base(connectionString) { }
		
		protected override DbConnection GetConnection()
		{
			return new System.Data.OleDb.OleDbConnection(m_connectionString);
		}
	}
}
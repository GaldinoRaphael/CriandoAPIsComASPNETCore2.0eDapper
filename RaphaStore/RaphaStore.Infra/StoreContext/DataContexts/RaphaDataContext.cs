using System;
using System.Data;
using System.Data.SqlClient;
using RaphaStore.Shared;

namespace RaphaStore.Infra.DataContexts
{
    public class RaphaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public RaphaDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace IDataAccessLayer
{
    public interface IDataAccessLayer
    {
        SqlConnection GetConnection();

        DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType);

        DbParameter GetParameter(string parameter, object value);

        SqlParameter GetParameterOut(string parameter, SqlDbType type, object value = null,
            ParameterDirection parameterDirection = ParameterDirection.InputOutput);

        int ExecuteNonQuery(string procedureName, List<DbParameter> parameters,
            CommandType commandType = CommandType.StoredProcedure);

        object ExecuteScalar(string procedureName, List<DbParameter> parameters);

        DbDataReader GetDataReader(string procedureName, List<DbParameter> parameters,
            CommandType commandType = CommandType.StoredProcedure);

        DbDataReader GetDataReader(string procedureName, DbParameter parameter,
            CommandType commandType = CommandType.StoredProcedure);

        DbDataReader GetDataReader(string procedureName,
            CommandType commandType = CommandType.StoredProcedure);
        
        
    }
}
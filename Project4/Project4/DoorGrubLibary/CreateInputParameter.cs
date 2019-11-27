using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServerSide.Utilities
{
    public class CreateInputParameter
    {
        public SqlParameter CreateVarChar(SqlParameter sqlp)
        {
            sqlp.Direction = ParameterDirection.Input;
            sqlp.SqlDbType = SqlDbType.VarChar;
            sqlp.Size = 50;
            return sqlp;
        }

        public SqlParameter CreateVarChar(SqlParameter sqlp, int size)
        {
            sqlp.Direction = ParameterDirection.Input;
            sqlp.SqlDbType = SqlDbType.VarChar;
            sqlp.Size = size;
            return sqlp;
        }

        public SqlParameter CreateInt(SqlParameter sqlp)
        {
            sqlp.Direction = ParameterDirection.Input;
            sqlp.SqlDbType = SqlDbType.Int;
            sqlp.Size = 4;
            return sqlp;
        }

        public SqlParameter CreateInt(SqlParameter sqlp, int size)
        {
            sqlp.Direction = ParameterDirection.Input;
            sqlp.SqlDbType = SqlDbType.Int;
            sqlp.Size = size;
            return sqlp;
        }
    }
}
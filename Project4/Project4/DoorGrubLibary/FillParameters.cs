using ServerSide.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoorGrubMate.DoorGrubLibary
{
    public class FillParameters
    {
        CreateInputParameter cip = new CreateInputParameter();

        //Adds a string parameter to the objCommand object
        public void AddParameter(ref SqlCommand objCommand, string pName, string pValue)
        {
            SqlParameter ip = new SqlParameter(pName, pValue);
            ip = cip.CreateVarChar(ip);
            objCommand.Parameters.Add(ip);
        }

        //Adds a string parameter to the objCommand object at size
        public void AddParameter(ref SqlCommand objCommand, string pName, string pValue, int size)
        {
            SqlParameter ip = new SqlParameter(pName, pValue);
            ip = cip.CreateVarChar(ip, size);
            objCommand.Parameters.Add(ip);
        }

        //Adds an int parameter to the objcommand object
        public void AddParameter(ref SqlCommand objCommand, string pName, int pValue)
        {
            SqlParameter ip = new SqlParameter(pName, pValue);
            ip = cip.CreateInt(ip);
            objCommand.Parameters.Add(ip);
        }
    }
}
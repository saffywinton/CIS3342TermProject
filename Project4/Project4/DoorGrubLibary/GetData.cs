using ServerSide.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utilities;

namespace DoorGrubMate.DoorGrubLibary
{

    /*
    *   This class assists in getting data from the database
    */

    public class GetData
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand;
        string strSQL;
        FillParameters fp = new FillParameters();

        public DataSet GetProfile(string name)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProfile";

            //Inputs parameters to the command object
            SqlParameter ip = new SqlParameter("@name", name);
            ip = cip.CreateVarChar(ip);//Calls a class that does all the work of creating a parameter
            objCommand.Parameters.Add(ip);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetCustomer(string userID)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomer";

            fp.AddParameter(ref objCommand, "@userID", userID);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetRestaurantRep(string userID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurantRep";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@userID", id);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetCart(string userID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCart";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@userID", id);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Gets all restaurants
        public DataSet GetRestaurants()
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurants";

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Will get a dataset of restaurants filtered by type
        public DataSet GetRestaurants(string type)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurantsByType";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@type", type);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetMenu(string restaurantsID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMenu";

            //Inputs parameters to the command object
            SqlParameter ip = new SqlParameter("@restaurantsID", restaurantsID);
            ip = cip.CreateVarChar(ip);//Calls a class that does all the work of creating a parameter
            objCommand.Parameters.Add(ip);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
{
    /*
    *   This class assists in getting data from the database
    */

    public class GetData
    {
        IeuanDBConnect objDB = new IeuanDBConnect();
        SqlCommand objCommand;
        string strSQL;
        FillParameters fp = new FillParameters();

        public DataSet GetProfile(string email)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProfile";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@email", email);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        
        public DataSet GetCustomer(string userID)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomer";

            int userid = int.Parse(userID);

            fp.AddParameter(ref objCommand, "@userID", userid);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        public DataSet GetItem(string itemID)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetItem";

            fp.AddParameter(ref objCommand, "@itemID", Convert.ToInt32(itemID));

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
            fp.AddParameter(ref objCommand, "@userID", userID);

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
            fp.AddParameter(ref objCommand, "@userID", userID);

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

        public DataSet GetMenu(int restaurantsID, string type)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMenu";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@restaurantID", restaurantsID);
            fp.AddParameter(ref objCommand, "@type", type);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetAPIKey()
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKey";

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        public DataSet GetOrders(int userID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOrders";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@UserID", userID);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetRestaurantType()
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurantTypes";

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Will get a dataset of restaurants filtered by type
        public DataSet GetLikeRestaurants(string keyword)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRestaurantsByKeyword";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@keyword", keyword);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
    }
}

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
         *  This class assists creating, updating and deleting of data in the database
         */

    public class SetData
    {
        IeuanDBConnect objDB = new IeuanDBConnect();
        SqlCommand objCommand;
        string strSQL;
        FillParameters fp = new FillParameters();
        Serializor serial = new Serializor();

        //Creates a user in the database
        //When creating a new user, this one should be called, then grab the user id from the database, then create whatever type of user the user is.
        public void CreateUser(string e, string p, string t)
        {
            //Creates a new objCommand to over write any that might exist
            objCommand = new SqlCommand();

            //Selects what storedProcedue will be used
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateUser";

            //Adds the parameters to the objCommand
            fp.AddParameter(ref objCommand, "@email", e);
            fp.AddParameter(ref objCommand, "@password", p);
            fp.AddParameter(ref objCommand, "@type", t);

            //Updates the database
            objDB.DoUpdateUsingCmdObj(objCommand);

            //All other methods work in the same way as this one
        }

        //Creates a customer in the database
        public void CreateCustomer(int id, string fn, string ln, string pn, string da, string ba)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateCustomerAndUser";

            //Adds the parameters to the objCommand
            fp.AddParameter(ref objCommand, "@userID", id);
            fp.AddParameter(ref objCommand, "@firstName", fn);
            fp.AddParameter(ref objCommand, "@lastName", ln);
            fp.AddParameter(ref objCommand, "@phoneNumber", pn, 10);
            fp.AddParameter(ref objCommand, "@deliveryAddress", da, 250);
            fp.AddParameter(ref objCommand, "@billingAddress", ba, 250);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Creates a customer and user in the database
        public void CreateCustomer(string e, string p, string t, string fn, string ln, string pn, string da, string ba)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateCustomer";

            fp.AddParameter(ref objCommand, "@email", e);
            fp.AddParameter(ref objCommand, "@password", p);
            fp.AddParameter(ref objCommand, "@type", t);
            fp.AddParameter(ref objCommand, "@firstName", fn);
            fp.AddParameter(ref objCommand, "@lastName", ln);
            fp.AddParameter(ref objCommand, "@phoneNumber", pn, 10);
            fp.AddParameter(ref objCommand, "@deliveryAddress", da, 250);
            fp.AddParameter(ref objCommand, "@billingAddress", ba, 250);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
      

        //Creates a restaurant in the database
        public void CreateRestaurant(int id, string na, string lo, string pn, string ty)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateRestaurant";

            fp.AddParameter(ref objCommand, "@userID", id);
            fp.AddParameter(ref objCommand, "@name", na);
            fp.AddParameter(ref objCommand, "@logo", lo);
            fp.AddParameter(ref objCommand, "@phoneNumber", pn, 10);
            fp.AddParameter(ref objCommand, "@type", ty);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Creates a restaurant and user in the database
        public void CreateRestaurant(string e, string p, string t, string na, string lo, string pn, string ty)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateRestaurant";

            fp.AddParameter(ref objCommand, "@email", e);
            fp.AddParameter(ref objCommand, "@password", p);
            fp.AddParameter(ref objCommand, "@type", t);
            fp.AddParameter(ref objCommand, "@name", na);
            fp.AddParameter(ref objCommand, "@logo", lo);
            fp.AddParameter(ref objCommand, "@phoneNumber", pn, 10);
            fp.AddParameter(ref objCommand, "@rType", ty);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Creates an admin in the database
        public void CreateAdmin(int id)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateAdmin";

            fp.AddParameter(ref objCommand, "@userID", id);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Creates a restaurantItem in the database
        public void CreateItem(int id, int rid, string na, string de, string pr, string im, string ty)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateItem";

            fp.AddParameter(ref objCommand, "@itemID", id);

            fp.AddParameter(ref objCommand, "@restaurantID", rid);
            fp.AddParameter(ref objCommand, "@name", na);
            fp.AddParameter(ref objCommand, "@description", de);
            fp.AddParameter(ref objCommand, "@price", pr);
            fp.AddParameter(ref objCommand, "@type", ty);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        //Creates a restaurantItem in the database
        public void UpdateItem(string id, int rid, string na, string de, string pr, string im, string ty)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateItem";

            fp.AddParameter(ref objCommand, "@itemID", Convert.ToInt32(id));
            fp.AddParameter(ref objCommand, "@restaurantID", rid);
            fp.AddParameter(ref objCommand, "@name", na);
            fp.AddParameter(ref objCommand, "@description", de);
            fp.AddParameter(ref objCommand, "@price", pr);
            fp.AddParameter(ref objCommand, "@type", ty);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        public void DeleteItem(string id)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteItem";

            fp.AddParameter(ref objCommand, "@itemID", Convert.ToInt32(id));

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        public void CreateOrder(int userID, int restaurantID, Cart c)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateOrder";

            byte[] byteArray = serial.serializeObject(c);

            fp.AddParameter(ref objCommand, "@cart", byteArray);
            fp.AddParameter(ref objCommand, "@customerID", userID);
            fp.AddParameter(ref objCommand, "@restaurantID", restaurantID);

            objDB.DoUpdateUsingCmdObj(objCommand);

            //Deletes record from the cart table since it is now an order
            DeleteCart(userID, restaurantID);
        }

        //Deletes a cart 
        internal void DeleteCart(int userID, int restaurantID)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteCart";

            fp.AddParameter(ref objCommand, "@customerID", userID);
            fp.AddParameter(ref objCommand, "@restaurantID", restaurantID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public void AddWalletID(int userID, int walletID)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddWalletID";

            fp.AddParameter(ref objCommand, "@userID", userID);
            fp.AddParameter(ref objCommand, "@walletID", walletID);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Updates a customer and user in the database
        public void UpdateCustomer(string id, string e, string p, string fn, string ln, string pn, string da, string ba)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateCustomer";

            fp.AddParameter(ref objCommand, "@id", id);
            fp.AddParameter(ref objCommand, "@email", e);
            fp.AddParameter(ref objCommand, "@password", p);
            fp.AddParameter(ref objCommand, "@firstName", fn);
            fp.AddParameter(ref objCommand, "@lastName", ln);
            fp.AddParameter(ref objCommand, "@phoneNumber", pn, 10);
            fp.AddParameter(ref objCommand, "@deliveryAddress", da, 250);
            fp.AddParameter(ref objCommand, "@billingAddress", ba, 250);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}

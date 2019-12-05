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
        public void CreateItem(int id, string na, string de, string pr, string im, string ty)
        {
            objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateRestaurant";

            fp.AddParameter(ref objCommand, "@userID", id);
            fp.AddParameter(ref objCommand, "@name", na);
            fp.AddParameter(ref objCommand, "@description", de);
            fp.AddParameter(ref objCommand, "@price", pr);
            fp.AddParameter(ref objCommand, "@type", ty);

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Creates a cart in the database
        public void CreateCart()
        {

        }

        //Deletes a cart 
        internal void DeleteCart()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
{
    public class Customer
    {
        string userID;
        string firstName;
        string lastName;
        string email;
        string password;
        string phoneNumber;
        string deliveryAddress;
        string billingAddress;
        string apiKey;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string DeliveryAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }

        public string BillingAddress
        {
            get { return billingAddress; }
            set { billingAddress = value; }
        }

        public string APIKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }
    }
}

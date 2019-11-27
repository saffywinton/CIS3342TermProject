using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoorGrubMate.DoorGrubLibary
{

    /*
     *    Ieuan Horton
     * 
     *    Return codes
     *   -1 = Failure|UserError
     *    0 = Failure|LogicError
     *    1 = Success
     */ 

    [Serializable]
    public class Cart
    {
        int CustomerID;
        ArrayList ItemList = new ArrayList();

        //Gets a combined total of all the items in the ItemList
        public float GetCartTotal()
        {
            float total = 0;
            foreach(Item item in ItemList)
            {
                total = total + item.Price;
            }
            return total;
        }

        //Allows for modifications to the cart
        public int ModCart(string modType, Item item)
        {
            if (modType.Equals("Add"))
            {
                return AddToCart(item);
            }
            else if (modType.Equals("Delete"))
            {
                return DeleteFromCart(item);
            }
            else if (modType.Equals("Switch"))
            {
                return SwapItem(item);
            }
            else
            {
                //Not correct input type
                return -1;
            }
        }


        internal int AddToCart(Item item)
        {
            if(ItemList.IndexOf(item) > -1)
            {
                ItemList.Add(item);
                return 1;
            }
            else
            {
                //Item already exists
                return 0;
            }
        }

        internal int DeleteFromCart(Item item)
        {
            if(ItemList.IndexOf(item) > -1)
            {
                ItemList.Remove(item);
                return 1;
            }
            else
            {
                //Item does not exist
                return 0;
            }
        }

        internal int SwapItem(Item item)
        {
            if(ItemList.IndexOf(item) > -1)
            {
                ItemList[ItemList.IndexOf(item)] = item;
                return 1;
            }
            else
            {
                //Item does not exist
                return 0;
            }
        }
    }
}
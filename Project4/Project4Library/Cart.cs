using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
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
            foreach (Item item in ItemList)
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

        public ArrayList GetList()
        {
            return ItemList;
        }


        //Takes an arraylist of index values and deletes them from ItemList
        public int DeleteIndexs(ArrayList listNums)
        {
            int count = 0;
            try//Incase a number ouside the scope of ItemList is passed through.
            {
                for (int i = listNums.Count - 1; i >= 0; i--)
                {
                    ItemList.RemoveAt(int.Parse(listNums[i].ToString()));
                    count++;
                }
                return count;
            }
            catch
            {
                return -1;
            }
        }

        public int GetSize()
        {
            return ItemList.Count;
        }

        internal int AddToCart(Item item)
        {
            if (ItemList.IndexOf(item) > -1)
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
            if (ItemList.IndexOf(item) > -1)
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
            if (ItemList.IndexOf(item) > -1)
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

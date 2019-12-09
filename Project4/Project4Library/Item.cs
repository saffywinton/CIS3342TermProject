using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
{
    public class Item
    {
        string itemID;
        string name;
        string description;
        string image;
        float price;
        string type;
        string comments;

        public Item(string id, string n, string d, string i, float p, string t, string c)
        {
            itemID = id;
            name = n;
            description = d;
            image = i;
            price = p;
            type = t;
            comments = c;
        }

        public Item(string id, string n, string d, string i, string p, string t, string c)
        {
            itemID = id;
            name = n;
            description = d;
            image = i;
            price = float.Parse(p);
            type = t;
            comments = c;
        }

        public Item()
        {
            name = "";
            description = "";
            image = "";
            price = 0;
            type = "";
            comments = "";
        }

        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
{
    public class Item
    {
        string name;
        string description;
        string image;
        float price;

        public Item(string n, string d, string i, float p)
        {
            name = n;
            description = d;
            image = i;
            price = p;
        }

        public Item(string n, string d, string i, string p)
        {
            name = n;
            description = d;
            image = i;
            price = float.Parse(p);
        }

        public Item()
        {
            name = "";
            description = "";
            image = "";
            price = 0;
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
    }
}

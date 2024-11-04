using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Shop
{
    internal class CPU : IProduct
    {
        public int ID { get; }
        public string Name { get; }
        public float Price { get; }
        public string Description { get; }
        public Bitmap Image { get; }

        public CPU(int id, string name, float price, string descrption, Bitmap image)
        {
            ID = id;
            Name = name;
            Price = price;
            Description = descrption;
            Image = image;
        }
    }
}

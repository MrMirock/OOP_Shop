using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Shop
{
    internal class GPU : IProduct
    {
        public int ID { get; }
        public string Name { get; }
        public float Price { get; }
        public string Description { get; }
        public Bitmap Image { get; }

        public GPU(int id, string name, float price, string descrption, Bitmap image)
        {
            ID = id;
            Name = name;
            Price = price;
            Description = descrption;
            Image = image;
        }
        public static float operator +(float a, GPU b)
        {
            return a + b.Price;
        }
    }
}

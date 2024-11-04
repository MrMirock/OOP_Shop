using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Shop
{
    internal class ThermalPaste<T>: IProduct
    {
    public int ID { get; }
    public string Name { get; }
    public float Price { get; }
    public string Description { get; }
    public Bitmap Image { get; }
    public T Amount { get; }

    public ThermalPaste(int id, string name, float price, string descrption, Bitmap image, T amount)
    {
        ID = id;
        Name = name;
        Price = price;
        Description = descrption;
        Image = image;
        Amount = amount;
    }
}
}

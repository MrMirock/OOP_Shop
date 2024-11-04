using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Shop
{
    public interface IProduct
    {
        int ID { get; }
        string Name { get; }
        float Price { get; }
        string Description { get; }
        Bitmap Image { get; }
    }
}

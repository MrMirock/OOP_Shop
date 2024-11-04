using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Shop
{
    public class Customer
    {
        public string Login { get; }
        public string Password { get; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public List<IProduct> buyingStory { get; }
        public List<IProduct> shoppingCart { get; }

        public Customer(string login, string password)
        {
            Login = login;
            Password = password;
            buyingStory = new List<IProduct>();
            shoppingCart = new List<IProduct>();
        }
        public void addToStory(IProduct product)
        {
            buyingStory.Add(product);
        }
        public void addToCart(IProduct product)
        {
            shoppingCart.Add(product);
        }
        public void emptyCart()
        {
            shoppingCart.Clear();
        }
        public void addCardData(string cardnumber, string cvc) 
        {
            CardNumber = cardnumber;
            CVC = cvc;
        }
    }
}

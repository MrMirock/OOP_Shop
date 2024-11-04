using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Shop
{
    public partial class FormShoppingCart : Form
    {
        private Customer account = null;
        private int selectedIndex = -1;
        public event Action<Customer> dataE;
        public FormShoppingCart(Customer recievedCustomer)
        {
            InitializeComponent();
            account = recievedCustomer;
            textBox1.Text = account.Login;
            textBox2.Text = account.CVC;
            cardBtn.Enabled = false;
            if(account.shoppingCart.Count() > 0)
            {
                float summa = 0;
                foreach(IProduct product in account.shoppingCart)
                {
                    if (product is GPU)
                    {
                        GPU pr = product as GPU;
                        summa = summa + pr;
                    }
                    else summa += product.Price;
                    listBox1.Items.Add(product.Name + " " + product.Price.ToString() + " рублей");
                }
                textBox2.Text = summa.ToString();
                cardBtn.Enabled = true;
            }
        }

        private void cardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(account.CardNumber) > 0 && int.Parse(account.CVC) > 0)
                    if (account.shoppingCart.Count() > 0) foreach (IProduct product in account.shoppingCart) account.addToStory(product);
                account.shoppingCart.Clear();
                dataE?.Invoke(account);
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("У вас нет привязанной карты!","",MessageBoxButtons.OK);
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

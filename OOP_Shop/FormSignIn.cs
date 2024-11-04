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
    public partial class FormSignIn : Form
    {
        private List<Customer> cList = new List<Customer>();
        public event Action<bool, Customer> dataE;
        public FormSignIn(List<Customer> recievedList)
        {
            InitializeComponent();
            cList = recievedList;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            foreach(Customer customer in cList)
            {
                if(customer.Login == textBox1.Text && customer.Password == textBox2.Text)
                {
                    dataE?.Invoke(false, customer);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            FormRegistration registration = new FormRegistration(false, null);
            registration.dataE += NewCustomer;
            registration.ShowDialog();
        }
        private void NewCustomer(Customer customer)
        {
            Customer registrat = customer;
            dataE?.Invoke(true, registrat);
            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

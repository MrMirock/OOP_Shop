using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Shop
{
    public partial class FormRegistration : Form
    {
        public event Action<Customer> dataE;
        bool access = false;
        Customer account = null;
        public FormRegistration(bool isAccess, Customer ChangeAccount)
        {
            InitializeComponent();
            access = isAccess;
            if(access && ChangeAccount != null)
            {
                account = ChangeAccount;
                textBox1.Text = account.Login;textBox1.Enabled = false;
                textBox2.Text = account.Password;textBox2.Enabled = false;
                textBox3.Text = account.CardNumber;
                textBox4.Text = account.CVC;
                if(account.buyingStory.Count()>0)foreach(var story in account.buyingStory) listBox1.Items.Add(story.Name);
            }
            exitBtn.Enabled = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(!access)
            {
                Customer newAccount = new Customer(textBox1.Text, textBox2.Text);
                if (textBox3.Text.Length > 0 && textBox4.Text.Length > 0) newAccount.addCardData(textBox3.Text, textBox4.Text);
                dataE?.Invoke(newAccount);
                DialogResult = DialogResult.OK;
            }
            else
            {
                account.addCardData(textBox3.Text, textBox4.Text);
                dataE?.Invoke(account);
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            dataE?.Invoke(null);
            DialogResult= DialogResult.OK;
        }
    }
}

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
    public partial class FormProdDesc : Form
    {
        IProduct product;
        bool Access = false;
        public event Action<IProduct> dataE;
        public FormProdDesc(IProduct recievedProd, bool recievedFlag)
        {
            InitializeComponent();
            product = recievedProd;
            Access = recievedFlag;
            panel1.BackgroundImage = product.Image;
            textBox1.Text = product.Name;
            textBox2.Text = product.Price.ToString();
            textBox3.Text = product.Description;
            if(product is ThermalPaste<float>)
            {
                ThermalPaste<float> tp = product as ThermalPaste<float>;
                label2.Text = "мл*";
                textBox4.Text = tp.Amount.ToString();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            if (Access) dataE?.Invoke(product);
            else dataE?.Invoke(null);
            DialogResult = DialogResult.OK;
        }
    }
}

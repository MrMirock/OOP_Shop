using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_Shop
{
    public partial class Form1 : Form
    {
        private List<IProduct> pList = new List<IProduct>();
        private List<Customer> cList = new List<Customer>();
        private int selectedIndexTab = 0;
        private Customer account = null;
        public Form1()
        {
            InitializeComponent();
            Catalog();
            showList();
            signInBtn.BackColor = Color.White;
            cList.Add(new Customer("Me", "111"));
        }
        private void Catalog() 
        {
            pList.Add(new GPU(1, "Palit RTX 4060 8G", 39999, "Видеокарта MSI GeForce RTX 4060 VENTUS 2X BLACK OC с архитектурой Ada Lovelace" +
            "обеспечивает производительность и скорость для достижения реалистичности графики при рендеринге, запуске профессиональных программ и игр.", Properties.Resources._4060));
            pList.Add(new GPU(2, "Palit RTX 4070 Ti Super 12G", 104999, "Видеокарта Palit GeForce RTX 4070 Ti SUPER JetStream OC [NED47TSS19T2-1043J] "+ 
            "ориентирована на комплектацию производительных игровых компьютеров. Быстродействие видеоадаптера позволяет использовать большинство игр на"+
            "максимальных настройках графики.", Properties.Resources._4070));
            pList.Add(new CPU(3, "Intel Core i9 14900K", 67499, "24-ядерный процессор Intel Core i9-14900K OEM базируется на архитектуре Intel Raptor Lake "+
            "и произведен по техпроцессу Intel 7.", Properties.Resources._14900));
            pList.Add(new CPU(4, "AMD Ryzen 7 5800X3D", 39590, "Процессор AMD Ryzen 7 5800X3D OEM сделает игровой компьютер более производительным благодаря "+
            "трехмерному вертикальному кэшу и 7-нм техпроцессу.", Properties.Resources._5800));
            pList.Add(new ThermalPaste<int>(5, "Arctic Cooling MX-4", 1399, "Термопаста Arctic Cooling MX-4 (2019) может быть полезна профессиональным сборщикам "+
            "стационарных компьютеров, инженерам по ремонту компьютерной техники и частным пользователям.", Properties.Resources.mx4,8));
            pList.Add(new ThermalPaste<float>(6, "Thermal Grizzly Kryonaut Extreme", 16999, "Термопаста Thermal Grizzly Kryonaut Extreme [TG-KE-090-R] – отличный выбор для "+
            "компьютерных энтузиастов, увлекающихся экстремальным разгоном системы. ", Properties.Resources.tg, 50f));
        }
        private void showList()
        {
            ImageList imagelist = new ImageList();
            imagelist.ImageSize = new Size(150, 150);
            for(int i = 0; i < pList.Count; i++)
            {
                ListViewItem AddingItem = new ListViewItem();
                imagelist.Images.Add(pList[i].Image);
                AddingItem.Text = pList[i].ID + " " + pList[i].Name + " " + pList[i].Price.ToString() + "руб ";
                switch(selectedIndexTab)
                {
                    case 0:
                        if (pList[i] is GPU)
                        {
                            listView1.LargeImageList = imagelist;
                            AddingItem.ImageIndex = i;
                            listView1.Items.Add(AddingItem);
                        }
                        break;
                    case 1:
                        if (pList[i] is CPU)
                        {
                            listView2.LargeImageList = imagelist;
                            AddingItem.ImageIndex = i;
                            listView2.Items.Add(AddingItem);
                        }
                        break;
                    case 2:
                        if (pList[i] is ThermalPaste<int> || pList[i] is ThermalPaste<float>)
                        {
                            listView3.LargeImageList = imagelist;
                            AddingItem.ImageIndex = i;
                            listView3.Items.Add(AddingItem);
                        }
                        break;
                    case 3:
                        {
                            listView4.LargeImageList = imagelist;
                            AddingItem.ImageIndex = i;
                            listView4.Items.Add(AddingItem);
                        }
                        break;

                }
            }
        }
        private void shoppingCartBtn_Click(object sender, EventArgs e)
        {
            if(account != null)
            {
                FormShoppingCart cart = new FormShoppingCart(account);
                cart.dataE += UserChange;
                cart.ShowDialog();
            }
            else MessageBox.Show("Необходима авторизация!", "", MessageBoxButtons.OK);
        }
        private void UserChange(Customer customer)
        {
            if (customer != null)
            {
                signInBtn.Text = "Войти";
                signInBtn.BackColor = Color.White;
                account = null;
                return;
            }
            cList.Remove(account);
            account = customer;
            cList.Add(account);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(selectedIndexTab)
            {
                case 0:
                    listView1.Items.Clear();
                    break;
                case 1:
                    listView2.Items.Clear();
                    break;
                case 2:
                    listView3.Items.Clear();
                    break;
                case 4:
                    listView4.Items.Clear();
                    break;
            }
            selectedIndexTab = tabControl1.SelectedIndex;
            showList();
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndexProduct;
            System.Windows.Forms.ListView listViewObject;
            if (sender == listView1) listViewObject = listView1;
            else if(sender == listView2) listViewObject = listView2;
            else if(sender == listView3) listViewObject = listView3;
            else listViewObject = listView4;

            if(listViewObject.SelectedIndices.Count > 0)
            {
                selectedIndexProduct = listViewObject.SelectedIndices[0];
                for(int i = 0; i < pList.Count; i++)
                {
                    if (pList[i].ID.ToString() == listViewObject.Items[selectedIndexProduct].Text[0].ToString())
                    {
                        if(account == null)
                        {
                            FormProdDesc productDescription = new FormProdDesc(pList[i], false);
                            productDescription.dataE += AddToCart;
                            productDescription.ShowDialog();
                        }
                        else
                        {
                            FormProdDesc productDescription = new FormProdDesc(pList[i], true);
                            productDescription.dataE += AddToCart;
                            productDescription.ShowDialog();
                        }
                    }
                }
            }
        }

        private void AddToCart(IProduct recievedProduct)
        {
            if (recievedProduct != null) account.addToCart(recievedProduct);
            else MessageBox.Show("Необходима авторизация!","", MessageBoxButtons.OK);
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            if(account == null)
            {
                FormSignIn signIn = new FormSignIn(cList);
                signIn.dataE += AccessCheck;
                signIn.ShowDialog();
            }
            else
            {
                FormRegistration registrat = new FormRegistration(true, account);
                registrat.dataE += UserChange;
                registrat.ShowDialog();
            }
        }
        private void AccessCheck(bool New,Customer newCustomer)
        {
            if(New)
            {
                cList.Add(newCustomer);
                return;
            }
            account = newCustomer;
            signInBtn.Text = newCustomer.Login;
            signInBtn.BackColor = Color.Orange;
        }
    }
}

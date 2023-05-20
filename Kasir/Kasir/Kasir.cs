using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir
{
    public partial class Kasir : Form
    {
        class ShopItem
        {
            public ShopItem(string Name, float Price, int Ammount)
            {
                name = Name;
                price = Price;
                ammount = Ammount;
            }
            public string name;
            public float price;
            public int ammount;
        }
        List<ShopItem> shop_items;
        public Kasir()
        {
            InitializeComponent();
            shop_items = new List<ShopItem>();
            UpdateTable();
        }

        private void Kasir_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void UpdateTable()
        {
            tableLayoutPanel1.Controls.Clear();
            int row_index = 1;
            tableLayoutPanel1.RowCount = shop_items.Count() + 1;
            float totalPrice = 0.0f;

            var nameHead = new Label();
            nameHead.Text = "Nama Item";
            nameHead.Size = new Size(124, 16);
            nameHead.Margin = new Padding(0);
            var headFont = new Font(nameHead.Font, FontStyle.Bold);
            nameHead.Font = headFont;

            var priceHead = new Label();
            priceHead.Text = "Harga";
            priceHead.Size = new Size(64, 16);
            priceHead.Margin = new Padding(0);
            priceHead.Font = headFont;

            var sumHead = new Label();
            sumHead.Text = "Jml";
            sumHead.Size = new Size(32, 16);
            sumHead.Margin = new Padding(0);
            sumHead.Font = headFont;

            tableLayoutPanel1.Controls.Add(nameHead, 0, 0);
            tableLayoutPanel1.Controls.Add(priceHead, 1, 0);
            tableLayoutPanel1.Controls.Add(sumHead, 2, 0);

            foreach (var shop_item in shop_items)
            {   
                var itemName = new Label();
                itemName.Text = shop_item.name;
                itemName.Size = new Size(124, 16);
                itemName.Margin = new Padding(0);

                var itemPrice = new Label();
                itemPrice.Text = shop_item.price.ToString();
                itemPrice.Size = new Size(64, 16);
                itemPrice.Margin = new Padding(0);

                var itemSum = new Label();
                itemSum.Text = shop_item.ammount.ToString();
                itemSum.Size = new Size(24, 16);
                itemSum.Margin = new Padding(0);

                //var plusButton = new Button();
                //plusButton.Text = "+";
                //plusButton.Size = new Size(36, 16);
                //plusButton.Margin = new Padding(0);
                //plusButton.MouseClick += onAddButtonClick;
                //
                //var minButton = new Button();
                //minButton.Text = "-";
                //minButton.Size = new Size(36, 16);
                //minButton.Margin = new Padding(0);

                totalPrice += shop_item.ammount * shop_item.price;

                tableLayoutPanel1.Controls.Add(itemName, 0, row_index);
                tableLayoutPanel1.Controls.Add(itemPrice, 1, row_index);
                tableLayoutPanel1.Controls.Add(itemSum, 2, row_index);
                //tableLayoutPanel1.Controls.Add(plusButton, 3, row_index);
                //tableLayoutPanel1.Controls.Add(minButton, 4, row_index);
                row_index += 1;
            }
            label5.Text = "Total Price: " + totalPrice.ToString();
        }

        static void onAddButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("tes");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemName = textBox1.Text;
            float itemPrice = float.Parse(textBox2.Text);
            int itemCount = int.Parse(textBox3.Text);

            shop_items.Add(new ShopItem(itemName, itemPrice, itemCount));
            UpdateTable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

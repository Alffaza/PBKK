using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ETS
{
    public partial class Form1 : Form
    {
        //string APIKey = "lvbNskBkHGncoGP88QOx3NhuCr06WGHG";
        string APIKey = "lvbNskBkHGncoGP88QOx3NhuCr06WGHG";

        class ExchangeResponse
        {
            public bool success { get; set; }
            public float result { get; set; }
        }
        
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public void exchange()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Set("apikey", APIKey);
                string exchangeUrl = "https://api.apilayer.com/fixer/convert";
                string latestUrl = "https://api.exchangeratesapi.io/v1/latest";
                string urlParams = "?access_key=" + APIKey;
                string srcCurr = (string)comboBox1.SelectedItem;
                string dstCurr = (string)comboBox2.SelectedItem;
                string amount = textBox1.Text;

                exchangeUrl += "&from=" + srcCurr;
                exchangeUrl += "&to=" + dstCurr;
                exchangeUrl += "&amount=" + amount;

                var json = web.DownloadString(exchangeUrl);
                ExchangeResponse resp = JsonConvert.DeserializeObject<ExchangeResponse>(json);
                if (resp.success)
                {
                    label3.Text = resp.result.ToString();
                    return;
                }
                label3.Text = "failed :(";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string inp = textBox1.Text;
            bool isValid = Regex.IsMatch(inp, @"^[0-9.]+$");
            if (!isValid)
            {
                label3.Text = "INVALID";
            }
            else
            {
                exchange();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

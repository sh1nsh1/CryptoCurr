using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCurr
{
    public partial class Form1 : Form
    {
        private bool toggle_start = false;
        //private List<decimal> prices = new List<decimal> {};
        private List<Currency> Currencies { get; set; } = new List<Currency>();
    
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            start_btn.Text = toggle_start ? "Start watching" : "Stop watching";
            toggle_start = !(toggle_start is true);
            PollPrices(this.comboBox1.Text);
            
        }

        private async void PollPrices(string ticker)
        {
            List<IClient> clients = toggle_start ? new List<IClient> {
                new BinanceClient(),
                new BitgetClient(),
                new BybitClient(),
                new KucoinClient(),
            } : null;
            if ((from c in Currencies select c.Ticker).Count() == 0){
                Currencies.Add(null);
            }

            while (toggle_start)
            {   
                foreach (IClient client in clients){
                    client.CheckPrice(ticker);
                    
                }
                Currencies[0] = new Currency(
                    clients[0].Price, clients[1].Price, clients[2].Price, clients[3].Price, ticker
                );
                dataGridView1.DataSource = new BindingList<Currency>(Currencies);
                await Task.Delay(5000);
            }
        }
        
        
    }
}

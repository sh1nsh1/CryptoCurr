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
        private List<Currency> Currencies { get; set; }
    
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            toggle_start = !(toggle_start is true);
            start_btn.Text = toggle_start ?"Stop watching": "Start watching";
            PollPrices("BTC.USDT");
        }

        private async void PollPrices(string ticker)
        {
            List<IClient> clients = toggle_start ? new List<IClient> {
                new BinanceClient(),
                new BitgetClient(),
                new BybitClient(),
                new KucoinClient(),
            } : null;

            while (toggle_start)
            {   
                foreach (IClient client in clients){
                    client.CheckPrice(ticker);
                }
                
                await Task.Delay(5000);
            }
        }
        
        
    }
}

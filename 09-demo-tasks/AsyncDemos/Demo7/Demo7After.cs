using AsyncDemos.Demo7.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemos.Demo7
{
    public partial class Demo7After : Form
    {

        public Demo7After()
        {
            InitializeComponent();
        }
        
        private async void btnSearch_Click(object sender, EventArgs e)
        {                      
            try
            {                
                btnSearch.Text = "Cancel";

                var service = new FakeService();

                var amiibos = await service.GetAllData();

                foreach (var amiibo in amiibos)
                {
                    lstAmiibos.Items.Add($"Name: {amiibo.name}, Image: {amiibo.image}");
                }

                lblMessage.Text = $"{amiibos.Count()} obtained!";

                btnSearch.Text = "Search";
                
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }           
        }
    }
}

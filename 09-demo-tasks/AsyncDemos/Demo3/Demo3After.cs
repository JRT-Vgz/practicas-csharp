using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemos.Demo3
{
    public partial class Demo3After : Form
    {
        public Demo3After()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var task1 = Task.Run(() =>
                {
                    return GetAll();
                });

                var faulted = task1.ContinueWith((completedTask) =>
                {
                    var exception = completedTask.Exception;
                    lblMessage.Invoke(() => lblMessage.Text = exception.Message);
                }, TaskContinuationOptions.OnlyOnFaulted);


                var task2 = task1.ContinueWith((completedTask) =>
                {
                    var amiibos = completedTask.Result;
                    foreach (var amiibo in amiibos)
                    {
                        lstAmiibos.Invoke(() => lstAmiibos.Items.Add(amiibo));
                    }
                    return amiibos.Count;
                }, TaskContinuationOptions.OnlyOnRanToCompletion);


                task2.ContinueWith((completedTask) =>
                {
                    var amiibosCount = completedTask.Result;
                    lblMessage.Invoke(() => lblMessage.Text = $"{amiibosCount} obtained!");
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {

            }
            


        }

        private List<string> GetAll()
        {            
            Thread.Sleep(5000);
            List<string> amiibos = ["Pikachu", "Charmander", "Bulbasaur", "Squirtle", "Eevee", "Jigglypuff", "Snorlax", "Meowth", "Gengar", "Mewtwo", "Mew", "Charizard", "Blastoise", "Venusaur", "Machamp", "Arcanine", "Gyarados", "Lapras", "Alakazam", "Dragonite", "Ditto", "Pidgeot", "Raichu", "Golem", "Rapidash", "Vaporeon", "Jolteon", "Flareon"];
            return amiibos;
        }
    }
}

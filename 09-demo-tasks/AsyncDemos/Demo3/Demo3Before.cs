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
    public partial class Demo3Before : Form
    {
        public Demo3Before()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            var task1 = Task.Run(() =>
            {
                return GetAll();
            });

            var task2 = task1.ContinueWith((completedTask) =>
            {
                var amiibos = completedTask.Result;
                foreach (var amiibo in amiibos)
                {
                    lstAmiibos.Invoke(() => lstAmiibos.Items.Add(amiibo));
                }
                return amiibos.Count;
            });


            task2.ContinueWith((completedTask) =>
            {
                var amiibosCount = completedTask.Result;
                lblMessage.Invoke(() => lblMessage.Text = $"{amiibosCount} obtained!");
            });


        }

        private List<string> GetAll()
        {
            Thread.Sleep(5000);
            List<string> amiibos = ["Pikachu", "Charmander", "Bulbasaur", "Squirtle", "Eevee", "Jigglypuff", "Snorlax", "Meowth", "Gengar", "Mewtwo", "Mew", "Charizard", "Blastoise", "Venusaur", "Machamp", "Arcanine", "Gyarados", "Lapras", "Alakazam", "Dragonite", "Ditto", "Pidgeot", "Raichu", "Golem", "Rapidash", "Vaporeon", "Jolteon", "Flareon"];
            return amiibos;
        }
    }
}

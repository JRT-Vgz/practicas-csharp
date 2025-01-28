using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemos.Demo2
{
    public partial class Demo2Before : Form
    {
        public Demo2Before()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Task getData = new Task(() =>
            {
                var amiibos = GetAll();
                foreach (var amiibo in amiibos)
                {
                    lstAmiibos.Invoke(() => lstAmiibos.Items.Add(amiibo));
                }
            });
            getData.Start();
        }

        private List<string> GetAll()
        {
            Thread.Sleep(5000);
            List<string> amiibos = ["Pikachu", "Charmander", "Bulbasaur", "Squirtle", "Eevee", "Jigglypuff", "Snorlax", "Meowth", "Gengar", "Mewtwo", "Mew", "Charizard", "Blastoise", "Venusaur", "Machamp", "Arcanine", "Gyarados", "Lapras", "Alakazam", "Dragonite", "Ditto", "Pidgeot", "Raichu", "Golem", "Rapidash", "Vaporeon", "Jolteon", "Flareon"];
            return amiibos;
        }
    }
}

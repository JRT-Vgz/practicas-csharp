﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemos.Demo5
{
    public partial class Demo5After : Form
    {
        public Demo5After()
        {
            InitializeComponent();
        }

        CancellationTokenSource? cts;
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (cts is not null)
            {
                cts.Cancel();
                btnSearch.Text = "Search";
                return;
            }

            try
            {
                cts = new();
                btnSearch.Text = "Cancel";


                var amiibos = await GetAll();

                foreach (var amiibo in amiibos)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        break;
                    }

                    await GenerateAIImage(amiibo);
                }

                foreach (var amiibo in amiibos.Where(x=>!string.IsNullOrEmpty(x.AmiiboImagePath)))
                {
                    lstAmiibos.Items.Add($"Name: {amiibo.AmiiboName}, Image: {amiibo.AmiiboImagePath}");
                }

                lblMessage.Text = $"{amiibos.Count()} obtained!";

                btnSearch.Text = "Search";
                               
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            


        }

        private async Task<List<Amiibo>> GetAll()
        {
            await Task.Delay(5000);
            List<Amiibo> amiibos = new List<Amiibo>
            {
                new Amiibo { AmiiboName = "Mario"},
                new Amiibo { AmiiboName = "Luigi"},
                new Amiibo { AmiiboName = "Peach"},
                new Amiibo { AmiiboName = "Yoshi"},
                new Amiibo { AmiiboName = "Bowser"},
                new Amiibo { AmiiboName = "Rosalina"},
                new Amiibo { AmiiboName = "Wario"},
                new Amiibo { AmiiboName = "Donkey Kong"},
                new Amiibo { AmiiboName = "Diddy Kong"},
                new Amiibo { AmiiboName = "Link"},
                new Amiibo { AmiiboName = "Zelda"},
                new Amiibo { AmiiboName = "Sheik"},
                new Amiibo { AmiiboName = "Ganondorf"},
                new Amiibo { AmiiboName = "Toon Link"},
                new Amiibo { AmiiboName = "Samus"},
                new Amiibo { AmiiboName = "Zero Suit Samus"},
                new Amiibo { AmiiboName = "Kirby"},
                new Amiibo { AmiiboName = "Meta Knight"},
                new Amiibo { AmiiboName = "King Dedede"},
                new Amiibo { AmiiboName = "Fox"},
                new Amiibo { AmiiboName = "Falco"},
                new Amiibo { AmiiboName = "Pikachu"},
                new Amiibo { AmiiboName = "Charizard"},
                new Amiibo { AmiiboName = "Lucario"},
                new Amiibo { AmiiboName = "Jigglypuff"},
                new Amiibo { AmiiboName = "Greninja"},
                new Amiibo { AmiiboName = "Ness"},
                new Amiibo { AmiiboName = "Captain Falcon"},
                new Amiibo { AmiiboName = "Villager"},
                new Amiibo { AmiiboName = "Olimar"},
                new Amiibo { AmiiboName = "Wii Fit Trainer"},
                new Amiibo { AmiiboName = "Dr. Mario"},
            };
            return amiibos;
        }


        private async Task GenerateAIImage(Amiibo amiibo)
        {
            await Task.Delay(1000);
            Debug.WriteLine($"Generating image for {amiibo.AmiiboName}");
            amiibo.AmiiboImagePath = Guid.NewGuid().ToString();
        }

    }
}

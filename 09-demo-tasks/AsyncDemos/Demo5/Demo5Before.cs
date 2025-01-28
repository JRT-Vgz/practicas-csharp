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

namespace AsyncDemos.Demo5
{
    public partial class Demo5Before : Form
    {
        public Demo5Before()
        {
            InitializeComponent();
        }

        CancellationTokenSource? cts;
        private void btnSearch_Click(object sender, EventArgs e)
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
                        if (cts.Token.IsCancellationRequested)
                        {
                            break;
                        }

                        GenerateAIImage(amiibo);
                    }
                    return amiibos.Where(x => !string.IsNullOrEmpty(x.AmiiboImagePath));
                }, cts.Token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Current);


                var task3 = task2.ContinueWith((completedTask) =>
                {
                    var amiibos = completedTask.Result;
                    foreach (var amiibo in amiibos)
                    {
                        lstAmiibos.Invoke(() => lstAmiibos.Items.Add($"Name: {amiibo.AmiiboName}, Image: {amiibo.AmiiboImagePath}"));
                    }

                    lblMessage.Invoke(() => {
                        lblMessage.Text = $"{amiibos.Count()} obtained!";

                        cts?.Dispose();
                        cts = null;

                        btnSearch.Text = "Search";
                    });

                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            


        }

        private List<Amiibo> GetAll()
        {
            Thread.Sleep(5000);
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


        private void GenerateAIImage(Amiibo amiibo)
        {
            Thread.Sleep(1000);
            Debug.WriteLine($"Generating image for {amiibo.AmiiboName}");
            amiibo.AmiiboImagePath = Guid.NewGuid().ToString();
        }

    }
}

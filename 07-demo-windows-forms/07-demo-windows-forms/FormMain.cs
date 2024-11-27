using Microsoft.Extensions.DependencyInjection;

namespace _07_demo_windows_forms
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public FormMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola Mundo");
        }

        private void brandsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void brandsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //var frm = new FormBrand();
            var frm = _serviceProvider.GetRequiredService<FormBrand>();
            frm.ShowDialog();
        }
    }
}

using _1_Entities;
using _2_Services;
using Microsoft.Extensions.DependencyInjection;

namespace _07_demo_windows_forms
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepositorySimple<Sale> _saleRepository;
        public FormMain(IServiceProvider serviceProvider,
            IRepositorySimple<Sale> saleRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _saleRepository = saleRepository;
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

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            dgv.DataSource = await _saleRepository.GetAllAsync();
            dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void cervezasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormBeer>();
            frm.ShowDialog();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormNewSale>();
            frm.ShowDialog();
            await Refresh();
        }
    }
}

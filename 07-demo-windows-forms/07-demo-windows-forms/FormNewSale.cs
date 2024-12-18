using _1_Entities;
using _2_Services;
using _2_Services.DTOs;
using _3_Repositories.AdditionalDataClass;

namespace _07_demo_windows_forms
{
    public partial class FormNewSale : Form
    {
        private readonly IRepositoryAdditionalData<Beer, BeerAdditionalData> _beerRepository;
        private readonly CreateSale _createSale;

        public FormNewSale(IRepositoryAdditionalData<Beer, BeerAdditionalData> beerRepository,
            CreateSale createSale)
        {
            InitializeComponent();
            _beerRepository = beerRepository;
            _createSale = createSale;
        }

        private async void FormNewSale_Load(object sender, EventArgs e)
        {
            await ChargeData();
        }

        private async Task ChargeData()
        {
            cbo_beer.DataSource = await _beerRepository.GetAllAsync();
            cbo_beer.DisplayMember = "Name";
            cbo_beer.ValueMember = "Id";
            if (cbo_beer.Items.Count > 0) { cbo_beer.SelectedIndex = 0; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal unitPrice = ((Beer)cbo_beer.SelectedItem).Price;
            int idBeer = ((Beer)cbo_beer.SelectedItem).Id;
            string name = ((Beer)cbo_beer.SelectedItem).Name;
            int quantity = int.Parse(txtQuantity.Value.ToString());

            dgv.Rows.Add(idBeer, quantity, name, unitPrice, unitPrice * quantity);

            txtQuantity.Value = 1;
            if (cbo_beer.Items.Count > 0) { cbo_beer.SelectedIndex = 0; }
            cbo_beer.Focus();
            GetTotal();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
                var saleDTO = new SaleDTO();
                saleDTO.Concepts = new List<ConceptDTO>();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var conceptDTO = new ConceptDTO()
                    {
                        IdBeer = int.Parse(row.Cells[0].Value.ToString()),
                        UnitPrice = decimal.Parse(row.Cells[3].Value.ToString()),
                        Quantity = int.Parse(row.Cells[1].Value.ToString())
                    };

                    saleDTO.Concepts.Add(conceptDTO);
                }
                await _createSale.ExecuteAsync(saleDTO);
                this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ocurrió un error: " + ex.Message);
            //}
        }

        private void GetTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                total += decimal.Parse(row.Cells[4].Value.ToString());
            }

            lbl_total.Text = total.ToString("C");
        }
    }
}

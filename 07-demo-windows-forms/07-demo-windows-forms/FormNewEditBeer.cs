using _1_Entities;
using _2_Services;
using _2_Services.DTOs;
using _3_Repositories.AdditionalDataClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_demo_windows_forms
{
    public partial class FormNewEditBeer : Form
    {
        private readonly IRepository<Brand> _repository;
        private readonly AddBeer<BeerAdditionalData> _addBeer;
        private readonly EditBeer<BeerAdditionalData> _editBeer;

        private BeerDTO _beer;
        public BeerDTO Beer { set { _beer = value; } }

        public FormNewEditBeer(IRepository<Brand> repository,
            AddBeer<BeerAdditionalData> addBeer,
            EditBeer<BeerAdditionalData> editBeer)
        {
            InitializeComponent();
            _repository = repository;
            _addBeer = addBeer;
            _editBeer = editBeer;
        }

        private async void FormNewEditBeer_Load(object sender, EventArgs e)
        {
            await ChargeData();

            if (_beer != null)
            {
                SetInfo();
            }
        }

        private async Task ChargeData()
        {
            cboBrand.DataSource = await _repository.GetAllAsync();
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";

            if (cboBrand.Items.Count > 0)
            {
                cboBrand.SelectedIndex = 0;
            }
        }

        private void SetInfo()
        {
            Text = "Editar cerveza";
            txtName.Text = _beer.Name;
            cboBrand.SelectedValue = _beer.BrandId;
            txtAlcohol.Text = _beer.Alcohol.ToString();
            txtDescription.Text = _beer.Description;
        }

        private void txtAlcohol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            var textBox = (sender as TextBox);
            if (e.KeyChar == ',' && textBox.Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_beer == null)
                {
                    await Add();
                }
                else
                {
                    Edit();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private async Task Add()
        {
            string name = txtName.Text.Trim();
            int idBrand = int.Parse(cboBrand.SelectedValue.ToString());
            decimal alcohol = decimal.Parse(txtAlcohol.Text.Trim().ToString());
            string description = txtDescription.Text.Trim();

            await _addBeer.ExecuteAsync(new BeerDTO
            {
                Name = name,
                BrandId = idBrand,
                Alcohol = alcohol,
                Description = description
            });

            this.Close();
        }

        private async Task Edit()
        {
            string name = txtName.Text.Trim();
            int idBrand = int.Parse(cboBrand.SelectedValue.ToString());
            decimal alcohol = decimal.Parse(txtAlcohol.Text.Trim().ToString());
            string description = txtDescription.Text.Trim();

            await _editBeer.ExecuteAsync(new BeerDTO
            {
                Id = _beer.Id,
                Name = name,
                BrandId = idBrand,
                Alcohol = alcohol,
                Description = description
            });

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

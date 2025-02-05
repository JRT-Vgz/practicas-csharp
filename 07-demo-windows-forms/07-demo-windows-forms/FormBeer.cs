﻿using _1_Entities;
using _2_Services;
using _3_Repositories.AdditionalDataClass;
using _3_Repositories.QueryObjects;
using Microsoft.Extensions.DependencyInjection;

namespace _07_demo_windows_forms
{
    public partial class FormBeer : Form
    {
        private readonly IRepositoryAdditionalData<Beer, BeerAdditionalData> _repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly GetBeerById<BeerAdditionalData> _getBeerById;
        private readonly BeerWithBrandQuery _query;
        public FormBeer(IRepositoryAdditionalData<Beer, BeerAdditionalData> repository,
            IServiceProvider serviceProvider,
            GetBeerById<BeerAdditionalData> getBeerById,
            BeerWithBrandQuery query)
        {
            InitializeComponent();
            _repository = repository;
            _serviceProvider = serviceProvider;
            _getBeerById = getBeerById;
            _getBeerById = getBeerById;
            _query = query;
        }

        private async void FormBeer_Load(object sender, EventArgs e)
        {
            await Refresh();
            AddColumns();
        }

        private async Task Refresh()
        {
            var beers = await _query.GetAsync();
            dgv.DataSource = beers;
        }

        private void AddColumns()
        {
            var editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditButton";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "Editar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.DefaultCellStyle.BackColor = Color.LightGray;
            dgv.Columns.Add(editButtonColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Red;
            dgv.Columns.Add(deleteButtonColumn);
        }

        private async void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgv.Columns[e.ColumnIndex].Name == "EditButton")
            {
                var frm = _serviceProvider.GetRequiredService<FormNewEditBeer>();
                var beerDTO = await _getBeerById.ExecuteAsync(id);
                frm.Beer = beerDTO;
                frm.ShowDialog();
                await Refresh();
            }
            else if (dgv.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                var confirmResult = MessageBox.Show("¿Estás seguro de eliminar la cerveza?",
                    "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    await _repository.DeleteAsync(id);
                    await Refresh();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormNewEditBeer>();
            frm.ShowDialog();
            await Refresh();
        }
    }
}

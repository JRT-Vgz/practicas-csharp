using _1_Entities;
using _2_Services;

namespace _07_demo_windows_forms
{
    public partial class FormNewEditBrand : Form
    {
        private int _id = 0;
        private readonly AddBrand _addBrand;
        private readonly EditBrand _editBrand;
        public FormNewEditBrand(AddBrand addBrand, 
            EditBrand editBrand)
        {
            InitializeComponent();
            _addBrand = addBrand;
            _editBrand = editBrand;
        }

        public void SetInfo(Brand brand)
        {
            _id = brand.Id;
            Text = "Editar Marca";
            txtName.Text = brand.Name;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    await Add();
                }
                else
                {
                    await Edit();
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
            await _addBrand.ExecuteAsync(new Brand { Name = name });

            this.Close();
        }

        private async Task Edit()
        {
            string name = txtName.Text.Trim();;
            await _editBrand.ExecuteAsync(new Brand { Id = _id, Name = name });

            this.Close();
        }
    }
}

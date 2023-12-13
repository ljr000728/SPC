using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace SPC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (ProductsContext dbContext = new ProductsContext())
            {
                var categories = dbContext.Categories.ToList();
                this.categoryBindingSource.DataSource = categories;
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
        }

        private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            using (ProductsContext dbContext = new ProductsContext())
            {
                var category = (Category)this.dataGridViewCategories.CurrentRow.DataBoundItem;
                if (category != null)
                {
                    var products = dbContext.Categories.Include(c => c.Products).Single(c => c.CategoryId == category.CategoryId);
                    this.productsBindingSource.DataSource = products.Products.ToList();
                }
                else
                {
                    this.productsBindingSource.DataSource = null;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (ProductsContext dbContext = new ProductsContext())
            {
                var category = (Category)this.dataGridViewCategories.CurrentRow.DataBoundItem;
                if (category != null)
                {
                    var products = dbContext.Categories.Include(c => c.Products).Single(c => c.CategoryId == category.CategoryId);
                    products.Products.ToList();
                }
            }

            this.dataGridViewCategories.Refresh();
            this.dataGridViewProductModels.Refresh();
        }
    }
}
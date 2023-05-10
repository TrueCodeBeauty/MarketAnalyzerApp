using MarketAnalyzerApp.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarketAnalyzerApp;

public partial class ProductsForm : Form
{
    public ProductsForm()
    {
        InitializeComponent();
    }
    List<Product> _products;
    private void ProductsForm_Load(object sender, EventArgs e)
    {
        CustomizeGridAppearance();
        _products = CSVDataLoader.LoadData();
        RefreshGrid();

        ConfigureChart();
        PricesChart.Visible = false;
    }
    private void CustomizeGridAppearance()
    {
        ProductsGrid.AutoGenerateColumns = false;
        ProductsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        ProductsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        ProductsGrid.RowHeadersVisible = false;

        DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
        titleCol.HeaderText = "Title";
        titleCol.DataPropertyName = "Title";
        ProductsGrid.Columns.Add(titleCol);

        DataGridViewTextBoxColumn brandCol = new DataGridViewTextBoxColumn();
        brandCol.HeaderText = "Brand";
        brandCol.DataPropertyName = "Brand";
        ProductsGrid.Columns.Add(brandCol);
    }
    private async void SearchText_TextChanged(object sender, EventArgs e)
    {
        int lengthBeforePause = SearchText.Text.Length;

        await Task.Delay(300);

        int lengthAfterPause = SearchText.Text.Length;

        if (lengthBeforePause == lengthAfterPause)
            RefreshGrid();
    }
    private void RefreshGrid()
    {
        List<Product> searchResult = _products.Where(p => p.Brand.ToLower().Contains(SearchText.Text.ToLower())).ToList();

        ProductsGrid.DataSource = searchResult;
    }
    private void RefreshChart(Product selectedProduct)
    {
        PricesChart.Visible = true;

        PricesChart.Series["Price"].Points.Clear();
        PricesChart.Series["Price"].Points.AddXY("Dec 2021", Calculations.ConvertToDecimal(selectedProduct.Dec2021Price));
        PricesChart.Series["Price"].Points.AddXY("May 2022", Calculations.ConvertToDecimal(selectedProduct.May2022Price));
        PricesChart.Series["Price"].Points.AddXY("Jul 2022", Calculations.ConvertToDecimal(selectedProduct.Jul2022Price));
        PricesChart.Series["Price"].Points.AddXY("Sep 2022", Calculations.ConvertToDecimal(selectedProduct.Sep2022Price));
        PricesChart.Series["Price"].Points.AddXY("Oct 2022", Calculations.ConvertToDecimal(selectedProduct.Oct2022Price));

        foreach (DataPoint point in PricesChart.Series["Price"].Points)
            point.Label = point.YValues[0].ToString();
    }
    private void ConfigureChart()
    {
        PricesChart.Series.Clear();
        PricesChart.ChartAreas.Clear();

        PricesChart.ChartAreas.Add(new ChartArea());
        PricesChart.Series.Add(new Series("Price")
        {
            ChartType = SeriesChartType.Area
        });

    }
    private void ProductsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        Product selectedProduct = (Product)ProductsGrid.Rows[e.RowIndex].DataBoundItem;
        RefreshChart(selectedProduct);
    }
    private void CalculateChangeButton_Click(object sender, EventArgs e)
    {
        var selectedRows = ProductsGrid.SelectedRows;
        if (selectedRows.Count == 0)
            return;

        List<Product> selectedProducts = new List<Product>();

        foreach (DataGridViewRow row in selectedRows)
        {
            selectedProducts.Add((Product)row.DataBoundItem);
        }

        string message = Calculations.CalculateChangeInPrice(selectedProducts);
        MessageBox.Show(message);
    }
    private void BiggestIncreaseBtn_Click(object sender, EventArgs e)
    {
        Dictionary<string, decimal> brandsWithHighestPriceIncrease = Calculations.CalculateBrandsPriceChange(_products, SortType.Increase);

        string message = "";
        foreach (var brand in brandsWithHighestPriceIncrease)
        {
            message += $"{brand.Key} increased price for {brand.Value}%\n\n";
        }

        MessageBox.Show(message, "Top Brands with Highest Price Increase between Dec 2021 and Oct 2022");
    }
    private void BiggestDecreaseBtn_Click(object sender, EventArgs e)
    {
        Dictionary<string, decimal> brandsWithHighestPriceIncrease = Calculations.CalculateBrandsPriceChange(_products, SortType.Decrease);

        string message = "";
        foreach (var brand in brandsWithHighestPriceIncrease)
        {
            message += $"{brand.Key} dropped price for {brand.Value}%\n\n";
        }

        MessageBox.Show(message, "Top Brands with Highest Price Decrease between Dec 2021 and Oct 2022");
    }
}
namespace MarketAnalyzerApp
{
    partial class ProductsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            ProductsGrid = new DataGridView();
            SearchText = new TextBox();
            PricesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            CalculateChangeButton = new Button();
            BiggestIncreaseBtn = new Button();
            BiggestDecreaseBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PricesChart).BeginInit();
            SuspendLayout();
            // 
            // ProductsGrid
            // 
            ProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsGrid.Location = new Point(38, 70);
            ProductsGrid.Margin = new Padding(5);
            ProductsGrid.Name = "ProductsGrid";
            ProductsGrid.RowTemplate.Height = 25;
            ProductsGrid.Size = new Size(534, 413);
            ProductsGrid.TabIndex = 0;
            ProductsGrid.CellDoubleClick += ProductsGrid_CellDoubleClick;
            // 
            // SearchText
            // 
            SearchText.Location = new Point(38, 12);
            SearchText.Name = "SearchText";
            SearchText.PlaceholderText = "Search products...";
            SearchText.Size = new Size(534, 33);
            SearchText.TabIndex = 1;
            SearchText.TextChanged += SearchText_TextChanged;
            // 
            // PricesChart
            // 
            chartArea1.Name = "ChartArea1";
            PricesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            PricesChart.Legends.Add(legend1);
            PricesChart.Location = new Point(597, 70);
            PricesChart.Name = "PricesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            PricesChart.Series.Add(series1);
            PricesChart.Size = new Size(609, 413);
            PricesChart.TabIndex = 2;
            PricesChart.Text = "chart1";
            // 
            // CalculateChangeButton
            // 
            CalculateChangeButton.Location = new Point(38, 503);
            CalculateChangeButton.Name = "CalculateChangeButton";
            CalculateChangeButton.Size = new Size(222, 39);
            CalculateChangeButton.TabIndex = 3;
            CalculateChangeButton.Text = "Calculate change";
            CalculateChangeButton.UseVisualStyleBackColor = true;
            CalculateChangeButton.Click += CalculateChangeButton_Click;
            // 
            // BiggestIncreaseBtn
            // 
            BiggestIncreaseBtn.Location = new Point(597, 503);
            BiggestIncreaseBtn.Name = "BiggestIncreaseBtn";
            BiggestIncreaseBtn.Size = new Size(261, 39);
            BiggestIncreaseBtn.TabIndex = 4;
            BiggestIncreaseBtn.Text = "Biggest price increases";
            BiggestIncreaseBtn.UseVisualStyleBackColor = true;
            BiggestIncreaseBtn.Click += BiggestIncreaseBtn_Click;
            // 
            // BiggestDecreaseBtn
            // 
            BiggestDecreaseBtn.Location = new Point(940, 503);
            BiggestDecreaseBtn.Name = "BiggestDecreaseBtn";
            BiggestDecreaseBtn.Size = new Size(266, 39);
            BiggestDecreaseBtn.TabIndex = 5;
            BiggestDecreaseBtn.Text = "Biggest price decreases";
            BiggestDecreaseBtn.UseVisualStyleBackColor = true;
            BiggestDecreaseBtn.Click += BiggestDecreaseBtn_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 566);
            Controls.Add(BiggestDecreaseBtn);
            Controls.Add(BiggestIncreaseBtn);
            Controls.Add(CalculateChangeButton);
            Controls.Add(PricesChart);
            Controls.Add(SearchText);
            Controls.Add(ProductsGrid);
            Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "ProductsForm";
            Text = "Form1";
            Load += ProductsForm_Load;
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PricesChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ProductsGrid;
        private TextBox SearchText;
        private System.Windows.Forms.DataVisualization.Charting.Chart PricesChart;
        private Button CalculateChangeButton;
        private Button BiggestIncreaseBtn;
        private Button BiggestDecreaseBtn;
    }
}
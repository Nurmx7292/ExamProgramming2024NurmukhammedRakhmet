using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExpensesManager
{
    public partial class ExpensesManager : Form
    {
        private List<ExpenseRecord> expenseRecords = new List<ExpenseRecord>();
        public ExpensesManager()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;

            if (File.Exists(filePath))
            {
                expenseRecords = ReadExpenseFile(filePath);
                DisplayExpenseRecords(expenseRecords);
            }
            else
            {
                ShowErrorMessage($"File does not exist {filePath}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (expenseRecords.Count > 0)
                DisplaySummary(expenseRecords);
            else
                ShowInfoMessage("No parsed data. Load a file first.");
        }
        private List<ExpenseRecord> ReadExpenseFile(string filePath)
        {
            List<ExpenseRecord> records = new List<ExpenseRecord>();
            try
            {
                records.AddRange(File.ReadLines(filePath).Skip(1).Select(line =>
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3 && DateTime.TryParseExact(parts[0], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) &&
                        decimal.TryParse(parts[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal price))
                    {
                        return new ExpenseRecord { Date = date, Price = price, Category = parts[2] };
                    }
                    else
                    {
                        ShowErrorMessage($"Invalid format in line: {line}");
                        return null;
                    }
                }).Where(record => record != null));
            }
            catch (FileNotFoundException)
            {
                ShowErrorMessage("Couldn't find the file");
            }
            catch (UnauthorizedAccessException)
            {
                ShowErrorMessage("Unauthorized access");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error reading file: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            return records;
        }
        private void DisplayExpenseRecords(List<ExpenseRecord> records)
        {
            label1.Text = string.Join(Environment.NewLine, records.Select(record => $"{record.Date:yyyy-MM-dd} | {record.Price:C} | {record.Category}"));
        }
        private void DisplaySummary(List<ExpenseRecord> records)
        {
            decimal totalExpenses = records.Sum(record => record.Price);
            int numberOfCategories = records.Select(record => record.Category).Distinct().Count();
            int totalDatesOfPayments = records.Select(record => record.Date).Distinct().Count();
            var categorySummary = records.GroupBy(record => record.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    TotalPurchases = group.Count(),
                    PurchaseMonths = string.Join(", ", group.Select(record => record.Date.ToString("MMMM"))),
                    TotalExpense = group.Sum(record => record.Price)
                });
            label2.Text = $"Total expenses: {totalExpenses:C}\nNumber of categories: {numberOfCategories}\nTotal dates of payments: {totalDatesOfPayments}\nCategories:\n" +
                string.Join(Environment.NewLine, categorySummary.Select(category =>
                    $"    {category.Category} – bought {category.TotalPurchases} times in total. Purchases in: {category.PurchaseMonths}. Total expense: {category.TotalExpense:C}"));
        }
        private void ShowErrorMessage(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ShowInfoMessage(string message) => MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public class ExpenseRecord
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}

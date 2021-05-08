using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETS_PosApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public double CostOfItems()
        {
            Double sum = 0;
            int i = 0;
            for (i = 0; i < (dataGridView1.Rows.Count); i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        private void AddCost()
        {
            Double tax, g;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                lblTax.Text = String.Format("{0:c2}", (( CostOfItems() * tax) / 100));
                lblSubTotal.Text = String.Format("{0:c2}", ( CostOfItems() ));
                g = ((CostOfItems() * tax) / 100);
                lblTotal.Text = String.Format("{0:c2}", (CostOfItems() + g));
                lblBarcode.Text = Convert.ToString(g + CostOfItems());
            }
        }
        
        private void Change()
        {
            Double tax, g, c;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                g = ((CostOfItems() * tax) / 100) + CostOfItems();
                c = Convert.ToInt32(lblCash.Text);
                this.lblChange.Text = String.Format("{0:c2}", c - g);
            }
        }

        Bitmap bitmap;

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                lblBarcode.Text = "";
                lblCash.Text = "0";
                lblChange.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cboPayment.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("Visa Card");
            cboPayment.Items.Add("Master Card");
        }

        private void NumbersOnly1(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (lblCash.Text == "0")
            {
                lblCash.Text = "";
                lblCash.Text = b.Text;
            }
            else if (b.Text == ".")
            {
                if (!lblCash.Text.Contains("."))
                {
                    lblCash.Text = lblCash.Text + b.Text;
                }
            }
            else
                lblCash.Text = lblCash.Text + b.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Double CostifItem = 20000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button24"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Cap Coffee", "1", CostifItem);
            AddCost();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Double CostifItem = 19000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button23"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Cappucino", "1", CostifItem);
            AddCost();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Double CostifItem = 22000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button22"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Black Coffee", "1", CostifItem);
            AddCost();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Double CostifItem = 25000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button36"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Moccachino", "1", CostifItem);
            AddCost();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Double CostifItem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button35"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Coffee Bean", "1", CostifItem);
            AddCost();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Double CostifItem = 15000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button34"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Caramel Latte", "1", CostifItem);
            AddCost();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Double CostifItem = 16000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button21"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Jus Jeruk", "1", CostifItem);
            AddCost();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Double CostifItem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button20"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Jus Jambu", "1", CostifItem);
            AddCost();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Double CostifItem = 14000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button19"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Es Coklat", "1", CostifItem);
            AddCost();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Double CostifItem = 30000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button33"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Jus Strawberry", "1", CostifItem);
            AddCost();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Double CostifItem = 15000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button32"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Sirup", "1", CostifItem);
            AddCost();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Double CostifItem = 15000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button31"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Jus Leci", "1", CostifItem);
            AddCost();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Double CostifItem = 25000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button18"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Roti Permen", "1", CostifItem);
            AddCost();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Double CostifItem = 19000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button17"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Roti Karamel", "1", CostifItem);
            AddCost();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Double CostifItem = 25000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button16"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Kue Gelay", "1", CostifItem);
            AddCost();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Double CostifItem = 25000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button30"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Waffle Strawberry", "1", CostifItem);
            AddCost();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Double CostifItem = 35000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button29"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Kue Coklat", "1", CostifItem);
            AddCost();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Double CostifItem = 25000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button28"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Roti Coklat", "1", CostifItem);
            AddCost();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Double CostifItem = 22000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button15"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Roti Krim", "1", CostifItem);
            AddCost();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Double CostifItem = 21000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button14"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Roti Kukus", "1", CostifItem);
            AddCost();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Double CostifItem = 23000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button13"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Roti Warna Warni", "1", CostifItem);
            AddCost();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Double CostifItem = 29000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button27"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Coklat Lava", "1", CostifItem);
            AddCost();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Double CostifItem = 27000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button26"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Rooti Pelangi", "1", CostifItem);
            AddCost();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Double CostifItem = 24000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "button25"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostifItem;
                }
            }
            dataGridView1.Rows.Add("Kue Strawberry", "1", CostifItem);
            AddCost();
        }
    }
}

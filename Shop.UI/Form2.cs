using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GunShop;

namespace Shop.UI
{
    public partial class AddGun : Form
    {
        public AddGun(Specifications specifications)
        {
            Specifications = specifications;

            InitializeComponent();
        }

        public Specifications Specifications { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddGun_Load(object sender, EventArgs e)
        {
            textBox1.Text = Specifications.Name;
            dateTimePicker1.Text = Specifications.ProductionDate.ToLongDateString();
            textBox2.Text = Specifications.Caliber;
            comboBox1.Text = Specifications.GunType;
            textBox3.Text = Convert.ToString(Specifications.Weight);
            textBox4.Text = Convert.ToString(Specifications.Price);


        }


        private void button1_Click(object sender, EventArgs e)

        {
            Specifications.Name = textBox1.Text;
            Specifications.ProductionDate = dateTimePicker1.Value;
            Specifications.Caliber = textBox2.Text;
            Specifications.GunType = comboBox1.Text;
            Specifications.Weight = Convert.ToDouble(textBox3.Text);
            Specifications.Price = Convert.ToDouble(textBox4.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void translate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Match mh = Regex.Match(e.KeyChar.ToString(), "[0-9,]");

                if (!(mh.Success) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using GunShop;

namespace Shop.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var LoadPicture = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var lp = LoadPicture.ShowDialog(this);
            if (lp == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(LoadPicture.FileName);
            }

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            var ad = new AddGun(new Specifications { ProductionDate = DateTime.Now } );
            if (ad.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(ad.Specifications);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Specifications)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listBox1.SelectedItem is Specifications;
        }

        

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var item = (Specifications)listBox1.Items[index];
                var ad = new AddGun(item);
                if (ad.ShowDialog(this) == DialogResult.OK)
                {
                    listBox1.Items.Remove(item);
                    listBox1.Items.Insert(index, item);
                }
            }

        }

      
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() {Filter = "Магазин|*.gunshop" };
            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            var shop = new GunShop.Shop()
            {
                Name = textBox1.Text,
                Guns = listBox1.Items.OfType<Specifications>().ToList(),
                Address = textBox2.Text,
                Contacts = textBox3.Text,
            };
            var stream = new MemoryStream();
            pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
            shop.Photo = stream.ToArray();

            var xs = new XmlSerializer(typeof(GunShop.Shop));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, shop);
            file.Close();


        }


        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Магазин|*.gunshop" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xmlser = new XmlSerializer(typeof(GunShop.Shop));
            var file = File.OpenRead(ofd.FileName);
            var shop = (GunShop.Shop)xmlser.Deserialize(file);
            file.Close();

            textBox1.Text = shop.Name;
            textBox2.Text = shop.Address;
            textBox3.Text = shop.Contacts;

            var ms = new MemoryStream(shop.Photo);
            pictureBox1.Image = Image.FromStream(ms);

            listBox1.Items.Clear();

            foreach (var catalog in shop.Guns)
            {
                listBox1.Items.Add(catalog);
            }


        }
    }
}

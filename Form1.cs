using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        private readonly Config _config = null;
        public Form1()
        {
            InitializeComponent();
            _config = Config.GetConfig();
            Init();
        }
        private void Init()
        {
            if (!_config.IsNullProp())
            {
                ob_pira.Text = _config.Pira_Ob;
                polow_osn_pira.Text = _config.Pira_SBich;
                plowa_full_pira.Text = _config.Pira_SPovn;
                ob_kon.Text = _config.Conus_Ob;
                polow_osn_kon.Text = _config.Conus_SBich;
                polow_full_kon.Text = _config.Conus_SPovn;
                ob_zul.Text = _config.Cilindr_Ob;
                polow_osn_zul.Text = _config.Cilindr_SBich;
                polow_full_zul.Text = _config.Cilindr_SPovn;
            }
        }

        private void button_pira_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric1 = int.TryParse(vis_pira.Text, out n);
            bool isNumeric2 = int.TryParse(apof_pira.Text, out n);
            bool isNumeric3 = int.TryParse(dosh_pira.Text, out n);
            if (isNumeric1 == false && !vis_pira.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'висота' не валідне!");
            }
            else if (isNumeric2 == false && !apof_pira.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'апофема' не валідне!");
            }
            else if (isNumeric3 == false && !dosh_pira.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'довжина' не валідне!");
            }
            else 
            { 
                double vis = Double.Parse(vis_pira.Text);
                double apof = Double.Parse(apof_pira.Text);
                double dosh = Double.Parse(dosh_pira.Text);
                double plowa = 0.43 * dosh * dosh;
                double ob = 0.3 * plowa * vis;
                double plowa_full = 4 * plowa;
                double plowa_bich = 2 * dosh*apof;
                ob_pira.Text = string.Format("{0:F1}", (ob));
                polow_osn_pira.Text = string.Format("{0:F1}", (plowa_bich));
                plowa_full_pira.Text = string.Format("{0:F1}", (plowa_full));
            }
        }

        private void button_kon_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric1 = int.TryParse(vis_kon.Text, out n);
            bool isNumeric2 = int.TryParse(r_kon.Text, out n);
            bool isNumeric3 = int.TryParse(dosh_kon.Text, out n);
            if (isNumeric1 == false && !vis_kon.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'висота' не валідне!");
            }
            else if (isNumeric2 == false && !r_kon.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'радіус' не валідне!");
            }
            else if (isNumeric3 == false && !dosh_kon.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'довжина' не валідне!");
            }
            else
            {
                double vis1 = Double.Parse(vis_kon.Text);
                double rad = Double.Parse(r_kon.Text);
                double tvir = Double.Parse(dosh_kon.Text);
                double plowa = 3.14 * rad * rad;
                double ob = 0.3 * plowa * vis1;
                double plowa_full = 3.14 * rad * tvir + 3.14 * rad * rad;
                double plowa_bich = 3.14 * rad * tvir;
                ob_kon.Text = string.Format("{0:F1}", (ob));
                polow_osn_kon.Text = string.Format("{0:F1}", (plowa_bich));
                polow_full_kon.Text = string.Format("{0:F1}", (plowa_full));
            }
        }

        private void button_zul_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric1 = int.TryParse(textBox18.Text, out n);
            bool isNumeric2 = int.TryParse(textBox17.Text, out n);

            if (isNumeric1 == false && !textBox18.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'висота' не валідне!");
            }
            else if (isNumeric2 == false && !textBox17.Text.Contains(",") && !textBox18.Text.Contains("."))
            {
                MessageBox.Show("Поле 'радіус' не валідне!");
            }

            else 
            { 
                double vis2 = Double.Parse(textBox18.Text);
                double rad2 = Double.Parse(textBox17.Text);
                double plowa = 3.14 * rad2 * rad2;
                double ob = plowa * vis2;
                double plowa_full = 3.14*2 * rad2 *(vis2+rad2);
                double plowa_bich = 3.14 *2*rad2*vis2;
                ob_zul.Text = string.Format("{0:F1}", (ob));
                polow_osn_zul.Text = string.Format("{0:F1}", (plowa_bich));
                polow_full_zul.Text = string.Format("{0:F1}", (plowa_full));
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isTextEmpty())
            {
                _config.Pira_Ob = ob_pira.Text ;
                _config.Pira_SBich=polow_osn_pira.Text;
                _config.Pira_SPovn=plowa_full_pira.Text;
                _config.Conus_Ob = ob_kon.Text;
                _config.Conus_SBich = polow_osn_kon.Text;
                _config.Conus_SPovn = polow_full_kon.Text;
                _config.Cilindr_Ob = ob_zul.Text;
                _config.Cilindr_SBich = polow_osn_zul.Text;
                _config.Cilindr_SPovn = polow_full_zul.Text;
                _config.Save();
            }
            else
            {
                _config.Clear();
                _config.Save();
            }
        }

        private bool isTextEmpty()
        {
            return string.IsNullOrEmpty(ob_pira.Text)
                && string.IsNullOrEmpty(polow_osn_pira.Text)
                && string.IsNullOrEmpty(plowa_full_pira.Text)
                && string.IsNullOrEmpty(plowa_full_pira.Text)
                && string.IsNullOrEmpty(ob_kon.Text)
                && string.IsNullOrEmpty(polow_osn_kon.Text)
                && string.IsNullOrEmpty(polow_full_kon.Text)
                && string.IsNullOrEmpty(ob_zul.Text)
                && string.IsNullOrEmpty(polow_osn_zul.Text)
                && string.IsNullOrEmpty(polow_full_zul.Text);
        }   
    }
}

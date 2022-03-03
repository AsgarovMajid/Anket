using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WINDOWSFORm
{
    public partial class Form1 : Form
    {
        public class UserFile
        {
            public string fathername { get; set; }
            public string surname { get; set; }
            public string country { get; set; }
            public string phone { get; set; }
            public DateTime DOT { get; set; }
            public string name { get; set; }
            public string city { get; set; }
            public bool gender { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserFile file = new UserFile();

            var jsonStr = File.ReadAllText(textBox1.Text + ".json");

            file = JsonConvert.DeserializeObject<UserFile>(jsonStr);

            if (textBox1.Text == file.name && textBox1.Text != null)
            {
                maskedTextBox1.Text = file.phone;
                dateTimePicker1.Value = file.DOT;
                textBox4.Text = file.fathername;
                textBox3.Text = file.surname;
                textBox5.Text = file.country;
                textBox2.Text = file.name;
                textBox6.Text = file.city;

                if (file.gender == true){radioButton1.Checked = false; radioButton2.Checked = true;}

                else { radioButton1.Checked = true; radioButton2.Checked = false; }
            }

            else {  MessageBox.Show("NOT FOUND", "NOT!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserFile file = new UserFile();

            file.phone = maskedTextBox1.Text;
            file.DOT = dateTimePicker1.Value;
            file.fathername = textBox4.Text;
            file.surname = textBox3.Text;
            file.country = textBox5.Text;
            file.name = textBox2.Text;
            file.city = textBox6.Text;

            if (radioButton1.Checked){file.gender = true;}

            else{file.gender = false;}

            var str = JsonConvert.SerializeObject(file, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(textBox2.Text + ".json", str);

            MessageBox.Show("Your info was saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            maskedTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}

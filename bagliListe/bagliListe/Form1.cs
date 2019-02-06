using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace bagliListe
{
    public unsafe partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public class BListe
        {
            public int data;
            public int* sonraki;

        }

       int say3 = 0,yks=25,yer=0;
        ListViewItem lst;
        int var2 = 0;
       
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int lcount = 0; lcount <= listView1.Items.Count - 1; lcount++)
                {
                    if (listView1.Items[lcount].Selected == true)
                    {
                        var2 = lcount;
                        break;
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (var2 == (listView1.Items.Count-1))
                {
                    listView1.SelectedItems[0].Remove();
                    listView1.Items[listView1.Items.Count - 1].SubItems[1].Text = "000000000";
                }
                else
                {
                    listView1.SelectedItems[0].Remove();
                }

            
            btnGroup.Controls.Clear();
            yer = 0;
            yks = 25;
            int n = 1, m = 1;


                for (int i = 0; i < listView1.Items.Count; i++)
            {
           
            int countB = 0;
                foreach (Control c in btnGroup.Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        countB += 1;

                    }
                }

                Button btn = new Button();
            
            if (countB != 0 && countB % 6 == 0)
            {
                yks += 50;
                yer = 0;
                btn.Location = new Point(yer, yks);
                yer = 150;
            }
            else
            {
                btn.Location = new Point(yer, yks);


            }
                    if (n % 2 == 1)
                    {
                        n += 1;
                        btn.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        n += 1;
                        btn.BackColor = Color.Yellow;
                    }

                    btn.Name = "btn_" + i.ToString();
            btn.Size = new Size(50, 30);
            btn.Text = listView1.Items[i].SubItems[0].Text;
            btnGroup.Controls.Add(btn);

            Button btn2 = new Button();
            if (countB != 0 && countB % 6 == 0)
            {

                btn2.Location = new Point(40, yks);
            }
            else
            {

                btn2.Location = new Point(40 + yer, yks);
                yer += 150;
            }

                    if (m % 2 == 1)
                    {
                        m += 1;
                        btn2.BackColor = Color.Yellow;
                    }
                    else
                    {
                        m += 1;
                        btn2.BackColor = Color.LawnGreen;
                    }
                    btn2.Name = "btn2_" + i.ToString();
            btn2.Size = new Size(90, 30);
            btn2.Text = listView1.Items[i].SubItems[1].Text; ;
            btnGroup.Controls.Add(btn2);
            }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen önce silinecek veriyi seçiniz");
            }
        }


        private unsafe void button3_Click(object sender, EventArgs e)
        {
            try
            {

            say3 = 0;
            listView1.Items.Clear();
            btnGroup.Controls.Clear();
            int sayi = 0, sayi2 = 0;
            BListe p1 = new BListe();
            BListe p2 = new BListe();
            yer = 0;
            yks = 25;
            int n = 1,m = 1;

            foreach (var item in textBox1.Text.Split(','))
            {
                sayi2 +=1;
            }

            int[] dizi = new int[sayi2];

            foreach (var item in textBox1.Text.Split(','))
            {

                int deger = Convert.ToInt32(item);
                dizi[sayi] = deger;
                sayi += 1;
            }


           
            for (int i = 0; i < dizi.Length; i++) {

                say3 += 1;
                sayi = Convert.ToInt32(dizi[i]);
                p1.data = sayi;
               
                int countB = 0;
                foreach (Control c in btnGroup.Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        countB += 1;

                    }
                }


                if (i != dizi.Length - 1)
                    {
                        sayi2 = Convert.ToInt32(dizi[i + 1]);
                        p2.data = sayi2;
                        p2.sonraki = &sayi2;
                    p1.sonraki = p2.sonraki;
                       
                }
                    else
                    {
                        p2.sonraki=null;
                        p1.sonraki = p2.sonraki;
                }

                if (p2.sonraki == null) {
                    string[] bilgiler = { p1.data.ToString(), "000000000" };
                    lst = new ListViewItem(bilgiler);
                    listView1.Items.Add(lst);
                }
                else
                {
                    string[] bilgiler = { p1.data.ToString(), ((int)p1.sonraki).ToString() + say3 };
                     lst = new ListViewItem(bilgiler);
                    listView1.Items.Add(lst);
                }
               
                     

                    Button btn = new Button();
                if (countB!=0 && countB % 6 == 0)
                {
                    yks += 50;
                    yer = 0;
                    btn.Location = new Point(yer,yks);
                    yer = 150;
                }
                else
                {
                    btn.Location = new Point(yer, yks);
                  
                   
                }
                    if (n%2==1)
                    {
                        n += 1;
                        btn.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        n += 1;
                        btn.BackColor = Color.Yellow;
                    }
                    btn.Name = "btn_" + i.ToString();
                    btn.Size = new Size(50, 30);
                    btn.Text = lst.SubItems[0].Text;
                    btnGroup.Controls.Add(btn);
               
                    Button btn2 = new Button();
                if (countB != 0 && countB % 6 == 0)
                {
                   
                    btn2.Location = new Point(40, yks);
                }
                else
                {
                    
                    btn2.Location = new Point(40 + yer, yks);
                    yer += 150;
                }

                    if (m%2==1)
                    {
                        m += 1;
                        btn2.BackColor = Color.Yellow;
                    }
                    else
                    {
                        m += 1;
                        btn2.BackColor = Color.LawnGreen;
                    }
                    btn2.Name = "btn2_" + i.ToString();
                    btn2.Size = new Size(90, 30);
                    btn2.Text = lst.SubItems[1].Text; ;
                    btnGroup.Controls.Add(btn2);

               

            }
            }
            catch (Exception)
            {

                MessageBox.Show("Bağlantılı Liste Oluşturulamadı...");
            }



        }
    }
}

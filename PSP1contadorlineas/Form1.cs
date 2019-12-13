using System;   
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSP1contadorlineas
{
    public partial class Form1 : Form
    {
        int contar;
        public Form1()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            buscar.ShowDialog();
            string texto1 = buscar.FileName.ToString();
            string linea = "";
            StreamReader leer = new StreamReader(texto1);
            string nombre = buscar.SafeFileName;
            int contador = 0;
            int contarMetodo = 0;
            string comentario = "//";
            string comenInicio = "/*";
            string comenFinal = "*/";
            string metodo = "public";
            
            while ((linea = leer.ReadLine()) != null)
            {
                if (linea != "") 
                {
                    contador++;
                }
                if (linea.Contains(comentario) == true ) 
                {
                    contador--;
                }
                if ((linea.Contains(comenInicio) == true)&&(linea.Contains(comenFinal)==true))
                {
                    contador--;
                }
                else if (linea.Contains(comenInicio)== true)
                {
                    contador--;
                    while ((linea = leer.ReadLine()) != comenFinal)
                    {

                    }
                }
                if (linea.Contains(metodo) == true)
                {
                    contarMetodo++;
                }
            }
            /*while ((linea = leer.ReadLine()) != null)
            {
                if (linea.Contains(metodo) == true)
                {
                    contarMetodo++;
                }
            }*/
                dataGridView1.Rows.Add(nombre, "", contarMetodo, contador);
            contar = contar + contador;
            //dataGridView1.Rows.Add("","", "", contar);
            

        }
        public void numeroMetodo()
        {

        }
        public void sumar()
        {
            //int n
            
            dataGridView1.Rows.Add("", "", "", contar);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sumar();
        }
    }
}

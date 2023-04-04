using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//importar capa logica
using BLL;

//libreria para impresion de datos
using System.Drawing.Printing;


namespace AppCalculadora
{
    public partial class Form1 : Form
    {
        //variable objeto
        private Operaciones obj0per;

        //constructor por omision del formuario
        public Form1()
        {
            InitializeComponent();
            this.obj0per = new Operaciones();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            //Cerrar la pantalla
            this.Close();
        }

        private void LimpiarPantalla()
        {
            //se ponen valores de 0 en los campos
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
            //selecciona el primer item desplegable de la lista
            this.cbxOperaciones.SelectedIndex = 0;
            this.txtResultado.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //al cargar el formulario se limpia la pantalla
            this.LimpiarPantalla();
        }



        //evento clic para el boton calcular
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //se utiliza el metodo dentro del click del boton
            Calcular();
        }
        //metodo encargado de realizar las operaciones
        private void Calcular()
        {
            //se rellena el objeto con los numeros del front end de las cajas de texto
            this.obj0per.Numero1 = float.Parse(this.txtNumero1.Text);
            this.obj0per.Numero2 = float.Parse(this.txtNumero2.Text);

            //verificar la operacion selleccionada
            switch (this.cbxOperaciones.SelectedIndex)
            {
                case 0://proceso de sumar
                    this.txtResultado.Text = this.obj0per.Sumar().ToString();
                    break;
                case 1://proceso de restar
                    this.txtResultado.Text = this.obj0per.Restar().ToString();
                    break;
                case 2://preceso de multiplicar
                    this.txtResultado.Text = this.obj0per.Multiplicar().ToString();
                    break;
                case 3://proceso de dividir
                    this.txtResultado.Text = this.obj0per.Dividir().ToString();
                    break;
            }
        }

        //evento click el boton nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //se llama al limpiar pantalla
            this.LimpiarPantalla();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //se crea una instancia del documento de impresion
            this.printDocument1 = new PrintDocument();

            //se crea un objeto de ajustes de configuracion de impresion
            PrinterSettings settings = new PrinterSettings();

            //se asigna al documento los ajustes de impresion
            this.printDocument1.PrinterSettings = settings;

            //se asigna el evento de impresion de datos
            this.printDocument1.PrintPage += this.ImprimirTiquete;

            //se imprime el documento
            this.printDocument1.Print();

        }
        /// <summary>
        /// evento encargado de realizar la impresion de los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImprimirTiquete(object sender, PrintPageEventArgs e)
        {
            //fuente de letra
            Font fuente = new Font("Arial", 14);

            //parametros de impresion
            int ancho = 500;
            int y = 20;

            e.Graphics.DrawString("----Tiquete cálculo----", fuente,
                Brushes.Black, new RectangleF(20, y += 20, ancho, 30));

            e.Graphics.DrawString("Numero 1: " + this.obj0per.Numero1, fuente,
               Brushes.Black, new RectangleF(0, y += 30, ancho, 30));

            e.Graphics.DrawString("Numero 2: " + this.obj0per.Numero2, fuente,
               Brushes.Black, new RectangleF(0, y += 30, ancho, 30));

            e.Graphics.DrawString("Operacion a realizar: " + this.cbxOperaciones.Text, fuente,
                Brushes.Black, new RectangleF(0, y += 30, ancho, 30));

            e.Graphics.DrawString("Resultado: " + this.txtResultado.Text, fuente,
                Brushes.Black, new RectangleF(0, y += 30, ancho, 30));

            e.Graphics.DrawString("Gracias por usar calc v2 " + this.txtResultado.Text, fuente,
                Brushes.Black, new RectangleF(0, y += 30, ancho, 30));

        }
        
    }//cierre formulario
}//cierre namespace

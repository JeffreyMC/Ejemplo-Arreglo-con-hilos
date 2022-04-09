using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arreglos
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//INSTANCIA LA CLASE METODOS
		Metodos f = new Metodos();

		//hilos
		Thread hiloArreglo;
		Thread hiloNumero;
		Thread hiloLetra;

		private void Form1_Load(object sender, EventArgs e)
		{
			//deshabilita los botones necesarios hasta que se ingrese una cadena
			btnSepara.Enabled = false;
			btnMostrar.Enabled = false;

			//se inicializan los hilos que se van a usar
			hiloArreglo = new Thread(new ParameterizedThreadStart(f.insertarCadena));
			hiloNumero = new Thread(new ThreadStart(f.separaNumero));
			hiloLetra = new Thread(new ThreadStart(f.separaCaracter));


		}

		//botón para ingresar la cadena
		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (txtCadena.Text.Equals(""))
			{
				MessageBox.Show("Por favor ingrese una cadena de caracteres");
			}
			else
			{
				//se inicia el subproceso para llenar el arreglo de caracteres
				hiloArreglo.Start(txtCadena.Text);

				//se habilita el botón separar letras y números
				btnSepara.Enabled = true;
				//Se deshabilita el de aceptar
				btnAceptar.Enabled = false;
			}

		}

		//muestra en el datagrid las letras y numeros del arreglo ingresado
		private void btnMostrar_Click(object sender, EventArgs e)
		{
			dataTable.Columns.Add("Números", "Números");
			dataTable.Columns.Add("Letras", "Letras");

			//muetra el arreglo en el datagrid
			for (int i = 0; i < f.numeros.Length; i++)
			{
				dataTable.Rows.Add(f.numeros[i], f.letras[i]);
			}

			//desahbilita el botón
			btnMostrar.Enabled = false;
		}

		//botón que inicia los subprocesos para llenar los dos arreglos restantes
		private void btnSepara_Click(object sender, EventArgs e)
		{
			//iniciar el hilo que separa los números
			hiloNumero.Start();
			//inicia el hilo que separa los caracteres
			hiloLetra.Start();

			//habilita el botón de mostrar
			btnMostrar.Enabled = true;
			//deshabilita el botón de separar
			btnSepara.Enabled = false;

		}
	}
}

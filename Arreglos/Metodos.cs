using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arreglos
{
	class Metodos
	{
		//vectores/arreglos
		char[] principal;
		public int[] numeros = new int[60];
		public char[] letras = new char[60];


		//método que recibe la cadena
		public void insertarCadena(object x)
		{
			string dato = x.ToString();
			//se convierte la cadena en un arreglo
			principal = dato.ToArray();
		}

		//contador de las letras
		int contLetra = 0;

		//función que separa las letras de los números
		public void separaCaracter()
		{
			foreach (char c in principal)
			{
				if (!char.IsDigit(c) && c != ' ')
				{
					letras[contLetra] = c;
					contLetra++;
				}
			}
		}


		//contador de los numeros
		int contNumero = 0;

		//función que separa las numeros
		public void separaNumero()
		{
			foreach (char c in principal)
			{
				if (char.IsDigit(c) && c != ' ')
				{
					numeros[contNumero] = int.Parse(c.ToString());
					contNumero++;
				}
			}

		}
	}
}

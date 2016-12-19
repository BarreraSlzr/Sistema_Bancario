//
//  cuentaDeUsuario.cs
//
//  Author:
//       Emmanuel Barrera Salazar <barreraslzr@gmail.com>
//
//  Copyright (c) 2016 Emmanuel Barrera Salazar
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace Sistema_Bancario
{
	public class cuentaDeUsuario
	{
		//Atributos
		protected string _nombreCompleto;
		protected string _contraseña;
		private string direccionCalle;
		private string direccionColonia;
		private string direccionCiudad;
		private string direccionEstado;
		private int direccionCP;
		private int fechaCreacion;
		private int idUSuario;
		protected bool cuentaAhorroCreada;
		protected bool cuentaInversionCreada;
		protected bool cuentaCreditoCreada;
		//Propiedades
		private string NombreCompleto
		{
			get
			{
				return this._nombreCompleto;
			}
			set
			{
				if (value != null || value == "(?<FirstName>[A-Z]\\.?\\w*\\-?[A-Z]?\\w*)\\s?(?<MiddleName>[A-Z]\\w*|[A-Z]?\\.?)\\s?(?<ApellidoPaterno>[A-Z]\\w*\\-?[A-Z]?\\w*)\\s(?<ApellidoMaterno>[A-Z]\\w*\\-?[A-Z]?\\w*)") {
					this._nombreCompleto = value;
				}
			}
		}
		private string Contraseña
		{
			get
			{
				return this._contraseña;
			}
			set
			{
				/*Filtrar resultados
				 * Categorías de caracteres:
				 * 1- Al menos 1 carácter en mayúsculas
				 * 2- Al menos 1 minúscula de caracteres
				 * 3- Al menos 1 carácter numérico
				 * 4- Al menos 1 carácter especial
				 * También hace cumplir un mínimo de 6 a máximo 16 caracteres
				*/
				if (value == "(?=^.{6,16}$)((?=.*\\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*") {
					this._contraseña = value;
				}
			}
		}

		public cuentaDeUsuario ()
		{
			this.cuentaAhorroCreada = false;
			this.cuentaInversionCreada = false;
			this.cuentaCreditoCreada = false;

			asignarNombreCompleto ();
			asignarContraseña ();
			asignarDireccion ();
			crearCuentaBancaria ();
		}
		public void crearCuentaBancaria()
		{
			string opcion;
			bool cuentaCreada;

			do{
				cuentaCreada = false;
				System.Console.WriteLine ("Elige el tipo de cuenta a crear\n" +
					"1. Ahorro\n" +
					"2. Inversion\n" +
					"3. Credito");
				
				switch (opcion) {
				case '1':
					this.cuentaAhorroCreada ? cuentaCreada = true : crearCuentaAhorro ();
					break;
				case '2':
					this.cuentaInversionCreada ? cuentaCreada = true : crearCuentaInversion ();
					break;
				case '3':
					this.cuentaCreditoCreada ? cuentaCreada = true : crearCuentaCredito ();
					break;
				default:
					System.Console.WriteLine ("Opcion incorrecta");
					break;
				}

				if(cuentaCreada){
						System.Console.WriteLine ("Esta cuenta ya ha sido creada");
						cuentaCreada=false;
				}

				System.Console.ReadLine ();

				if(!this.cuentaAhorroCreada && !this.cuentaInversionCreada && !this.cuentaCreditoCreada){
					System.Console.WriteLine("¿Deseas crear una nueva cuenta bancaria? [S | N]");
					System.Console.ReadLine(opcion);
					if(opcion == 'S' || opcion == 's'){
						cuentaCreada=false;
					}
				}
			}while(cuentaCreada);

		}
		private void crearCuentaAhorro(){
			
		}

		private void crearCuentaInversion(){

		}

		private void crearCuentaCredito(){

		}
		private void asignarNombreCompleto()
		{
			string confirmacion;

			confirmacion="";
			do
			{
				System.Console.WriteLine ("Favor de escribir su nombre completo ");
				System.Console.ReadLine (this.NombreCompleto);
				System.Console.Clear ();
				System.Console.WriteLine ("\a*Este nombre no podra ser modificable*\n" +
				"[" + NombreCompleto + "]\n\n ¿Esta seguro que esta escrito correctamente? [S | N] ");
				System.Console.ReadLine (confirmacion);
			} while (confirmacion == 'S' || confirmacion == 's' );
		}

		private void asignarContraseña()
		{
			bool contraseñaCorrecta;
			do
			{
				System.Console.WriteLine ("Favor de escribir su nueva contraseña");
				System.Console.ReadLine (this.Contraseña);
				System.Console.Clear ();
				if(this.Contraseña.Length==0)
				{
					System.Console.WriteLine ("*Contraseña incorrecta*\n" +
						"Favor de revisar que tu contraseña cumpla con los siguientes requerimientos:\n" +
						"* 1. Mínimo de 6 a 16 caracteres máximo\n" +
						"* 2. Al menos 1 carácter especial\n" +
						"* 3. Al menos 1 mayúsculas\n" +
						"* 4. Al menos 1 minúscula\n" +
						"* 5. Al menos 1 numero\n");
					contraseñaCorrecta=false;
				}else{
					System.Console.WriteLine ("Contraseña asignada correctamente");
					contraseñaCorrecta=true;
				}
			}while(contraseñaCorrecta);
		}

		public void asignarDireccion()
		{
			bool direccionCorrecta;

			do {
				System.Console.WriteLine("Favor de escribir la direccion\nCalle: ");
				System.Console.ReadLine(this.direccionCalle);
				System.Console.WriteLine("Colonia: ");
				System.Console.ReadLine(this.direccionColonia);
				System.Console.WriteLine("CP: ");
				System.Console.ReadLine(this.direccionCP);
				System.Console.WriteLine("Ciudad: ");
				System.Console.ReadLine(this.direccionCiudad);
				System.Console.WriteLine("Estado: ");
				System.Console.ReadLine(this.direccionEstado);
			} while(direccionCorrecta);
		}

		// Metodos
		void crearCuentaDeUsuario ();
		void cancelarCuentaDeUsuario ();
		void modificarCuentaDeUsuario ();
		void crearCuentaBancaria ();
		void bloquearCuentaBancaria();
		void cancelarCuentaBancaria();
		}
	}
}


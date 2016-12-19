using System;

namespace Sistema_Bancario
{
	class MainClass
	{
		void ingresarCuentaBancaria ();
		void registrarCuentaBancaria ();
		bool confirmarEleccion (string nombreDeEleccion);

		public static void Main (string[] args)
		{
			int opcion;
			bool salirDelPrograma;
			do {
				Console.WriteLine ("Bienvenido a SCBE\n1- Ingresar\n2- Registrarme\n3- Salir");
				opcion = Console.Read ();
				switch (opcion) {
				case 1:
					ingresarCuentaBancaria();
				case 2:
					registrarCuentaBancaria();
				case 3:
					salirDelPrograma = confirmarEleccion("salir");
				default:
					Console.WriteLine ("Selecciona una opcion correcta");
				}
			} while(salirDelPrograma);
		}
		void registrarCuentaBancaria(){
		}
		bool confirmarEleccion(string nombreDeEleccion){
			Console.WriteLine("¿Estas seguro que deseas {0} ?", nombreDeEleccion);
		}
	}
}

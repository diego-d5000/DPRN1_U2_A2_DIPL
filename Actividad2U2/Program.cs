using System;

namespace Actividad2U2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int citizenAge;
			int licenseFullPrice;
			CLicencia driver = new CLicencia ();


			Console.WriteLine ("========== SISTEMA DE LICENCIAS 2016 ========== \n\n\n");
			Console.WriteLine ("Ingrese sus apellidos: ");
			driver.lastname = Console.ReadLine ();
			Console.WriteLine ("Ingrese su nombre(s): ");
			driver.firstname = Console.ReadLine ();
			Console.WriteLine ("Ingrese su año de nacimiento (ej. 1990): ");
			driver.birthdate = Int32.Parse (Console.ReadLine ());

			citizenAge = DateTime.Now.Year - driver.birthdate;

			if (citizenAge < 16) {
				Console.WriteLine ("--- No es posible realizar el tramite ---");
				return;
			} else if (citizenAge < 18) {
				Console.WriteLine ("--- Se tramitara la licencia para menores de edad ---");
				Console.WriteLine ("--- Debe realizar el examen teórico pràctico ---");
				driver.type = 0;
				driver.validity = 0;
			} else {
				driver.type = getLicenseTypeFromMenu ();
				driver.validity = getLicenseValidityFromMenu ();
			}

			Console.WriteLine ("\n\n\n--- Licencia a tramitar ... ---");
			Console.WriteLine ("Nombre: {0} {1}", driver.firstname, driver.lastname);
			Console.WriteLine ("Tipo de Licencia: {0}", licenseTypeOptionToString(driver.type));
			Console.WriteLine ("Vigencia: {0}", licenseValidityOptionToString(driver.validity));

			licenseFullPrice = getLicenseFullPrice ((driver.type * 10) + driver.validity);

			Console.WriteLine ("\ncosto Licencia ${0}", licenseFullPrice);
			if (citizenAge < 18) {
				Console.WriteLine ("costo examen teorico-practico: $165");
				Console.WriteLine (" -- Costo Total: ${0} --", licenseFullPrice + 165);
			} else {
				Console.WriteLine (" - Costo Total: ${0} -", licenseFullPrice);
			}
		}

		static int getLicenseFullPrice(int option)
		{
			switch(option){
			case 0:
				return 389;
			case 11:
				return 605;
			case 12:
				return 865;
			case 21:
				return 625;
			case 22:
				return 895;
			case 31:
				return 340;
			case 32:
				return 475;
			default:
				return 0;
			}
		}

		static string licenseValidityOptionToString(int option)
		{
			switch (option) {
			case 0:
				return "1 año";
			case 1:
				return "3 años";
			case 2:
				return "5 años";
			default:
				return "No valido";
			}
		}

		static string licenseTypeOptionToString(int option)
		{
			switch (option) {
			case 0:
				return "P - Permiso para menor de edad";
			case 1:
				return "A - Automovilista Particular";
			case 2:
				return "B - Chofer particular";
			case 3:
				return "C - Motociclista";
			default:
				return "No valido";
			}
		}

		static int getLicenseTypeFromMenu()
		{
			int licenseOption;
			do {
				Console.WriteLine ("--- Seleccione el tipo de licencia: ---");
				Console.WriteLine ("1) Automovilista Particular");
				Console.WriteLine ("2) Chofer particular");
				Console.WriteLine ("3) Motociclista \n");
				Console.WriteLine ("Ingrese Opcion: ");

				licenseOption = Byte.Parse (Console.ReadLine ());
			} while (licenseOption < 1 || licenseOption > 3);
			return licenseOption;
		}

		static int getLicenseValidityFromMenu()
		{
			int licenseOption;
			do {
				Console.WriteLine ("--- Seleccione el la vigencia de la licencia: ---");
				Console.WriteLine ("1) 3 años");
				Console.WriteLine ("2) 5 años");
				Console.WriteLine ("Ingrese Opcion: ");

				licenseOption = Byte.Parse (Console.ReadLine ());
			} while (licenseOption < 1 || licenseOption > 2);
			return licenseOption;
		}
	}

	class CLicencia
	{
		public string firstname;
		public string lastname;
		public int birthdate;
		public int type;
		public int validity;
	}
}

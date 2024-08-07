
using Estacion_Meteorologica;
using System.Globalization;
using System.Linq.Expressions;

Calendario calendario1 = new Calendario();
calendario1.CargaTempDias();
calendario1.CalcularPromediosSemanales();
calendario1.FiltrarTempPorUmbral();
int cierre = 0;
do
{
    Console.WriteLine("Elija entre una de las siguientes opciones:");
    Console.WriteLine("1 = Ver la temperatura que hizo en un dia especifico del mes");
    Console.WriteLine("2 = Ver una por una las temperaturas que hizo en mes( en base lo que desea el usuario ) ");
    Console.WriteLine("3 = Ver el promedio de temperaturas del mes");
    Console.WriteLine("4 = Ver el promedio de temperaturas de las semanas");
    Console.WriteLine("5 = Ver la temperatura mas alta y baja que hizo en el mes");
    Console.WriteLine("6 = Ver temperaturas que son superiores a el umbral de 20°");
    int expresion = int.Parse(Console.ReadLine());

    switch (expresion)
    {
        case 1:
            Console.WriteLine("ingrese el numero de la semana (1,2,3,4)");
            int semana = int.Parse(Console.ReadLine());
            semana = semana - 1;
            Console.WriteLine("ingrese el numero del dia de la semana (1,2,3,4,5,6,7)");
            int dia = int.Parse(Console.ReadLine());
            dia = dia - 1;
            Console.WriteLine("la temperatura fue de : " + calendario1.mostrarUnDiaPuntual(semana, dia));
            if (calendario1.mostrarUnDiaPuntual(semana, dia) < 0)
            {
                Console.WriteLine("Hizo mucho frio.");
            }
            // la consig deja en claro que pasa cuando es 0 o 20. Aca aplico la solucion a ese posible error.
            else if (calendario1.mostrarUnDiaPuntual(semana, dia) >= 0 && calendario1.mostrarUnDiaPuntual(semana, dia) <= 20)
            {
                Console.WriteLine("El clima estaba fresco");
            }
            else { Console.WriteLine("Hizo calor afuera"); }
            break;

        case 2:
            calendario1.mostrarDiaPorDia();
            break;

        case 3:
            Console.WriteLine(calendario1.CalcularPromedioMes());
            break;
        case 4:
            for (int i = 0; i < calendario1.tempPromedio.Length; i++)
            {
                Console.WriteLine($"Promedio de la semana {i}: {calendario1.tempPromedio[i]}");
            }
            break;
        case 5:
            {
                calendario1.BuscarTemperaturasExtremas();
                break;
            }
        case 6:
            {
                calendario1.mostrarTodosLosUmbral();
                break;
            }

        default:
            break;
    }
    Console.WriteLine("Desea selecionar otra opcion ? presione 0, si no 1");
    cierre = int.Parse(Console.ReadLine());
} while (cierre == 1);
Console.WriteLine("Muchas gracias");


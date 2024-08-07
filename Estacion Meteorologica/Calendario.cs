using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Estacion_Meteorologica
{
    internal class Calendario
    {
        public float[,] tempDiarias { get; set; } = new float[5, 7];
        public float[] tempPromedio { get; set; } = new float[5];
        public List<float> tempUmbral { get; set; } = new List<float>();
        public void CargaTempDias () // Funcion para añadir temperaturas diarias. 31 dias.
        {
            Random nram = new Random();
            for (int semana = 0; semana < 5; semana++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                    tempDiarias[semana, dia] = (float)nram.NextDouble() * 50 - 10;
                    // cargo temperaturas que van de -10 a 40 grados nomas.
                }
            }
        }

        public void CalcularPromediosSemanales() // Funcion para calccular las temperaturas promedio de cada semana y almacenarlas en una coleccion.
        {
            for (int semana = 0; semana < 5; semana++)
            {
                float sumaTemperaturas = 0;
                for (int dia = 0; dia < 7; dia++)
                {
                    sumaTemperaturas += tempDiarias[semana, dia];
                }
                tempPromedio[semana] = sumaTemperaturas / 7;
            }
        }
        public float CalcularPromedioMes() // Funcion para calcular el promedio de temperatura en el mes.
        {
            float prom = 0;
            int div = 0;
            foreach ( var promedio in tempPromedio)
            {
                div++;
                prom = promedio + prom;
            }
            return prom = prom / div;
        }
        public void FiltrarTempPorUmbral() // Funcion para encontrar todas las temperaturas que son mayores de 20° y las guardamos en una coleccion.
        {
            tempUmbral.Clear();
            // Limpio la lista por si ejecutamos varias veces el programa y bueno. Se limpien los datos en base lo que el usuario quiera.
            for (int semana = 0; semana < 5; semana++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                    if (tempDiarias[semana, dia] > 20)
                    {
                        tempUmbral.Add(tempDiarias[semana, dia]);
                    }
                }
            }
        }
        public float mostrarUnDiaPuntual(int semana, int dia)
        {
            return tempDiarias[semana, dia];
        }
        public void mostrarTODO()
        {
            for (int semana = 0; semana < 5; semana++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                        Console.WriteLine(tempDiarias[semana, dia]);
                }
            }
        }
        public void mostrarDiaPorDia()
        {
            int semana = 0;
            int dia = 0;
            Console.WriteLine($"Temperatura del día {dia}, semana {semana}: {tempDiarias[semana, dia]}");
            do
            {
                Console.WriteLine("Desea ver la temperatura del siguiente día? (Presione 1 para sí, 0 para no)");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    dia++;
                    if (dia > 7)
                    {
                        dia = 0;
                        semana++;
                    }
                }
                else {break;}
                if (semana > 5){break;}

                Console.WriteLine($"Temperatura del día {dia}, semana {semana}: {tempDiarias[semana, dia]}");

                if (dia == 0)
                {
                    Console.WriteLine("Desea ver la temperatura de la siguiente semana? (Presione 1 para sí, 0 para no)");
                    opcion = int.Parse(Console.ReadLine());

                    if (opcion == 0)
                    {
                        break;
                    }
                }
            } while (true);
        }
        public void BuscarTemperaturasExtremas() //Funcion para buscar las temperaturas mas altas y bajas del mes.
        {
            var temperaturas = tempDiarias.Cast<float>();

            float tempMax = temperaturas.Max();
            float tempMin = temperaturas.Min();

            Console.WriteLine($"La temperatura más alta del mes es: {tempMax}");
            Console.WriteLine($"La temperatura más baja del mes es: {tempMin}");
        }
        public void mostrarTodosLosUmbral()
        {
            foreach (var umbral in tempUmbral )
            {
                Console.WriteLine(umbral);
            }
        }
    }
}

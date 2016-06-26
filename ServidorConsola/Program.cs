using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LibreriaSuprocesos;

namespace ServidorConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Contador miContador = new Contador();
            //Thread hilo1 = new Thread(new ThreadStart(miContador.ContarHastaCien));
            //Thread hilo2 = new Thread(new ThreadStart(miContador.ContarDesdeCien));
            //Thread hilo1 = new Thread(new ThreadStart(miContador.ContarHastaCienConflictoMonitor));
            //Thread hilo2 = new Thread(new ThreadStart(miContador.ContarHastaCienConflictoMonitor));
            Thread hilo1 = new Thread(new ThreadStart(miContador.ContarHastaCienSemaforo));
            Thread hilo2 = new Thread(new ThreadStart(miContador.ContarHastaCienSemaforo));
            hilo1.Name = "Hilo +";
            hilo2.Name = "Hilo -";
            //hilo2.Priority = ThreadPriority.Highest;
            hilo1.Start();
            hilo2.Start();
            Console.ReadLine();
            //Fin del ejemplo
        }
    }
}

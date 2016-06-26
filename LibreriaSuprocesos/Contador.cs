using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibreriaSuprocesos
{
    public class Contador
    {
        private int _datoCompartido;
        private Semaphore _semaforoContar;

        public int DatoCompartido
        {
            get { return _datoCompartido; }
            set { _datoCompartido = value; }
        }

        /// <summary>
        /// Inicializa el contador en cero
        /// </summary>
        public Contador()
        {
            _datoCompartido = 0;
            _semaforoContar = new Semaphore(1,1);
        }

        /// <summary>
        /// Inicializa el contador en un numero especifico.
        /// </summary>
        /// <param name="a">Numero para iniciar el contador</param>
        public Contador(int a)
        {
            _datoCompartido = a;
        }

        /// <summary>
        /// Aumenta el dato compartido de 0 a 100
        /// </summary>
        public void ContarHastaCien()
        {
            for (int i = 1; i <= 100; i++)
            {
                _datoCompartido = i;
                Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
            }
        }

        /// <summary>
        /// Aumenta el dato compartido de 0 a 100
        /// </summary>
        public void ContarHastaCienConflictoLock()
        {
            lock (this)
            {
                for (_datoCompartido = 1; _datoCompartido <= 100; _datoCompartido++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
                }
            }
        }

        /// <summary>
        /// Aumenta el dato compartido de 0 a 100
        /// </summary>
        public void ContarHastaCienConflictoMonitor()
        {
            for (_datoCompartido = 1; _datoCompartido <= 100; _datoCompartido++)
            {
                lock (this)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
                    Monitor.Pulse(this);
                    Monitor.Wait(this);
                }
            }
        }

        /// <summary>
        /// Reinicia el dato compartido en 0
        /// </summary>
        public void Reiniciar()
        {
            _datoCompartido = 0;
        }

        /// <summary>
        /// Decrementa el dato compartido desde 100 hasta 0
        /// </summary>
        public void ContarDesdeCien()
        {
            for (int i = 100; i >= 0; i--)
            {
                _datoCompartido = i;
                Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
            }
        }

        /// <summary>
        /// Decrementa el dato compartido desde 100 hasta 0
        /// </summary>
        public void ContarDesdeCienConflictoLock()
        {
            lock (this)
            {
                for (_datoCompartido = 100; _datoCompartido >= 0; _datoCompartido--)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
                }
            }
        }

        /// <summary>
        /// Decrementa el dato compartido desde 100 hasta 0
        /// </summary>
        public void ContarDesdeCienConflictoMonitor()
        {
            for (_datoCompartido = 100; _datoCompartido >= 0; _datoCompartido--)
            {
                lock (this)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
                    Monitor.Pulse(this);
                    Monitor.Wait(this);
                }
            }
        }

        /// <summary>
        /// Aumenta el dato compartido de 0 a 100
        /// </summary>
        public void ContarHastaCienSemaforo()
        {
            _semaforoContar.WaitOne();
            for (int i = 1; i <= 100; i++)
            {
                _datoCompartido = i;
                Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
            }
            _semaforoContar.Release();
        }

        /// <summary>
        /// Decrementa el dato compartido desde 100 hasta 0
        /// </summary>
        public void ContarDesdeCienSemaforo()
        {
            for (int i = 100; i >= 0; i--)
            {
                _datoCompartido = i;
                Console.WriteLine(Thread.CurrentThread.Name + " = " + DatoCompartido);
            }
        }
    }
}

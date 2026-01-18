using System;

class Nodo
{
    public double Dato;
    public Nodo Siguiente;

    public Nodo(double dato)
    {
        Dato = dato;
        Siguiente = null2;
    }
}

class ListaEnlazada
{
    public Nodo Cabeza;

    public void Agregar(double dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (Cabeza == null)
        {
            Cabeza = nuevo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    public void Mostrar()
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + "  ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    public double CalcularPromedio()
    {
        double suma = 0;
        int contador = 0;
        Nodo actual = Cabeza;

        while (actual != null)
        {
            suma += actual.Dato;
            contador++;
            actual = actual.Siguiente;
        }

        return contador > 0 ? suma / contador : 0;
    }
}

class Program
{
    static void Main()
    {
        ListaEnlazada listaPrincipal = new ListaEnlazada();
        ListaEnlazada listaMenoresIguales = new ListaEnlazada();
        ListaEnlazada listaMayores = new ListaEnlazada();

        Console.Write("Ingrese la cantidad de datos: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el dato {i + 1}: ");
            double dato = double.Parse(Console.ReadLine());
            listaPrincipal.Agregar(dato);
        }

        double promedio = listaPrincipal.CalcularPromedio();

        Nodo actual = listaPrincipal.Cabeza;
        while (actual != null)
        {
            if (actual.Dato <= promedio)
                listaMenoresIguales.Agregar(actual.Dato);
            else
                listaMayores.Agregar(actual.Dato);

            actual = actual.Siguiente;
        }

        Console.WriteLine("\n--- RESULTADOS ---");
        Console.WriteLine("a) Datos en la lista principal:");
        listaPrincipal.Mostrar();

        Console.WriteLine($"b) Promedio: {promedio:F2}");

        Console.WriteLine("c) Datos menores o iguales al promedio:");
        listaMenoresIguales.Mostrar();

        Console.WriteLine("d) Datos mayores al promedio:");
        listaMayores.Mostrar();
    }
}
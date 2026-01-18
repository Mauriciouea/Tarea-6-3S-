using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo Cabeza;
    public int Contador;

    // Agregar por el final
    public void AgregarFinal(int dato)
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
        Contador++;
    }

    // Agregar por el inicio
    public void AgregarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = Cabeza;
        Cabeza = nuevo;
        Contador++;
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
}

class Program
{
    static bool EsPrimo(int numero)
    {
        if (numero <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
            if (numero % i == 0)
                return false;
        return true;
    }

    static bool EsArmstrong(int numero)
    {
        int original = numero;
        int suma = 0;
        int digitos = numero.ToString().Length;

        while (numero > 0)
        {
            int digito = numero % 10;
            suma += (int)Math.Pow(digito, digitos);
            numero /= 10;
        }

        return suma == original;
    }

    static void Main()
    {
        ListaEnlazada listaPrimos = new ListaEnlazada();
        ListaEnlazada listaArmstrong = new ListaEnlazada();

        Console.Write("Ingrese la cantidad de números a evaluar: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el número {i + 1}: ");
            int numero = int.Parse(Console.ReadLine());

            if (EsPrimo(numero))
                listaPrimos.AgregarFinal(numero);

            if (EsArmstrong(numero))
                listaArmstrong.AgregarInicio(numero);
        }

        Console.WriteLine("\n--- RESULTADOS ---");

        // a. Número de datos insertados
        Console.WriteLine($"Primos: {listaPrimos.Contador}");
        Console.WriteLine($"Armstrong: {listaArmstrong.Contador}");

        // b. Lista con más elementos
        if (listaPrimos.Contador > listaArmstrong.Contador)
            Console.WriteLine("La lista de números primos contiene más elementos.");
        else if (listaArmstrong.Contador > listaPrimos.Contador)
            Console.WriteLine("La lista de números Armstrong contiene más elementos.");
        else
            Console.WriteLine("Ambas listas contienen la misma cantidad de elementos.");

        // c. Mostrar datos
        Console.WriteLine("\nLista de números primos:");
        listaPrimos.Mostrar();

        Console.WriteLine("Lista de números Armstrong:");
        listaArmstrong.Mostrar();
    }
}

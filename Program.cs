using System;

class RadixSortt
{
    // Función para obtener el dígito en una posición específica
    static int GetDigit(int number, int position)
    {
        return (number / (int)Math.Pow(10, position)) % 10;
    }

    // Función para encontrar el valor máximo en el array
    static int FindMax(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    // Función principal del algoritmo Radix Sort
    static void RadixSort(int[] array)
    {
        // Registra el tiempo de inicio
        DateTime startTime = DateTime.Now;

        // Encuentra el valor máximo en el array
        int max = FindMax(array);

        // Itera sobre cada posición del dígito (de derecha a izquierda)
        for (int position = 0; max / (int)Math.Pow(10, position) > 0; position++)
        {
            // Llama a CountingSort para ordenar en la posición actual
            CountingSort(array, position);

            // Imprime el estado actual del array después de la iteración
            Console.WriteLine($"Iteración {position + 1}: ");
            PrintArray(array);
        }

        // Registra el tiempo de finalización
        DateTime endTime = DateTime.Now;

        // Calcula y muestra el tiempo total de ejecución
        TimeSpan duration = endTime - startTime;
        Console.WriteLine($"Tiempo de ejecución: {duration.TotalMilliseconds} ms");
    }

    // Función de ordenación usando Counting Sort en el dígito específico
    static void CountingSort(int[] array, int position)
    {
        int[] output = new int[array.Length];
        int[] count = new int[10];

        // Inicializa el array de conteo
        for (int i = 0; i < 10; i++)
        {
            count[i] = 0;
        }

        // Cuenta la frecuencia de cada dígito en la posición actual
        for (int i = 0; i < array.Length; i++)
        {
            count[GetDigit(array[i], position)]++;
        }

        // Ajusta el array de conteo para tener las posiciones correctas
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Construye el array de salida usando el array de conteo
        for (int i = array.Length - 1; i >= 0; i--)
        {
            output[count[GetDigit(array[i], position)] - 1] = array[i];
            count[GetDigit(array[i], position)]--;
        }

        // Copia el array de salida al array original
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = output[i];
        }
    }

    // Función para imprimir el estado actual del array
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Programa principal para probar Radix Sort
    static void Main()
    {
        int[] array = { 170, 45, 75, 90, 802, 24, 2, 66 };
        Console.WriteLine("Array original:");
        PrintArray(array);

        // Llama a RadixSort para ordenar el array
        RadixSort(array);

        Console.WriteLine("\nArray ordenado:");
        PrintArray(array);
    }
}

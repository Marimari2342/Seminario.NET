using System.Runtime.InteropServices;

namespace ejercicios;

public class Matriz
{
    public double[,] MiMatriz { get; set; }

    //Constructores

    public Matriz(int filas, int columnas)
    {
        this.MiMatriz = new double[filas, columnas];

    }

    public Matriz(double[,] matriz)
    {
        this.MiMatriz = matriz;
    }

    public void Imprimir()
    {
        for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
        {
            for (int j = 0; j < this.MiMatriz.GetLength(1); j++)
            {
                Console.Write($"{this.MiMatriz[i, j],-5}");
            }
            Console.Write("\n");
        }
    }

    public void Imprimir(string formatString)
    {
        for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
        {
            for (int j = 0; j < this.MiMatriz.GetLength(1); j++)
            {
                Console.Write($"{this.MiMatriz[i, j].ToString(formatString),-5}");
            }
            Console.Write("\n");
        }
    }

    public double[] GetFila(int fila)
    {
        double[] aux = new double[this.MiMatriz.GetLength(1)];
        for (int i = 0; i < this.MiMatriz.GetLength(1); i++)
        {
            aux[i] = this.MiMatriz[fila, i];
        }
        return aux;
    }

    public double[] GetColumna(int columna)
    {
        double[] aux = new double[this.MiMatriz.GetLength(0)];
        for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
        {
            aux[i] = this.MiMatriz[i, columna];
        }
        return aux;
    }

    /*public double[] GetDiagonalPrincipal
    {
        get
        {
            EsCuadrada(this.MiMatriz.GetLength(0), this.MiMatriz.GetLength(1));
            double[] diagPrinc = new double[this.MiMatriz.GetLength(0)];
            for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
            {
                diagPrinc[i] = this.MiMatriz[i, i];
            }
            return diagPrinc;
        }
    }

    public double[] GetDiagonalSecundaria()
    {
        Get{
            EsCuadrada(this.MiMatriz.GetLength(0), this.MiMatriz.GetLength(1));
            double[] diagSec = new double[this.MiMatriz.GetLength(0)];
            for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
            {
                diagSec[i] = this.MiMatriz[i, this.MiMatriz.GetLength(0) - i - 1];
            }
            return diagSec;
        }
    }*/

    public double[][] GetArregloDeArreglo()
    {
        int a = this.MiMatriz.GetLength(0);
        int b = this.MiMatriz.GetLength(1);
        double[][] arreglo = new double[b][];
        for (int i = 0; i < a; i++)
        {
            arreglo[i] = new double[a];
            for (int j = 0; j < b; j++)
            {
                arreglo[i][j] = this.MiMatriz[i, j];
            }
        }
        return arreglo;
    }

    public void Sumarle(Matriz m)
    {
        if (this.MiMatriz.GetLength(0) == m.MiMatriz.GetLength(0) && this.MiMatriz.GetLength(1) == m.MiMatriz.GetLength(1))
        {
            for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
            {
                for (int j = 0; j < this.MiMatriz.GetLength(1); j++)
                {
                    this.MiMatriz[i, j] = this.MiMatriz[i, j] + m.MiMatriz[i, j];
                }
            }

        }
        else
        {
            Console.WriteLine("Sólo se pueden sumar matrices del mismo tamaño");
        }
    }

    public void restarle(Matriz m)
    {
        if (this.MiMatriz.GetLength(0) == m.MiMatriz.GetLength(0) && this.MiMatriz.GetLength(1) == m.MiMatriz.GetLength(1))
        {
            for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
            {
                for (int j = 0; j < this.MiMatriz.GetLength(1); j++)
                {
                    this.MiMatriz[i, j] = this.MiMatriz[i, j] - m.MiMatriz[i, j];
                }
            }

        }
        else
        {
            Console.WriteLine("Sólo se pueden restar matrices del mismo tamaño");
        }
    }

    public void multiplicarPor(Matriz m)
    {
        if (this.MiMatriz.GetLength(1) == m.MiMatriz.GetLength(0))
        {
            double[,] mul = new double[this.MiMatriz.GetLength(0), m.MiMatriz.GetLength(1)];
            double suma;
            for (int i = 0; i < this.MiMatriz.GetLength(0); i++)
            {
                for (int j = 0; j < m.MiMatriz.GetLength(1); j++)
                {
                    suma = 0;
                    for (int k = 0; k < m.MiMatriz.GetLength(0); k++)
                    {
                        suma += this.MiMatriz[i, k] * m.MiMatriz[k, j];
                    }
                    mul[i, j] = suma;
                }
            }
        }
        else
        {
            Console.WriteLine("La cantidad de columnas de la matriz 1 es distinto a la cantidad de filas de la matriz 2");
        }
    }


    //Metodo para ver si la matriz es cuadrada (cuando busco diag princ o secund).
    static void EsCuadrada(int f, int c)
    {
        if (f != c)
        {
            throw new Exception("La matriz NO es cuadrada");
        }
        return;
    }
}
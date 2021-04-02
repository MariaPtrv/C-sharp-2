using System;
using System.Collections.Generic;




//


//public static Matrix GetUnity(int Size) {  }
//public static Matrix GetEmpty(int Size) { }

//public override string ToString() { } //матрица в строку


public class Matrix {
    private int Rows;
    private int Cols;
    private double[,] data;
    static List<string> allm = new List<string>();
    public Matrix(int nRows, int nCols)
    {
    this.Rows = nRows;
    this.Cols = nCols;
    data = new double[this.Cols , this.Rows ];
    }
    public Matrix(double[,] initData) {
        this.data = initData;
    }

    public double this[int i, int j]
    {
        get
        {
            return (double)data[i, j];
        }
        set
        {
            data[i, j] = value;
        }
    }

    public int rows { get { return Rows; } }
    public int columns { get { return Cols; } }
    public string ToString(Matrix m1)
    {
        int i; int j;
        int n = m1.columns;
        int m = m1.rows;
        string str = "";
        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                str = str + ' ' + Convert.ToString(m1[i, j]);
            }
            str = str + ',';
        }
        str = str.TrimEnd(',');
        return str;
    }
    public void ReadMatrix()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Console.Write(data[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    public void WriteMatrix(int n, int m)
    {     
        Console.WriteLine("Введите матрицу, разделяя элементы пробелами, а строки запятой:");
        int num = 0; bool iflet = false;
        string readme = Console.ReadLine();
        int i; int count = 0;
        char[] separators = new char[] { ' ', ',' };        
        string[] subs = readme.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (i =0; i < readme.Length; i++)
        {
            if (readme[i] == ',') count++;
        }
        if (m == count + 1 && n == subs.Length / (count + 1)) iflet = false;
        else iflet = true;
        do
        {

            if (iflet != false) 
            { 
                Console.WriteLine("Ошибка ввода. Введите матрицу, разделяя элементы пробелами, а строки запятой:"); 
                readme = Console.ReadLine();
                subs = readme.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                count = 0;
                for (i = 0; i < readme.Length; i++)
                {
                    if (readme[i] == ',') count++;
                }
                if (m == count + 1 && n == subs.Length / (count + 1)) iflet = false;
                else iflet = true;
            }
            
            if (iflet == false)
                for (i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Double.TryParse(subs[num], out double whatnum) && (!String.IsNullOrEmpty(subs[num])))
                    {
                        data[i, j] = Double.Parse(subs[num]);
                        num++; 
                    }
                    else
                    {
                        Console.WriteLine("Некорректные значения! Повторить ввод!");
                        iflet = true; break;

                    }
                }
                if (iflet) { i = 0; break; }
            }
            if (i == n) iflet = false;
        } while (iflet);
        allm.Add(readme);
    }
    public double Trace()
    {
        int n = this.columns;
        int m = this.rows;
        double summ = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i ==j  ) summ = summ + this.data[i,j];
            }
        }
        return summ;
    }

    //размер квадратной матрицы
    public int Size() { return rows; }
    //Является ли матрица квадратной
    public bool IsSquared() { if (rows == columns) return true; else return false; }
    //Является ли матрица нулевой
    public bool IsEmpty() 
    {
        int n = this.columns;
        int m = this.rows;
        int mnotNull = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (this.data[j,i] != 0) mnotNull++;             
            }
        }

        if (mnotNull == 0) return true;
        else return false;
    }
    //Является ли матрица единичной
    public bool IsUnity() {
        int n = this.columns;
        int m = this.rows;
        int mUnity = 0;
        for (int i = 0; i < n; i++)
        {         
                if (this.data[i, i] == 1) mUnity++;         
        }

        if (mUnity == n && n==m) return true;
        else return false;
    }
    //Является ли матрица диагональной
    public bool IsDiagonal() 
    {
        int n = this.columns;
        int m = this.rows;
        int mDiagonal = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (this.data[j, i] != 0 && i!=j) mDiagonal++;
        
            }
        }

        if (mDiagonal == 0 && m==n) return true;
        else return false;
    }
    //Является ли матрица симметричной
    public bool IsSymmetric() {
        int n = this.columns;
        int m = this.rows;
        int mSymm = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (this.data[i, j] == this.data[j, i] && i != j) mSymm++;
            }
        }
        if (mSymm == m*n - n && m == n) return true;
        else return false;
    }

    public void Transpose(Matrix m1)
    {
        int n = m1.columns;
        int m = m1.rows;
    

        for (int j= 0; j < m; j++)
        {
            for (int i = 0; i < n;i++)
            {       
                Console.Write(m1.data[i, j] + " \t ");
            }
            Console.WriteLine();
        }

    }

    public void makenewMatrix(int n, int m, string str)
    {
 
        int num = 0;
        int i;
        char[] separators = new char[] { ' ', ',' };
        string[] subs = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    
            for (i = 0; i < m; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    if (Double.TryParse(subs[num], out double whatnum))
                    {
                        data[i, j] = Double.Parse(subs[num]);
                        num++;
                    }
                }                
             }
            Console.WriteLine("\nЧисло столбцов: {0}", rows);
            Console.WriteLine("Число строк: {0}", columns);
            if (this.IsSquared()) Console.WriteLine("Тип матрицы: квадратная\nРазмер: {0}", this.Size());
            else Console.WriteLine("Тип матрицы: прямоугольная");
            if (this.IsEmpty()) Console.WriteLine("Матрица нулевая");
            else Console.WriteLine("Матрица ненулевая");
        if (this.IsSquared())
        {
            if (this.IsUnity()) Console.WriteLine("Матрица является единичной");
            else Console.WriteLine("Матрица не является единичной");
            if (this.IsDiagonal()) Console.WriteLine("Матрица является диагональной");
            else Console.WriteLine("Матрица не является диагональной");
            if (this.IsSymmetric()) Console.WriteLine("Матрица является симметричной");
            else Console.WriteLine("Матрица не является симметричной");
            Console.WriteLine("След матрицы: {0}", this.Trace());
        }
        else
        {
            Console.WriteLine("Матрица не является единичной");
            Console.WriteLine("Матрица не является диагональной");
            Console.WriteLine("Матрица не является симметричной");
            Console.WriteLine("След матрицы: ----");
        }
            
            Console.WriteLine("Транспонированная матрица: \n");
            Transpose(this);
        
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        int i; int j;
        int n = m1.rows;
        int m = m1.columns;
        Matrix m3 = new Matrix(n, m);
        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                m3[i, j] = m1[i, j] + m2[i, j];
            }
        }
        //добавить матрицу в список полученных
        return m3;
    }

    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        int i; int j;
        int n = m1.rows;
        int m = m1.columns;
        Matrix m3 = new Matrix(n, m);
        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                m3[i, j] = m1[i, j] - m2[i, j];
            }
        }
        //добавить матрицу в список полученных
        return m3;
    }

    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        int n = m1.rows;
        int m = m1.columns;
        Matrix m3 = new Matrix(m2.rows,  m1.columns);
        for (int i = 0; i < m1.columns; i++)
            for (int j = 0; j < m2.rows; j++)
                for (int k = 0; k < n; k++)
                   m3[i, j] += m1[i, k] * m2[k, j];
        //добавить матрицу в список полученных
        return m3;
    }

    public static Matrix operator *(Matrix m1, double d)
    {
        int i; int j;
        int n = m1.rows;
        int m = m1.columns;
        Matrix m3 = new Matrix(n, m);
        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                m3[i, j] = m1[i, j] * d;
            }
        }
        return m3;
    }
    public static void readallmatrix()
    {
        string temp = "";
        char[] separators = new char[] { ' ', ','};
        string[] subs; int count = 0;int commas = 0; int n=0; int m=0;
        for (var index = 0; index < allm.Count; index++)
        {

            Console.WriteLine("\n-------------------------------\nМатрица №{0}", index+1);
            temp =  allm[index];
            commas = 0; count = 0;
            subs = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            while (count < temp.Length) { if (temp[count] == ',') commas++; count++; }
            count = 0;
            for (int t = 0; t < subs.Length; t++)
            {
                if (count == subs.Length / (commas + 1)-1)
                {
                    Console.Write(subs[t] + "\n");
                    count = 0;

                }
                else { Console.Write(subs[t] + "\t"); count++;}
            }
            n = subs.Length / (commas + 1);
            m = commas + 1;
            Matrix curMatrix = new Matrix(n, m);
            curMatrix.makenewMatrix(n, m, allm[index]);
        }

    }


    public static Matrix Parse(string s) {

        char[] separators = new char[] { ' ', ',' }; int n; int m;
        int commas = 0; int count = 0; string[] subs;
        subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        while (count < s.Length) { if (s[count] == ',') commas++; count++; }
        count = 0;
        for (int t = 0; t < subs.Length; t++)
        {
            if (count == subs.Length / (commas + 1) - 1)
            {
                count = 0;
            }
            else
            { 
                count++;
            }
        }
        n = subs.Length / (commas + 1);
        m = commas + 1;
        Matrix m1 = new Matrix(n, m);  // выделяем новую матрицу
        int num = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (Double.TryParse(subs[num], out double whatnum))
                {
                    m1.data[i, j] = Double.Parse(subs[num]);
                    num++;
                }
            }
        }
        return m1;
    }
    public static bool TryParse(string s, out Matrix matr) 
    {
        char[] separators = new char[] { ' ', ',' }; int n; int m;
        int commas = 0; int count = 0; string[] subs;
        subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        while (count < s.Length) { if (s[count] == ',') commas++; count++; }
        count = 0;
        for (int t = 0; t < subs.Length; t++)
        {
            if (count == subs.Length / (commas + 1) - 1)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }
        n = subs.Length / (commas + 1);
        m = commas + 1; bool result;
        Matrix m1 = new Matrix(n, m);  // выделяем новую матрицу
        int num = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (Double.TryParse(subs[num], out double whatnum))
                {
                    try
                    {
                       result = Double.TryParse(subs[num], out m1.data[i, j]);
                       num++;
                    }
                    catch (FormatException)
                    {
                        matr = null;
                        return false;
                    }
                }
            }
        }
        matr = m1;
        return true;
    }
    public static void matrixForOperation(int operation)
    // метод для выделения матриц для три возможных действия над 2 матрицами: 1 сложение, 2 вычитание, 3 перемножение 
    //4 умножение на число
    {
        string temp = "";
        char[] separators = new char[] { ' ', ',' };
        string[] subs; int count = 0; int commas = 0; int n = 0; int m = 0; var index = 0;
        for (index = 0; index < allm.Count; index++)
        {

            Console.WriteLine("\n-------------------------------\nМатрица №{0}", index + 1);
            temp = allm[index];
            commas = 0; count = 0;
            subs = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            while (count < temp.Length) { if (temp[count] == ',') commas++; count++; }
            count = 0;
            for (int t = 0; t < subs.Length; t++)
            {
                if (count == subs.Length / (commas + 1) - 1)
                {
                    Console.Write(subs[t] + "\n");
                    count = 0;

                }
                else
                {
                    Console.Write(subs[t] + "\t");
                    count++;
                }
            }
            n = subs.Length / (commas + 1);
            m = commas + 1;
        }
        int num1; int num2;
        bool flag = true;

        if (operation!= 4)
        {
            Console.WriteLine("Введите номер первой матрицы");
            do
            {
                num1 = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                if (num1 > 0 && num1 < allm.Count + 1) { flag = false; Console.WriteLine(num1); }
                else Console.WriteLine("Некорректный ввод! Повторите попытку");

            }
            while (flag);

            Console.WriteLine("Введите номер второй матрицы");
            flag = true;
            do
            {
                num2 = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                if (num2 > 0 && num2 < allm.Count + 1) { flag = false; Console.WriteLine(num2); }
                else Console.WriteLine("Некорректный ввод! Повторите попытку");

            }
            while (flag);

            //вытащить из массива первую матрицу  - вычислить м и н, разбить на символы строку
            index = num1 - 1;
            temp = allm[index];
            commas = 0; count = 0;
            subs = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            while (count < temp.Length) { if (temp[count] == ',') commas++; count++; }
            count = 0;
            for (int t = 0; t < subs.Length; t++)
            {
                if (count == subs.Length / (commas + 1) - 1)
                {
                    // Console.Write(subs[t] + "\n");
                    count = 0;

                }
                else
                {
                    //Console.Write(subs[t] + "\t"); 
                    count++;
                }
            }
            n = subs.Length / (commas + 1);
            m = commas + 1;
            Matrix m1 = new Matrix(n, m);  // выделяем новую матрицу
            int num = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Int32.TryParse(subs[num], out int whatnum))
                    {
                        m1.data[i, j] = Double.Parse(subs[num]);
                        num++;
                    }
                }
            }

            //вытащить из массива вторую матрицу  - вычислить м и н, разбить на символы строку
            index = num2 - 1;
            temp = allm[index];
            commas = 0; count = 0;
            subs = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            while (count < temp.Length) { if (temp[count] == ',') commas++; count++; }
            count = 0;
            for (int t = 0; t < subs.Length; t++)
            {
                if (count == subs.Length / (commas + 1) - 1)
                {
                    //Console.Write(subs[t] + "\n");
                    count = 0;

                }
                else
                { //Console.Write(subs[t] + "\t"); 
                    count++;
                }
            }
            n = subs.Length / (commas + 1);
            m = commas + 1;
            Matrix m2 = new Matrix(n, m);  // выделяем новую матрицу
            num = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Double.TryParse(subs[num], out double whatnum))
                    {
                        m2.data[i, j] = Double.Parse(subs[num]);

                        num++;
                    }
                }
            }

            switch (operation)
            {
                case 1:
                    if (m2.rows == m1.rows && m2.columns == m1.columns)
                    {
                        Matrix m3 = new Matrix(m1.data);
                        m3 = m1 + m2;
                        Console.WriteLine("\n-------------------------------\nОтвет\n");
                        for (int i = 0; i < m; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write(m3.data[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine("Операция невозможна!");
                    break;
                case 2:
                    if (m2.rows == m1.rows && m2.columns == m1.columns)
                    {
                        Matrix m3 = new Matrix(m1.data);
                        m3 = m1 - m2;
                        Console.WriteLine("\n-------------------------------\nОтвет\n");
                        for (int i = 0; i < m; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write(m3.data[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine("Операция невозможна!");
                    break;
                case 3:
                    if (m1.rows == m2.columns)
                    {
                        Matrix m3 = new Matrix(m1.data);
                        m3 = m1 * m2;
                        Console.WriteLine("\n-------------------------------\nОтвет\n");
                        for (int i = 0; i < m1.columns; i++)
                        {
                            for (int j = 0; j < m2.rows; j++)
                            {
                                Console.Write(m3.data[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine("Операция невозможна!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Введите номер матрицы");
            do
            {
                num1 = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                if (num1 > 0 && num1 < allm.Count + 1) { flag = false; Console.WriteLine(num1); }
                else Console.WriteLine("Некорректный ввод! Повторите попытку");

            }
            while (flag);

            //вытащить из массива первую матрицу  - вычислить м и н, разбить на символы строку
            index = num1 - 1;
            temp = allm[index];
            commas = 0; count = 0;
            subs = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            while (count < temp.Length) { if (temp[count] == ',') commas++; count++; }
            count = 0;
            for (int t = 0; t < subs.Length; t++)
            {
                if (count == subs.Length / (commas + 1) - 1)
                {
                    // Console.Write(subs[t] + "\n");
                    count = 0;

                }
                else
                {
                    //Console.Write(subs[t] + "\t"); 
                    count++;
                }
            }
            n = subs.Length / (commas + 1);
            m = commas + 1;
            Matrix m1 = new Matrix(n, m);  // выделяем новую матрицу
            int num = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Double.TryParse(subs[num], out double whatnum))
                    {
                        m1.data[i, j] = Double.Parse(subs[num]);
                        num++;
                    }
                }
            }

            
            bool fl1 = true; int way = 0; int dont = 0;
            double d; string may="";
            while (fl1)
            {
                Console.WriteLine("Введите число");
                may = Console.ReadLine();
                while (way < may.Length)
                {
                    if (Char.IsNumber(may[way]) || may[way] == '.' || may[way] == '-') way++;
                    else dont++;
                }
                if (dont!=0) Console.WriteLine("Введите корректное значение!");
                else fl1 = false;
            }
            d = Convert.ToDouble(may);
            Matrix m3 = new Matrix(m1.data);
            m3 = (m1*d);
            Console.WriteLine("\n-------------------------------\nОтвет\n");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m3.data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    public static Matrix GetUnity(int Size)
    {
        string str = "";
        Matrix curMatrix = new Matrix(Size, Size);
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
            {
                if (i == j) curMatrix[i, j] = 1;
                else curMatrix[i, j] = 0;
            }
        str= curMatrix.ToString(curMatrix);
        allm.Add(str);
        return curMatrix;
    }
    public static Matrix GetEmpty(int Size)
    {
        string str = "";
        Matrix curMatrix = new Matrix(Size, Size);
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
            {
                curMatrix[i, j] = 0;
            }
        str = curMatrix.ToString(curMatrix);
        allm.Add(str);
        return curMatrix;
    }
}

namespace Lab2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool fl = true; int n = 0; int m = 0; bool fl1 = true; bool fl2 = true;
            string info1 = "\nРабота с матрицами\n-------------------------------\n1 – Ввод матрицы\n2 - Операции\n0 - Выход\n-------------------------------\n";
            string infoact = "\nОперации\n-------------------------------\n1-Свойства матрицы\n2-Сложение матриц\n3-Вычитание матриц\n4-Умножение матрицы на число\n5-Перемножение матриц\n6-Сгенерировать единичную матрицу\n7-Сгенерировать нулевую матрицу\n0-Вернуться назад";
            while (fl)
            {
                Console.WriteLine(info1);
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '0':
                        fl = false;
                        break;
                    case '1':
                        
                        string infoRows = "Введите число строк\n";
                        string infoColumns = "Введите число столбцов\n";
                        fl1 = true;
                        while (fl1)
                        {
                            Console.WriteLine(infoRows);
                            m  = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                            
                            if (m<1) Console.WriteLine("Введите корректное значение!");
                            else fl1 = false;
                        }
                        Console.WriteLine(m);
                        fl1 = true;
                        while (fl1)
                        {
                            Console.WriteLine(infoColumns);
                            n = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                            if (n < 1) Console.WriteLine("Введите корректное значение!");
                            else fl1 = false; 
                        }
                        Console.WriteLine(n);
                        Matrix curMatrix = new Matrix(n, m);
                        curMatrix.WriteMatrix(n,m);
                        Console.WriteLine("Введенная матрица:");
                        curMatrix.ReadMatrix();
                        break;
                    case '2':
                        {
                            
                            fl2 = true;
                            while (fl2)
                            {
                                Console.WriteLine(infoact);
                                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                                {
                                case '0': fl2 = false;  break;
                                case '1':Matrix.readallmatrix();break;
                                case '2':Matrix.matrixForOperation(1); break;
                                case '3': Matrix.matrixForOperation(2); break;
                                case '4': Matrix.matrixForOperation(4); break;
                                case '5': Matrix.matrixForOperation(3); break;
                                case '6':
                                        bool fl3 = true; int size = 0; ;
                                        while (fl3)
                                        {
                                            Console.WriteLine("Введите размер единичной матрицы:");
                                            
                                            size = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                                            Console.WriteLine(size);
                                            if (size < 1) Console.WriteLine("Введите корректное значение!");
                                            else fl3 = false;
                                        }
                                        curMatrix = Matrix.GetUnity(size); break;
                                case '7':
                                        bool fl4 = true; int size1 = 0; ;
                                        while (fl4)
                                        {
                                            Console.WriteLine("Введите размер нулевой матрицы:");
                                            size1 = (int)Char.GetNumericValue(Console.ReadKey(true).KeyChar);
                                            Console.WriteLine(size1);
                                            if (size1 < 1) Console.WriteLine("Введите корректное значение!");
                                            else fl4 = false;
                                        }
                                        curMatrix = Matrix.GetEmpty(size1);  break;
                                }
                            }
                        }
                        break;
                 
                    default: break;
                }
            }
        }
    }
}

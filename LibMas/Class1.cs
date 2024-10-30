namespace LibMas
{
    public class RandomMas
    {
        public static void RndMas(out int[] mas, int column, int randMax)//Метод, при котором Выходом результат является массив mas,
                                                                         //а переменная column является длинной массива и переменная randMax это максимальное рандомное число для массива
        {
            Random rnd; rnd = new Random();//Рандом
            mas = new int[column]; //Присваеваем длину массива(column)
            for (int i = 0; i < column; i++)// при котором Будет заполнятся каждая ячейка массива
            {
                mas[i] = rnd.Next(randMax);//Присваеваем к одной ячейке рандомное число которое указали в переменной randMax
            }
        }
    }
}
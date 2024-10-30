namespace Lib_4
{
    public class RaschetMas
    {
        public static void RasMas(out string plusKorenMas, int[] mas)//Метод, korenMas используется для Вывода результата,
                                                              //а mas используется для Ввода массива для дальнейшего расчета
        {
            plusKorenMas = "";//Присваеваем значение ""
            double sqrtMas = 0;//Присваевается значение 0
            for (int i = 0; i < mas.Length; i++)//Цикл для длины массива
            {
                sqrtMas = Convert.ToDouble(mas[i]);//Одно из значений массива присваевается к переменно korenMas
                if (mas[i] > 0)//Условие, если одно из значений массива будет больше 0, то производится дальнейшие действия
                {
                    double korenMas = Math.Sqrt(sqrtMas);//Возводит в корень korenMas
                    plusKorenMas += korenMas + "\n";//Присваеваем ,складываем и добавляем запятую к переменной plusKorenMas 
                }
            }
        }
    }
}

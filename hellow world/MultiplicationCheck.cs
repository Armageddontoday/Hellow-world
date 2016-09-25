using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class MultiplicationCheck
    {
        /// <summary>
        ///  попытка преобразовать введённую строку в целое число и, в случае успеха, проверить верен ли ответ
        /// </summary>
        /// <param name="input">введённая пользователем строка</param>
        public void AnswerCheck(string userInput, int num1, int num2)
        {
            
            UIHelper uiHelper = new UIHelper();
            try 
            {
                int numResult = int.Parse(userInput);
                if (numResult == num1 * num2)//правильный ответ?
                    uiHelper.ShowCorrectAnswer(num1, num2, numResult);
                else
                    uiHelper.ShowWrongAnswer(num1, num2, numResult);

            }
            catch //при провале преобразования(введено некорректное число\ничего не введено\символы) сообщение об ошибке
            {
                uiHelper.ShowErrorMessage();
            }
            finally
            { }

            
        }
    }
}

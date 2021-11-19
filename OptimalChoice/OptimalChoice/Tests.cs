using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace OptimalChoice_
{
    public class Tests
    {
        private List<Question> questions;

        public Tests()
        {
            Questions = new List<Question>();
            // открытие документа с указанным именем и считывание данных
            string fileQuestions = "вопросы.txt";
            string fileAnswers = "ответы.txt";
            var inFileQ = new StreamReader(fileQuestions);
            var inFileA = new StreamReader(fileAnswers);
            string allQ = inFileQ.ReadToEnd(); //считываем данные
            string allA = inFileA.ReadToEnd(); //считываем данные

            inFileQ.Close();
            inFileA.Close();

            string[] strArrQ = allQ.Split('\n');
            string[] strArrA = allA.Split('\n');
            List<string> temp = new List<string>();
            for (int i = 0,j=0; i < strArrQ.Length; i++,j+=4)
            {
                temp.Clear();
                temp.Add(strArrA[j]);
                temp.Add(strArrA[j+1]);
                temp.Add(strArrA[j+2]);
                temp.Add(strArrA[j+3]);
                Questions.Add(new Question(strArrQ[i],temp));
            }
        }

        public List<Question> Questions { get => questions; set => questions = value; }
    }
}

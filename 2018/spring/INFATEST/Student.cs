﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFATEST
{
    public class Student
    {
        public int TrueAsks;
        public string SecondName;
        public Student(int trueAsk, string name)
        {
            TrueAsks = trueAsk;
            SecondName = name;
        }
        public Student()//пустой конструктор для рефлексии
        {
            TrueAsks = 0;
            SecondName = null;
        }
        public double Calculate(int a, int b) => a * b;

        public double Divide(int a, int b) => (double)a / b;
    }
}
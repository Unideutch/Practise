using System;

namespace hello
{
    internal class Person
    {
        // private виден только внутри класса
        private string _name;


        //свойство - аналог метода
        public string Name
        {
            get
            {
                return _name;
            }
            
            //value - переданный параметр
            set
            {
                _name = value;
            }
        }

        public Person(string name)
        {
            _name = name;
        }

    }
}

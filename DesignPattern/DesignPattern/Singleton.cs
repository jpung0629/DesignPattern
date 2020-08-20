using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Singleton
    {
        private static Singleton instance;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public static Singleton GetInstance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}

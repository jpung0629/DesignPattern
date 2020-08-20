using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Singleton
    {
        private static Singleton instance;

        private string name;

        public string Name { get => name; set => name = value; }

        protected Singleton() { }

        public static Singleton GetInstance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    class Singleton2
    {
        private static List<KeyValuePair<string, Singleton2>> registry = new List<KeyValuePair<string, Singleton2>>();

        private static Singleton2 instance;

        protected Singleton2()
        {
            Register("SINGLETON", this);
        }

        protected static Singleton2 LookUp(string key)
        {
            KeyValuePair<string, Singleton2> pair = registry.Find(instance => instance.Key == key);
            return pair.Value;
        }

        public static Singleton2 Instance()
        {
            if(instance == null)
            {
                const string singletonName = "SINGLETON";

                instance = LookUp(singletonName);
            }
            return instance;
        }

        public static void Register(string key, Singleton2 instance)
        {
            registry.Add(new KeyValuePair<string, Singleton2>(key, instance));
        }
    }

    class SubSingleton : Singleton2
    {
        private static SubSingleton instance;
        protected SubSingleton()
        {
            Singleton2.Register("SUBSINGLETON", this);
        }

        public static Singleton2 GetInstance()
        {
            return LookUp("SUBSINGLETON");
        }
    }
}

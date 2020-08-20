using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    interface IButton
    {
        void Paint();
    }
    interface IGUIFactory
    { 
        IButton CreateButton();
    }

    class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
    }

    class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }
    }
    class WinButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("WinButton::Paint()");
        }
    }

    class MacOSButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("MacOSButton::Paint()");
        }
    }
    class AbstractFactory
    {
    }
}

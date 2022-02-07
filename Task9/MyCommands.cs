using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task9
{
    class MyCommands
    {
        public static RoutedCommand Exit { get; set; } //объявляем свойства типа RoutedCommand(команда)
        //в статическом конструкторе класса необходимо инициализировать эту команду
        static MyCommands()
        {
            //создаем коллекцию -перечень жестов
            InputGestureCollection inputs = new InputGestureCollection();
            //добавляем в нее методом Add новое сочетание клавиш Ctrl + T
            //KeyGesture - конструктор, ао = ргументами передаем клавиши
            inputs.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            //для инициализации будем использовать конструктор класса  RoutedCommand
            //с параметрами, первый аргумент -имя команды, дальше тип собственника(класс MyCommands)
            //третий аргумент -перечень жестов(горячие клавиши) - коллекция
            Exit = new RoutedCommand("Exit", typeof(MyCommands), inputs);
        }
    }
}

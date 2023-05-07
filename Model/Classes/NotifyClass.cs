using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Model.Classes
{
    public class NotifyClass : INotifyPropertyChanged  //Наследуемся от класса который позволяет отслеживать изменения свойтв 
    {
        public event PropertyChangedEventHandler PropertyChanged; //Создание переменной от наследуемого класса которая хранит изменение свойств

        public void OnPropertyChanged([CallerMemberName] string prop = "") //Метод регистрирует изменение с сохранением изменений в параметр prop который используется в непосредственном изменении  
        {
            if (PropertyChanged != null) //проверка непосредственного изменения 
                PropertyChanged(this, new PropertyChangedEventArgs(prop)); //в случае изменения применяет изменения хранящее в prop
        }

    }
}

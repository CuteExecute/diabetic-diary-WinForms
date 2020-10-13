using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetControl
{
    // Паттерн стратегия для замены вида редактирования в рантайме (новая запись/редактирование)
    interface IData
    {
        void Edit(DateTime thisDateTime, float result);
    }

    class DataEdit
    {
        // Поля которые будут содержать данные нужные для ввода
        DateTime thisDateTime;
        float result;

        // Конструктор заающий поля данных для ввода
        public DataEdit(DateTime thisDateTime, float result)
        {
            this.thisDateTime = thisDateTime;
            this.result = result;
        }

        // Универсальный метод который принимает необходимый класс реализующий интерфейс IData
        public void DoEdit(IData data)
        {
            if(data != null)
            {
                data.Edit(thisDateTime, result);
            }
        }
    }

    class NewData : IData
    { 
        public void Edit(DateTime thisDateTime, float result)
        {
            // Записываем данные
        }
    }

    class EditData : IData
    {
        public void Edit(DateTime thisDateTime, float result)
        {
            // Заменяем данные
        }
    }
}

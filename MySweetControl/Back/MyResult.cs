using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetControl.Main_classes
{
    // Небольшой класс представляющий результаты, и объединяющий их в ркзультирующую строку
    class MyResult
    {
        string result;
        string time;
        string date;

        public MyResult(string result, string time, string date)
        {
            this.result = result;
            this.time = time;
            this.date = date;
        }

        public string CreateResult()
        {
            string res = $"{result}/{time}/{date}";
            return res;
        }
    }
}

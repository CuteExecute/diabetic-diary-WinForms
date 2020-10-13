using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetControl.Main_classes
{
    class DataWorker
    {
        public static void NewResult(string result, string time, string date)
        {
            // Если рузультат пустой выбрасываю исключение
            if (result == null || result == "")
                throw new ArgumentNullException();

            // Экземпляр текущих результатов
            MyResult res = new MyResult(result, time, date);

            List<string> writeList = new List<string>();
            writeList.Add(res.CreateResult());

            // Запись в файл
            FileWorker.WriteResult(System.IO.FileMode.Append, writeList);
        }

        public static bool CheckData(string data)
        {
            string[] dataArr = File.ReadAllLines("dataResult.txt");

            IEnumerable<string> query = from str in dataArr
                                        where str.Contains($"{data}") // DateTime.Now.ToShortDateString()
                                        select str;

            if (query.Count() == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}

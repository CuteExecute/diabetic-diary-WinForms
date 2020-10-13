using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySweetControl
{
    class FileWorker
    {
        // Функция записи в файл
        public static void WriteResult(FileMode flMode, List<string> data)
        {
            // Создание файла хранения результатов, если такого еще нету
            if (!File.Exists("dataResult.txt"))
                File.Create("dataResult.txt");

            // Запись в файл
            using (FileStream fStream = new FileStream("dataResult.txt", flMode)) // FileMode.Open/Append
            {
                for (int i  = 0; i < data.Count; i++)
                {
                    byte[] byteArr = Encoding.Default.GetBytes(data[i] + "\n");
                    fStream.Write(byteArr, 0, byteArr.Length);
                }
            }
        }

        // Функция удаления всех указанных строк в файле
        public static void DeleteResult(string removable)
        {
            string[] dataArr = File.ReadAllLines("dataResult.txt");

            // Выборка с "удаленными" элементами
            IEnumerable<string> query = from str in dataArr
                        where str != removable
                        select str;

            // Новый список 
            List<string> result = new List<string>();
            foreach (var str in query)
            {
                result.Add(str);
            }

            // Перезапись файла
            WriteResult(FileMode.Truncate, result);
        }

        // Функция замены указанной строки на новую
        public static void EditResult(string EditString, string NewString)
        {
            string[] dataArr = File.ReadAllLines("dataResult.txt");

            for (int i = 0; i < dataArr.Length; i++)
            {
                if (EditString == dataArr[i])
                {
                    dataArr[i] = NewString;
                    break;
                }
            }

        }
    }
}

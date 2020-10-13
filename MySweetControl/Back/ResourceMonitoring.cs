using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetControl.Back
{
    static class ResourceMonitoring
    {
        // Функция возвращающая текущее кол во занимаемой памяти
        public static string GetUseMemory()
        {
            string res = "memory " + (Process.GetCurrentProcess().WorkingSet64 / 1024) / 1024 + " MB";
            return res;
        }
    }
}

using System;

namespace MemoryMan_lab_5
{
    public class Process
    {
       public int size;//размер процесса
       public int life_time;//Время жизни процесса
       public string name;

        public Process(string s)
        {
            string[] str = s.Split(',');
            name = str[0];
            size = Convert.ToInt32(str[1]);
            life_time = Convert.ToInt32(str[2]);
        }
    }
}

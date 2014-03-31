using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemoryMan_lab_5
{
    class MemStat
    {
        GroupBox panel;
        int TotalMem=0;//Всего памяти доступно
        int TotalUnFreeMem=0;//Свободная память
        int Acepted = 0;//Удовлетворённые запросы
        int Total=0;//Всего запросов

       
        public MemStat(GroupBox panel)
        {
            this.panel = panel;
        }

        public int TotalMemory
        {
            get { return TotalMem; }
        }


        public int AceptedRequests//Удовлетворенные запросы
        {
            get { return Acepted; }
            set
            {
                Acepted= value;
            }
        }

        public int TotalRequests//Всего запросов
        {
            get { return Total; }
            set
            {
              Total = value;
            }
        }

        public int TotalUnFreeMemory
        {
            get { return TotalUnFreeMem; }
            set { TotalUnFreeMem=value;
        }
        }

        public void DrawMemoryStatus(Part[] Parts)//Рисует на панели разделы
        {
            int PartWidth = (panel.Width - (10 * Parts.Length)) / Parts.Length;//Ширина одного раздела
            Brush Br = Brushes.Black;
            Pen Bl_pen = Pens.Black;
            Font F = new Font(FontFamily.GenericSerif, 10);
            int CurrentPos = 5;//вычисление иксовой координаты следующего раздела
            Graphics Graph = Graphics.FromHwnd(panel.Handle);//Создаём объект graphics из хэндла панели
            Graph.Clear(panel.BackColor);
            TotalMem = 0;
            TotalUnFreeMem = 0;
            for (int i = 0; i < Parts.Length; i++)//Рисуем каждый раздел
            {
                TotalMem += Parts[i].Size;//Считаем общее количество памяти
                if (Parts[i].TimerState == true && Parts[i].CurrentProcess != null)//Если в разделе процесс существует запущен
                {//то
                    TotalUnFreeMem += Parts[i].CurrentProcess.size;//увеличиваем счётчик занятого пространства
                    Graph.DrawString(Parts[i].Name, F, Br, CurrentPos, 10);//Рисуем название раздела
                    Graph.DrawRectangle(Bl_pen, CurrentPos, 35, PartWidth, Convert.ToInt32(Convert.ToSingle(Parts[i].Size) / PartWidth * 100));
                    Graph.FillRectangle(Brushes.Coral, CurrentPos + 1, 36, PartWidth - 1, Convert.ToInt32(Convert.ToSingle(Parts[i].Size) / PartWidth * 100 - 1));
                    Graph.FillRectangle(Brushes.Chartreuse, CurrentPos + 1, 36, PartWidth - 1, Convert.ToInt32(Convert.ToSingle(Parts[i].CurrentProcess.size) / PartWidth * 100 - 1));
                }//Рисуем блоки и заливаем цветами
                else//Если же процесс не существует,то заливаем блок синим цветом, что означает что раздел пуст
                    Graph.FillRectangle(Brushes.Coral, CurrentPos + 1, 36, PartWidth - 1, Convert.ToInt32(Convert.ToSingle(Parts[i].Size) / PartWidth * 100 - 1));
                CurrentPos += PartWidth + 10;
            }
            //Рисуем текст статистики занятой памяти и статистики запросов
            Graph.DrawString(TotalMem.ToString() + "/" + TotalUnFreeMem.ToString() + " байт всего/занято", F, Br, 5, panel.Height-30);
            Graph.DrawString(Total.ToString() + "/" + Acepted.ToString() + " всего/удовлетворено " + (Convert.ToSingle(Acepted) / Total * 100).ToString() + "%", F, Br, 5, panel.Height - 15);
        }
    }
}

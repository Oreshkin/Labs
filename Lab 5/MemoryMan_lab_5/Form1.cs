using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace MemoryMan_lab_5
{
    public struct Part
    {
        private string name;
        private string start_adress; //логический адрес начала раздела
        private string end_adress; //логический адрес конца раздела
        private int size; //Размер раздела
        public byte[] memory;
        private ITimer TimeCounter;
        private Process Proc; //Процесс, который сейчас загружен в раздел
        private Queue<Process> Ochered; //Очередь процессов для раздела
        private Form1 form; //ссылка на форму
        private bool AllowToWork;
        public event EventHandler ProcessAdd; //Событие на добавление процесса
        public event EventHandler ProcessChange; //на изменение текущего процесса

        public Part(string name, int size, Form1 form, string adress)
        {
            this.name = name;
            this.size = size;
            memory = new byte[size];
            AllowToWork = true;
            this.Proc = null; //Инициализируем текущий процесс нулевой ссылкой
            Ochered = new Queue<Process>(); //Инициализируем очередь процессов

#if false
            TimeCounter = new TimerWrapper();
#else
            TimeCounter = ClickTimer.CreateTimer();
#endif

            this.form = form;
            string[] adresArr = adress.Split('-'); //Инициализируем поля адресов
            start_adress = adresArr[0]; //адрес начала
            end_adress = adresArr[1]; //адрес конца
            ProcessAdd = new EventHandler(form.OnProcessAdd);
            ProcessChange = new EventHandler(form.OnCurrentProcChange);
            //TimeCounter.Tick += new EventHandler(TimeCounter_Tick);
            TimeCounter.SetAction(TimeCounter_Tick);
        }

        public bool TimerState
        {
            get { return TimeCounter.Enabled; }
            set { TimeCounter.Enabled = value; }
        }

        public bool AllowWork
        {
            get { return AllowToWork; }
            set { AllowToWork = value; }
        }

        //public void TimeCounter_Tick(object sender, EventArgs e)
        public void TimeCounter_Tick(int t)
        {
            if (Ochered.Count != 0 && AllowToWork)
            {
                CurrentProcess = Ochered.Dequeue();  //Когда истекает время жизни процесса, загружаем следующий процесс из очереди
            }
            else
            {
                CurrentProcess = null;
            }
        }

        public Process this[int i] //Индексатор для доступа к элементам очереди
        {
            get
            {
                Process[] pr = Ochered.ToArray();
                return pr[i];
            }
        }

        public int Size
        {
            get { return size; }
        }

        public int ProcessesCount
        {
            get { return Ochered.Count; }
        }

        public string Name
        {
            get { return name; }
        }


        public string StartSegmentAdress
        {
            get { return start_adress; }
        }


        public string EndSegmentAdress
        {
            get { return end_adress; }
        }

        public Process CurrentProcess //Изменение текущего процесса
        {
            get { return Proc; }
            set
            {
                TimeCounter.Enabled = false; //Отключаем таймер
                Proc = value; //Устанавливаем процес
                if (value != null) //если не пусто, то устанавливаем время жизни и запускаем таймер 
                {
                    TimeCounter.Interval = value.life_time;
                    if (AllowToWork) //Если разрешена обработка процессов
                        TimeCounter.Enabled = true;
                }
                ProcessChange(this, EventArgs.Empty);
            }
        }

        public void AddProcessToQueue(Process item)
        {
            if (CurrentProcess == null)
            //Проверяем, если текущего процесса нет, то загружаем туда только что добавленный
            {
                CurrentProcess = item;
            }
            else
            {
                Ochered.Enqueue(item);
            }
            ProcessAdd(this, EventArgs.Empty);
        }

        public void DeleteProcessFromPart() //Завершение текущего процесса
        {
            CurrentProcess = null;
            //if(Ochered.Count>=0)
            //CurrentProcess = Ochered.Dequeue();
        }

        public void LoadProcToPartFromQueue() //Загружаем процесс из очереди в текущий раздел
        {
            Proc = Ochered.Dequeue();
        }

        public static void AllPartsOn(Part[] parts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].TimerState = true;
                parts[i].AllowWork = true;
            }
        }


        public static void AllPartsOff(Part[] parts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].TimerState = false;
                parts[i].AllowWork = false;
            }
        }



    }

    public partial class Form1 : Form
    {
        private settings _s; //форма настроек
        private MemStat _memStatistics; //поле- статистика памяти
        public Part[] Parts; //массив разделов
        private NewProcess _procss; //форма для создания процесса


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Обработчик события, когда форма загружается
            _s = new settings(); //Создаём экземпляр окна настроек
            if (_s.ShowDialog() == DialogResult.OK) //если в окне настроек нажали ок
            {
                Parts = _s.GetMemStruct; //Передаём строку со структурой разделов из формы настроек
                for (int i = 0; i < Parts.Length; i++)
                {
                    dataGridView1.Columns.Add(Parts[i].Name, Parts[i].Name);
                    //добавляем колонки с названиями сегментов в dataGridView
                }
                _memStatistics = new MemStat(StatusPannel); //Создаём экземпляр класса статистики
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Событие при нажатии на кнопку создать процесс
            _procss = new NewProcess(Parts);
            if (_procss.ShowDialog() == DialogResult.OK) //Создаём новый процесс
            {
                var createProc = new Process(_procss.GetInfo);
                //Увеличиваем счётчик числа запросов
                _memStatistics.TotalRequests += 1;
                if (createProc.size <= Parts[_procss.GetPart].Size)
                {
                    Parts[_procss.GetPart].AddProcessToQueue(createProc);
                    //Добавляем только что созданый процесс в очередь процессов
                }
                else
                {
                    MessageBox.Show(
                        "Ошибка добавления процесса в очередь! Запрошено: " + createProc.size +
                        " байт, доступно для данного раздела: "
                        + Parts[_procss.GetPart].Size + " байт.",
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Выводим сообщение красным цветом
                    string msg = "Ошибка добавления процесса в очередь! Запрошено: " + createProc.size +
                                 " байт, доступно для данного раздела: "
                                 + Parts[_procss.GetPart].Size + " байт.";
                    richTextBox1.AppendText(msg + "\n");
                    richTextBox1.SelectionStart = richTextBox1.Find(msg);
                    richTextBox1.SelectionLength = msg.Length;
                    richTextBox1.SelectionColor = Color.Red;
                }
            }
        }

        public void OnCurrentProcChange(object sender, EventArgs e)
        {
            int l = 0;
            for (int i = 0; i < Parts.Length; i++) //Ищем, в каком разделе процесс
            {
                if (Parts[i].Name == ((Part)sender).Name)
                {
                    l = i;
                    if (((Part)sender).CurrentProcess != null && Parts[l].CurrentProcess != null)
                        Parts[l].CurrentProcess.size = ((Part)sender).CurrentProcess.size;
                    break;
                }
            }

            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++) //Подвигаем процессы в сетке для этого раздела
            {
                dataGridView1[l, j].Value = dataGridView1[l, j + 1].Value;
            }
            if (dataGridView1.RowCount > 1) //Уменьшаем количество рядов
                dataGridView1.RowCount -= 1;
            //Пересчитываем объём памяти
            _memStatistics.TotalUnFreeMemory = 0;
            for (int i = 0; i < Parts.Length; i++)
            {
                if (Parts[i].CurrentProcess != null)
                    _memStatistics.TotalUnFreeMemory += Parts[i].CurrentProcess.size;
            }
            if (((Part)sender).CurrentProcess == null && ((Part)sender).ProcessesCount == 0)
            {
                string msg = "В очереди для " + ((Part)sender).Name + " больше нет процессов! Ожидание...";
                richTextBox1.AppendText(msg + "\n");
                richTextBox1.SelectionStart = richTextBox1.Find(msg);
                richTextBox1.SelectionLength = msg.Length;
                richTextBox1.SelectionColor = Color.Green;
                //Останавливаем таймер, если процесса нет
                Part p = (Part)sender;
                p.TimerState = false;
            }
            else
            {
                _memStatistics.AceptedRequests += 1;
                string msg = "В раздел " + ((Part)sender).Name + " загружен процесс " +
                             ((Part)sender).CurrentProcess.name;
                richTextBox1.AppendText(msg + "\n");
                richTextBox1.SelectionStart = richTextBox1.Find(msg);
                richTextBox1.SelectionLength = msg.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }
            _memStatistics.DrawMemoryStatus(Parts);
        }


        public void OnProcessAdd(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Parts.Length; i++) //Заполняем сетку очередями
            {
                for (int j = 0; j < Parts[i].ProcessesCount; j++)
                {
                    dataGridView1.Rows.Add();
                    if (j == 0 && Parts[i].CurrentProcess != null) //сначала текущие процессы
                        dataGridView1[i, j].Value = Parts[i].CurrentProcess.name;
                    else
                        dataGridView1[i, j].Value = Parts[i][j].name;
                }
            }
            Part p = (Part)sender;
            if (p.AllowWork) //если обработка процессов разрешена
            {
                p.TimerState = true;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //Циклическое выделение памяти
            int i = 0;
            //Начинаем формировать строку с данными о процессе
            var part = new Random();
            var size = new Random();
            var time = new Random();
            Part.AllPartsOff(Parts);
            while (i < 20)
            {
                //Генерируем случайные величины
                Thread.Sleep(50);
                int sizeM = size.Next(1, 128);
                int partM = part.Next(0, Parts.Length);
                _memStatistics.TotalRequests += 1;
                if (Parts[partM].Size >= sizeM)
                {
                    if (Parts[partM].ProcessesCount <= 5)
                    {
                        //формируем строку с информацией о процессе(в конструктор класса процесс передается строка)
                        string str = "Процесс_" + i + "," + sizeM + "," + time.Next(10, 5000) +
                              ",Раздел " + partM;
                        Parts[partM].AddProcessToQueue(new Process(str)); //Добавляем процесс в очередь
                    }
                }
                else
                {
                    string msg = "Ошибка добавления процесса в очередь! Запрошено: " + sizeM +
                                 " байт, доступно для данного раздела: "
                                 + Parts[partM].Size + " байт.";
                    richTextBox1.AppendText(msg + "\n");
                    richTextBox1.SelectionStart = richTextBox1.Find(msg);
                    richTextBox1.SelectionLength = msg.Length;
                    richTextBox1.SelectionColor = Color.Red;
                }
                i++;

            }
            Part.AllPartsOn(Parts);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parts[dataGridView1.SelectedCells[0].ColumnIndex].DeleteProcessFromPart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            readAnDwrite rw = new readAnDwrite(this);
            rw.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var reader = new StreamReader(openFileDialog1.FileName);
            int i = 0;
            while (!reader.EndOfStream)
            {
                try
                {
                    Part.AllPartsOff(Parts);
                    var data = reader.ReadLine();
                    if (data != null)
                    {
                        var arrProc = data.Split(','); // Увеличиваем счётчик числа запросов
                        _memStatistics.TotalRequests += 1;
                        if (Parts[int.Parse(arrProc[3])].Size >= int.Parse(arrProc[1]))
                        {
                            if (Parts[int.Parse(arrProc[3])].ProcessesCount <= 5)
                            {
                                //формируем строку с информацией о процессе(в конструктор класса процесс передается строка)
                                string str = arrProc[0] + "," + int.Parse(arrProc[1]) + "," +
                                             arrProc[2] +
                                             ",Раздел " + int.Parse(arrProc[3]);
                                Parts[int.Parse(arrProc[3])].AddProcessToQueue(new Process(str));
                                //Добавляем процесс в очередь
                            }
                        }
                        else
                        {
                            string msg = "Ошибка добавления процесса в очередь! Запрошено: " + int.Parse(arrProc[1]) +
                                         " байт, доступно для данного раздела: "
                                         + Parts[int.Parse(arrProc[3])].Size + " байт.";
                            richTextBox1.AppendText(msg + "\n");
                            richTextBox1.SelectionStart = richTextBox1.Find(msg);
                            richTextBox1.SelectionLength = msg.Length;
                            richTextBox1.SelectionColor = Color.Red;
                        }
                    }
                    i++;
                }
                catch { }

            }
            Part.AllPartsOn(Parts);
        }

        private void StatusPannel_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Part.AllPartsOn(Parts);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Part.AllPartsOff(Parts);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var i = ClickTimer.Next();
            button8.Text = @"next (" + i + @")";
        }
    }
}



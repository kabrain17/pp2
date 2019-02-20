using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager2
{
    enum ViewMode  //создаем енумерэйтор
                   // enum используем для определения состояния ,перечесление
                   //у нас есть два состояния , dir -папка и file-файл  

    {
        Dir,
        File

    }

    class Layer
    {
        public FileSystemInfo[] Content //Создаем массив в который будем класть всё что есть в директории 
        {
            get;  //для возврщения значения
            set;  //для регулирования значения
        }

        public int SelectedItem //выбранный элемент то есть подсвеченный 
        {
            get;   //для возврщения значения
            set;   //для регулирования значения
        }

        public void Draw() //метод отрисовки
        {
            int num = 1;   //для визуального счетчика в консоли
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear(); //очистка консоли перед выводом новой директории или предыдущего стека

            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem) // отрисовка курсора
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Content[i].GetType() == typeof(DirectoryInfo)) // если это директория подствечиваем белым 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;//в другом случае желтым
                }
                Console.WriteLine((num++) + ".  " + Content[i].Name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Багдан\Desktop\sabak");    // наша главная директория 
            Stack<Layer> history = new Stack<Layer>(); // стэк в котором хранится вся история по принципу LIFO(last in, first out)
            history.Push(  // добавить контент в стэк 
                new Layer
                {
                    Content = dir.GetFileSystemInfos()
                    //внутри history  в content добавляем инфо то что в папке dir
                }
            );
            ViewMode viewMode = ViewMode.Dir;  // режим просмотра меняем на показ  директории

            bool esc = false;
            //пока что равен фолсе
            while (!esc)//и пока он фолсе
            {
                if (viewMode == ViewMode.Dir) // если включен режим прсомотра директории

                {
                    history.Peek().Draw(); // пытаемся вызвать стек 
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); // создаем переменную клавиш которая считывает клавишу с консоли

                switch (consoleKeyInfo.Key)  //создаем условный оператор  
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;  // индекс минус
                        // Peek: просто возвращает первый элемент из стека без его удаления
                        if (history.Peek().SelectedItem == -1) // если вышло за границы массива 
                        {

                            history.Peek().SelectedItem = history.Peek().Content.Length - 1; // переводим в конец 
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;   // индекс плюс
                        //Peek: просто возвращает первый элемент из стека без его удаления
                        if (history.Peek().SelectedItem == history.Peek().Content.Length) // если вышло за границы массива 
                        {

                            history.Peek().SelectedItem = 0; // переводим в начало курсор 
                        }

                        break;
                    case ConsoleKey.Enter:  // открывание
                        int x = history.Peek().SelectedItem;      // сохраняем индекс выбранного курсором файла 
                                                                  //Peek: просто возвращает первый элемент из стека без его удаления
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];  /// берем его как файла а не как индекс 
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        // если это директория 
                        {
                            viewMode = ViewMode.Dir; // режим прсомотра директории
                            DirectoryInfo selectedDir = fileSystemInfo as DirectoryInfo;
                            //  переменная селектед равна выбранной папке
                            history.Push(new Layer { Content = selectedDir.GetFileSystemInfos() });//показываем внутренности
                            // добавляем в контент содержимое папки 
                            // и этот контент кидаем в стэк 
                        }
                        else
                        {
                            viewMode = ViewMode.File;    // если это файл 
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            // создание переменной
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;  //белый цвет как в блокноте 
                                    Console.Clear();  // очищение консоли  
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(sr.ReadToEnd());  // вывести весь текст
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Delete:  // клавиша удаления
                        int x2 = history.Peek().SelectedItem;    // сохранения индекса курсора 
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];       // передаем контент курсора 
                        history.Peek().SelectedItem--;         // перемещаем курсора на индекс ниже
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))     // если директория  
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo2 as DirectoryInfo;
                            // копируем директорию удаляемой папки
                            Directory.Delete(fileSystemInfo2.FullName, true);           // удаляем папку
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();
                            // кидаем в стэк только его парентс  
                            // так как файла уже нет 
                        }
                        else    // если файл 
                        {
                            FileInfo fileInfo = fileSystemInfo2 as FileInfo;     // копируем удаляемый файл
                            File.Delete(fileSystemInfo2.FullName);     // удаляем файл 
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();
                            // получаем экземпляр родительского каталога 
                        }


                        break;
                    case ConsoleKey.F2:
                        Console.BackgroundColor = ConsoleColor.Black;   //консоль фон черного цвета
                        Console.Clear();  //очищаем наш консоль
                        string name = Console.ReadLine();   //пишем новое имя
                        int x3 = history.Peek().SelectedItem;   // сохранения индекса курсора
                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3];  // передаем контент курсора
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo))   //если это папка
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo;
                            Directory.Move(fileSystemInfo3.FullName, directoryInfo.Parent + "/" + name);
                            // изначальный путь файла, 
                            //путь на который нужно поменять , изза того что после преспоследнего слеша мы меняем  
                            // его имя то берем его парент то есть без имени директории и присоединяем имя которое мы ввели в консоль 
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();
                            // ну и конечно же изза того что мы поменяли 
                            // имя файла нужно теперь его контент изменить в истории  
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo3 as FileInfo;   // если это не папка а файл
                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name);  // так же прям меняем имя 
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();   // опять изменяем его в стэке 
                        }

                        break;
                    case ConsoleKey.Backspace:     // возвращение назад  
                        if (viewMode == ViewMode.Dir)    // режим директории 
                        {
                            history.Pop();   // удаление нынешнего слоя
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;    // сделать черным
                            Console.Clear();   // очистить
                            Console.ForegroundColor = ConsoleColor.White;     // покрасить в белое
                            viewMode = ViewMode.Dir;    // режим просмотра директории
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                }
            }
        }
    }
}

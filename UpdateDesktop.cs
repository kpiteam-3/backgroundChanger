///////////////////////////////////////////////////////////////////////////////
//   http://www.interestprograms.ru
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;


namespace ADesktop
{
    // Обеспечивает изменение картинки на рабочем столе,
    // в ручном и автоматическом режиме, фиксирует
    // путь к выбранной картинке в реестре.
    class UpdateDesktop
    {
        // Поскольку Framework .NET еще только создается,
        // в данное время вышла 3-я серия (сравним с API на языке Си - ровестницей Windows),
        // приходится заимствовать исходные функции из API Windows.
        // Для этого в начале файла объявляем строку "using System.Runtime.InteropServices"
        // конкретно описываем из какой динамической библиотеки и какую функцию 
        // будем использовать.
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;
        const int SPI_GETDESKWALLPAPER = 0x0073;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);


        /// <summary>
        /// Таймер автоматической смены картинок на столе.
        /// </summary>
        Timer timerAutoChange;



        public void SetTimerInterval(int interval)
        {
            // Если интервал таймера меньше минуты (для тестирования)
            // приравниваем интервал к 3 секундам.
            if (interval < (1000 * 60)) interval = 3000;

            Global.iWaitingChange = interval;
            timerAutoChange.Interval = interval;
        }

        // ССылка на главную форму.
        UIForm uiForm;
        public UpdateDesktop(UIForm uiform)
        {
            uiForm = uiform;

            this.timerAutoChange = new Timer();
            this.timerAutoChange.Interval = Global.iWaitingChange;
            this.timerAutoChange.Tick += new System.EventHandler(this.timerAutoChange_Tick);
            
        }

        /// <summary>
        /// Инициализация объекта класса при загрузке приложения.
        /// </summary>
        public void InitDesktop()
        {
            // Если установка автоматической смены, ставим приложение на этот режим
            if (Global.bAutoChange == true)
            {
                if (Global.bLoadChange == false)
                    timerAutoChange.Enabled = true;
            }
        }

        /// <summary>
        /// Функция подготавливающая изменение картинки рабочего 
        /// стола при загрузке системы. При закрытии приложения 
        /// она производит запись пути к новому файлу изображения в реестре
        /// без перерисовки, чтобы при загрузке появился обновленный десктоп.
        /// </summary>
        public void CloseUpdateDesktop()
        {
            if (Global.bAutoChange == true && Global.bLoadChange == true)
            {
                PrepareWallpaperFromDirectory();
                RegistryChangePicture();
            }
        }
      

        /// <summary>
        /// Непосредственное изменение рабочего стола
        /// взависимости от выбранного способа.
        /// </summary>
        public void DoChangeWallpaper()
        {
            if (Global.bAutoChange == true)
            {
                // Изменим рисунок на рабочем столе
                // в подтверждение выбранного пользователем режима смены картинок. 
                AutoChangeWallpaper();

                if (Global.bLoadChange == false)
                {
                    timerAutoChange.Enabled = true;
                }
            }
            else
            {
                RegistryChangePicture();
                NotifyWindows();
            }

            
        }


        int countFiles = 0;
        /// <summary>
        /// Подготовка следующего файла из директория
        /// для загрузки в авторежиме.
        /// </summary>
        void PrepareWallpaperFromDirectory()
        {
            if (Global.listPictures == null || Global.listPictures.Count == 0) return;

            // В соответствии с выбранным способом загружаем картинку
            // на рабочий стол.
            if (Global.bRandomSelection == true)
            {
                Random randFunction = new Random(Environment.TickCount);
                // Получаем следующий псевдослучайный номер.
                int randNumber = randFunction.Next(Global.listPictures.Count - 1);

                countFiles = randNumber;
            }
            else
            {

                // При загрузке приложения, при режиме смены картинок
                // при загрузке, создаем автономный счетчик
                // относительно текущей картинки.
                for (int i = 0; i < Global.listPictures.Count; i++)
                {
                    if (Global.strConvertedWallpaperPath == Global.listPictures[i])
                    {
                        countFiles = i;
                        break;
                    }
                }

                countFiles++;
                if (countFiles == Global.listPictures.Count)
                    countFiles = 0;
  
            }

            Global.strConvertedWallpaperPath = Global.listPictures[countFiles];
        }

        /// <summary>
        /// Событие срабатывания таймера.
        /// </summary>
        private void timerAutoChange_Tick(object sender, EventArgs e)
        {
            AutoChangeWallpaper();
        }

        /// <summary>
        /// Остановка таймера
        /// </summary>
        public void StopAutoChange()
        {
            timerAutoChange.Stop();
        }

        /// <summary>
        /// Изменение картники рабочего стола в авторежиме.
        /// </summary>
        void AutoChangeWallpaper()
        {
            // Подготовим список файлов
            PrepareWallpaperFromDirectory();
            // Изменим записи в реестре
            RegistryChangePicture();
            // Известим операционную систему об изменениях
            NotifyWindows();
        }

        /// <summary>
        /// Запись информации о новой картинки в реестр
        /// </summary>
        void RegistryChangePicture()
        {
            try
            {
                // Преобразованную картинку будем хранить в том месте
                // откуда было запущено приложение.
                FileInfo fi = new FileInfo(Global.strConvertedWallpaperPath);
                string path = Application.StartupPath + "\\wallpaper.bmp";
                Global.strWallpaperPath = path;

                switch (Global.osVersion)
                {
                    case Global.OSVersion.XP:
                        {
                            // Для XP расширение файла картинки может быть
                            // .bmp другие форматы требуют преобразования в bmp.
                            if (fi.Extension == ".bmp" || fi.Extension == ".BMP")
                            {
                                Global.strWallpaperPath = Global.strConvertedWallpaperPath;
                            }
                            else
                            {
                                Bitmap bmp = null;
                                bmp = new Bitmap(Global.strConvertedWallpaperPath);
                                bmp.Save(Global.strWallpaperPath, ImageFormat.Bmp);
                                bmp.Dispose();
                            }
                        }
                        break;
                    case Global.OSVersion.Vista:
                        {
                            // Для Висты расширение файла картинки может быть
                            // .bmp и jpg, другие форматы пока требуют преобразования в jpg.
                            if (fi.Extension == ".bmp" || fi.Extension == ".BMP" ||
                                fi.Extension == ".jpg" || fi.Extension == ".JPG" ||
                                fi.Extension == ".jpeg" || fi.Extension == ".JPEG")
                            {
                                Global.strWallpaperPath = Global.strConvertedWallpaperPath;
                            }
                            else
                            {
                                Bitmap bmp = null;
                                bmp = new Bitmap(Global.strConvertedWallpaperPath);
                                bmp.Save(Global.strWallpaperPath, ImageFormat.Bmp);
                                bmp.Dispose();
                            }
                        }
                        break;
                }


                // Устанавливаем необходимые настройки в реестре,
                RegistryKey regHCU = Registry.CurrentUser;
                RegistryKey regDesktop = regHCU.OpenSubKey("Control Panel\\Desktop", true);
                regDesktop.SetValue("Wallpaper", Global.strWallpaperPath, RegistryValueKind.String);

                if (Global.osVersion == Global.OSVersion.XP)
                    regDesktop.SetValue("ConvertedWallpaper", Global.strConvertedWallpaperPath, RegistryValueKind.String);

                if (Global.rpWayChange != Global.ReplacePicture.Tile)
                {
                    regDesktop.SetValue("TileWallpaper", "0");
                    switch (Global.rpWayChange)
                    {
                        case Global.ReplacePicture.ActualSize:
                            regDesktop.SetValue("WallpaperStyle", "0");
                            break;
                        case Global.ReplacePicture.Stretch:
                            regDesktop.SetValue("WallpaperStyle", "2");
                            break;
                    }
                }
                else
                {
                    regDesktop.SetValue("TileWallpaper", "1");
                }

                regDesktop.Close();
                regHCU.Close();

                uiForm.UpdatePictureBox();
            }
            catch
            {
                Global.DebugMessage("UpdateDesktop.RegistryChangePicture()");
            }
            finally
            {
                // В любом случае постараемся освободить память.
                System.GC.Collect();
            }
        }

        /// <summary>
        /// Оповещение системы об изменениях в реестре
        /// </summary>
        void NotifyWindows()
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, null, SPIF_SENDWININICHANGE);  
        }


        
        
    }
}

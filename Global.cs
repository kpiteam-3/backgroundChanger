///////////////////////////////////////////////////////////////////////////////
//   http://www.interestprograms.ru
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADesktop
{
    // Хранение глобальных переменных, функций для 
    // доступа к ним с любых мест пространства MyDesktop.
    class Global
    {
        /// <summary>
        /// Размещение картинки на столе,
        /// 1. Подогнать под размер
        /// 2. Расположить по центру картинку реального размера
        /// 3. Покрыть рабочий стол плиткой из картинки
        /// </summary>
        public enum ReplacePicture { Stretch = 1, ActualSize, Tile };
        public static ReplacePicture rpWayChange;


        /// <summary>
        /// Версия операционной системы
        /// </summary>
        public enum OSVersion { XP = 5, Vista = 6};
        public static OSVersion osVersion;


        /// <summary>
        /// Для операционной системы XP.
        /// Путь к  файлу-источнику картинки рабочего стола,
        /// (прописан в реестре HKEY_CURRENT_USER\Control Panel\Desktop\ConvertedWallpaper)
        /// Windows XP создает копию этого файла в формате .bmp,
        /// путь к которому хранится в реестре по адресу 
        /// HKEY_CURRENT_USER\Control Panel\Desktop\Wallpaper
        /// При просмотре свойств рабочего стола отображается
        /// именно эта картинка
        /// </summary>
        public static string strConvertedWallpaperPath = null;


        /// <summary>
        /// Путь к настоящему файлу картинки на столе
        /// прописанный в реестре.
        /// </summary>
        public  static string strWallpaperPath = null;

        /// <summary>
        /// Список имен картинок выбранного каталога
        /// </summary>
        public static List<string> listPictures = new List<string>();

        /// <summary>
        /// Автоматическая смена картинок рабочего стола
        /// </summary>
        public static bool bAutoChange = false;

        

        /// <summary>
        /// Выбор файлов в каталоге.
        /// Случайный метод выбора файлов если true,
        /// или последовательный если false.
        /// </summary>
        public static bool bRandomSelection = false;

        /// <summary>
        /// Смена картинки рабочего стола при загрузке Windows - true
        /// или через определенный промежуток времени - false.
        /// </summary>
        public static bool bLoadChange = true;

        /// <summary>
        /// Временной промежуток между сменой картинок, по умолчанию 1 минута.
        /// </summary>
        public static int iWaitingChange = 1000 * 60;

        /// <summary>
        /// Показ сообщений об ошибках при отладке - true,
        /// непоказ - false.
        /// </summary>
        const bool debugState = false;

        /// <summary>
        /// Показывает пользователю окно с сообщением об ошибке.
        /// </summary>
        /// <param name="message">показываемое сообщение</param>
        public static void DebugMessage(string message)
        {
            if(debugState == true)
                System.Windows.Forms.MessageBox.Show("Error " + message);
        }
    }
}

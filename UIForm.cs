///////////////////////////////////////////////////////////////////////////////
//   http://www.interestprograms.ru
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Collections;

namespace ADesktop
{
    // Класс взаимодействия пользователя с приложением.
    public partial class UIForm : Form
    {

        /// <summary>
        /// Путь к каталогу с картинками.
        /// </summary>
        string strDirectoryPicturePath = null;
      
        /// <summary>
        /// Функцианальность смены картинок.
        /// </summary>
        UpdateDesktop updateDeskTop;



        public UIForm()
        {
            InitializeComponent();

            updateDeskTop = new UpdateDesktop(this);

            // Определение версии операционной системы для корректировки
            // действий приложения взависимости от версии операционной системы.
            Global.osVersion = (Global.OSVersion)Environment.OSVersion.Version.Major;
            
        }
  

        /// <summary>
        /// Загрузка окна формы
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ограничим работу приложения в операционных системах
            // XP, Windows2003, Vista т.е. версий от до 6 включительно.
            // При желании список можно расширить. 
            if (Global.osVersion != Global.OSVersion.XP && Global.osVersion != Global.OSVersion.Vista)
            {
                MessageBox.Show("Несовместимая операционная система!", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }


            // 1. Чтение данных из реестра
            // 2. Обновление родительского интерфейса
            // 3. Обновление дочернего интерфейса

            ReadRegistry();    
            
            UpdatePictureBox();
            UpdateUI();

            updateDeskTop.InitDesktop();
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                OpenCloseToolStripMenuItem.Text = "Открыть";
                this.ShowInTaskbar = false;
            }
            else
            {
                OpenCloseToolStripMenuItem.Text = "Закрыть";
                this.ShowInTaskbar = true;
            }
        }


        /// <summary>
        /// Перед закрытием формы
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если разрешено закрыть приложение (при выключении компьютера или завершение сеанса пользователя),
            // или при принудительном закрытии приложения пользователем.
            if(bCanClose == true || (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                // Если пользователь закрывает приложение,
                // уточним желает ли он закрыть приложение или удалить
                // т.е. стереть все настройки из реестра.
                // При закрытии результат возврата равен DialogResult.OK,
                // при удалении любой другой.
                FormDlg fDlg = new FormDlg();
                if (bCanClose == false && fDlg.ShowDialog() != DialogResult.OK)
                {
                    Hide();
                    AutoRunApplication(false);
                    DeleteRegKey();
                    return;
                }

                // В случае если пользователь просто закрыл приложение,
                // запишем все настройки в реестр и приложение загрузится
                // вновь при запуске операционной системы или сеанса пользователя.
                AutoRunApplication(true);
                updateDeskTop.CloseUpdateDesktop();
                WriteRegistry();
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }

        }

        /// <summary>
        /// True - приложение можно закрыть, false - приложение вместо закрытия будет минимизироваться.
        /// </summary>
        bool bCanClose = false;

        // Идентификатор необходимого сообщения,
        // значение взято из заголовочного файла winuser.h из набора Win32 API
        const int WM_QUERYENDSESSION = 0x0011;
        /// <summary>
        /// Обработчик сообщений системы
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            // При выключении компьютера или закрытии сеанса пользователя,
            // зафиксируем в реестре необходимые данные.
            switch (m.Msg)
            {
                case WM_QUERYENDSESSION:
                    bCanClose = true;
                    break;
            }

            base.WndProc(ref m);

        }

        /// <summary>
        /// Обновляется интерфейс, взависимости от 
        /// принятых настроек.
        /// </summary>
        void UpdateUI()
        {
            // Инициализация групп при ручной или автоматической 
            // смены картинок на рабочем столе
            radioButtonAuto.Checked = Global.bAutoChange;
            radioButtonManual.Checked = !Global.bAutoChange;
            groupBoxChangePicture.Enabled = Global.bAutoChange;
            groupBoxFrequencyChange.Enabled = Global.bAutoChange;


            if (Global.bAutoChange == false)
            {
                updateDeskTop.StopAutoChange();
                buttonSelectPictures.Text = "Выбрать файл";
                labelNumberFiles.Visible = false;

                // Кнопка "Применить" всегда активна в ручном режиме.
                buttonApply.Enabled = true;
            }
            else
            {
                if (Global.bAutoChange == true && Global.bLoadChange == true)
                    updateDeskTop.StopAutoChange();

                // Исследуем файлы в выбранном директории.
                PrepareFilesFromDirectory();

                buttonSelectPictures.Text = "Выбрать каталог";
                labelNumberFiles.Visible = true;
            }



            // Радиокнопки выбора метода смены картинок
            radioButtonRandom.Checked = Global.bRandomSelection;
            radioButtonConsecutively.Checked = !Global.bRandomSelection;


            // Радиокнопки выбора частоты смены картинок
            radioButtonByLoad.Checked = Global.bLoadChange;
            radioButtonFrequency.Checked = !Global.bLoadChange;
            numericUpDownHour.Enabled = !Global.bLoadChange;
            numericUpDownMin.Enabled = !Global.bLoadChange;
            labelHour.Enabled = !Global.bLoadChange;
            labelMinute.Enabled = !Global.bLoadChange;


            // Радиокнопки группы Картинка на столе
            switch (Global.rpWayChange)
            {
                case Global.ReplacePicture.Tile:
                    radioButtonTile.Checked = true;
                    break;
                case Global.ReplacePicture.ActualSize:
                    radioButtonActualSize.Checked = true;
                    break;
                case Global.ReplacePicture.Stretch:
                    radioButtonStretch.Checked = true;
                    break;
            }


            // Инициализация часов и минут промежутка
            // смены картинок.
            int sec = Global.iWaitingChange / 1000;
            int min = sec / 60;
            int hour = min / 60;
            min = min - hour * 60;

            numericUpDownMin.Value = min;
            numericUpDownHour.Value = hour;
           
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // После команды "Принять" объект класса UpdateDesktop
            // выберет заявленный пользователем режим работы.
            updateDeskTop.DoChangeWallpaper(); 
        }

        private void radioButtons_Click(object sender, EventArgs e)
        {
            RadioButton rbTest = (RadioButton)sender;
            // В дизайнере формы объекту Tag радиокнопок 
            // (и других объектов имеющих свойство Tag)
            // можно присвоить только строковое значение.
            // Но мы без проблем можем строку преобразовать в число.
            int number = int.Parse((string)rbTest.Tag);

            switch (number)
            {
                case 1:
                    Global.bAutoChange = !((RadioButton)sender).Checked;
                    break;
                case 2:
                    Global.bAutoChange = ((RadioButton)sender).Checked;
                    break;
                case 3:
                    Global.bRandomSelection = !((RadioButton)sender).Checked;
                    break;
                case 4:
                    Global.bRandomSelection = ((RadioButton)sender).Checked;
                    break;
                case 5:
                    Global.rpWayChange = Global.ReplacePicture.Stretch;
                    break;
                case 6:
                    Global.rpWayChange = Global.ReplacePicture.ActualSize;
                    break;
                case 7:
                    Global.rpWayChange = Global.ReplacePicture.Tile;
                    break;
                case 8:
                    Global.bLoadChange = ((RadioButton)sender).Checked;
                    break;
                case 9:
                    Global.bLoadChange = !((RadioButton)sender).Checked;
                    break;
            }

            UpdateUI();
        }

        /// <summary>
        /// Подготовим файлы картинок из выбранного директория.
        /// </summary>
        void PrepareFilesFromDirectory()
        {
            try
            {
                buttonApply.Enabled = false;
                // Очистим список перед заполнением новыми строковыми данными.
                Global.listPictures.RemoveRange(0, Global.listPictures.Count);

                if (strDirectoryPicturePath == null || Directory.Exists(strDirectoryPicturePath) == false)
                {
                    labelNumberFiles.Text = "Не выбран каталог картинок";
                    return;
                }

                // Общий список файлов в директории
                string[] listFiles = Directory.GetFiles(strDirectoryPicturePath);

                // В каталоге обязательно должен быть хотя бы один файл.
                if (listFiles != null && listFiles.Length != 0)
                {
                    for (int i = 0; i < listFiles.Length; i++)
                    {

                        FileInfo fi = new FileInfo(listFiles[i]);
                        // быстрая фильтрация по расширению 
                        if (fi.Extension == ".jpg" || fi.Extension == ".JPG" ||
                            fi.Extension == ".jpeg" ||fi.Extension == ".JPEG" ||
                            fi.Extension == ".bmp" || fi.Extension == ".BMP" ||
                            fi.Extension == ".png" || fi.Extension == ".PNG" ||
                            fi.Extension == ".gif" || fi.Extension == ".GIF" ||
                            fi.Extension == ".tif" || fi.Extension == ".TIF")

                            Global.listPictures.Add(fi.FullName);
                    }
                }

                // Если картинок не найдено оповестим об этом пользователя.
                if (Global.listPictures.Count == 0)
                {
                    labelNumberFiles.Text = "В каталоге \"" + strDirectoryPicturePath + "\" нет картинок для рабочего стола";
                    return;
                }

                // При успешной подготовке списка картинок, разблокируем кнопку 
                // изменения картинки десктопа.
                buttonApply.Enabled = true;


                // Отсортируем список по алфавиту.
                Global.listPictures.Sort();
                // Показ пользователю информацию о выбранном каталоге.
                string strTemp = Global.listPictures.Count.ToString() + " картинок";
                labelNumberFiles.Text = strDirectoryPicturePath + " - " + strTemp;
            }
            catch
            {
                Global.DebugMessage("UIForm.GetFilesFromDirectory()");
            }
        }



        /// <summary>
        /// Загрузка новой картинки в вспомогательный экран,
        /// изменение надписи пути к новому файлу-картинке.
        /// </summary>
        public void UpdatePictureBox()
        {
            // Если форма не видима нет необходимости обновлять 
            // изображение в нем.
            //if (this.WindowState == FormWindowState.Minimized) return;

            try
            {
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();

                if (Global.strConvertedWallpaperPath != null)
                {
                    if (new FileInfo(Global.strConvertedWallpaperPath).Exists == true)
                    {
                        FileStream fs = new FileStream(Global.strWallpaperPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        pictureBox1.BackgroundImage = new Bitmap(fs);
                        fs.Close();
                        labelPath.Text = Global.strConvertedWallpaperPath;
                    }
                    else
                    {
                        labelPath.Text = "Файл \"" + Global.strConvertedWallpaperPath + "\" не найден!";
                    }
                }
            }
            catch
            {
                Global.DebugMessage("UIForm.UpdatePictureBox()");
            }
           
        }

        private void buttonSelectPictures_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.bAutoChange == false)
                {
                    // Открываем диалог выбора файлов,
                    // начальный каталог открываем по возможности тот 
                    // в котором находится текущая картинка рабочего стола.
                    OpenFileDialog openfileDialog = new OpenFileDialog();
                    if (Global.strConvertedWallpaperPath != null)
                    {
                        FileInfo fileInfo = new FileInfo(Global.strConvertedWallpaperPath);
                        if(fileInfo.Exists == true)
                            openfileDialog.InitialDirectory = fileInfo.DirectoryName;
                    }

                    openfileDialog.Filter = "Картинки (*.jpg;*.jpeg;*.bmp;*.png;*.gif;*.tif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif;*.tif";
                    if (openfileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Global.strConvertedWallpaperPath = openfileDialog.FileName;
                        UpdatePictureBox();
                        buttonApply.Enabled = true;
                    }
                }
                else
                {
                    // Открываем диалог выбора каталогов,
                    // по возможности открываем начальный каталог прописанный в реестре
                    // или ранее выбранный пользователем.
                    FolderBrowserDialog fbDialog = new FolderBrowserDialog();
                    fbDialog.Description = "Выбери каталог содержащий картинки";
                    fbDialog.SelectedPath = strDirectoryPicturePath;

                    if (fbDialog.ShowDialog() == DialogResult.OK)
                    {
                        strDirectoryPicturePath = fbDialog.SelectedPath;
                        PrepareFilesFromDirectory();
                    }
                }
            }
            catch
            {
                Global.DebugMessage("UIForm.buttonSelectPictures_Click()");
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int hour = (int)numericUpDownHour.Value * 3600;
            int min = (int)numericUpDownMin.Value * 60;

            int timeChange = (hour + min) * 1000;
            updateDeskTop.SetTimerInterval(timeChange);
        }


        /// <summary>
        /// Читаем последние установки приложения из реестра
        /// </summary>
        void ReadRegistry()
        {
            try
            {
                RegistryKey regHCU = Registry.CurrentUser;

                // Читаем из реестра данные операционной системы об 
                // уже загруженной картинки
                RegistryKey regDesktop = regHCU.OpenSubKey("Control Panel\\Desktop", false);
                Global.strWallpaperPath = (string)regDesktop.GetValue("Wallpaper");
                Global.strConvertedWallpaperPath = (string)regDesktop.GetValue("ConvertedWallpaper");

                string tileWallpaper = (string)regDesktop.GetValue("TileWallpaper");
                string wallpaperStyle = (string)regDesktop.GetValue("WallpaperStyle");
                if (int.Parse(tileWallpaper) == 0)
                {
                    switch (int.Parse(wallpaperStyle))
                    {
                        case 0:
                            Global.rpWayChange = Global.ReplacePicture.ActualSize;
                            break;
                        case 2:
                            Global.rpWayChange = Global.ReplacePicture.Stretch;
                            break;
                    }
                }
                else
                {
                    Global.rpWayChange = Global.ReplacePicture.Tile;
                }
                regDesktop.Close();


                // Чтение данных предустановок приложения
                RegistryKey regSoftware = regHCU.OpenSubKey("Software", false);
                RegistryKey regMyWallpaper = regSoftware.OpenSubKey("MyWallpaper");
                if (regMyWallpaper != null)
                {
                    string str = (string)regMyWallpaper.GetValue("AutoChange");
                    Global.bAutoChange = bool.Parse(str);
                    str = (string)regMyWallpaper.GetValue("randomChange");
                    Global.bRandomSelection = bool.Parse(str);
                    str = (string)regMyWallpaper.GetValue("LoadChange");
                    Global.bLoadChange = bool.Parse(str);
                    strDirectoryPicturePath = (string)regMyWallpaper.GetValue("strDirectoryPath");
                    Global.iWaitingChange = (int)regMyWallpaper.GetValue("waitingChange");
                    regMyWallpaper.Close();
                }
                regSoftware.Close();

                regHCU.Close();

                // Если система Vista или не найден путь к файлу-источнику в системе XP,
                // запишем в "Global.strConvertedWallpaperPath" путь к реальному файлу
                if (Global.osVersion == Global.OSVersion.Vista ||
                    Global.strConvertedWallpaperPath == null ||
                    Global.strConvertedWallpaperPath.Length == 0)

                    Global.strConvertedWallpaperPath = Global.strWallpaperPath;
            }
            catch
            {
                Global.DebugMessage("UIForm.ReadRegistry()");
            }
        }

        /// <summary>
        /// Запишем установки пользователя в реестр
        /// </summary>
        void WriteRegistry()
        {
            try
            {
                RegistryKey regHCU = Registry.CurrentUser;
                RegistryKey regSoftware = regHCU.OpenSubKey("Software", true);

                RegistryKey regMyWallpaper = regSoftware.CreateSubKey("MyWallpaper");
                regMyWallpaper.SetValue("AutoChange", Global.bAutoChange, RegistryValueKind.String);
                regMyWallpaper.SetValue("randomChange", Global.bRandomSelection, RegistryValueKind.String);
                regMyWallpaper.SetValue("LoadChange", Global.bLoadChange, RegistryValueKind.String);

                // Если каталог не выбран, не будем устанавливать значение, чтобы не вызывать исключение.
                if (strDirectoryPicturePath != null)
                    regMyWallpaper.SetValue("strDirectoryPath", strDirectoryPicturePath, RegistryValueKind.String);

                regMyWallpaper.SetValue("waitingChange", Global.iWaitingChange, RegistryValueKind.DWord);
                regMyWallpaper.Close();


                RegistryKey regKeyDesktop = regHCU.OpenSubKey("Control Panel\\Desktop", true);
                switch (Global.rpWayChange)
                {
                    case Global.ReplacePicture.Tile:
                        regKeyDesktop.SetValue("TileWallpaper", "1", RegistryValueKind.String);
                        regKeyDesktop.SetValue("WallpaperStyle", "0", RegistryValueKind.String);
                        break;
                    case Global.ReplacePicture.ActualSize:
                        regKeyDesktop.SetValue("TileWallpaper", "0", RegistryValueKind.String);
                        regKeyDesktop.SetValue("WallpaperStyle", "0", RegistryValueKind.String);
                        break;
                    case Global.ReplacePicture.Stretch:
                        regKeyDesktop.SetValue("TileWallpaper", "0", RegistryValueKind.String);
                        regKeyDesktop.SetValue("WallpaperStyle", "2", RegistryValueKind.String);
                        break;
                }
                regKeyDesktop.Close();

                regSoftware.Close();
                regHCU.Close();
            }
            catch
            {
                Global.DebugMessage("UIForm.WriteRegistry()");
            }
        }

        /// <summary>
        /// Удаление ключа приложения из реестра,
        /// своего рода функция uninstall.
        /// </summary>
        void DeleteRegKey()
        {
            // На случай если ключ приложения не существует
            // заключим код в блок try для предотвращения срабатывания исключения.
            RegistryKey regHCU = null;
            RegistryKey regSoftware = null; 
            try
            {
                regHCU = Registry.CurrentUser;
                regSoftware = regHCU.OpenSubKey("Software", true);
                regSoftware.DeleteSubKey("MyWallpaper");
            }
            catch
            {
            }
            finally
            {
                regSoftware.Close();
                regHCU.Close();
                MessageBox.Show("Приложение успешно удалено!");
            }
        }

        

        /// <summary>
        /// Размещение записи или удаление записи в реестре 
        /// для автоматического запуска приложения
        /// при загрузке операционной системы.
        /// </summary>
        void AutoRunApplication(bool autoRun)
        {
            // HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
            try
            {
                // Создать запись в реестре
                RegistryKey regHCU = Registry.CurrentUser;
                RegistryKey regSoftware = regHCU.OpenSubKey("Software", true);
                RegistryKey regMicrosoft = regSoftware.OpenSubKey("Microsoft", true);
                RegistryKey regWindows = regMicrosoft.OpenSubKey("Windows", true);
                RegistryKey regCurrentVersion = regWindows.OpenSubKey("CurrentVersion", true);
                RegistryKey regRun = regCurrentVersion.OpenSubKey("Run", true);


                if (autoRun == true)
                {
                    regRun.SetValue("ADesktop", Application.ExecutablePath, RegistryValueKind.String);

                }
                else
                {
                    regRun.DeleteValue("ADesktop");
                }

                regRun.Close();
                regCurrentVersion.Close();
                regWindows.Close();
                regMicrosoft.Close();
                regSoftware.Close();
                regHCU.Close();
            }
            catch
            {
                Global.DebugMessage("UIForm.AutoRunApplication");
            }

        }

        /// <summary>
        /// Команда меню - Открыть или закрыть,
        /// при этом приложение или показывается или скрывается.
        /// </summary>
        private void OpenCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Восстанавливаем окно
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// Команда меню - Выход
        /// </summary>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            bCanClose = true;
            Close();
        }

        
        private void notifyIconApp_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

           
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Восстанавливаем окно
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                // Минимизируем окно
                this.WindowState = FormWindowState.Minimized;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("help.htm");
            }
            catch
            {
                MessageBox.Show("Файл помощи отсутствует, скачайте программу на http://www.interestprograms.ru");
            }
        }

       

            
        
    }
}

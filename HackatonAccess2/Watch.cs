using System;
using System.ComponentModel;
using System.IO;

using System.Security.Permissions;
using System.Text;
using System.Windows.Input;

namespace HackatonAccess2
{
    public class Watch : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string text;
        public string Text { get { return text; } set { text = value; NotifyPropertyChanged("Text"); } }
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private Server server;
        private FileSystemWatcher watcher;


        public object voice { get; private set; }

        public Watch()
        {
            server = new Server(5400);
            server.Start();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        {

            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher();

            watcher.Path = "C:\\Users\\yael4\\Desktop\\voice";

            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.mp3";

            // Add event handlers.
            watcher.Created += OnChanged;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
                        
            ///////////////////////////////////////////////////////////////////////////////
            // Specify what is done when a file is changed, created, or deleted.
            Text = e.FullPath;
            // server.Write(e.FullPath);
        }


        private ICommand _sendCommand;
        public ICommand SendCommand
        {
            get
            {
                Console.WriteLine(1);
                return _sendCommand ?? (_sendCommand = new CommandHandler(() => OnPress()));
            }
        }
        private void OnPress()
        {
            byte[] bytesToSend = Encoding.UTF8.GetBytes(Text);
            byte[] intBytes = BitConverter.GetBytes(bytesToSend.Length);
            server.Write(intBytes);
            server.Write(bytesToSend);

        }


    }

}

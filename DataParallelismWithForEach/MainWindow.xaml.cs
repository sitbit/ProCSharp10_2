using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CancellationTokenSource _cancelToken = new();

        public MainWindow()
        {
            InitializeComponent();
            cmdCancel.Click += CmdCancel_Click;
            //cmdCancel.IsEnabled = false;
            cmdClose.Click += CmdClose_Click;
            cmdProcess.Click += CmdProcess_Click;
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            _cancelToken.Cancel();
        }
        private void CmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CmdProcess_Click(object sender, EventArgs e)
        {
            //ParallelProcessFiles();
            //Title = "Starting...";
            _ = Task.Factory.StartNew(() => { ProcessFiles(); });
            //Title = "Processing Complete";
        }

#pragma warning disable IDE0051 // Remove unused private members
        private void ParallelProcessFiles()
        {
            //  Need to slow this down a bit
            int sleep = 100;

            //cmdCancel.IsEnabled = true;
            ParallelOptions parOpts = new()
            {
                CancellationToken = _cancelToken.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Title = "Starting...";

            string basePath = Directory.GetCurrentDirectory();
            int pos = basePath.IndexOf(@"\bin\");
            basePath = basePath[..pos];
            string picPath = Path.Combine(basePath, "TestPics");
            string outPath = Path.Combine(basePath, "Modified");
            if (Directory.Exists(outPath))
            {
                Directory.Delete(outPath, true);
            }
            Directory.CreateDirectory(outPath);
            string[] files = Directory.GetFiles(picPath, "*.jpg", SearchOption.AllDirectories);

            try
            {
                _ = Parallel.ForEach(files, parOpts, file =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    int threadId = Environment.CurrentManagedThreadId;
                    Random r = new();
                    string filename = Path.GetFileName(file);
                    //Dispatcher.Invoke(() => { Title = $"Processing {filename} on thread {threadId}"; });
                    using (Bitmap bmp = new(file))
                    {
                        bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bmp.Save(Path.Combine(outPath, filename));
                    }
                    Thread.Sleep(sleep * r.Next(1, files.Length));
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => Title = ex.Message);
            }
            Title = "Processing Complete";
            //cmdCancel.IsEnabled = false;
        }
        private void ProcessFiles()
        {
            //  Need to slow this down a bit
            int sleep = 1000;

            Dispatcher.Invoke(() => Title = "Starting...");

            string basePath = Directory.GetCurrentDirectory();
            int pos = basePath.IndexOf(@"\bin\");
            basePath = basePath[..pos];
            string picPath = Path.Combine(basePath, "TestPics");
            string outPath = Path.Combine(basePath, "Modified");
            if (Directory.Exists(outPath))
            {
                Directory.Delete(outPath, true);
            }
            Directory.CreateDirectory(outPath);
            string[] files = Directory.GetFiles(picPath, "*.jpg", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                int threadId = Environment.CurrentManagedThreadId;
                Dispatcher.Invoke(() => Title = $"Processing {filename} on thread {threadId}");
                using (Bitmap bmp = new(file))
                {
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bmp.Save(Path.Combine(outPath, filename));
                }
                if (_cancelToken.IsCancellationRequested)
                {
                    break;
                }
                Thread.Sleep(sleep);
            }
            if (_cancelToken.IsCancellationRequested)
            {
                Dispatcher.Invoke(() => Title = "Cancel requested!");
            }
            else
            {
                Dispatcher.Invoke(() => Title = "Processing Complete");
            }
        }
    }
}

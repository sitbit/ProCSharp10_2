using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PictureHandlerWithAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cancelToken;
        private readonly int sleepTime = 2_000;

        public MainWindow()
        {
            InitializeComponent();
            cmdCancel.Content = "Close";
            sbiStatus.Content = "Ready";
        }

        private void CmdCancel_Click(object sender, RoutedEventArgs e)
        {
            if (cmdCancel.Content.ToString() == "Cancel")
            {
                _cancelToken.Cancel();
            }
            else
            {
                Close();
            }
        }
        private async void CmdProcess_Click(object sender, RoutedEventArgs e)
        {
            _cancelToken = new();
            cmdCancel.Content = "Cancel";
            //sbiStatus.Content = "Status: processing...";
            string basePath = Directory.GetCurrentDirectory();
            int pos = basePath.IndexOf(@"\bin\");
            basePath = basePath[..pos];
            string picturePath = Path.Combine(basePath, "TestPics");
            string outDir = Path.Combine(basePath, "ModifiedPics");

            if (Directory.Exists(outDir))
            {
                Directory.Delete(outDir, true);
            }
            Directory.CreateDirectory(outDir);

            string[] files = Directory.GetFiles(picturePath, "*.jpg", SearchOption.AllDirectories);

            try
            {
                foreach (string file in files)
                {
                    try
                    {
                        await ProcessFileAsync(file, outDir, _cancelToken.Token);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
                //throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
            }
            finally
            {
                _cancelToken = null;
                sbiStatus.Content = "Ready";
                cmdCancel.Content = "Close";
            }
        }

        private async Task ProcessFileAsync(string currentFile, string outDir, CancellationToken token)
        {
            string filename = Path.GetFileName(currentFile);
            using (Bitmap bitmap = new(currentFile))
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            sbiStatus.Content = $"Processing {filename}";
                        });
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(outDir, filename));
                        Thread.Sleep(sleepTime);
                    },
                    token);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }
    }
}

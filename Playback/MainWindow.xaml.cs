using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Playback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Mp3FileReader reader;
        private WaveOut output;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog =
                new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                txtruta.Text = openFileDialog.FileName;
            }
        }

        private void btnplay_Click(object sender, RoutedEventArgs e)
        {
            if (txtruta.Text != null && txtruta.Text != "")
            {
                output = new WaveOut();
                output.PlaybackStopped += OnPlaybackStop;
                reader = new Mp3FileReader(txtruta.Text);
                output.Init(reader);
                output.Play();
            }else
            {
                //Avisarle al usuario que elija un archivo
            }
        }

        private void OnPlaybackStop(object sender, StoppedEventArgs e)
        {
            reader.Dispose();
            output.Dispose();
        }

        private void btnstop_Click(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                output.Stop();
            }
        }
    }
}

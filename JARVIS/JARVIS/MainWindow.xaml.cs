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
using System.Speech.Recognition;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;

namespace JARVIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        SpeechRecognitionEngine speechReconitionEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer JARVIS = new SpeechSynthesizer();


        public MainWindow()
        {
            InitializeComponent();
            
                //hook to events
                speechReconitionEngine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(engine_AudioLevelUpdated);
                speechReconitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(engine_SpeechReconized);
                // Load Grammar And Comands
                LoadGrammarAndCommands();
                //use system default mic
                speechReconitionEngine.SetInputToDefaultAudioDevice();
                //start listening

                speechReconitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                JARVIS.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(JARVIS_SpeakCompleted);

                if (JARVIS.State == SynthesizerState.Speaking)
                    JARVIS.SpeakAsyncCancelAll();

         
            JARVIS.SpeakAsync("Hello, how can I help you?");
        }

       
        



        private void JARVIS_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (JARVIS.State == SynthesizerState.Speaking)
                JARVIS.SpeakAsyncCancelAll();
        }

        private void LoadGrammarAndCommands()
        {
            try
            {
                Choices Text = new Choices();
                string[] Lines = File.ReadAllLines(Environment.CurrentDirectory + "\\Commands.txt");
                Text.Add(Lines);
                Grammar WorldList = new Grammar(new GrammarBuilder(Text));
                speechReconitionEngine.LoadGrammar(WorldList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
       
        private void engine_SpeechReconized(object sender, SpeechRecognizedEventArgs e)
        {
            string Speech = e.Result.Text;
            switch (Speech)
            {


                case "google":
                    
                    System.Diagnostics.Process.Start("http://www.google.com");

                    break;
                case "facebook":
                    
                    System.Diagnostics.Process.Start("http://www.facebook.com");
                    break;


                case "date":
                    JARVIS.SpeakAsync(DateTime.Now.Date.ToString());
                    break;

                case "close":
                    Application.Current.Shutdown();
                    break;



            }
        }

        private void engine_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            progress.Value = e.AudioLevel;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }

}

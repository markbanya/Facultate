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

namespace runWPFrun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            InitializeComponent();

            this.raceTrack.ItemsSource = CreateRacePersons();

            this.Loaded += delegate { this.StartRace(); };
            this.lnkStartNewRace.Click += delegate { this.StartRace(); };

        }
        void StartRace()
        {
            foreach (RacePerson racePerson in this.raceTrack.Items)
                racePerson.StartNewRace();
        }

        static List<RacePerson> CreateRacePersons()
        {
            List<RacePerson> racePerson = new List<RacePerson>(7);

           racePerson.Add(new RacePerson("Usain Bolt"));
            racePerson.Add(new RacePerson("Yohan Blake"));
            racePerson.Add(new RacePerson("Walter Dix"));
            racePerson.Add(new RacePerson("Tyson Gay"));
            racePerson.Add(new RacePerson("Christophe Lemaitre"));
            racePerson.Add(new RacePerson("Churandy Martina"));
            racePerson.Add(new RacePerson("Mark Banya"));






            return racePerson;
        }
    }
}
    


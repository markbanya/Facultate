using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace runWPFrun
{
    public class RacePerson : INotifyPropertyChanged
    {

        #region Data
        //Static fields
        readonly static Random random;
        static RacePerson raceWinner = null;

        //instance fields
        readonly DispatcherTimer timer = new DispatcherTimer();
        readonly string name;
        int percentComplete;

        #endregion

        #region Constructor
        static RacePerson()
        {
            RacePerson.random = new Random(DateTime.Now.Millisecond);
        }
        public RacePerson(string name)
        {
            this.name = name;
            this.percentComplete = 0;
            this.timer.Tick += this.timer_Tick;
        }
        #endregion

        #region Public Properties

        public bool IsFinished
        {
            get { return this.PercentComplete >= 100; }
        }

        public bool IsWinner
        {
            get { return RacePerson.raceWinner == this;
               
            }
        }

        public string Name
        {
            get { return this.name; }
        }

        public int PercentComplete 
        {
            get { return this.percentComplete; }
            private set
            {
                if (this.percentComplete == value)
                    return;

                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("PercentComplete");

                bool wasFinished = this.IsFinished;

                this.percentComplete = value;

                this.RaisePropertyChanged("PercentComplete");

                if (wasFinished != this.IsFinished)
                {
                    if (this.IsFinished && RacePerson.raceWinner == null)
                    {
                       RacePerson.raceWinner = this;
                        this.RaisePropertyChanged("IsWinner");
                    }

                    this.RaisePropertyChanged("IsFinished");
                }

                // In case this horse was the previous winner and a new race has begun,
                // notify the world that the IsWinner property has changed on this horse.
                if (wasFinished && value == 0)
                    this.RaisePropertyChanged("IsWinner");
            }
        }

        #endregion // Public Properties

        #region Public Methods

        public void StartNewRace()
        {
            // When a race begins, remove a reference to the previous winner.
            if (RacePerson.raceWinner != null)
                RacePerson.raceWinner = null;

            // Put the person back at the start of the track.
            this.PercentComplete = 0;

            // Give the person a random "speed" to run at.
            this.timer.Interval = TimeSpan.FromMilliseconds(RacePerson.random.Next(20, 100));

            // Start the DispatcherTimer, which ticks when the person should "move."
            if (!this.timer.IsEnabled)
                this.timer.Start();
        }

        #endregion // Public Methods	





        #region timer_Tick

        void timer_Tick(object sender, EventArgs e)
        {
            if (!this.IsFinished)
                ++this.PercentComplete;

            if (this.IsFinished)
                this.timer.Stop();
        }

        #endregion // timer_Tick

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

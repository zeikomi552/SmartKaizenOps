using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartKaizenOps.Views
{
    /// <summary>
    /// MediaPlayer.xaml の相互作用ロジック
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        #region Properties

        protected Storyboard TimelineStory
        {
            get { return (Storyboard)this.FindResource(nameof(TimelineStory)); }
        }

        protected bool IsPlaying
        {
            get { return this.Media.Clock != null && !this.IsPaused && !this.IsStopped; }
        }

        protected bool IsPaused
        {
            get { return this.Media.Clock != null && this.Media.Clock.IsPaused; }
        }

        protected bool IsStopped
        {
            get { return this.Media.Clock == null || this.Media.Clock.CurrentState.HasFlag(ClockState.Stopped); }
        }

        #endregion

        #region Constructors

        public MediaPlayer()
        {
            InitializeComponent();
        }

        #endregion


        #region Control Events

       

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            this.Stop();
        }

        #endregion

        #region Methods

        public void Play()
        {
            if (this.IsStopped)
            {
                this.TimelineStory.Begin();
            }
            if (this.IsPaused)
            {
                this.TimelineStory.Resume();
            }
        }

        public void Play(TimeSpan position)
        {
            this.Seek(position);
            this.Play();
        }

        public void Seek(TimeSpan timeSpan)
        {
            var value = timeSpan;
            if (value.TotalMilliseconds < 0)
            {
                value = new TimeSpan();
            }
            this.TimelineStory.Seek(value);
        }

        public void Rewind(TimeSpan timeSpan)
        {
            this.Seek(TimeSpan.FromMilliseconds(this.SeekSlider.Value).Subtract(timeSpan));
        }

        public void Forward(TimeSpan timeSpan)
        {
            this.Seek(TimeSpan.FromMilliseconds(this.SeekSlider.Value).Add(timeSpan));
        }

        public void Pause()
        {
            this.TimelineStory.Pause();
        }

        public void Stop()
        {
            this.TimelineStory.Stop();
        }

        #endregion

    }
}

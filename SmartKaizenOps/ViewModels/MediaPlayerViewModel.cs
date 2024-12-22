using Microsoft.Win32;
using SmartKaizenOps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SmartKaizenOps.ViewModels
{
    public class MediaPlayerViewModel : BindableBase, IDialogAware
    {
        #region IDialogAware Overwrite

        public string Title
        {
            get { return "Control Panel"; }
        }


        private DelegateCommand<string>? _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));
        public DialogCloseListener RequestClose { get; }

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return false;
        }

        public virtual void OnDialogClosed()
        {

        }
        public virtual void OnDialogOpened(IDialogParameters parameters)
        {

        }
        #endregion


        #region Properties

        //protected Storyboard TimelineStory
        //{
        //    get { return (Storyboard)this.FindResource(nameof(TimelineStory)); }
        //}

        protected bool IsPlaying
        {
            get { return this._Media!.Clock != null && !this.IsPaused && !this.IsStopped; }
        }

        protected bool IsPaused
        {
            get { return this._Media!.Clock != null && this._Media!.Clock.IsPaused; }
        }

        protected bool IsStopped
        {
            get { return this._Media!.Clock == null || this._Media!.Clock.CurrentState.HasFlag(ClockState.Stopped); }
        }

        #endregion

        #region Movie制御クラス
        /// <summary>
        /// Movie制御クラス
        /// </summary>
        IMovieControlerModel? _MovieControler;
        /// <summary>
        /// Movie制御クラス
        /// </summary>
        public IMovieControlerModel? MovieControler
        {
            get
            {
                return _MovieControler;
            }
            set
            {
                if (_MovieControler == null || !_MovieControler.Equals(value))
                {
                    _MovieControler = value;
                    RaisePropertyChanged("MovieControler");
                }
            }
        }
        #endregion

        #region 動画位置
        /// <summary>
        /// 動画位置
        /// </summary>
        double _SeekValue = 0.0;
        /// <summary>
        /// 動画位置
        /// </summary>
        public double SeekValue
        {
            get
            {
                return _SeekValue;
            }
            set
            {
                if (!_SeekValue.Equals(value))
                {
                    _SeekValue = value;
                    RaisePropertyChanged("SeekValue");
                }
            }
        }
        #endregion

        #region 動画位置最大値
        /// <summary>
        /// 動画位置最大値
        /// </summary>
        double _SeekMaxValue = 0.0;
        /// <summary>
        /// 動画位置最大値
        /// </summary>
        public double SeekMaxValue
        {
            get
            {
                return _SeekMaxValue;
            }
            set
            {
                if (!_SeekMaxValue.Equals(value))
                {
                    _SeekMaxValue = value;
                    RaisePropertyChanged("SeekMaxValue");
                }
            }
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MediaPlayerViewModel(IMovieControlerModel movie_ctrl)
        {
            this.MovieControler = movie_ctrl;
        }
        #endregion

        Storyboard? _Storyboard;

        public void Timeline_Loaded(object sender, RoutedEventArgs e)
        {
            _Storyboard = sender as Storyboard;
        }

        public void Media_Loaded(object sender, RoutedEventArgs e)
        {
            _Media = sender as MediaElement;

            //if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            //{
            //    return;
            //}
            ////this.Play();
            //this.Stop();
        }

        MediaElement? _Media;

        public void Media_MediaOpened(object sender, EventArgs e)
        {
            if (_Media != null)
            {
                this.SeekMaxValue = _Media.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
        }

        public void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            //this.Stop();
        }

        public void Media_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (this.IsPlaying)
            //{
            //    this.Pause();
            //}
            //if (this.IsStopped)
            //{
            //    this.Play();
            //}
            //if (this.IsPaused)
            //{
            //    this.Play(TimeSpan.FromMilliseconds(this.SeekSlider.Value));
            //}
        }


        public void MediaTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            //this.SeekSlider.Value = this.Media.Position.TotalMilliseconds;
        }

        public void SeekSlider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.SeekSlider.IsMoveToPointEnabled = true;
            //if (this.IsPlaying)
            //{
            //    this.Pause();
            //}
            //if (this.IsStopped)
            //{
            //    this.Play(TimeSpan.FromMilliseconds(this.SeekSlider.Value));
            //    this.Pause();
            //}
        }

        public void SeekSlider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (this.IsPaused)
            //{
            //    this.Play(TimeSpan.FromMilliseconds(this.SeekSlider.Value));
            //}
            //this.SeekSlider.IsMoveToPointEnabled = false;
        }
        public void SeekSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (this.SeekSlider.IsMoveToPointEnabled)
            //{
            //    this.TimelineStory.Seek(TimeSpan.FromMilliseconds(this.SeekSlider.Value));
            //}
        }


        public void Media_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //if (this.IsStopped == false && this.IsPaused)
            //{
            //    if (e.Delta > 0)
            //    {
            //        SeekSlider.Value += 100;
            //        this.TimelineStory.Seek(TimeSpan.FromMilliseconds(this.SeekSlider.Value));
            //        Debug.WriteLine(SeekSlider.Value);
            //    }
            //    else
            //    {
            //        SeekSlider.Value -= 100;
            //        this.TimelineStory.Seek(TimeSpan.FromMilliseconds(this.SeekSlider.Value));
            //        Debug.WriteLine(SeekSlider.Value);
            //    }
            //}
        }


        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Play();
        }

        public void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Pause();
        }

        public void StopButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Stop();
        }


        #region Methods

        public void Play()
        {
            if (this.IsStopped)
            {
                this._Storyboard!.Begin();
            }
            if (this.IsPaused)
            {
                this._Storyboard!.Resume();
            }
        }

        public void Seek(TimeSpan timeSpan)
        {
            var value = timeSpan;
            if (value.TotalMilliseconds < 0)
            {
                value = new TimeSpan();
            }
            this._Storyboard!.Seek(value);
        }

        public void Play(TimeSpan position)
        {
            this.Seek(position);
            this.Play();
        }

        public void Rewind(TimeSpan timeSpan)
        {
            this.Seek(TimeSpan.FromMilliseconds(this.SeekValue).Subtract(timeSpan));
        }

        public void Forward(TimeSpan timeSpan)
        {
            this.Seek(TimeSpan.FromMilliseconds(this.SeekValue).Add(timeSpan));
        }

        public void Pause()
        {
            this._Storyboard!.Pause();
        }

        public void Stop()
        {
            this._Storyboard!.Stop();
        }

        #endregion
    }
}

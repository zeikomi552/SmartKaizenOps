using Microsoft.Win32;
using SmartKaizenOps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MediaPlayerViewModel(IMovieControlerModel movie_ctrl)
        {
            this.MovieControler = movie_ctrl;
        }
        #endregion

        public void Media_Loaded(object sender, RoutedEventArgs e)
        {
            //if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            //{
            //    return;
            //}
            ////this.Play();
            //this.Stop();
        }


        public void Media_MediaOpened(object sender, EventArgs e)
        {
            //this.SeekSlider.Maximum = this.Media.NaturalDuration.TimeSpan.TotalMilliseconds;
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
    }
}

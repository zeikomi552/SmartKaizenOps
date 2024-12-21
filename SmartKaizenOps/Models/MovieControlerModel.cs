using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartKaizenOps.Models
{
    public class MovieControlerModel : BindableBase, IMovieControlerModel
    {
        public MovieControlerModel()
        {
            ExecuteFileOpenCommand = new DelegateCommand(FileOpenExecute, CanExecute);
            ExecuteMovieCut = new DelegateCommand(MovieCutExecute, CanExecute);
        }

        #region 動画スピード
        /// <summary>
        /// 動画スピード
        /// </summary>
        double _SpeedRatio = 1;
        /// <summary>
        /// 動画スピード
        /// </summary>
        public double SpeedRatio
        {
            get
            {
                return _SpeedRatio;
            }
            set
            {
                if (!_SpeedRatio.Equals(value))
                {
                    _SpeedRatio = value;
                    RaisePropertyChanged("SpeedRatio");
                }
            }
        }
        #endregion

        #region 動画位置
        /// <summary>
        /// 動画位置
        /// </summary>
        TimeSpan _Position = new TimeSpan();
        /// <summary>
        /// 動画位置
        /// </summary>
        public TimeSpan Position
        {
            get
            {
                return _Position;
            }
            set
            {
                if (!_Position.Equals(value))
                {
                    _Position = value;
                    RaisePropertyChanged("Position");
                }
            }
        }
        #endregion


        #region 動画のパス
        /// <summary>
        /// 動画のパス
        /// </summary>
        string _MoviePath = string.Empty;
        /// <summary>
        /// 動画のパス
        /// </summary>
        public string MoviePath
        {
            get
            {
                return _MoviePath;
            }
            set
            {
                if (_MoviePath == null || !_MoviePath.Equals(value))
                {
                    _MoviePath = value;
                    RaisePropertyChanged("MoviePath");
                }
            }
        }
        #endregion

        #region 動画スライス要素
        /// <summary>
        /// 動画スライス要素
        /// </summary>
        MovieSliceCollectionModel _MovieSliceItems = new MovieSliceCollectionModel();
        /// <summary>
        /// 動画スライス要素
        /// </summary>
        public MovieSliceCollectionModel MovieSliceItems
        {
            get
            {
                return _MovieSliceItems;
            }
            set
            {
                if (_MovieSliceItems == null || !_MovieSliceItems.Equals(value))
                {
                    _MovieSliceItems = value;
                    RaisePropertyChanged("MovieSliceItems");
                }
            }
        }
        #endregion


        public DelegateCommand? ExecuteFileOpenCommand { get; set; }


        public DelegateCommand? ExecuteMovieCut { get; set; }

        #region ファイルを開く処理
        /// <summary>
        /// ファイルを開く処理
        /// </summary>
        private void FileOpenExecute()
        {
            try
            {
                // ダイアログのインスタンスを生成
                var dialog = new OpenFileDialog();

                // ファイルの種類を設定
                dialog.Filter = "動画ファイル (*.mkv)|*.mkv|全てのファイル (*.*)|*.*";

                // ダイアログを表示する
                if (dialog.ShowDialog() == true)
                {
                    // 選択されたファイル名 (ファイルパス) をメッセージボックスに表示
                    this.MoviePath = dialog.FileName;
                }
            }
            catch
            {

            }
        }
        private bool CanExecute()
        {
            return true;
        }
        #endregion

        private void MovieCutExecute()
        {
            try
            {
                
            }
            catch
            {

            }
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace SmartKaizenOps.Models
{
    public class MovieControlerModel : BindableBase, IMovieControlerModel
    {
        public MovieControlerModel()
        {
            ExecuteFileOpenCommand = new DelegateCommand(FileOpenExecute, CanExecute);
        }

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

        #region 動画再生位置
        /// <summary>
        /// 動画再生位置
        /// </summary>
        double _MoviePositionValue = 0.0;
        /// <summary>
        /// 動画再生位置
        /// </summary>
        public double MoviePositionValue
        {
            get
            {
                return _MoviePositionValue;
            }
            set
            {
                if (!_MoviePositionValue.Equals(value))
                {
                    _MoviePositionValue = value;
                    RaisePropertyChanged("MoviePositionValue");
                }
            }
        }
        #endregion

        #region 動画の長さ(ミリ秒)
        /// <summary>
        /// 動画の長さ(ミリ秒)
        /// </summary>
        double _MovieLength = 0.0;
        /// <summary>
        /// 動画の長さ(ミリ秒)
        /// </summary>
        public double MovieLength
        {
            get
            {
                return _MovieLength;
            }
            set
            {
                if (!_MovieLength.Equals(value))
                {
                    _MovieLength = value;
                    RaisePropertyChanged("MovieLength");
                }
            }
        }
        #endregion



        [XmlIgnore]
        public DelegateCommand? ExecuteFileOpenCommand { get; set; }

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

    }
}

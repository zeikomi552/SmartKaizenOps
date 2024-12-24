using Microsoft.Win32;
using SmartKaizenOps.Common.Utilities;
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

        #region 追加モード
        /// <summary>
        /// 追加モード
        /// </summary>
        bool _AddMode = true;
        /// <summary>
        /// 追加モード
        /// </summary>
        public bool AddMode
        {
            get
            {
                return _AddMode;
            }
            set
            {
                if (!_AddMode.Equals(value))
                {
                    _AddMode = value;
                    RaisePropertyChanged("AddMode");
                }
            }
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

        public void MouseRightButtonDown()
        {
            // 追加モード
            if (this.AddMode)
            {
                this.MovieControler!.MovieSliceItems.Items.Add(new MovieSliceModel()
                {
                    Parent = this.MovieControler!.MovieSliceItems,
                    ElementName = "Element",
                    MoviePositionValue = this.MovieControler.MoviePositionValue,
                    Length = this.MovieControler.MovieLength - this.MovieControler.MoviePositionValue
                }
                );
            }
            // 修正モード
            else
            {
                // 修正モードで要素作業が存在しない場合抜ける
                if (this.MovieControler == null)
                {
                    return;
                }

                // 選択位置を取得
                int index = this.MovieControler.MovieSliceItems.Items.IndexOf(this.MovieControler.MovieSliceItems.SelectedItem);

                // 選択されていない場合は最初の項目を選択
                if (index < 0)
                {
                    this.MovieControler.MovieSliceItems.SelectedItem = this.MovieControler.MovieSliceItems.Items.ElementAt(0);
                }

                // 値を修正
                this.MovieControler.MovieSliceItems.SelectedItem.MoviePositionValue = this.MovieControler.MoviePositionValue;
            }

            for (int i = 0; i < this.MovieControler.MovieSliceItems.Items.Count; i ++)
            {
                if (this.MovieControler.MovieSliceItems.Items.Count > i + 1)
                {
                    if (this.MovieControler.MovieSliceItems.Items.ElementAt(i + 1).MoviePositionValue < this.MovieControler.MovieSliceItems.Items.ElementAt(i).MoviePositionValue)
                    {
                        this.MovieControler.MovieSliceItems.Items.ElementAt(i).Length = 0;
                        this.MovieControler.MovieSliceItems.Items.ElementAt(i + 1).MoviePositionValue = this.MovieControler.MovieSliceItems.Items.ElementAt(i).MoviePositionValue;
                    }
                    else
                    {
                        this.MovieControler.MovieSliceItems.Items.ElementAt(i).Length
                            = this.MovieControler.MovieSliceItems.Items.ElementAt(i + 1).MoviePositionValue - this.MovieControler.MovieSliceItems.Items.ElementAt(i).MoviePositionValue;
                    }
                }
                else
                {
                    this.MovieControler.MovieSliceItems.Items.ElementAt(i).Length
                        = this.MovieControler.MovieLength - this.MovieControler.MovieSliceItems.Items.ElementAt(i).MoviePositionValue;

                }
            }

        }

        public void SelectionChanged()
        {
            if (this.MovieControler != null && this.MovieControler.MovieSliceItems.SelectedItem != null)
            {
                this.MovieControler!.MoviePositionValue
                    = this.MovieControler.MovieSliceItems.SelectedItem.MoviePositionValue;
            }
        }

        public void FileSave()
        {
            try
            {
                // ダイアログのインスタンスを生成
                var dialog = new SaveFileDialog();

                // ファイルの種類を設定
                dialog.Filter = "テキストファイル (*.skops)|*.skops";

                // ダイアログを表示する
                if (dialog.ShowDialog() == true)
                {
                    XMLUtil.Seialize<MovieControlerModel>(dialog.FileName, MovieControler as MovieControlerModel);
                }
            }
            catch
            {

            }
        }

        public void FileLoad()
        {
            try
            {
                // ダイアログのインスタンスを生成
                var dialog = new OpenFileDialog();

                // ファイルの種類を設定
                dialog.Filter = "テキストファイル (*.skops)|*.skops";

                // ダイアログを表示する
                if (dialog.ShowDialog() == true)
                {
                    var tmp = XMLUtil.Deserialize<MovieControlerModel>(dialog.FileName);
                    this.MovieControler = tmp;
                }
            }
            catch
            {

            }
        }
    }
}

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKaizenOps.Models
{
    public class MovieSliceModel : BindableBase
    {
        #region 要素作業名
        /// <summary>
        /// 要素作業名
        /// </summary>
        string _ElementName = string.Empty;
        /// <summary>
        /// 要素作業名
        /// </summary>
        public string ElementName
        {
            get
            {
                return _ElementName;
            }
            set
            {
                if (_ElementName == null || !_ElementName.Equals(value))
                {
                    _ElementName = value;
                    RaisePropertyChanged("ElementName");
                }
            }
        }
        #endregion



        #region 開始秒
        /// <summary>
        /// 開始秒
        /// </summary>
        decimal _StartSecond = 0;
        /// <summary>
        /// 開始秒
        /// </summary>
        public decimal StartSecond
        {
            get
            {
                return _StartSecond;
            }
            set
            {
                if (!_StartSecond.Equals(value))
                {
                    _StartSecond = value;
                    RaisePropertyChanged("StartSecond");
                }
            }
        }
        #endregion

        #region 長さ
        /// <summary>
        /// 長さ
        /// </summary>
        decimal _Length = 0;
        /// <summary>
        /// 長さ
        /// </summary>
        public decimal Length
        {
            get
            {
                return _Length;
            }
            set
            {
                if (!_Length.Equals(value))
                {
                    _Length = value;
                    RaisePropertyChanged("Length");
                }
            }
        }
        #endregion


    }
}

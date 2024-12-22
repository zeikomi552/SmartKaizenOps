using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKaizenOps.Models
{
    public class MovieSliceModel : BindableBase
    {
        public MovieSliceCollectionModel? Parent { get; set; }

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

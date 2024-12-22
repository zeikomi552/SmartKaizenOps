using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartKaizenOps.Models
{
    public class MovieSliceCollectionModel : BindableBase
    {
        #region 要素
        /// <summary>
        /// 要素
        /// </summary>
        ObservableCollection<MovieSliceModel> _Items = new ObservableCollection<MovieSliceModel>();
        /// <summary>
        /// 要素
        /// </summary>
        public ObservableCollection<MovieSliceModel> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                if (_Items == null || !_Items.Equals(value))
                {
                    _Items = value;
                    RaisePropertyChanged("Items");
                }
            }
        }
        #endregion

        #region 選択要素
        /// <summary>
        /// 選択要素
        /// </summary>
        MovieSliceModel _SelectedItem = new MovieSliceModel();
        /// <summary>
        /// 選択要素
        /// </summary>
        [XmlIgnore]
        public MovieSliceModel SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if (_SelectedItem == null || !_SelectedItem.Equals(value))
                {
                    _SelectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace SmartKaizenOps.Common.Helper
{
    public class MediaElementHelper
    {
        /// <summary>
        /// ViewModelから制御するための依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty SpeedRatioProperty =
            DependencyProperty.RegisterAttached(
                "SpeedRatio",
                typeof(double),
                typeof(MediaElementHelper),
                new PropertyMetadata((d, e) =>
                {
                    var mediaElement = d as MediaElement;

                    if (mediaElement != null)
                    {
                        mediaElement.SpeedRatio = Convert.ToDouble(e.NewValue);
                    }
                }));

        /// <summary>
        /// Xamlから添付プロパティとして設定させるためのメソッド
        /// </summary>
        public static void SetSpeedRatio(MediaElement target, int value)
        {
            target.SetValue(SpeedRatioProperty, value);
        }

        /// <summary>
        /// ViewModelから制御するための依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached(
                "Position",
                typeof(TimeSpan),
                typeof(MediaElementHelper),
                new PropertyMetadata((d, e) =>
                {
                    var mediaElement = d as MediaElement;

                    if (mediaElement != null)
                    {
                        mediaElement.Position = (TimeSpan)e.NewValue;
                    }
                }));

        /// <summary>
        /// Xamlから添付プロパティとして設定させるためのメソッド
        /// </summary>
        public static void SetPosition(MediaElement target, TimeSpan value)
        {
            target.SetValue(PositionProperty, value);
        }
        public static TimeSpan GetPosition(MediaElement target)
        {
            return (TimeSpan)target.GetValue(PositionProperty);
        }

    }
}

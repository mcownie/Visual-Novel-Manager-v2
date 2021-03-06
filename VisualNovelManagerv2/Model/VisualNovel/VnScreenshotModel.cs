﻿using System.Windows;
using System.Windows.Media.Imaging;

namespace VisualNovelManagerv2.Model.VisualNovel
{
    public class VnScreenshotModel: DependencyObject    
    {


        public BitmapSource Screenshot
        {
            get { return (BitmapSource)GetValue(ScScreenshotProperty); }
            set { SetValue(ScScreenshotProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Screenshot.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScScreenshotProperty =
            DependencyProperty.Register("ScScreenshot", typeof(BitmapSource), typeof(VnScreenshotModel), new PropertyMetadata(null));


    }
}

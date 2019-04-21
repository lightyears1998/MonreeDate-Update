﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 倒计时
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Details : Page
    {
        public Details()
        {
            this.InitializeComponent();
            //this.NavigationCacheMode = NavigationCacheMode.Enabled;
            DetailsPickedDate.Text = All.Current.str1;
            DetailsEvent.Text = All.Current.str3;
            DetailsDate.Text = All.Current.str2;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            //{
            //    InitialText.Text = $"Hi, {e.Parameter.ToString()}";
            //}
            //else
            //{
            //    InitialText.Text = "Hi!";
            //}
            //base.OnNavigatedTo(e);
        }

    }
}

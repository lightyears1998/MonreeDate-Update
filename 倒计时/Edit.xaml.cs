﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class Edit : Page
    {
        public double MinMyNav = MainPage.Current.MyNav.CompactModeThresholdWidth;
        public string EditBirthday_Date;
        public string EditSex_Sex;
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public Edit()
        {
            this.InitializeComponent();
            SetThemeColor();
            EditNickName.Text = Settings.Current.PersonalNickName.Text;
            EditSign.Text = Settings.Current.PersonalSign.Text;
            if(Settings.Current.PersonalSex.Text != "未选择")
            {
                if (Settings.Current.PersonalSex.Text == "男")
                    EditSex.SelectedIndex = 0;
                else
                    EditSex.SelectedIndex = 1;
            }
            if(Settings.Current.PersonalBirthday.Text!="未设置")
                EditBirthday.Date = Convert.ToDateTime(Settings.Current.PersonalBirthday.Text);
            MainPage.Current.MyNav.IsBackEnabled = true;
            MainPage.Current.SelectedPageItem = "Edit";
        }

        private void SetThemeColor()
        {
            if (localSettings.Values["ThemeColor"] == null)
                localSettings.Values["ThemeColor"] = "CornflowerBlue";
            switch (localSettings.Values["ThemeColor"].ToString())
            {
                case "CornflowerBlue":
                    TC.Color = Colors.CornflowerBlue;
                    break;
                case "DeepSkyBlue":
                    TC.Color = Colors.DeepSkyBlue;
                    break;
                case "Orange":
                    TC.Color = Colors.Orange;
                    break;
                case "Crimson":
                    TC.Color = Colors.Crimson;
                    break;
                case "Gray":
                    TC.Color = Color.FromArgb(255, 73, 92, 105);
                    break;
                default:
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditSex_Sex = EditSex.SelectedItem.ToString();
        }

        private void Add_Picker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            string Picker = EditBirthday.Date.ToString();
            DateTime s1 = Convert.ToDateTime(Picker);
            EditBirthday_Date = string.Format("{0}/{1}/{2}", s1.Year, s1.Month, s1.Day);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (EditNickName.Text != null
                && EditSign.Text != null
                && EditBirthday_Date != null
                && EditSex_Sex != null
                && EditNickName.Text != ""
                && EditSign.Text != ""
                && EditSex_Sex != ""
                && EditBirthday_Date != "")
            {
                Settings.Current.PersonalNickName.Text = EditNickName.Text;
                Settings.Current.PersonalSign.Text = EditSign.Text;
                Settings.Current.PersonalBirthday.Text = EditBirthday_Date;
                Settings.Current.PersonalSex.Text = EditSex_Sex;
                localSettings.Values["NickName"] = EditNickName.Text;
                localSettings.Values["Sign"] = EditSign.Text;
                localSettings.Values["PersonalSex"] = EditSex_Sex;
                localSettings.Values["BirthDay_Date"] = EditBirthday_Date;
                Frame.Navigate(typeof(Settings));
                PopupNotice popupNotice = new PopupNotice("个人信息已更新");
                popupNotice.ShowAPopup();
            }
            else
            {
                MessageDialog AboutDialog = new MessageDialog("请确保填入完整的信息！");
                await AboutDialog.ShowAsync();
            }
            
        }
    }
}

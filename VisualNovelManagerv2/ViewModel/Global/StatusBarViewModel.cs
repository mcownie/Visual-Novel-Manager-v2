﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

// ReSharper disable ExplicitCallerInfoArgument

namespace VisualNovelManagerv2.ViewModel.Global
{
    public class StatusBarViewModel: ViewModelBase
    {
        public StatusBarViewModel() { }

        #region IsDatabaseProcessing
        private bool _isDbProcessing = false;
        public bool IsDbProcessing
        {
            get { return _isDbProcessing; }
            set
            {
                _isDbProcessing = value;
                RaisePropertyChanged(nameof(IsDbProcessing));
            }
        }
        #endregion

        #region IsUploading
        private bool _isUploading;
        public bool IsUploading
        {
            get { return _isUploading; }
            set
            {
                _isUploading = value;
                RaisePropertyChanged(nameof(IsUploading));
            }
        }
        #endregion

        #region IsDownloading
        private bool _isDownloading;
        public bool IsDownloading
        {
            get { return _isDownloading; }
            set
            {
                _isDownloading = value;
                RaisePropertyChanged(nameof(IsDownloading));
            }
        }
        #endregion

        #region IsWorkProcessing
        private bool _isWorkProcessing;
        public bool IsWorkProcessing
        {
            get { return _isWorkProcessing; }
            set
            {
                _isWorkProcessing = value;
                RaisePropertyChanged(nameof(IsWorkProcessing));
            }
        }
        #endregion

        #region IsShowOnlineStatusEnabled
        private bool _isShowOnlineStatusEnabled;
        public bool IsShowOnlineStatusEnabled
        {
            get { return _isShowOnlineStatusEnabled; }
            set
            {
                _isShowOnlineStatusEnabled = value;
                RaisePropertyChanged(nameof(IsShowOnlineStatusEnabled));
            }
        }
        #endregion

        #region OnlineStatusColor
        private string _onlineStatusColor;
        public string OnlineStatusColor
        {
            get { return _onlineStatusColor; }
            set
            {
                //OrangeRed for offline, DeepSkyBlue for online
                _onlineStatusColor = value;
                RaisePropertyChanged(nameof(OnlineStatusColor));
            }
        }
        #endregion

        #region ProgressPercentage
        private double? _progressPercentage;
        public double? ProgressPercentage
        {
            get { return _progressPercentage; }
            set
            {
                if (value != null)
                {
                    value = Math.Round((double)value, 0);
                    _progressPercentage = value;
                    RaisePropertyChanged(nameof(ProgressPercentage));
                }
                else
                {
                    _progressPercentage = null;
                    RaisePropertyChanged(nameof(ProgressPercentage));
                }                                
            }
        }
        #endregion

        #region ProgressText
        private string _progressText;
        public string ProgressText
        {
            get { return _progressText; }
            set
            {
                _progressText = value;
                RaisePropertyChanged(nameof(ProgressText));
            }
        }
        #endregion

        #region Message
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }
        #endregion

        public void SetOnlineStatusColor(bool value)
        {
            switch (value)
            {
                case true:
                    OnlineStatusColor = "DeepSkyBlue";
                    break;
                case false:
                    OnlineStatusColor = "OrangeRed";
                    break;
                default:
                    OnlineStatusColor = String.Empty;
                    break;
            }
        }
    }
}

﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using ControlzEx.Theming;
using Resizer.Domain.Infrastructure.Events;
using Resizer.Domain.Infrastructure.Messenger;
using Resizer.Domain.Settings;
using Resizer.Gui.Infrastructure.Common.Command;
using Resizer.Gui.Infrastructure.Common.ViewModel;
using Resizer.Gui.Settings;

namespace Resizer.Gui.Window
{
    /// <summary>
    /// Defines a class that provides and handles application information
    /// </summary>
    public class WindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the version of the application
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets or Sets the state of the menu
        /// </summary>
        public bool MenuIsOpen
        {
            get => _menuIsOpen;
            set => SetProperty(ref _menuIsOpen, value);
        }

        private bool _menuIsOpen;

        /// <summary>
        /// Gets or Sets an idicator that defines if the window should be minimized when closed
        /// </summary>
        public bool MinimizeOnClose { get; set; }

        /// <summary>
        /// <see cref="ISettingFactory"/> used to load the application settings on creation
        /// </summary>
        private readonly ISettingFactory _settingFactory;

        /// <summary>
        /// <see cref="IEventAggregator"/> used to be notified when the general setting have changed
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Gets the <see cref="ApplicationSettingsViewModel"/>
        /// </summary>
        public ApplicationSettingsViewModel ApplicationSettings { get; }

        /// <summary>
        /// Shows the project source code on Github
        /// </summary>
        public DelegateCommand ShowSourceOnGithubCommand { get; }

        /// <summary>
        /// Shows the project versions on Github
        /// </summary>
        public DelegateCommand ShowVersionsOnGithubCommand { get; }

        public DelegateCommand WindowLoadedCommand { get; }

        /// <summary>
        /// Create a new instance of the <see cref="WindowViewModel"/>
        /// </summary>
        /// <param name="generalSettings">Instance of the <see cref="ApplicationSettingsViewModel"/></param>
        public WindowViewModel(ISettingFactory settingFactory, IEventAggregator eventAggregator, ApplicationSettingsViewModel applicationSettings)
        {
            _settingFactory = settingFactory ?? throw new ArgumentNullException(nameof(settingFactory));
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            ApplicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));

            Version = $"v:{Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString(3)}";
            ShowSourceOnGithubCommand = new DelegateCommand(() =>
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://github.com/AKruimink/WindowResizer",
                    UseShellExecute = true
                };
                Process.Start(psi);
            });
            ShowVersionsOnGithubCommand = new DelegateCommand(() =>
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://github.com/AKruimink/WindowResizer/releases",
                    UseShellExecute = true
                };
                Process.Start(psi);
            });
            WindowLoadedCommand = new DelegateCommand(WindowLoaded);
        }

        /// <summary>
        /// Loads all the settings once the window is loaded
        /// </summary>
        private void WindowLoaded()
        {
            ApplicationSettingsChanged(_settingFactory.Create<ApplicationSettings>()); // Manualy set the application settings once as we wont be notified until something changes
            _eventAggregator.GetEvent<SettingChangedEvent<ApplicationSettings>>().Subscribe(ApplicationSettingsChanged, ThreadOption.UIThread, false);
        }

        /// <summary>
        /// Invoked when the general application settings have changed
        /// </summary>
        private void ApplicationSettingsChanged(ISetting<ApplicationSettings> settings)
        {
            UpdateTheme(settings.CurrentSetting.UseDarkTheme);
            MinimizeOnClose = settings.CurrentSetting.MinimizeOnClose;
        }

        /// <summary>
        /// Updates the current application theme
        /// </summary>
        /// <param name="useDarkTheme">Indicates if the current theme should be <see cref="ThemeManager.BaseColorDark"/></param>
        private void UpdateTheme(bool useDarkTheme)
        {
            var themeName = useDarkTheme ? ThemeManager.BaseColorDark : ThemeManager.BaseColorLight;

            if(ThemeManager.Current.DetectTheme()?.BaseColorScheme != themeName && Application.Current != null)
            {
                ThemeManager.Current.ChangeThemeBaseColor(Application.Current, themeName);
            }     
        }
    }
}

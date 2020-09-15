using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Asteroids.Avalonia
{
    /// <inheritdoc />
    internal sealed class App : Application
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <inheritdoc />
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IControlledApplicationLifetime controlled)
            {
                controlled.Startup += OnApplicationStartup;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void OnApplicationStartup(object sender, ControlledApplicationLifetimeStartupEventArgs e)
        {
            switch (sender)
            {
                case IClassicDesktopStyleApplicationLifetime desktop:
                    desktop.ShutdownMode = ShutdownMode.OnLastWindowClose;

                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    break;
            }
        }
    }
}

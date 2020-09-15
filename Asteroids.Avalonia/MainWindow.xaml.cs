using Asteroids.Standard;
using Asteroids.Standard.Interfaces;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Asteroids.Avalonia
{
    /// <summary>
    /// View for the main window.
    /// </summary>
    public class MainWindow : Window
    {
        private readonly IGameController _controller;

        /// <summary>
        /// Initializes a new instance of <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _controller = new GameController();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

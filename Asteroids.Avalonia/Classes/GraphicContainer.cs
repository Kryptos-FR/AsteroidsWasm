using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Asteroids.Standard.Enums;
using Asteroids.Standard.Interfaces;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Asteroids.Avalonia.Classes
{
    internal sealed class GraphicContainer : Image, IGraphicContainer
    {
        private WriteableBitmap _bitmap;
        private IDictionary<DrawColor, Color> _colorCache;

        public Task Draw(IEnumerable<IGraphicLine> lines, IEnumerable<IGraphicPolygon> polygons)
        {
            return Task.CompletedTask;
        }

        public Task Initialize(IDictionary<DrawColor, string> drawColorMap)
        {
            //Cache the colors
            _colorCache = new ReadOnlyDictionary<DrawColor, Color>(
                drawColorMap.ToDictionary(kvp => kvp.Key, kvp => Color.Parse(kvp.Value))
            );

            //Since the control has no size yet simply draw a size bitmap
            _bitmap = new WriteableBitmap(PixelSize.Empty, Vector.One);
            Source = _bitmap;
            return Task.CompletedTask;
        }
    }
}

using Jamesnet.Core;
using System.Windows;
using System.Windows.Controls;

namespace Jamesnet.OpenSilver
{
    public class OpenSilverLayer : ContentControl, ILayer
    {
        public static readonly DependencyProperty LayerNameProperty =
            DependencyProperty.Register(nameof(LayerName), typeof(string), typeof(OpenSilverLayer), new PropertyMetadata(null, OnLayerNameChanged));

        public bool IsRegistered { get; set; }

        public string LayerName
        {
            get => (string)GetValue(LayerNameProperty);
            set => SetValue(LayerNameProperty, value);
        }

        public OpenSilverLayer()
        {
            DefaultStyleKey = typeof(OpenSilverLayer);
            LayerManager.InitializeLayer(this);
        }

        private static void OnLayerNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is OpenSilverLayer layer)
            {
                layer.IsRegistered = false;
                LayerManager.RegisterToLayerManager(layer);
            }
        }
    }
}

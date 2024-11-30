using System.Windows;

namespace Jamesnet.Core;

public interface ILayer
{
    UIElement Content { get; set; }
    string LayerName { get; set; }
    bool IsRegistered { get; set; }
}

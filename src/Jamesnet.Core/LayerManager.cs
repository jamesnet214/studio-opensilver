using System;
using System.Collections.Generic;

namespace Jamesnet.Core;

public class LayerManager : ILayerManager
{
    private readonly Dictionary<string, ILayer> _layers = new Dictionary<string, ILayer>();
    private readonly Dictionary<string, List<IView>> _layerViews = new Dictionary<string, List<IView>>();
    private readonly Dictionary<string, IView> _layerViewMappings = new Dictionary<string, IView>();

    public void Register(string layerName, ILayer layer)
    {
        Console.WriteLine($"LayerManager.Register called with layerName: {layerName}");

        if (!_layers.ContainsKey(layerName))
        {
            _layers[layerName] = layer;
            _layerViews[layerName] = new List<IView>();
            if (_layerViewMappings.TryGetValue(layerName, out var view))
            {
                Show(layerName, view);
            }
        }
    }

    public void Show(string layerName, IView view)
    {
        if (!_layers.TryGetValue(layerName, out var layer))
        {
            throw new InvalidOperationException($"Layer not registered: {layerName}");
        }

        if (view == null)
        {
            layer.Content = null;
            return;
        }

        if (!_layerViews[layerName].Contains(view))
        {
            Add(layerName, view);
        }

        layer.Content = view;
    }

    public void Add(string layerName, IView view)
    {
        if (!_layers.ContainsKey(layerName))
        {
            throw new InvalidOperationException($"Layer not registered: {layerName}");
        }

        if (!_layerViews.ContainsKey(layerName))
        {
            _layerViews[layerName] = new List<IView>();
        }

        if (!_layerViews[layerName].Contains(view))
        {
            _layerViews[layerName].Add(view);
        }
    }

    public void Hide(string layerName)
    {
        if (_layers.TryGetValue(layerName, out var layer))
        {
            layer.Content = null;
        }
    }

    public void Mapping(string layerName, IView view)
    {
        _layerViewMappings[layerName] = view;
    }

    public static void InitializeLayer(ILayer layer)
    {
        if (layer == null)
            throw new ArgumentNullException(nameof(layer));

        var type = layer.GetType();
        var loadedEvent = type.GetEvent("Loaded");
        if (loadedEvent != null)
        {
            // 델리게이트 변수를 먼저 선언
            Delegate handler = null;

            // 델리게이트 액션 정의 (handler 참조 가능)
            Action<object, object> handlerAction = (s, e) =>
            {
                RegisterToLayerManager(layer);
                // 이벤트 핸들러 제거
                loadedEvent.RemoveEventHandler(layer, handler);
            };

            // 델리게이트 생성
            handler = Delegate.CreateDelegate(loadedEvent.EventHandlerType, handlerAction.Target, handlerAction.Method);

            // 이벤트 핸들러 추가
            loadedEvent.AddEventHandler(layer, handler);
        }
        else
        {
            // Loaded 이벤트가 없을 경우 바로 등록
            RegisterToLayerManager(layer);
        }
    }


    public static void RegisterToLayerManager(ILayer layer)
    {
        if (string.IsNullOrEmpty(layer.LayerName) || layer.IsRegistered)
        {
            return;
        }

        var layerManager = ContainerProvider.GetContainer().Resolve<ILayerManager>();
        if (layerManager != null)
        {
            layerManager.Register(layer.LayerName, layer);
            layer.IsRegistered = true;
        }
    }
}

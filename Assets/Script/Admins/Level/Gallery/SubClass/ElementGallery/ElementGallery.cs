using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс являющийся элементом галереи (инициализированная кнопка).
/// </summary>
public class ElementGallery : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AnimElementGallery _animElement;

    public Action SoundPlay;

    private AdminLevel _adminLevel;
    private Game _client;
    private int _index;

    public Game Client { set => _client = value; }
    public AdminLevel AdminLevel { set =>  _adminLevel = value; }
    public int Index { get => _index; set => _index = value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundPlay?.Invoke();
        _client.IndexImage = _index;
        _adminLevel.LoalLevel(NameLevel.View);
    }

    /// <summary>
    /// Отключение анимации загрузки.
    /// </summary>
    public void OffLoading() => _animElement.OffLoading();
}
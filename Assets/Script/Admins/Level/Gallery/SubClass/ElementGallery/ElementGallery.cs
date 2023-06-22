using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс являющийся элементом галереи (инициализированная кнопка).
/// </summary>
public class ElementGallery : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AnimElementGallery _animElement;

    private AdminLevel _adminLevel;
    private Game _client;
    private int _index;

    public Game Client { set => _client = value; }
    public AdminLevel AdminLevel { set =>  _adminLevel = value; }
    public int Index { get => _index; set => _index = value; }

    public void OnPointerDown(PointerEventData eventData)
    {
        _client.IndexImage = _index;
        _adminLevel.LoalLevel(NameLevel.View);
    }
    /// <summary>
    /// Отключение анимации загрузки.
    /// </summary>
    public void OffLoading() => _animElement.OffLoading();
}
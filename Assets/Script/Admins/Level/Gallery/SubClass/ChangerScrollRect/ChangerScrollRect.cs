using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс изменяющий свойства прямоугольника(лист с кнопками).
/// </summary>
public class ChangerScrollRect : MonoBehaviour
{
    private RectTransform _content;

    private const int SPACE_BOTTOM = -250;
    public void Init(RectTransform content,ScrollRect scrollRect)
    {
        _content = content;
    }
    /// <summary>
    /// Увеличение высоты прямоугольника(листа с кнопками).
    /// </summary>
    /// <param name="element">Картинка с кнопкой</param>
    /// <param name="index">Индекс кнопки</param>
    /// <param name="startCountImage">Условия начала увеличения прямоугольника.</param>
    public void AddHeight(RawImage element,int index,int startCountImage)
    {
        if (index % 2 != 0 && index > startCountImage)
            _content.offsetMin = new Vector2(_content.offsetMin.x, _content.offsetMin.y + SPACE_BOTTOM);

        element.transform.SetParent(_content.transform, false);
    }
}
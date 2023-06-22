using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс создающий кнопки.
/// </summary>
public class CreatorButton : MonoBehaviour
{
    private ChangerScrollRect _changerScrollRect;
    private RawImage _prefabImage;

    private const int START_COUNT_IMAGE = 9;

    private int _index = 0;

    public void Init(RawImage prefabImage,ChangerScrollRect changerScroll)
    {
        _prefabImage = prefabImage;
        _changerScrollRect = changerScroll;
    }

    /// <summary>
    /// Создание кнопки.
    /// </summary>
    /// <returns></returns>
    public ResultCreatorElement Create()
    {
        _index++;

        if (_index > Ranges.MAX_IMAGE)
            return null;

        var element = Instantiate(_prefabImage);
        element.GetComponent<ElementGallery>().Index = _index;

        _changerScrollRect.AddHeight(element, _index, START_COUNT_IMAGE);

        return new (element,_index);
    }
}
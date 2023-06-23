using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Класс создающий кнопки.
/// </summary>
public class CreatorButton : MonoBehaviour
{

    private Action _soundButton;
    private ChangerScrollRect _changerScrollRect;
    private RawImage _prefabImage;

    private const int START_COUNT_IMAGE = 9;

    private int _index = 0;

    public void Init(RawImage prefabImage,ChangerScrollRect changerScroll,Action soundButton)
    {
        _prefabImage = prefabImage;
        _soundButton = soundButton;
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

        var elementGallery = element.GetComponent<ElementGallery>();
        elementGallery.Index = _index;
        elementGallery.SoundPlay = _soundButton;
        _changerScrollRect.AddHeight(element, _index, START_COUNT_IMAGE);

        return new (element,_index);
    }
}
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Класс хранящий данные игы в RunTime.
/// </summary>
public class Register : MonoBehaviour
{
    private static Dictionary<int, Texture> _texture = new(); 

    public Dictionary<int, Texture> Texture
    {
        get { return _texture; }
        set { _texture = value; }
    }
    /// <summary>
    /// Проверка на наличие заданной картинки
    /// </summary>
    /// <param name="index">Индекс кнопки</param>
    /// <param name="image">Картинка кнопки</param>
    /// <returns></returns>
    public bool CheckStoreImage(int index,RawImage image, Action OffLoading,Action IndexMoveNext)
    {
        Texture.TryGetValue(index, out Texture texture);

        if (texture == null)
        {
            return false;
        }
        else
        {
            image.texture = texture;
            OffLoading();
            IndexMoveNext();
            return true;
        }
    }
    /// <summary>
    /// Сохранение картинки.
    /// </summary>
    /// <param name="index">Индекс кнопки</param>
    /// <param name="image">Картинка кнопки</param>
    /// <param name="texture">Скаченная текстура</param>
    public void CacheImage(int index, RawImage image,Texture texture,Action OffLoading)
    {
        bool isStore = _texture.TryGetValue(index, out Texture casheTexture);

        if (isStore)
            if (casheTexture == null)
                _texture[index] = texture;

        if (!isStore)
            _texture.Add(index, texture);

        if (image != null)
            image.texture = texture;

        OffLoading();
    }
    /// <summary>
    /// Возвращает линейную последовательность прогруженных элементов до незагруженного.
    /// </summary>
    /// <returns></returns>
    public int CountLoadTexture()
    {
        if (_texture.Count == 0 || _texture.Count < 11)
            return 0;

        int result = 0;
        var arrayKeys = _texture.Keys.ToArray();

        for(int i = 0; i < arrayKeys.Length;i++)
        {
           for(int j = 0; j < arrayKeys.Length; j++)
           {
                if (arrayKeys[i] > arrayKeys[j])
                    (arrayKeys[i], arrayKeys[j]) = (arrayKeys[j], arrayKeys[i]);
           }
        }

        for(int i = 1; i < _texture.Count; i++)
        {
            if (i != arrayKeys[_texture.Count - i])
            {
                result = i - 1;
                break;
            }
            else
                result++;
        }

        return result;
    }
}
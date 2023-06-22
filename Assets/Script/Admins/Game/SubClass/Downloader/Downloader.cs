using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс отправляющий команды на загрузку файлов.
/// </summary>
public class Downloader : MonoBehaviour 
{
    private RequstService _requst;
    private int _index = 1;

    public void Init(RequstService requst) => _requst = requst;
    /// <summary>
    /// Сброс указатель файла.
    /// </summary>
    public void ResetIndex() => _index = 1;
    /// <summary>
    /// Сдвинуть указатель.
    /// </summary>
    public void IndexMoveNext() => ++_index;

    /// <summary>
    /// Скачать со встроенным индексом.
    /// </summary>
    /// <param name="image">Картинка кнопки</param>
    /// <returns></returns>
    public ResultDownload DownloadData(RawImage image,Action offLoading)
    {
        string url = StoragePath.URL + _index + StoragePath.JPG;

        _requst.GetImage(_index, url, image,offLoading);

        _index++;

        return new ResultDownload(_index,image.texture);
    }

    /// <summary>
    /// Скачать с заданным индексом.
    /// </summary>
    /// <param name="image">Картинка кнопки</param>
    /// <param name="index">Индекс кнопки</param>
    /// <returns></returns>
    public ResultDownload DownloadData(RawImage image,int index, Action offLoading)
    {
        string url = StoragePath.URL + index + StoragePath.JPG;

        _requst.GetImage(index,url,image,offLoading);

        return new (index,image.texture);
    }
}
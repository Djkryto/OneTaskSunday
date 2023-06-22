using UnityEngine;
/// <summary>
/// Класс являющийся типом возвращаемого значения класса Downloader.
/// </summary>
public class ResultDownload
{
    public int Index;
    public Texture Texture;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="index">Индекс созданной кнопки.</param>
    /// <param name="texture">Скаченная текстура.</param>
    public ResultDownload(int index, Texture texture)
    {
        Index = index;
        Texture = texture;
    }
}
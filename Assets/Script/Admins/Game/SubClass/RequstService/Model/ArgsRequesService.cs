using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс с аргументами для класса RequesService.
/// </summary>
public class ArgsRequesService
{
    public int Index;
    public string Url;
    public RawImage Image;
    public Texture Texture;
    public Action<int, RawImage, Texture> CacheRegister;

    public ArgsRequesService(int index, string url, RawImage image,Texture texture, Action<int, RawImage, Texture> cacheRegister)
    {
        Index = index;
        Url = url;
        Image = image;
        Texture = texture;
        CacheRegister = cacheRegister;
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Класс отечающий за запросы.
/// </summary>
public class RequstService : MonoBehaviour
{
    private Register _register;
    public void Init(Register register) => _register = register;
    /// <summary>
    /// Запрос текстуры с сервера.
    /// </summary>
    /// <param name="index">Индекс кнопки</param>
    /// <param name="url">Путь к серверу</param>
    /// <param name="image">Картинка кнопки</param>
    /// <param name="offLoading">Отключение анимации загрузки у кнопки</param>
    public void GetImage(int index, string url, RawImage image, Action offLoading) => StartCoroutine(DownloadImage(index, url, image,offLoading));

    private IEnumerator DownloadImage(int index, string url, RawImage image, Action offLoading)
    {
        var request = UnityWebRequestTexture.GetTexture(new Uri(url));
        request.url = url;

        yield return request.SendWebRequest();

        if (request.isHttpError && request.isHttpError)
            yield return null;

        var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

        _register.CacheImage(index, image, texture,offLoading);
    }

}
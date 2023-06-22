using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// ����� ��������� �� �������.
/// </summary>
public class RequstService : MonoBehaviour
{
    private Register _register;
    public void Init(Register register) => _register = register;
    /// <summary>
    /// ������ �������� � �������.
    /// </summary>
    /// <param name="index">������ ������</param>
    /// <param name="url">���� � �������</param>
    /// <param name="image">�������� ������</param>
    /// <param name="offLoading">���������� �������� �������� � ������</param>
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
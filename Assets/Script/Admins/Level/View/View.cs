using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Менеджер сцены View.
/// </summary>
public class View : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private Button _back;

    private Downloader _downloader;
    private void Awake() => Init();

    private void Init()
    {
        var scripts = FinderScript.FindGameScript;
        _downloader = scripts.GetComponent<Downloader>();

        InitButtons(scripts);
        InitImage(scripts);
    }

    private void InitImage(GameObject scripts)
    {
        var client = scripts.GetComponent<Game>();
        var animElement = _image.GetComponent<AnimElementGallery>();
        Action offLoadingImage = animElement.OffLoading;// use c# 9.0...

        var index = client.IndexImage;
        var register = client.Register;

        if(register.Texture.TryGetValue(index, out Texture texture))
        {
            if (texture != null)
            {
                _image.texture = texture;
                offLoadingImage();
            }
            else
            {
                Reload(register, index,offLoadingImage);
            }
        }
        else
        {
            var result = _downloader.DownloadData(_image, index, offLoadingImage);
            register.Texture.TryAdd(result.Index, result.Texture);
        }
    }

    private void InitButtons(GameObject scripts)
    {
        var adminLevel = scripts.GetComponent<AdminLevel>();
        _back.onClick.AddListener(() => { adminLevel.LoalLevel(NameLevel.Gallery); });
    }

    private void Reload(Register register,int index,Action offLoadingImage)
    {
        var result = _downloader.DownloadData(_image, index, offLoadingImage);
        register.Texture.TryAdd(result.Index, result.Texture);
    }
}
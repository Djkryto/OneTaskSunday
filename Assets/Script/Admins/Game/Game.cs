using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Главный класс по взаимодействию с игрой.
/// </summary>
public class Game : MonoBehaviour
{
    private static Game _instance;

    [SerializeField] private DataView _data;
    [SerializeField] private Register _register;
    [SerializeField] private AdminLevel _adminLevel;
    [SerializeField] private Downloader _downloader;
    [SerializeField] private RequstService _requstService;
    [SerializeField] private ReassignmentButton _reassignmentButton;

    /// <summary>
    /// Индекс хранящий значение для загрузки картинки на сцене View. 
    /// </summary>
    public int IndexImage { get => _data.Index; set => _data.Index = value; }
    public Register Register { get => _register; }

    private void Awake() => Init();

    private void Init()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        _requstService.Init(_register);
        _downloader.Init(_requstService);
        _reassignmentButton.Init(_adminLevel);
    }

    /// <summary>
    /// Загрузка текстуры.
    /// </summary>
    /// <param name="image">Картинка кнопки</param>
    /// <param name="index">Индекс кнопки</param>
    public void LoadImage(RawImage image,int index,Action OffLoading)
    {
        if (_register.Texture.Keys.Count == 0)
            _downloader.DownloadData(image,OffLoading);
        else
            if(!_register.CheckStoreImage(index, image, OffLoading,_downloader.IndexMoveNext))
                _downloader.DownloadData(image, OffLoading);
    }

    /// <summary>
    /// Сброс значений загрузчику для повторной проверки скаченных текстур.
    /// </summary>
    public void ResetIndexDonwloder() => _downloader.ResetIndex();
}   
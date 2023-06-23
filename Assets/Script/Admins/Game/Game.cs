using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������� ����� �� �������������� � �����.
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
    /// ������ �������� �������� ��� �������� �������� �� ����� View. 
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
    /// �������� ��������.
    /// </summary>
    /// <param name="image">�������� ������</param>
    /// <param name="index">������ ������</param>
    public void LoadImage(RawImage image,int index,Action OffLoading)
    {
        if (_register.Texture.Keys.Count == 0)
            _downloader.DownloadData(image,OffLoading);
        else
            if(!_register.CheckStoreImage(index, image, OffLoading,_downloader.IndexMoveNext))
                _downloader.DownloadData(image, OffLoading);
    }

    /// <summary>
    /// ����� �������� ���������� ��� ��������� �������� ��������� �������.
    /// </summary>
    public void ResetIndexDonwloder() => _downloader.ResetIndex();
}   
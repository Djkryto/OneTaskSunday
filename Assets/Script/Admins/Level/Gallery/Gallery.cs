using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Менеджер сцены Gallery.
/// </summary>
public class Gallery : MonoBehaviour
{
    private Game _client;
    private AdminLevel _level;

    [SerializeField] private RectTransform _content;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private RawImage _prefabButton;

    [SerializeField] private TriggerLoad _triggerLoad;
    [SerializeField] private CreatorButton _creatorButton;
    [SerializeField] private ChangerScrollRect _changerScrollRect;
    [SerializeField] private CreatorElementGallery _creatorElement;

    private void Awake()
    {
        Init();
        CreatFirstButton();
    }

    private void Init()
    {
        var scripts = FinderScript.FindGameScript;

        _client = scripts.GetComponent<Game>();
        _level = scripts.GetComponent<AdminLevel>();

        _client.ResetIndexDonwloder();

        var argsCreatorElement = new ArgsCreatorElementGallery(_client, _level, _creatorButton);

        _creatorButton.Init(_prefabButton,_changerScrollRect);
        _changerScrollRect.Init(_content, _scrollRect);
        _creatorElement.Init(argsCreatorElement);
        _triggerLoad.Init(this,_content);
    }

    
    private void CreatFirstButton() => _creatorElement.CreatStartButton();
    /// <summary>
    /// Создание элемента кнопки (Инициализированная кнопка).
    /// </summary>
    public void CreateElement() => _creatorElement.CreateElement();
}
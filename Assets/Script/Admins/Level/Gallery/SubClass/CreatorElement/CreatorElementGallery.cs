using UnityEngine;
/// <summary>
/// Класс создающий элементы галереи (Инициализированные кнопки).
/// </summary>
public class CreatorElementGallery : MonoBehaviour
{
    private CreatorButton _creatorButton;
    private AdminLevel _adminLevel;
    private Game _client;

    private const int COUNT_START_ELEMENT = 11;
    public void Init(ArgsCreatorElementGallery args)
    {
        _creatorButton = args.CreatorButton;
        _adminLevel = args.AdminLevel;
        _client = args.Client;
    }

    /// <summary>
    /// Создание начальных кнопок.
    /// </summary>
    public void CreatStartButton()
    {
        int countLoadTexture = _client.Register.CountLoadTexture();

        if (countLoadTexture > COUNT_START_ELEMENT)
            for (int i = 0; i <= countLoadTexture; i++)
                CreateElement();
        else
            for (int i = 0; i <= COUNT_START_ELEMENT; i++)
                CreateElement();
    }

    /// <summary>
    /// Проверка регистра на полную загрузку текстур.
    /// </summary>
    public bool CheckRegisterOnAllTexture()
    {
        var texturs = _client.Register.Texture;
        bool result = _client.Register.Texture.Count == Ranges.MAX_IMAGE;

        if (result)
            for (int i = 0; i < Ranges.MAX_IMAGE; i++)
                CreateElement();
        
        return result;
    }
    /// <summary>
    /// Создание элемента галереи.
    /// </summary>
    public void CreateElement()
    {
        var result = _creatorButton.Create();

        if (result == null)
            return;

        if (result.RawImage == null)
            return;

        var elementGallery = result.RawImage.GetComponent<ElementGallery>();

        elementGallery.AdminLevel = _adminLevel;
        elementGallery.Client = _client;

        _client.LoadImage(result.RawImage, result.Index,elementGallery.OffLoading);
    }
}
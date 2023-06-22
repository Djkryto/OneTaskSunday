using UnityEngine.UI;
/// <summary>
/// Тип возвращаемого значения CreatorElement.
/// </summary>
public class ResultCreatorElement
{
    /// <summary>
    /// Картинка с текстурой.
    /// </summary>
    public RawImage RawImage;
    /// <summary>
    /// Индекс елемента.
    /// </summary>
    public int Index;

    public ResultCreatorElement(RawImage rawImage, int index)
    {
        RawImage = rawImage;
        Index = index;
    }
}
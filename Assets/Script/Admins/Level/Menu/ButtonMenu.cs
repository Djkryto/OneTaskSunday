using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс отвечающий за нажатие кнопки меню.
/// </summary>
public class ButtonMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var gameScript = FinderScript.FindGameScript;
        var adminLevel = gameScript.GetComponent<AdminLevel>();

        gameScript.GetComponent<Sound>().Button();
        adminLevel.LoalLevel(NameLevel.Gallery);
    }
}
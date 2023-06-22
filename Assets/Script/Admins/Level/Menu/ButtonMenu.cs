using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс отвечающий за нажатие кнопки меню.
/// </summary>
public class ButtonMenu : MonoBehaviour,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        var adminLevel = FinderScript.FindGameScript.GetComponent<AdminLevel>();
        adminLevel.LoalLevel(NameLevel.Gallery);
    }
}

using UnityEngine;

/// <summary>
/// Класс по настройке поведения кнопок Android, IOS.
/// </summary>
public class ReassignmentButton : MonoBehaviour
{
    private AdminLevel _adminLevel;

    public void Init(AdminLevel adminLevel) => _adminLevel = adminLevel;

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            BackButton();

        if (Application.platform == RuntimePlatform.IPhonePlayer)
            BackButton();

        if (Input.GetKeyDown(KeyCode.Escape))
            BackButton();
    }

    private void BackButton()
    {
        var scene = _adminLevel.GetIndexScene();

        if (scene == NameLevel.Load)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            if (scene != NameLevel.Load)
                if(scene != NameLevel.Gallery)
                    _adminLevel.LoalLevel(--scene);
                else
                    _adminLevel.LoalLevel(NameLevel.Menu);
            else
                _adminLevel.Quit();
    }
}

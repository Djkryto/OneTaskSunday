using UnityEngine;
/// <summary>
/// ����� ���������� �� ������� ��������� ������.
/// </summary>
public class PositionScreen : MonoBehaviour
{
    [SerializeField] private bool _poratain;
    private void Awake()
    {
        if (_poratain)
            Screen.orientation = ScreenOrientation.Portrait;
        else
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
}

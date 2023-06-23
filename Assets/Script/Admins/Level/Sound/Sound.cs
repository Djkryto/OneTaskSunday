using UnityEngine;
/// <summary>
/// ����� ���������� �� ����� ������.
/// </summary>
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip _button;

    /// <summary>
    /// ���� ������.
    /// </summary>
    public void Button()
    {
        _sound.clip = _button;
        _sound.Play();
    }
}

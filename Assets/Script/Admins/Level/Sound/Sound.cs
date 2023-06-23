using UnityEngine;
/// <summary>
/// Класс отвечающий за звуки кнопок.
/// </summary>
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip _button;

    /// <summary>
    /// Звук кнопки.
    /// </summary>
    public void Button()
    {
        _sound.clip = _button;
        _sound.Play();
    }
}

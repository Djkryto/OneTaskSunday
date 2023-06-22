using UnityEngine;

/// <summary>
/// Класс отвечающий за анимацию кнопки.
/// </summary>
public class AnimElementGallery : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    /// <summary>
    /// Отключение анимации загрузки.
    /// </summary>
    public void OffLoading()
    {
        if (_anim != null)
            _anim.SetBool(NameAnimElementGallery.OffLoading, true);
    }
}

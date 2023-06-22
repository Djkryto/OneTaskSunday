using UnityEngine;

/// <summary>
/// Элемент при отображении которого посылается команда на загрузку картинки.
/// </summary>
public class TriggerLoad : MonoBehaviour
{
    private Gallery _gallery;
    private RectTransform _content;

    private float _timer;
    private const float DELAY = 0.25f;
    private const float SPACE_LOAD = -50;

    public void Update() => Timer();

    public void Init(Gallery gallery, RectTransform content)
    {
        _content = content;
        _gallery = gallery;
    }

    private void Timer()
    {
        _timer += Time.deltaTime;

        if (_timer > DELAY)
        {
            if (_content.offsetMax.y >= -_content.offsetMin.y + SPACE_LOAD)
            {
                Create();
                _timer = 0;
            }
        }
    }
   private void Create()
   {
        _gallery.CreateElement();
        _gallery.CreateElement();
   }
}
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Загрузчик сцен.
/// </summary>
public class LoaderScene : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TextMeshProUGUI _numberProgress;

    private int _levelLoad;

    private void Start()
    {
        _levelLoad = FinderScript.FindGameScript.GetComponent<AdminLevel>().LevelLoad;
        StartCoroutine(LoadAsync(_levelLoad));
    }
    
    private IEnumerator LoadAsync(int nameLevel)
    {
        AsyncOperation operation = Application.LoadLevelAsync(nameLevel);

        while (!operation.isDone)
        {
            _progressBar.value += operation.progress;
            _numberProgress.text = Convert.ToInt32(_progressBar.value * 100) + "%";

            yield return null;
        }
    }
}
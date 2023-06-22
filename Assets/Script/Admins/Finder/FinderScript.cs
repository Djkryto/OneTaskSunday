using UnityEngine;

/// <summary>
/// Класс являющийся поисковиком файлов на сцене.
/// </summary>
public static class FinderScript
{
    /// <summary>
    /// Поиск Игрового(главного) скрипта.
    /// </summary>
    public static GameObject FindGameScript => GameObject.Find(TypeScript.GAME);
    /// <summary>
    /// Поиск менеджера уровня.
    /// </summary>
    public static GameObject FindLevelScript => GameObject.Find(TypeScript.LEVEL);
}

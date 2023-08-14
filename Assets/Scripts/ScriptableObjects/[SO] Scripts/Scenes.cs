using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scene", menuName = "Scenes")]
public class Scenes : ScriptableObject
{
    public enum MenuTypes { Main, Controls, Score, Game}
    public MenuTypes menu;
    public string GetMenuName()
    {
        switch (menu)
        {
            case MenuTypes.Main:
                return "Main Menu";
            case MenuTypes.Controls:
                return "Controls Menu";
            case MenuTypes.Score:
                return "Score Menu";
            case MenuTypes.Game:
                return "New Game";
            default:
                return "";
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CS
{
    //public static int TK = 0; 

    public static AudioClip[] MainAudio = new AudioClip[11];

    public enum M { a00startgame, a01gameover, a02clickground, a03missclick, a04boomhit, a05getbonus, a06wingame, a07enemyrotate, a08playermove, a09musicmenu, a10musicgame};

    public static string[] MPackPath;

    //public static Color[] Mcolor = { Color.yellow, Color.red, Color.green, Color.grey, Color.blue }; 
    //public enum C { c00bonus, c01boom, c02cube, c03enemy, c04plane };

    //public static GameObject[] Mprefabs = new GameObject[4];
    //public enum P { p00boom, p01cube, p02enemy, p03bonusbar};
}//public static class CS

// 0 // jingle Начало игры - 00startgame.mp3 !
// 1 // jingle Конец игры (-) (поражение) - 01gameover.mp3 !
// 2 // Клик по земле (+) (добавление точки пути) - 02clickground.mp3 !
// 3 // Клик по земле (-) (нельзя добавить точу) - 03missclick.mp3 !
// 4 // Взрыв шарика - 04boomhit.mp3 !
// 5 // Бонус сбор монетки - 05getbonus.mp3 !
// 6 // jingle Конец игры (+) (победа) - 06wingame.mp3 !
// 7 // Вращение кубов - 07enemyrotate.mp3 !
// 8 // Перемещение шарика - 08playermove.mp3 !
// 9 // music меню - 09musicmenu.mp3 !
// 10 // music боя - 10musicgame.mp3 !

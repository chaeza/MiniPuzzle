using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMGR : MonoBehaviour
{
    private static GameMGR instance;
    public static GameMGR _instance
    {
        get
        {
            if (instance == null)
            {
                GameMGR NewGameMGr = FindObjectOfType<GameMGR>();
                if (NewGameMGr == null)
                    instance = new GameObject("GameMgr").AddComponent<GameMGR>();
                else
                    instance = NewGameMGr; 
            }
            return _instance;
        }
    }
}

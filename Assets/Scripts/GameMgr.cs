using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static GameMgr _instance;
    public static GameMgr instance
    {
        get 
        {
            if(_instance == null)
            {
                GameMgr gameMgr = GameObject.FindObjectOfType<GameMgr>();
                if(gameMgr == null)
                    gameMgr = new GameObject("GameMgr").AddComponent<GameMgr>();
            }
            return _instance; 
        }
    }
}

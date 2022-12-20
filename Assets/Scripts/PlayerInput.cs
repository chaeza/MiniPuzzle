using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void Del_PlayerClick(string dir);
    public Del_PlayerClick del_PlayerClick;
    public bool canClick ;
    private void Start()
    {
        canClick=true;
    }
    void Update()
    {
        if (canClick==false) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            del_PlayerClick("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            del_PlayerClick("Right");
        }
    }
}

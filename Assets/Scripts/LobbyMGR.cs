using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyMGR : MonoBehaviour
{
    public void OnClick_ToSingle()
    {
        SceneManager.LoadScene("SingleMode");
    }
    public void OnClick_ToMulti()
    {
        SceneManager.LoadScene("MultiMode");
    }
}

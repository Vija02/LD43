using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {
    
    [SerializeField]
    private Scene scene;

    public void Button_OnClick()
    {
        SceneManager.LoadScene("Level");
    }
}

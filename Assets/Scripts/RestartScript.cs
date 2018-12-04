using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {
    
    [SerializeField]
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetSceneAt(0);
    }

    public void Button_OnClick()
    {
        SceneManager.LoadScene(scene.name);
    }
}

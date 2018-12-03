using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour {

    public Scene scene;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void Button_OnClick()
    {
        SceneManager.LoadScene(scene.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mediaplayer()
    {
        SceneManager.LoadScene("mediaplayer");
    }

    public void gallery()
    {
        SceneManager.LoadScene("gallery");
    }

    public void manipulation()
    {
        SceneManager.LoadScene(1);
    }

    public void returnkuy(){
        SceneManager.LoadScene(0);
    }
}

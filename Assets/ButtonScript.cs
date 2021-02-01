using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Reload()
    {
        FindObjectOfType<GameController>().totalTime -= 10;
        FindObjectOfType<GameController>().level++;
        SceneManager.LoadScene(1);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Button reload;
    public float totalTime;
    public static GameController inst;
    public int level;

    private void Awake()
    {
        level = 1;
        totalTime = 90;
        DontDestroyOnLoad(this);
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void Reload()
    {
        totalTime = totalTime - 10;
        level++;
        SceneManager.LoadScene(1);
        
    }

    

   
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControl : MonoBehaviour
{
  //startar en instans för singleton
  public static GameControl instance;
  public bool gameOver = false;


    void Awake()
    {
      //om instansen inte finns, this är instans - annars destroy
      if (instance == null)
      {
        instance = this;
      } else if (instance != this)
      {
        Destroy(gameObject);
      } 
    }
    void Start()
      {
        
      }

    void Update()
    {
        
    }
    public void SnakeDied()
    {
      Debug.Log("SnakeDied called!");
      gameOver = true;
    }
}

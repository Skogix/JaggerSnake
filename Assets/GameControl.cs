using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControl : MonoBehaviour
{
  public static GameControl instance;
  public bool gameOver = false;


    void Awake()
    {
      if (instance == null)
      {
        instance = this;
      } else if (instance != this)
      {
      Destroy(gameObject);
      } 
    }
  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SnakeDied()
  {
    Debug.Log("SnakeDied called!");
    gameOver = true;
  }
}

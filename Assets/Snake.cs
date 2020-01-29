using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
  Vector2 dir = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("Move", 0.3f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.RightArrow))
      dir = Vector2.right;
    else if (Input.GetKey(KeyCode.LeftArrow))
      dir = -Vector2.right;
    else if (Input.GetKey(KeyCode.UpArrow))
      dir = Vector2.up;
    else if (Input.GetKey(KeyCode.DownArrow))
      dir = -Vector2.up;
    }
    void Move()
    {
      transform.Translate(dir);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  //behövs för listor
using System.Linq;

/*
 * Translate betyder i princip sett "lägg till den här
 * vectorn till min nuvarande position". 
 * 
 * Quaternion
 * The identity rotation (Read Only).
 * This quaternion corresponds to "no rotation" - the object is perfectly aligned with the world or parent axes.
 */


public class Snake : MonoBehaviour
{
  //startdir = höger
  Vector2 dir = Vector2.right;

  //lista över alla tails från transform
  List<Transform> tail = new List<Transform>();
  
  //har du ätit något den här updaten?
  private bool ate = false;

  //är du död?
  private bool isDead = false;
  //rb
  private Rigidbody2D rb;


  //tail prefab
  public GameObject tailPrefab;
    void Start()
    {
      //gör en egen "update" var 0.1e sek
      InvokeRepeating("Move", 0.1f, 0.1f);

      // hämta från objektet
      rb = GetComponent<Rigidbody2D>(); 
    }

  void Update()
  {
    if (isDead)
    {
      Debug.Log("Du är död och ska inte röra dig!");
      dir = Vector2.zero;
    }
    else
    {
      //sätt dir åt det håll vi trycker
      if (Input.GetKey(KeyCode.RightArrow) && dir != Vector2.left)
        dir = Vector2.right;
      else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
        dir = Vector2.left;
      else if (Input.GetKey(KeyCode.UpArrow) && dir != Vector2.down)
        dir = Vector2.up;
      else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
        dir = Vector2.down;
    }
  }
    void Move()
    {
      //sparar nuvarande position som vi ska fylla i
      Vector2 v = transform.position;
      
      //flyttar head åt nya dir
      //"Moves the transform in the direction and distance of translation."
      transform.Translate(dir);

    if (ate)
    {
      //ladda in prefab 
      GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
      //lägg till den i listan
      tail.Insert(0, g.transform);

      ate = false;
    }

    //har vi svans?
    else if (tail.Count > 0)
      {
        //flytta sista tailen till där huvudet var
        tail.Last().position = v;
        //lägg till i början av listan, ta bort från slutet
        tail.Insert(0, tail.Last());
        tail.RemoveAt(tail.Count - 1);
      }
    }

  void OnTriggerEnter2D(Collider2D coll)
  {
    //collidade du med food?
    //namnet blir "FoodPrefab(clone)", fixa tags?
    // TODO
    if (coll.name.StartsWith("FoodPrefab"))
    {
      //bli längre nästa moveupdate
      ate = true;
      //förtör maten
      Destroy(coll.gameObject);

      Debug.Log("Du åt!");
    } else if(coll.name.StartsWith("Border"))
    {
      Debug.Log("Du åkte in i väggen!");
      GameControl.instance.SnakeDied();
      isDead = true;
    } else if (coll.name.StartsWith("TailPrefab"))
    {
      isDead = true;
      Debug.Log("Du åkte in i svansen!");
      GameControl.instance.SnakeDied();
    }
  }
}

using UnityEngine;

public class SpawnFood : MonoBehaviour
{
  //food
  public GameObject foodPrefab;

  //border prefab
  public Transform borderTop;
  public Transform borderBottom;
  public Transform borderLeft;
  public Transform borderRight;
  void Start()
  {
    InvokeRepeating("Spawn", 3, 4);
  }
  void Spawn()
  {
    //sätt random mellan borderpositions
    int x = (int)Random.Range(
      borderLeft.position.x, borderRight.position.x);
    int y = (int)Random.Range(
      borderTop.position.y, borderBottom.position.y);
    //spawna foodprefab 
    Instantiate(foodPrefab,
      new Vector2(x, y),
      Quaternion.identity);

  }
}

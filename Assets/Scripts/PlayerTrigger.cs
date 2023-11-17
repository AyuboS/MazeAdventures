using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
  public int NumberOfCubes { get; set; }
    public void CubeCollected()
    {
        NumberOfCubes += 1;
    }
}

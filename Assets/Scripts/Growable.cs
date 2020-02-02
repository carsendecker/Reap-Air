using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
    public Sprite[] GrownSprites;
    
    public void Grow()
    {
        GetComponent<SpriteRenderer>().sprite = GrownSprites[Random.Range(0, GrownSprites.Length)];
    }
}

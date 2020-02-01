using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
    public Sprite GrownSprite;
    
    public void Grow()
    {
        GetComponent<SpriteRenderer>().sprite = GrownSprite;
    }
}

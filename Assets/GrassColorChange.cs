using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassColorChange : MonoBehaviour {
    public Color grassColor;
    public Color deadColor;
    public Color currentColor;
    public float transition = 0;
    private SpriteRenderer[] srArr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentColor = Color.Lerp(deadColor, grassColor, transition);

        srArr =  GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < srArr.Length; i++) {
            srArr[i].color = currentColor;
        }

        // grasscol
    }
}

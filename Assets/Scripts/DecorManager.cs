using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorManager : MonoBehaviour
{
    public static DecorManager DM;
    
    //List of possible objects to spawn
    public List<GameObject> GrowableObjects = new List<GameObject>();
    public List<GameObject> RemovableObjects = new List<GameObject>();
    
    //List of objects in the scene
    public List<GameObject> GrowablesInScene = new List<GameObject>();
    public List<GameObject> RemovablesInScene = new List<GameObject>();

    public Vector2 MapBounds;

    void Awake()
    {
        DM = this;
    }

    public void InstantiateRandomObject()
    {
        GameObject newObject = GrowableObjects[Random.Range(0, GrowableObjects.Count)];
        GameObject obj = Instantiate(newObject, new Vector2(Random.Range(-MapBounds.x, MapBounds.x), Random.Range(-MapBounds.y, MapBounds.y)), Quaternion.identity);

        GrowablesInScene.Add(obj);
    }
    
    public void RemoveRandomObject(float numberToRemove)
    {
        for (int i = 0; i < numberToRemove; i++)
        {
            GameObject toRemove = RemovablesInScene[Random.Range(0, RemovablesInScene.Count)];
            RemovablesInScene.Remove(toRemove);
            
            Destroy(toRemove);
        }
    }

    public void GrowObject(GameObject toGrow)
    {
        if (!toGrow.CompareTag("GrowDecor")) return;
        
        toGrow.GetComponent<Growable>().Grow();
    }
}

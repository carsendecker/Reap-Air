using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorManager : MonoBehaviour
{
    //List of possible objects to spawn
    public List<GameObject> GrowableObjects = new List<GameObject>();
    public List<GameObject> RemovableObjects = new List<GameObject>();
    
    //List of objects in the scene
    public List<GameObject> GrowablesInScene = new List<GameObject>();
    public List<GameObject> RemovablesInScene = new List<GameObject>();


    public void InstantiateRandomObject()
    {
//        GameObject newObject = 
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

    public void GrowRandomObject(float numberToGrow)
    {
        for (int i = 0; i < numberToGrow; i++)
        {
            GameObject toGrow = GrowablesInScene[Random.Range(0, RemovablesInScene.Count)];
            toGrow.GetComponent<Growable>().Grow();

            RemovablesInScene.Remove(toGrow);

            
            Destroy(toGrow);
            
        }
    }
}

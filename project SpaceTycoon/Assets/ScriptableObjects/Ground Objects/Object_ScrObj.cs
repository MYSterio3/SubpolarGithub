using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { ground,wall };

[CreateAssetMenu(menuName = "Create New Object")]
public class Object_ScrObj : ScriptableObject
{
    public GameObject gameObjectPrefab;
    public ObjectType objectType;
    public int objectID;
    public Sprite objectSprite;
    public string objectDescription;
}

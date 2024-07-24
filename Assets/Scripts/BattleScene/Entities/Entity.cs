using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/Entity", order = 2)]
public class Entity : ScriptableObject
{
    public string entityName;
    public int entityHealth;
    public int entityLevel;
}

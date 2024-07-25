using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/Entity", order = 2)]
public class Entity : ScriptableObject
{
    public new string name;
    public int health;
    public int level;
    public List<Attack> attackList = new List<Attack>();
}

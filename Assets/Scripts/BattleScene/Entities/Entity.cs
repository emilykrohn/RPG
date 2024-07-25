using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/Entity", order = 2)]
public class Entity : ScriptableObject
{
    [SerializeField] public int health;
    [SerializeField] public int level;
    [SerializeField] public List<Attack> attackList = new List<Attack>();
}

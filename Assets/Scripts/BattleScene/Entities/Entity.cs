using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "ScriptableObjects/Entity", order = 2)]
public class Entity : ScriptableObject
{
    [SerializeField] private string entityName;
    [SerializeField] private int entityHealth;
    [SerializeField] private int entityLevel;
    [SerializeField] private List<Attack> attackList = new List<Attack>();
}

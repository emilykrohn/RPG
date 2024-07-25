using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Entity enemy;
    public int health;

    private void Start()
    {
        health = enemy.health;
    }
}

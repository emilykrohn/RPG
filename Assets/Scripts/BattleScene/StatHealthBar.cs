using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatHealthBar
{
    private VisualElement root;
    private ProgressBar playerHealthBar;
    private ProgressBar enemyHealthBar;
    private Battle battle;
    private Entity player;
    private Entity enemy;

    public StatHealthBar(VisualElement root)
    {
        this.root = root;
        battle = GameObject.Find("UI").GetComponent<Battle>();
        player = battle.player;
        enemy = battle.enemy;
    }

    public void RegisterHealthBarCallBacks()
    {
        playerHealthBar = root.Q("PlayerHealthBar") as ProgressBar;
        enemyHealthBar = root.Q("EnemyHealthBar") as ProgressBar;

        playerHealthBar.value = player.health;
        playerHealthBar.highValue = player.health;

        enemyHealthBar.value = enemy.health;
        enemyHealthBar.highValue = enemy.health;
    }
}

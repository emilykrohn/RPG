using UnityEngine;
using UnityEngine.UIElements;

public class AttackMenuController
{
    private const string attackButtonClassName = "attackButton";
    private readonly VisualElement root;

    private Battle battle;
    private Entity player;
    private Entity enemy;

    public AttackMenuController(VisualElement root)
    {
        this.root = root;
        battle = GameObject.Find("UI").GetComponent<Battle>();
        player = battle.player;
        enemy = battle.enemy;
    }

    public void RegisterAttackCallbacks()
    {
        UQueryBuilder<Button> buttons = root.Query<Button>(className: attackButtonClassName);
        buttons.ForEach((button) =>
        {
            button.RegisterCallback<ClickEvent>(AttackButtonOnClick);
        });
    }

    private void AttackButtonOnClick(ClickEvent evt)
    {
        Button clickedButton = evt.currentTarget as Button;
        ProgressBar enemyHealth = root.Q("EnemyHealthBar") as ProgressBar;
        if (clickedButton.name == "Attack1")
        {
            enemy.health -= player.attackList[0].attackDamage;
            enemyHealth.value = enemy.health;
        }
        else if (clickedButton.name == "Attack2" && player.attackList.Count >= 2) Debug.Log("SecondAttack");
        else if (clickedButton.name == "Attack3" && player.attackList.Count >= 3) Debug.Log("ThirdAttack");
        else if (player.attackList.Count >= 4) Debug.Log("FourthAttack");
    }
}

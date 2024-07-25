using UnityEngine;
using UnityEngine.UIElements;

public class AttackMenuController
{
    private const string attackButtonClassName = "attackButton";
    private readonly VisualElement root;

    public AttackMenuController(VisualElement root)
    {
        this.root = root;
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
        if (clickedButton.name == "Attack1") Debug.Log("FirstAttack");
        else if (clickedButton.name == "Attack2") Debug.Log("SecondAttack");
        else if (clickedButton.name == "Attack3") Debug.Log("ThirdAttack");
        else Debug.Log("Attack4");
    }
}

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
        if (clickedButton.name == "FirstAttack") Debug.Log("FirstAttack");
        else if (clickedButton.name == "SecondAttack") Debug.Log("SecondAttack");
        else if (clickedButton.name == "ThirdAttack") Debug.Log("ThirdAttack");
        else Debug.Log("FourthAttack");
    }
}

using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;
public class MenuController
{
    private const string menuClassName = "menu";
    private const string currentlySelectedMenuClassName = "enabledMenus";
    private const string unselectedMenuClassName = "disabledMenus";
    private const string attackButtonClassName = "attackButton";
    private const string selectedAttackClassName = "selectedAttack";
    private const string unselectedAttackClassName = "unselectedAttack";

    private readonly VisualElement root;

    private Battle battle;

    public MenuController(VisualElement root)
    {
        this.root = root;
        battle = GameObject.Find("UI").GetComponent<Battle>();
    }

    public void RegisterMenuCallbacks()
    {
        Button attack = root.Q<Button>("Attack") as Button;
        attack.RegisterCallback<ClickEvent>(AttackOnClick);

        Button run = root.Q<Button>("Run") as Button;
        run.RegisterCallback<ClickEvent>(RunOnClick);
    }

    private void AttackOnClick(ClickEvent evt)
    {
        GroupBox menuToEnable = root.Q<GroupBox>("AttackGroupBox");
        if (!IsMenuCurrentlySelected(menuToEnable))
        {
            GetAllMenus().Where(
                (menu) => menu != menuToEnable && IsMenuCurrentlySelected(menu)
            ).ForEach(DisableMenu);

            UQueryBuilder<Button> attackButtons = menuToEnable.Query<Button>(className: attackButtonClassName);
            int attackAmount = battle.player.attackList.Count;

            attackButtons.Where(
                (button) => IsAttackSelected(button)
            ).ForEach(DisableAttack);

            for (int i = 0;  i < attackAmount; i++)
            {
                Button currentButton = root.Q<Button>("Attack" + (i + 1).ToString());
                EnableAttack(currentButton);
                currentButton.text = battle.player.attackList[i].name;
            }

            EnableMenu(menuToEnable);
        }
    }

    private void RunOnClick(ClickEvent evt)
    {
        SceneManager.LoadScene("OverWorld");
    }

    private UQueryBuilder<GroupBox> GetAllMenus()
    {
        return root.Query<GroupBox>(className: menuClassName);
    }

    private bool IsMenuCurrentlySelected(GroupBox groupBox)
    {
        return groupBox.ClassListContains(currentlySelectedMenuClassName);
    }

    private bool IsAttackSelected(Button attack)
    {
        return attack.ClassListContains(selectedAttackClassName);
    }

    private void EnableMenu(GroupBox menu)
    {
        menu.AddToClassList(currentlySelectedMenuClassName);
        menu.RemoveFromClassList(unselectedMenuClassName);
    }

    private void DisableMenu(GroupBox menu)
    {
        menu.RemoveFromClassList(currentlySelectedMenuClassName);
        menu.AddToClassList(unselectedMenuClassName);
    }

    private void EnableAttack(Button attack)
    {
        attack.AddToClassList(selectedAttackClassName);
        attack.RemoveFromClassList(unselectedAttackClassName);
    }

    private void DisableAttack(Button attack)
    {
        attack.RemoveFromClassList(selectedAttackClassName);
        attack.AddToClassList(unselectedAttackClassName);
    }
}

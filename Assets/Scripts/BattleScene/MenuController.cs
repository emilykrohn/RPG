using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MenuController
{
    private const string menuClassName = "menu";
    private const string currentlySelectedMenuClassName = "enabledMenus";
    private const string unselectedMenuClassName = "disabledMenus";

    private readonly VisualElement root;

    public MenuController(VisualElement root)
    {
        this.root = root;
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
}

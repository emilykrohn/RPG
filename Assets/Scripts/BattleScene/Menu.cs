using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private MenuController controller;
    private AttackMenuController attackController;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();

        VisualElement root = menu.rootVisualElement;

        controller = new(root);
        attackController = new(root);

        controller.RegisterMenuCallbacks();
        attackController.RegisterAttackCallbacks();
    }
}

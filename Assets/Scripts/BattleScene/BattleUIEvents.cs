using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleUIEvents : MonoBehaviour
{
    UIDocument document;

    Button button;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        button = document.rootVisualElement.Q("Attack") as Button;
        button.RegisterCallback<ClickEvent>(OnClick);
    }

    void OnClick(ClickEvent evt)
    {
        document.rootVisualElement.Q("MenuGroupBox").style.display = DisplayStyle.None;
        document.rootVisualElement.Q("AttackGroupBox").style.display = DisplayStyle.Flex;

    }
}

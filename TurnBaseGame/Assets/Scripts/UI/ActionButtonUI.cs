using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButtonUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Button button;
    [SerializeField] GameObject selectedGameObject;

    BaseAction baseAction;
    public void SetBaseAction(BaseAction baseAction)
    {
        this.baseAction = baseAction;

        textMeshPro.text = baseAction.GetActionName().ToUpper();

        button.onClick.AddListener(() => 
        {
            UnitActionSystem.Instance.SetSelectedAction(baseAction);
        });
    }

    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();
        selectedGameObject.SetActive(baseAction == selectedBaseAction);
    }
}

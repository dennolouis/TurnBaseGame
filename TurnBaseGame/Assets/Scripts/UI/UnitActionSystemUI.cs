using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UnitActionSystemUI : MonoBehaviour
{

    [SerializeField] Transform actionButtonPrefab;
    [SerializeField] Transform actionButtonContainerTransform;
    [SerializeField] TextMeshProUGUI actionPointsText;

    List<ActionButtonUI> actionButtonUIList;


    private void Awake()
    {
        actionButtonUIList = new List<ActionButtonUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UnitActionSystem.Instance.OnSelectedActionChanged += UnitActionSystem_OnSelectedActionChanged;
        UnitActionSystem.Instance.OnActionStarted += UnitActionSystem_OnActionStarted;
        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
        Unit.OnAnyActionPointsChanged += Unit_OnAnyActionPointsChanged;

        UpdateActionPoints();
        CreateUnitActionButtons();
        UpdateSlectedAction();
    }

    void CreateUnitActionButtons()
    {
        foreach(Transform buttonTransform in actionButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        actionButtonUIList.Clear();

        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();

        foreach(BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseAction(baseAction);

            actionButtonUIList.Add(actionButtonUI);
        }
    }

    void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        UpdateActionPoints();
        CreateUnitActionButtons();
        UpdateSlectedAction();
    }

    void UnitActionSystem_OnSelectedActionChanged(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }

    void UnitActionSystem_OnActionStarted(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }

    void UpdateSlectedAction()
    {
        foreach(ActionButtonUI actionButtonUI in actionButtonUIList)
        {
            actionButtonUI.UpdateSelectedVisual();
        }
    }

    void UpdateActionPoints()
    {
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        int actionPoints = selectedUnit.GetActionPoints();
        actionPointsText.text = "Action Points: " + actionPoints;
    }

    void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }

    void Unit_OnAnyActionPointsChanged(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }
}

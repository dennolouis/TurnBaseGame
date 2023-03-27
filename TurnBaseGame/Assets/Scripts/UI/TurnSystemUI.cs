using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TurnSystemUI : MonoBehaviour
{
   [SerializeField] Button endTurnBtn;
   [SerializeField] TextMeshProUGUI tunrNumberText;
   [SerializeField] GameObject enemyTurnVisualGameObject;


   private void Start()
   {
        endTurnBtn.onClick.AddListener(() => 
        {
            TurnSystem.Instance.NextTurn();
        });

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        UpdateTurnText();
        UpdateEnemyTurnVisual();
        UpdateEndTurnButtonVisual();
   }


   void UpdateTurnText()
   {
        tunrNumberText.text = "Turn " + TurnSystem.Instance.GetTurnNumber();
   }

   void TurnSystem_OnTurnChanged(object sender, EventArgs e)
   {
        UpdateTurnText();
        UpdateEnemyTurnVisual();
        UpdateEndTurnButtonVisual();
   }

   void UpdateEnemyTurnVisual()
   {
     enemyTurnVisualGameObject.SetActive(!TurnSystem.Instance.IsPlayerTurn());
   }

   void UpdateEndTurnButtonVisual()
   {
     endTurnBtn.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
   }
}

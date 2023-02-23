using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{

    public static GridSystemVisual Instance {get; private set;}

   [SerializeField] Transform gridSystemVisualSinglePrefab;
   GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
   private void Start()
   {
        gridSystemVisualSingleArray = new GridSystemVisualSingle
        [
            LevelGrid.Instance.GetWidth(),
            LevelGrid.Instance.GetHeight()
        ];

        for(int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for(int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                
                Transform gridSystemVisualTransform = 
                    Instantiate(gridSystemVisualSinglePrefab, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);

                gridSystemVisualSingleArray[x, z] = gridSystemVisualTransform.GetComponent<GridSystemVisualSingle>(); 
            }
        }
   }

   private void Update()
   {
        UpdateGridVisual();
   }


   public void HideAllGridPosition()
   {
        for(int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for(int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                gridSystemVisualSingleArray[x,z].Hide();
            }
        }
   }

   public void ShowGridPositionList(List<GridPosition> gridPositionList)
   {
    foreach(GridPosition gridPosition in gridPositionList)
    {
        gridSystemVisualSingleArray[gridPosition.x, gridPosition.z].Show();
    }
   }

   void UpdateGridVisual()
   {
        HideAllGridPosition();

        BaseAction selectedAction = UnitActionSystem.Instance.GetSelectedAction();
        
        ShowGridPositionList(
            selectedAction.GetValidActionGridPositionList()
        );
   }
}

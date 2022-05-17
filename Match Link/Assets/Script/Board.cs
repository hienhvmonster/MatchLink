using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Block container must be child of board

    private AllBoardsManager allBoardsManager;

    public int width;
    public int height;
    public int widthOffSet;
    public int heightOffSet;

    public GameObject blockContainer;

    private BlockContainer[,] allBlockContainers;


    public void BoardInit(AllBoardsManager boards)
    {
        allBoardsManager = boards;
        allBlockContainers = new BlockContainer[width, height];
        for (int i = 0; i < transform.childCount; i++)
        {
            BlockContainer tmp = transform.GetChild(i).GetComponent<BlockContainer>();
            if (tmp == null)
            {
                Debug.LogError(transform.GetChild(i).name + " doesnt contain BlockContainer", tmp.gameObject);
            }
            else
            {
                int xOnBoard = (int)tmp.transform.position.x + widthOffSet;
                int yOnBoard = (int)tmp.transform.position.y + heightOffSet;
                if (xOnBoard >= width || xOnBoard < 0 || yOnBoard >= height || yOnBoard < 0)
                {
                    Debug.LogError("Check board width and height.\nBlock container overflow at " + tmp.transform.position, tmp.gameObject);
                }
                else if (allBlockContainers[xOnBoard, yOnBoard] != null)
                {
                    Debug.LogWarning("Already have a block container at " + tmp.transform.position, tmp.gameObject);
                    DestroyImmediate(tmp.gameObject);
                    i--;
                }
                else//setup blockcontainer
                {
                    allBlockContainers[xOnBoard, yOnBoard] = tmp;
                    tmp.transform.name = (xOnBoard + ", " + yOnBoard);
                    allBoardsManager.GenerateBlock(tmp.transform);
                }
            }
        }
    }

    public void DestroyBlock(Vector2 blockPosition, bool isWorldPoint)
    {
        if (!isWorldPoint)
        {

        }
    }
}

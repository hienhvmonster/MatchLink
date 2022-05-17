using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    private Board myBoard;
    private Block myBlock;

    public void BlockContainerInit(Board board)
    {
        if(board == null)
        {
            Debug.LogError("BlockContainer in null board", this);
            return;
        }
        myBoard = board;
    }

    public Board GetBoard()
    {
        return myBoard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

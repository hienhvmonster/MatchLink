using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    private Block myBlock;

    public void BlockContainerInit(Block block)
    {
        SetMyBlock(block);
    }


    private void SetMyBlock(Block block)
    {
        if(block == null)
        {
            Debug.LogError(name + " contains null block", this);
        }
        myBlock = block;
    }

    public Block DestroyBlock()
    {
        return myBlock.DestroyBlock();
    }

    public void DropBlock(Transform nextDrop)
    {
        myBlock.Drop(nextDrop);
        myBlock = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private BlockType myBlockType;
    public int maxNormalBlock = 1;

    public float fallSpeed = .2f;
    public float minDistanceAllow = .05f;
    private bool isDrop = false;

    public void Spawn(BlockContainer blockContainer)
    {
        if(blockContainer == null)
        {
            Debug.LogError("Block spawn at null", this);
        }
        RandomNormalBlockType();
        Drop(blockContainer.transform);
    }

    public void Drop(Transform blockContainer)
    {
        transform.SetParent(blockContainer, true);
        isDrop = true;
    }


    private void FixedUpdate()
    {
        if (!isDrop) return;
        if (Mathf.Abs(transform.localPosition.y) <= minDistanceAllow)
        {
            transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
            isDrop = false;
        }
        else
        {
            transform.Translate(Vector3.down * Time.fixedDeltaTime * fallSpeed);
        }
        
    }

    public Block DestroyBlock()
    {
        return this;
    }

    public void RandomNormalBlockType()
    {
        int rand = Random.Range(0, maxNormalBlock);
        switch (rand)
        {
            case 0:
                {
                    myBlockType = new BlueBlock();
                    break;
                }
        }
    }

    private void Update()
    {
        if (transform.lossyScale != Vector3.one)
            transform.localScale = new Vector3(1 / transform.lossyScale.x, 1 / transform.lossyScale.y, 1 / transform.lossyScale.z);
    }
}

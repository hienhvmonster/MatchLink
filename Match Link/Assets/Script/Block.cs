using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float fallSpeed = .2f;
    public float minDistanceAllow = .05f;
    private bool isDrop = false;

    public void Spawn(BlockContainer blockContainer)
    {
        if(blockContainer == null)
        {
            Debug.LogError("Block spawn at null", this);
        }
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

    public void DestroyBlock()
    {

    }
}

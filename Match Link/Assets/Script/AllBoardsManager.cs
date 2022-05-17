using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBoardsManager : MonoBehaviour
{
    private Queue<Block> dropDownBlocks = new Queue<Block>();
    private List<Board> boards = new List<Board>();
    [SerializeField] Transform dropDownBlockContainer;
    public GameObject[] blockPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        AllBoardsInit();
    }

    private void AllBoardsInit()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Board board = transform.GetChild(i).GetComponent<Board>();
            if (board == null)
            {
                if(transform.GetChild(i) == dropDownBlockContainer)
                {
                    continue;
                }

                Debug.LogError(transform.GetChild(i).name + " doesnt contain Board", transform.GetChild(i));
                continue;
            }

            boards.Add(board);
            board.BoardInit(this);
        }
    }

    public void GenerateBlock(Transform blockContainer)//fix this
    {
        if (blockContainer == null)
        {
            Debug.LogWarning("Generate block in null");
            return;
        }
        if (blockContainer.GetComponentInChildren<Block>() != null)//block container already contain a block added by default
        {
            GameObject blockTmp = Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], dropDownBlockContainer);
            DropDownBlockEnqueue(blockTmp.GetComponent<Block>());
            return;
        }
        Instantiate(blockPrefabs[Random.Range(0, blockPrefabs.Length)], blockContainer);
    }

    public void ReturnDropDownBlock(Block block)
    {
        block.transform.SetParent(dropDownBlockContainer);
        block.transform.localPosition = Vector3.zero;
        DropDownBlockEnqueue(block);
    }

    public Block GetDropDownBlock(BlockContainer blockContainer, Vector3 dropPosition)
    {
        Block block = DropDownBlockDequeue();
        block.transform.position = dropPosition;
        block.Spawn(blockContainer);
        return block;
    }

    private void DropDownBlockEnqueue(Block block)
    {
        dropDownBlocks.Enqueue(block);
    }
    private Block DropDownBlockDequeue()
    {
        return dropDownBlocks.Dequeue();
    }
}

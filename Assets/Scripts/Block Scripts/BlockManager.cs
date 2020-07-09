using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private int maxBlocks=10;
    [SerializeField]
    private GameObject[] blocks;
    [SerializeField]
    private GameObject lastBlock;
    [HideInInspector]
    public GameObject catLandedBlock;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < maxBlocks; i++)
        {  
            Invoke("CreateNewBlock",i*0.05f);
        }
    }  

    // Update is called once per frame
    void CreateNewBlock()
    {
        Vector3 pos = Vector3.zero;
        while (true)
        {
            int randomm = Random.Range(0, 100);
            if (randomm < 50)
            {
                pos = new Vector3(lastBlock.transform.localPosition.x, 1f,
                    lastBlock.transform.localPosition.z + 1f);

                if (Physics.Raycast(pos, Vector3.down, 1.5f) &&
                    Physics.Raycast(new Vector3(pos.x, pos.y, pos.z + 1f), Vector3.down, 1.5f))
                    break;

            }
            else if (randomm < 70)
            {
                pos = new Vector3(lastBlock.transform.localPosition.x + 1f, 1f,
                    lastBlock.transform.localPosition.z);

                if (Physics.Raycast(pos, Vector3.down, 1.5f) &&
                    Physics.Raycast(new Vector3(pos.x + 1f, pos.y, pos.z), Vector3.down, 1.5f))
                    break;

            }
            else if (randomm < 90)
            {
                pos = new Vector3(lastBlock.transform.localPosition.x - 1f, 1f,
                    lastBlock.transform.localPosition.z);

                if (Physics.Raycast(pos, Vector3.down, 1.5f) &&
                    Physics.Raycast(new Vector3(pos.x - 1f, pos.y, pos.z), Vector3.down, 1.5f))
                    break;
            }
        }
        int num = Random.Range(0,100) > 0 ? 0 : 1;
        GameObject temp = Instantiate(blocks[num]) as GameObject;
        temp.transform.localPosition = new Vector3(pos.x, 0f, pos.z);
        temp.transform.parent = transform;
        temp.name = "Block";
        lastBlock = temp;

        temp.GetComponent<BlockScript>().moveLikeYoyo=true;
       
    }
    public void LeaveLandedBlock()
    {
        /*for (int i = 0; i < 2; i++)
        {
           CreateNewBlock();
        }*/
        CreateNewBlock();
        if (catLandedBlock != null)
        {
            catLandedBlock.SendMessage("FallBlock");
        }

    }
}

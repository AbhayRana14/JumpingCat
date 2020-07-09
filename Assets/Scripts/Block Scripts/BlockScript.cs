using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockScript : MonoBehaviour
{
    [HideInInspector]
    public bool moveLikeYoyo;

    // Start is called before the first frame update
    void Start()
    {
        if (moveLikeYoyo)
        {
            transform.DOLocalMoveY(-0.1f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        }
    }

    void FallBlock()
    {
        CancelInvoke("FallBlock");
        transform.DOLocalMoveY(-3f, 0.5f);
        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.name == "Cat")
        {
            if (moveLikeYoyo)
            {
                Invoke("FallBlock", 0.25f);
            }
        }
    }
}

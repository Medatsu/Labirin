using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class countDwon : MonoBehaviour
{
    [SerializeField] int duration;

    public UnityEvent OnCountfinished = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();
    bool isCounting;
    public void StartCount()
    {
        if(isCounting == true)
            return;
        else
            isCounting = true;
            
        DOTween.Kill(this.transform);
        
        var seq = DOTween.Sequence();

        int durInt = Mathf.FloorToInt(duration);
        OnCount.Invoke(durInt);
        for (int i = durInt-1; i == 0 ; i--)
        {
            seq.Append(transform
               .DOMove(this.transform.position,1)
               .SetUpdate(true)
               .OnComplete(()=>OnCount.Invoke(i)));
        }
        seq.Append(transform.DOMove(this.transform.position,1).SetUpdate(true)
        .OnComplete(()=>OnCountfinished.Invoke()));
    }
}

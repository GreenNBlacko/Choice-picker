using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerScript : MonoBehaviour
{
    public bool DestroyOverTime;
    public int TimeToWaitBeforeDestroy;
    public string DestroyTrigger;

    public Animator Animator;    

    void Start() {
        if(DestroyOverTime) {
            StartCoroutine(DestroyAfterInterval(TimeToWaitBeforeDestroy));
        }
    }

    public void SetTrigger (string TriggerName) {
        Animator.SetTrigger(TriggerName);
    }

    public string BoolName { private get; set; }
    public void SetBool () {
        if(Animator.GetBool(BoolName) == false) { Animator.SetBool(BoolName, true); }
        else { Animator.SetBool(BoolName, true); }
    }

    public void SelfDestruct() {
        Destroy(gameObject);
    }

    public IEnumerator DestroyAfterInterval(int IntervalInS) {
        int WaitedFrames = 0;
        for(int i = 0; i < 21; i++) {
            yield return 0;
            WaitedFrames++;
        }
        while (WaitedFrames != 20) {StartCoroutine(DestroyAfterInterval(TimeToWaitBeforeDestroy));}
        yield return new WaitForSecondsRealtime(IntervalInS);
        SetTrigger(DestroyTrigger);
    }
}

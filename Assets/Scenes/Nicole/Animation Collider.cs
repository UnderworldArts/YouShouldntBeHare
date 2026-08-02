using UnityEngine;

public class AnimationCollider : MonoBehaviour
{
    [SerializeField] GameObject animatedobject;
    [SerializeField] Animator anim;

    public void OnTriggerEnter()
    {
        Debug.Log("Triggered");
        //any bool checks for tutorial

        if (anim == null)
        return;
        anim.SetBool("In", false);
        anim.SetBool("Out", true);
    }

    public void OnTriggerExit()
    {
        Debug.Log("Triggered");

        if (anim == null)
        return;
        anim.SetBool("In", true);
        anim.SetBool("Out", false);
    }
}

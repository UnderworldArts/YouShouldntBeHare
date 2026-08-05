using UnityEngine;
using System.Collections;
using static Unity.VisualScripting.Member;

public class AnimationCollider : MonoBehaviour
{
    [SerializeField] GameObject animatedobject;
    [SerializeField] Animator anim;

    [SerializeField] bool Exit = false;
    [SerializeField] Menus menus;

    AudioSource source; // nickname for the text sound effect

    void Start()
    {
        source = GetComponent<AudioSource>(); // assigns as the audiosource from the game object the script is on
    }

    public void OnTriggerEnter()
    {
        Debug.Log("Triggered");
        //any bool checks for tutorial

        if (anim == null)
        return;
        anim.SetBool("In", false);
        anim.SetBool("Out", true);

        OpenAudio();

        if (Exit)
        {
            Debug.Log("Exit condition");
            StartCoroutine(ExitSequence());
        }
        else
        {
            Debug.Log("Random door");
        }
    }

    public IEnumerator ExitSequence()
    {
        yield return new WaitForSeconds(1f);
        menus.NextScene();
    }

    public void OnTriggerExit()
    {
        Debug.Log("Triggered");

        if (anim == null)
        return;
        anim.SetBool("In", true);
        anim.SetBool("Out", false);

        OpenAudio();
    }

    public void OpenAudio()
    {
        if (source != null && source.clip != null) // checks if audio source was on game object and if it has an audio clip attached
        {
            source.Play();
        }
        else // debugging
        {
            Debug.LogWarning("No audio source on game object");
        }
    }
}

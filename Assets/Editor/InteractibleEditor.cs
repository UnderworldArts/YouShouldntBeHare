using UnityEditor;

[CustomEditor(typeof(Interactible),true)]
public class InteractibleEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Interactible interactible = (Interactible)target;
        if(target.GetType() == typeof(EventOnlyInteractible))
        {
            interactible.interactionPrompt = EditorGUILayout.TextField("Interaction Prompt", interactible.interactionPrompt);
            EditorGUILayout.HelpBox("This interactible is event only, it will not have any default interaction behavior.", MessageType.Info);
            if(interactible.GetComponent<InteractionEvent>() == null)
            {
                interactible.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            base.OnInspectorGUI();
            if (interactible.useEvents)
            {
                if (interactible.GetComponent<InteractionEvent>() == null)
                {
                    interactible.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                if (interactible.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(interactible.GetComponent<InteractionEvent>());
                }
            }
        }
        
    }
}

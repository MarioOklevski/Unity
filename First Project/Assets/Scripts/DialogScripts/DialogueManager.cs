using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogueText;

    public Animator anim;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {

        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);

        NameText.text = dialogue.Name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
    }
}

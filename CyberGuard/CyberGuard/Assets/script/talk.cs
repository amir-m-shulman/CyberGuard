using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class talk : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    [SerializeField] GameObject bridgh;
    [SerializeField] GameObject edge;
    [SerializeField] float delay;
    [SerializeField] PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        pm.control = "none";
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if(bridgh != null)
            {
                bridgh.SetActive(true);
            }
            
            Invoke("DB", delay);
        }
    }
    private void DB()
    {
        pm.control = "player";
        Destroy(edge);
    }
}



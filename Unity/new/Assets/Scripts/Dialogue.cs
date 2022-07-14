using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image image;
    public TextMeshProUGUI nameOfPerson;
    //public TextMeshProUGUI[] lines;

    public GameObject[] lines;
    public float textspeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartDialogue()
    {
        index = 0;
        SetImageAndName(index);
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        //foreach (char c in lines[index].text.ToCharArray())
        foreach (char c in lines[index].GetComponent<TextMeshProUGUI>().text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index += 1;
            SetImageAndName(index);
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {

            Debug.Log("turn off AAA");
            FindObjectOfType<StoryFlow>().IsDoneWithDisplaying = true;
            this.transform.parent.gameObject.SetActive(false);
        }
    }

    public void WhenTapDown(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed && this.transform.parent.gameObject.activeSelf)
        {
            Debug.Log("tapped1");
            if (textComponent.text == lines[index].GetComponent<TextMeshProUGUI>().text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index].GetComponent<TextMeshProUGUI>().text;
            }
        }

    }

    void SetImageAndName(int index)
    {
        image.sprite = lines[index].GetComponentInChildren<Image>().sprite;
        image.color = lines[index].GetComponentInChildren<Image>().color;
        nameOfPerson.text = lines[index].GetComponentInChildren<Image>().GetComponentInChildren<TextMeshProUGUI>().text;
    }




}

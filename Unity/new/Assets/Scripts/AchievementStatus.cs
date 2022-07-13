using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementStatus : MonoBehaviour
{
    public bool Achieved = false;
    [SerializeField] GameObject Obtained;
    [SerializeField] GameObject Unobtained;
    [SerializeField] TMP_Text Name;
    
    // Update is called once per frame
    void Update()
    {
        if (Achieved)
        {
            Obtained.SetActive(true);
            Unobtained.SetActive(false);
        } else
        {
            Obtained.SetActive(false);
            Unobtained.SetActive(true);
        }
    }

    public void SetName(string _name)
    {
        Name.text = _name;
    }
}

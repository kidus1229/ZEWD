using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Manager.cs;

public class CountDown : MonoBehaviour 
{
    //[SerializeField] GameObject successpanel;
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;
    // Start is called before the first frame update
    void Start()
    {
        //successpanel.SetActive(false);
        panel.SetActive(false);
        currentTime = 180;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;

           /* if (Manager.DropNecklace() && Manager.DropHand() && Manager.DropLeg() == true;)
            {
                void SuccessPanel();
            } */
        }
        OpenPanel();    
    }


    void OpenPanel()
    {
        timeText.text = "";
        panel.SetActive(true);
    }

    /* void SucessPanel()
     {
      timeText.text = "";
      successpanel.SetActive(true);
    }

    
}

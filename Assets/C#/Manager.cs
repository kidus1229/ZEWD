using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Sth
{

    public class Manager : MonoBehaviour
    {
        /*  // Start is called before the first frame update
          void Start()
          {

          }

          // Update is called once per frame
          void Update()
          {

          } */
        public GameObject necklace, hand, leg, necklacePosition, handPosition, legPosition, successpanel, panel;
        [SerializeField] Image timeImage;
        [SerializeField] Text timeText;
        [SerializeField] float duration, currentTime;
        public static bool isDoneNecklace, isDoneHand, isDoneLeg;
        Vector2 necklaceInitialPos, handInitialPos, legInitialPos;



        void Start()
        {
            necklaceInitialPos = necklace.transform.position;
            handInitialPos = hand.transform.position;
            legInitialPos = leg.transform.position;
            successpanel.SetActive(false);
            panel.SetActive(false);
            currentTime = 180;
            timeText.text = currentTime.ToString();
            StartCoroutine(TimeIEn());
        }


        public void DragNecklace()
        {
            necklace.transform.position = Input.mousePosition;
        }

        public void DragHand()
        {
            hand.transform.position = Input.mousePosition;
        }

        public void DragLeg()
        {
            leg.transform.position = Input.mousePosition;
        }


        public void DropNecklace()
        {
            float Distance = Vector3.Distance(necklace.transform.position, necklacePosition.transform.position);
            if (Distance < 50)
            {
                necklace.transform.position = necklacePosition.transform.position;
                isDoneNecklace = true;
            }
            else
            {
                necklace.transform.position = necklaceInitialPos;
            }
        }


        public void DropHand()
        {
            float Distance = Vector3.Distance(hand.transform.position, handPosition.transform.position);
            if (Distance < 50)
            {
                hand.transform.position = handPosition.transform.position;
                isDoneHand = true;
            }
            else
            {
                hand.transform.position = handInitialPos;
            }
        }


        public void DropLeg()
        {
            float Distance = Vector3.Distance(leg.transform.position, legPosition.transform.position);
            if (Distance < 50)
            {
                leg.transform.position = legPosition.transform.position;
                isDoneLeg = true;
            }
            else
            {
                leg.transform.position = legInitialPos;
            }
        }

        IEnumerator TimeIEn()
        {
            while (currentTime >= 0)
            {
                timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
                timeText.text = currentTime.ToString();
                yield return new WaitForSeconds(1f);
                currentTime--;

                if (Manager.isDoneNecklace && Manager.isDoneHand && Manager.isDoneLeg == true)
                {
                    SuccessPanel();
                    break;
                }
            }
            OpenPanel();
        }


        void OpenPanel()
        {
            timeText.text = "";
            panel.SetActive(true);
        }

         void SuccessPanel()
         {
             timeText.text = "";
             successpanel.SetActive(true);
         }



    }
}
 /*namespace Sth
{

    public class CountDown : Manager
    {


        [SerializeField] GameObject successpanel;
        [SerializeField] GameObject panel;
        [SerializeField] Image timeImage;
        [SerializeField] Text timeText;
        [SerializeField] float duration, currentTime;
        // Start is called before the first frame update
        void Start()
        {
            successpanel.SetActive(false);
            panel.SetActive(false);
            currentTime = 10;
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

                if (Manager.isDoneNecklace && Manager.isDoneHand && Manager.isDoneLeg == true)
                {
                    Debug.Log("worked"); //void SuccessPanel();
                }
            }
            //SucessPanel();
            OpenPanel();
        }


        void OpenPanel()
        {
            timeText.text = "";
            panel.SetActive(true);
        }

        void SucessPanel()
        {
            timeText.text = "";
            successpanel.SetActive(true);
        }


    }
}*/
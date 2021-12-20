using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Sth
{

    public class Manager : MonoBehaviour
    {
        public GameObject necklace, hand, leg, necklacePosition, handPosition, legPosition, successpanel, panel, bgMusic, failSd, safePanel, inputFeild1, inputFeild2, inputFeild3, openSafePanel;
        [SerializeField] Image timeImage;
        [SerializeField] Text timeText;
        [SerializeField] float duration, currentTime;
        public static bool isDoneNecklace, isDoneHand, isDoneLeg, isKey1Correct, isKey2Correct, isKey3Correct;
        Vector2 necklaceInitialPos, handInitialPos, legInitialPos;
        public int testKey1, testKey2, testKey3;
        public string input1, input2, input3;



        void Start()
        {
            necklaceInitialPos = necklace.transform.position;
            handInitialPos = hand.transform.position;
            legInitialPos = leg.transform.position;
            openSafePanel.SetActive(false);
            safePanel.SetActive(false);
            successpanel.SetActive(false);
            panel.SetActive(false);
            currentTime = 180;
            isDoneHand = false;
            isDoneLeg = false;
            isDoneNecklace = false;
            testKey1 = 7;
            testKey2 = 4;
            testKey3 = 7;
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
                    
                    SafePanel();
                    if (isKey1Correct && isKey2Correct && isKey3Correct == true && currentTime >=0)
                    {
                        OpenSafePanel();
                        break;
                    }
                    
                }
            }
            OpenPanel();
        }


        void OpenPanel()
        {
            panel.SetActive(true);
            Destroy(bgMusic);
        }

        public void SuccessPanel()
        {
            successpanel.SetActive(true);
            Destroy(bgMusic);
            Destroy(failSd);
           
        }

        void OpenSafePanel()
        {
            openSafePanel.SetActive(true);
            Destroy(bgMusic);
            Destroy(failSd);
            Destroy(panel);
        }

        void SafePanel()
        {
            safePanel.SetActive(true);
            bgMusic.SetActive(true);
        }
        
        public void Play()
        {
            SceneManager.LoadScene("Level_1");
        }
        public void ReadInputCode1()
        {
            input1 = inputFeild1.GetComponent<Text>().text.ToString();
            Debug.Log(input1);
            checkKey1();
        }
        public void ReadInputCode2()
        {
            input2 = inputFeild2.GetComponent<Text>().text.ToString();
            Debug.Log(input2);
            checkKey2();
        }
        public void ReadInputCode3()
        {
            input3 = inputFeild3.GetComponent<Text>().text.ToString();
            Debug.Log(input3);
            checkKey3();
        }
        void checkKey1()
        {
            if(int.Parse(input1) == testKey1)
            {
                isKey1Correct = true;
            }
            else
            {
                isKey1Correct = false;
            }
        }
        void checkKey2()
        {
            if (int.Parse(input2) == testKey2)
            {
                isKey2Correct = true;
            }
            else
            {
                isKey2Correct = false;
            }
        }
        void checkKey3()
        {
            if (int.Parse(input3) == testKey3) 
            {
                isKey3Correct = true;
            }
            else
            {
                isKey3Correct = false;
            }
        }
    }
}

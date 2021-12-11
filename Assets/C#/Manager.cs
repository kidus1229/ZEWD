using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject necklace, hand, leg, necklacePosition, handPosition, legPosition;

    Vector2 necklaceInitialPos, handInitialPos, legInitialPos;


    void Start()
    {
        necklaceInitialPos = necklace.transform.position;
        handInitialPos = hand.transform.position;
        legInitialPos = leg.transform.position;
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
        if(Distance < 50)
        {
            necklace.transform.position = necklacePosition.transform.position;
            //return true;
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
            //return true;
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
            //return true;
        }
        else
        {
            leg.transform.position = legInitialPos;
        }
    }


}

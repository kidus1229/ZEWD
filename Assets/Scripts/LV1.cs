using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LV1 : MonoBehaviour
{
    // Start is called before the first frame update          
    GameObject[] pieces;
    int pieceNo = 0;
    GameObject piece1 = null;
    GameObject piece2 = null;

    Vector3 state1,state2;
    bool bothSelected = false;
    bool randomize = true;
    bool isWon = false;
    Vector3 travel = new Vector3(0.002f, 0.002f, 0.002f);
    Vector3 temp = new Vector3();
    Vector3 temp2 = new Vector3();
    Vector3 pic1Destination, pic2Destination;

    [SerializeField] private GameObject finishPanel = null, newRecord=null;
    [SerializeField] private Text yourFinishTime = null;
     [SerializeField] private Text yourBestTime = null;

    // [SerializeField] private  GameObject lostPanel;

    public static ArrayList keypos = new ArrayList();
    public static ArrayList id = new ArrayList();

    [SerializeField] private Button undoButton;
    private void Awake()
{
 undoButton.onClick.AddListener(undoMove);
    }
    void Start()
    {

        pieces = GameObject.FindGameObjectsWithTag("PIC");
        finishPanel.SetActive(false);


    }

    // Update is called once per frame




    void Update()
    {
        int stateIndex = 0;
        var a = GetComponent<Timer>();

        // shuffle runs only once
        {
            if (randomize == true)
            {
                shuffle();
                randomize = false;
            }

        }

        {     //bothSelected 
            if (bothSelected == false && (!isWon)) // check  2 selected pieces
                foreach (GameObject o in pieces)
                { if(stateIndex==3)
                     stateIndex = 0;

                    Tile swap = o.GetComponent<Tile>();
                    if (swap.retSelected() && pieceNo == 0)    // piece 1 that is selected
                    {
                        piece1 = o;
                        temp = piece1.transform.position;
                        state1 = piece1.transform.position;
                        pieceNo++;
                        swap.flipSelected();
                        pic2Destination = piece1.transform.position;
                        

                        //    Debug.Log(o.name + " : " + swap.retSelected());


                    }
                    else if (swap.retSelected() && pieceNo == 1) // piece 2 that is selected
                    {
                        piece2 = o;
                        temp2 = piece2.transform.position;
                        state2 = piece2.transform.position;
                        stateIndex++;
                        pieceNo++;
                        swap.flipSelected();
                         
                        // Debug.Log(o.name + " : " + swap.retSelected());
                        bothSelected = true;
                        pic1Destination = piece2.transform.position;
                        break;
                    }

                }
            //move the two pieces
            if (pieceNo == 2 && bothSelected == true)
            {

                Vector3 directionVector = Vector3.Normalize((pic1Destination - temp));    // from pice 1 to piece 2 and negative from pice2 to piece 1

                temp += directionVector / (5f);
                temp2 += -directionVector / (5f);
                piece1.transform.position = temp;
                piece2.transform.position = temp2;
                //Debug.Log("in");

                if (Mathf.Abs((piece1.transform.position.x - pic1Destination.x)) < 5.0f && Mathf.Abs((piece1.transform.position.y - pic1Destination.y)) < 5.0f && Mathf.Abs((piece2.transform.position.x - pic2Destination.x)) < 5.0f && Mathf.Abs((piece2.transform.position.y - pic2Destination.y)) < 5.0f)
                {
                    bothSelected = false;
                    pieceNo = 0;
                    piece1.transform.position = pic1Destination;
                    piece2.transform.position = pic2Destination;
                    piece1.GetComponent<SpriteRenderer>().color = Color.white;
                    piece2.GetComponent<SpriteRenderer>().color = Color.white;
                    Debug.Log("placed");
                    if (checkWin())
                    {isWon = true;
                        yourFinishTime.text = (a.minutes < 10 ? "0" : "") + a.minutes + ":" + (a.seconds < 10 ? "0" : "") + a.seconds;
                        a.StopTimer();
                        int bestTime;
                        if (PlayerPrefs.HasKey("bestTime"))
                        {
                            bestTime = PlayerPrefs.GetInt("bestTime");
                        }
                        else {
                            bestTime = 999999;
                        }
                        int yourTime = a.minutes * 60 + a.seconds;
                        if(yourTime < bestTime) {
                            newRecord.SetActive(true);
                            PlayerPrefs.SetInt("bestTime", yourTime);
                        }
                        else {
                            int minutes = bestTime / 60;
                            int seconds = bestTime - minutes;
                            yourBestTime.text = (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
                            yourBestTime.transform.parent.gameObject.SetActive(true);
                            newRecord.SetActive(false);

                        }

                        finishPanel.SetActive(true);

                        


                    }

                }


            }


        }



    }
    void shuffle()
    {
        int guess = 0;
        for (int i = 0; i < 16; i++) //each piece has correct position when the game starts
        {
            guess = Random.Range(0, 15);
            while (guess == i)
            {
                guess = Random.Range(0, 15);

            }

            Vector3 temp = pieces[i].transform.position;
            pieces[i].transform.position = pieces[guess].transform.position;
            pieces[guess].transform.position = temp;

        }


    }


    public void undoMove() {
                     piece1.transform.position = state1;
                     piece2.transform.position = state2 ;
                     
        // Debug.Log("Undo working");

    }

    bool checkWin()
    {
        int solvedPiece = 0;

        for (int i = 0; i < 16; i++)
        {

            if (pieces[i].transform.position.Equals(keypos[id.IndexOf(pieces[i].name)]))
                solvedPiece++;

        }



        Debug.Log("solved" + " " + solvedPiece);
        return (solvedPiece == 16) ? true : false;
    }

  

}
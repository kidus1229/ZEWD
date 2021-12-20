
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    // to hold the counter time value.
    [SerializeField] private Text timeText; 

    // to display GameOver promt if player loses
    [SerializeField] private  GameObject lostPanel;



    public  int seconds, minutes;

    // Start is called before the first frame update


    private void addToSecond()
    {
        seconds++;
        if (seconds > 59)
        {
            minutes++;
            seconds = 0;
        }
        timeText.text =(minutes<10 ? "0":"")+ minutes + ":" + (seconds < 10? "0":"") + seconds;

    //    this builtin method simulates the time functionality
        Invoke(nameof(addToSecond), 1);
            if(minutes==2) {
            StopTimer();
           lostPanel.SetActive(true);
        }

    }

    // setting initial conditions
    void Start() {
           addToSecond();
           lostPanel.SetActive(false);
    }

    // To stop the timer when game ends or player wins
    public void StopTimer(){
        CancelInvoke(nameof(addToSecond)); // TTo end the timer functionality
        timeText.gameObject.SetActive(false); //Stop the counter
    }
}

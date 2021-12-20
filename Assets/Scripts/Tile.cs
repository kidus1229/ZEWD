
using UnityEngine;

public class Tile : MonoBehaviour    
{
    // Start is called before the first frame update
    private bool is_selected;
    public Vector3 scale = new Vector3();


    void OnEnable()
    {
        LV1.keypos.Add(this.transform.position);
        LV1.id.Add(this.name);

    }

    void Start()
    {
        is_selected = false;
    }
   

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))                                  // check if this piece is clicked
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //convert the clicked position to world point 
            // in order to compare it against objects
            Vector2 mousePos2D = new Vector2(mousePos.x,mousePos.y);
            RaycastHit2D hit= Physics2D.Raycast(mousePos2D,Vector2.zero);

            if (hit.collider != null && hit.collider.transform.name == this.name)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                flipSelected();
                                this.GetComponent<SpriteRenderer>().color = Color.green;

                //Debug.Log(this.name)

            }

           
        }
    }
   public bool retSelected()
    {
        return is_selected;

    }
   public void flipSelected()
    {
        is_selected = !is_selected;
    }
   
}
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door; 
    public GameObject interior;
    public GameObject house;
    private bool isOpen = false;
   // public GameObject book;
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("PlayerCharacter") && !isOpen)
        {
           
            OpenDoor();

            ShowInterior();
            house.SetActive(false);
          
        }

    }
    public void Start()
    {
        interior.SetActive(false);
      //  book.SetActive(false);
    }
    private void Update()
    {
        // Burada gerekli ko?ullar? kontrol ederek kap?y? açabilir ve içeri?i gösterebilirsiniz.
        if (isOpen==false)
        {
            house.SetActive(true); 
         //   book.SetActive(false);   
        }
    }


    private void OpenDoor()
    {
       
      //  door.SetActive(false);
        isOpen = true;
        Debug.Log("Door is open");
        
        house.SetActive(false);
       // book.SetActive(true);
        
    }

    private void ShowInterior()
    {
        interior.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            house.SetActive(true);
            //interior.SetActive(false);
            isOpen = false;
           // book.SetActive(false);
        }
    }
}

using UnityEngine;

public class PopupController2D : MonoBehaviour
{
    public GameObject popup;
   


    private void Start()
    {   
        popup.SetActive(false); 
    
      
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("PlayerCharacter"))
        {
            Debug.Log("touched");

            ShowPopup();
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCharacter"))
        {
            Debug.Log("exit");
            HidePopup();
        }
    }

    private void ShowPopup()
    {
        popup.SetActive(true);
    }

    private void HidePopup()
    {
        popup.SetActive(false);
    }
}

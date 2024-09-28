using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class CursorLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;  
    public Transform playerCamera;         
    public float rayDistance = 100f;       

    private Button currentButton;          

    void Start()
    {
        
        //Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Cursor Look script started.");
    }

    void Update()
    {
        
        HandleMouseLook();

       
        HandleMouseInteraction();
    }

    
    public void HandleMouseLook()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        
        transform.Rotate(Vector3.up * mouseX);

        Debug.Log("Mouse horizontal movement detected: " + mouseX);
    }

   
    public void HandleMouseInteraction()
    {
        
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);  

            Button button = hit.collider.GetComponent<Button>();

            
            if (button != null)
            {
                Debug.Log("Hovering over button: " + button.name);

                
                if (button != currentButton)
                {
                    if (currentButton != null)
                    {
               
                        //sResetButtonVisuals(currentButton);
                        Debug.Log("Resetting previous button visuals.");
                    }

                    
                    HighlightButtonVisuals(button);
                    currentButton = button;
                    Debug.Log("Highlighting new button visuals: " + button.name);
                }

               
                if (Input.GetMouseButtonDown(0))  
                {
                    Debug.Log("Button clicked: " + button.name);
                    button.onClick.Invoke();  
                }
            }
            else
            {
               
                if (currentButton != null)
                {
                    //ResetButtonVisuals(currentButton);
                    currentButton = null;
                    Debug.Log("No button detected. Resetting current button visuals.");
                }
            }
        }
        else
        {
            
            if (currentButton != null)
            {
                //ResetButtonVisuals(currentButton);
                currentButton = null;
                Debug.Log("Raycast did not hit anything. Resetting button visuals.");
            }
        }
    }

    public void HighlightButtonVisuals(Button button)
    {
        Debug.Log("Changing button color to highlight.");
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = Color.yellow;  
        button.colors = colorBlock;
    }
}

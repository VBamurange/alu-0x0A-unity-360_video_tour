using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchRooms : MonoBehaviour
{
    public GameObject livingRoomSphere;   
    public GameObject cantinaSphere;      
    public GameObject cubeSphere;         
    public GameObject mezzanineSphere;    

    public Button cantinaHotspot;         
    public Button livingRoomHotspot;      
    public Button cubeHotspotFromLiving;  
    public Button cubeHotspotFromCantina; 
    public Button cubeHotspotFromMezzanine; 
    public Button mezzanineHotspot;       

    public Animator fadeAnimator;         

    private GameObject currentSphere;     

    void Start()
    {
        
        SetActiveSphere(livingRoomSphere);

        
        cantinaHotspot.onClick.AddListener(() => StartSwitch(cantinaSphere));
        livingRoomHotspot.onClick.AddListener(() => StartSwitch(livingRoomSphere));
        cubeHotspotFromLiving.onClick.AddListener(() => StartSwitch(cubeSphere));
        cubeHotspotFromCantina.onClick.AddListener(() => StartSwitch(cubeSphere));
        cubeHotspotFromMezzanine.onClick.AddListener(() => StartSwitch(cubeSphere));
        mezzanineHotspot.onClick.AddListener(() => StartSwitch(mezzanineSphere));
    }

    
    public void StartSwitch(GameObject targetSphere)
    {
        if (currentSphere != targetSphere)
        {
            StartCoroutine(SwitchWithFade(targetSphere));
        }
    }

    
    private IEnumerator SwitchWithFade(GameObject targetSphere)
    {
        
        fadeAnimator.SetTrigger("FadeOut");

        
        yield return new WaitForSeconds(1f);  

        
        SwitchSphere(targetSphere);

        
        fadeAnimator.SetTrigger("FadeIn");

        
        yield return new WaitForSeconds(1f);
    }

    
    public void SwitchSphere(GameObject targetSphere)
    {
      
        livingRoomSphere.SetActive(false);
        cantinaSphere.SetActive(false);
        cubeSphere.SetActive(false);
        mezzanineSphere.SetActive(false);

        
        SetActiveSphere(targetSphere);

        Debug.Log(targetSphere.name + " sphere is now active");
    }

    
    void SetActiveSphere(GameObject sphere)
    {
        sphere.SetActive(true);  
        currentSphere = sphere;  
    }
}

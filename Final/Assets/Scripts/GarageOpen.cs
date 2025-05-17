using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GarageOpen : MonoBehaviour
{
    public float TheDistance;
    public GameObject OpenKey;
    public GameObject CloseKey;
    public GameObject GarageOpener;
    public AudioSource MetalSound;
    public bool opened;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (TheDistance <= 4)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                opened = !opened;
            
                if (opened)
                {
                    Animation anim = GarageOpener.GetComponent<Animation>();
                    anim["Open"].normalizedSpeed = 0;
                    anim["Open"].speed = 1;
                    anim.Play();
                    // GarageDoor.GetComponent<Animation>().Play("OpenGarage1");
                    if (MetalSound.isPlaying)
                    {
                        MetalSound.Stop();
                    }
                    MetalSound.Play();
                }
                else
                {
                    Animation animation1 = GarageOpener.GetComponent<Animation>();
                    animation1["Open"].normalizedTime = 1;
                    animation1["Open"].speed = -1;
                    animation1.Play();
                    //GarageDoor.GetComponent<Animation>().Play("CloseGarage");
                    if (MetalSound.isPlaying)
                    {
                        MetalSound.Stop();
                    }
                    MetalSound.Play();
                }
            }
            if (opened)
            {
                OpenKey.SetActive(false);
                CloseKey.SetActive(true);
            }
            else
            {
                OpenKey.SetActive(true);
                CloseKey.SetActive(false);
            }
            
        }
    }
    void OnMouseExit()
    {
        OpenKey.SetActive(false);
        CloseKey.SetActive(false);
    }
}

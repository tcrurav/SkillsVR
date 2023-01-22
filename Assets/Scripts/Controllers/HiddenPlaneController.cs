using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class HiddenPlaneController : MonoBehaviour
{
    public RawImage hoverRawImage;
    public GameObject panel;
    public AudioSource audioClickButton;

    private Image image;

    private void Start()
    {
        image = panel.gameObject.GetComponent<Image>();
    }
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        //Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
        hoverRawImage.gameObject.SetActive(true);
        image.color = new Color32(255, 255, 255, 100);
        audioClickButton.Play();
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        //Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);
        hoverRawImage.gameObject.SetActive(false);
        image.color = new Color32(0, 0, 0, 199);
        audioClickButton.Play();
    }
}

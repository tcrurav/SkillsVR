using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System.IO;

public class PanelController : MonoBehaviour
{
    public GameObject panelRawImage;
    public TMP_Text panelTitleText;
    public TMP_Text panelDescriptionText;

    public GameObject backgroundVideoPlayer;

    public Canvas panelCanvas;
    public Canvas infoCanvas;

    public AudioSource audioClickPanel;
    public AudioSource audioClickButton;

    //public RawImage panelHoverRawImage;
    public XRRayInteractor rayInteractor;

    private readonly int NUMBER_OF_PANELS = 8;
    private int currentPanelNumber = 1;
    private int currentVideoNumber = 0;
    private Panels panels;

    //public Camera m_MainCamera;

    //InputDevice leftHand;
    //InputDevice rightHand;

    private void Start()
    {
        InitializePanels();
        FillCurrentPanel();
        UpdateCurrentVideo();

        //m_MainCamera = Camera.main;
    }

    //private void Update()
    //{

    //    if (Physics.Raycast(m_MainCamera.transform.position, m_MainCamera.transform.forward, out RaycastHit hit, Mathf.Infinity))
    //    {
    //        Debug.Log(hit.ToString());
    //        if (hit.transform.CompareTag("MyPanel"))
    //        {
    //            //Do something with the case
    //            Debug.Log("Tocado y hundido");
    //        }else
    //        {
    //            Debug.Log("algo");
    //        }
    //    }
    //    else
    //    {
    //        //Morido
    //        Debug.Log("sin éxito");
    //    }

    //}

    public void FillCurrentPanel()
    {
        panelRawImage.GetComponent<RawImage>().texture = 
            Resources.Load<Texture2D>("Videos360/" + panels.panels[currentPanelNumber].foto);
        panelTitleText.text = panels.panels[currentPanelNumber].title;
        panelDescriptionText.text = panels.panels[currentPanelNumber].description;
    }

    public void OnClickPanel()
    {
        audioClickPanel.Play();
        currentVideoNumber = currentPanelNumber;
        currentPanelNumber = (currentPanelNumber + 1) % NUMBER_OF_PANELS;

        FillCurrentPanel();
        UpdateCurrentVideo();
        HidePanelCanvas();
    }

    public void OnClickRight()
    {
        audioClickButton.Play();
        currentPanelNumber = (currentPanelNumber + 1) % NUMBER_OF_PANELS;

        FillCurrentPanel();
    }

    public void OnClickLeft()
    {
        audioClickButton.Play();
        if (currentPanelNumber == 0)
        {
            currentPanelNumber = NUMBER_OF_PANELS - 1;
        } else
        {
            currentPanelNumber--;
        }
        
        FillCurrentPanel();
    }

    public void OnClickClosePanel()
    {
        HidePanelCanvas();
    }

    public void UpdateCurrentVideo()
    {
        //backgroundVideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().clip =
        //    Resources.Load<UnityEngine.Video.VideoClip>("Videos360/" + panels.panels[currentVideoNumber].video);

        string fileName = panels.panels[currentVideoNumber].video + ".mp4";
        Debug.Log(fileName);
        string persistentDataPath = Application.persistentDataPath;
        Debug.Log(persistentDataPath);
        string path = Path.Combine(Path.Combine(persistentDataPath, "Videos360"), fileName);
        Debug.Log(path);
        backgroundVideoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().url = path;
    }

    public void HidePanelCanvas()
    {
        audioClickButton.Play();
        panelCanvas.gameObject.SetActive(false);
        infoCanvas.gameObject.SetActive(true);
    }

    public void ShowPanelCanvas()
    {
        audioClickButton.Play();
        panelCanvas.gameObject.SetActive(true);
        infoCanvas.gameObject.SetActive(false);
    }

    private void InitializePanels()
    {
        panels = new Panels
        {
            panels = new Panel[NUMBER_OF_PANELS]
        };

        panels.panels[0] = new Panel
        {
            video = "Video-1",
            foto = "Thumbnail-1",
            title = "Ciclo de Cocina",
            description = "El ciclo de Cocina del IES San Cristóbal se imparte en turno de tarde, y permite acceder al Ciclo de Grado Superior."
        };

        panels.panels[1] = new Panel
        {
            video = "Video-2",
            foto = "Thumbnail-2",
            title = "La jornada",
            description = "Hay que darse prisa para terminar la jornada. Es mucho el trabajo pero al final se consigue sin problemas."
        };

        panels.panels[2] = new Panel
        {
            video = "Video-3",
            foto = "Thumbnail-3",
            title = "La masa",
            description = "Se prepara la masa. Este texto es realmente una prueba que no tiene nada que ver creo yo con lo que está sucediendo."
        };

        panels.panels[3] = new Panel
        {
            video = "Video-4",
            foto = "Thumbnail-4",
            title = "El profesorado",
            description = "Mientras el alumnado realiza la tarea, el profesorado sigue atentamente la evolución de su alumnado sin perder detalle."
        };

        panels.panels[4] = new Panel
        {
            video = "Video-5",
            foto = "Thumbnail-5",
            title = "Más masa",
            description = "Sin prisa pero sin pausa, el alumnado va realizando sus tareas. No hay que olvidar que el trabajo bien hecho lleva su tiempo."
        };

        panels.panels[5] = new Panel
        {
            video = "Video-6",
            foto = "Thumbnail-6",
            title = "Ya queda menos",
            description = "Sin duda no es momento de relajarse. El progreso del trabajo se realiza con esmero y dedicación, y ya queda menos."
        };

        panels.panels[6] = new Panel
        {
            video = "Video-7",
            foto = "Thumbnail-7",
            title = "Un descanso",
            description = "Hasta en la pausa del desayuno se sigue buscando soluciones a los retos de cada día. Ya estamos acabando."
        };

        panels.panels[7] = new Panel
        {
            video = "Video-8",
            foto = "Thumbnail-8",
            title = "Los retoques",
            description = "Solo quedan los últimos retoques. No por ello hay que relajarse. El triunfo está en los detalles."
        };

    }

    //public void OnPanelEnterHover(HoverEnterEventArgs)
    //{
    //    Debug.Log("algo alguito para probar entró");
    //    //panelHoverRawImage.gameObject.SetActive(true);
    //    ShowHoverState();
    //    audioClickButton.Play();
    //}

    //public void OnPanelExitHover(HoverExitEventArgs)
    //{
    //    Debug.Log("algo alguito para probar salió");
    //    //panelHoverRawImage.gameObject.SetActive(false);
    //    ShowHoverState();
    //    audioClickButton.Play();
    //}

    //public void OnPanelFirstEnterHover(HoverEnterEventArgs)
    //{
    //    Debug.Log("algo alguito para probar first entró");
    //    //panelHoverRawImage.gameObject.SetActive(true);
    //    ShowHoverState();
    //}

    //public void OnPanelFirstExitHover(HoverExitEventArgs)
    //{
    //    Debug.Log("algo alguito para probar first salió");
    //    //panelHoverRawImage.gameObject.SetActive(false);
    //    ShowHoverState();
    //}

    //private void ShowHoverState()
    //{
    //    //var rayInteractor = GetComponent<UnityEngine.XR.Interaction.Toolkit.XRRayInteractor>();

    //    Debug.Log(rayInteractor.hasHover);
    //}


}

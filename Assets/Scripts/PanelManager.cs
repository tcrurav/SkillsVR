using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public GameObject rawImage;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public GameObject videoPlayer;
    public Canvas canvas;
    public Button buttonShow;
    public AudioSource audio1;
    public AudioSource audio2;

    private readonly int NUMBER_OF_PANELS = 8;
    private int currentPanelNumber = 1;
    private int currentVideoNumber = 0;
    private Panels panels;

    public Camera m_MainCamera;

    private void Start()
    {
        panels = new Panels
        {
            panels = new Panel[NUMBER_OF_PANELS]
        };
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
        rawImage.GetComponent<RawImage>().texture = 
            Resources.Load<Texture2D>("Videos360/" + panels.panels[currentPanelNumber].foto);
        titleText.text = panels.panels[currentPanelNumber].title;
        descriptionText.text = panels.panels[currentPanelNumber].description;
    }

    public void OnClickPanel()
    {
        audio1.Play();
        currentVideoNumber = currentPanelNumber;
        currentPanelNumber = (currentPanelNumber + 1) % NUMBER_OF_PANELS;

        FillCurrentPanel();
        UpdateCurrentVideo();
    }

    public void OnClickRight()
    {
        audio2.Play();
        currentPanelNumber = (currentPanelNumber + 1) % NUMBER_OF_PANELS;

        FillCurrentPanel();
    }

    public void OnClickLeft()
    {
        audio2.Play();
        if (currentPanelNumber == 0)
        {
            currentPanelNumber = NUMBER_OF_PANELS - 1;
        } else
        {
            currentPanelNumber--;
        }
        
        FillCurrentPanel();
    }

    public void UpdateCurrentVideo()
    {
        videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().clip =
            Resources.Load<UnityEngine.Video.VideoClip>("Videos360/" + panels.panels[currentVideoNumber].video);
    }

    public void HideCanvas()
    {
        audio2.Play();
        canvas.gameObject.SetActive(false);
        buttonShow.gameObject.SetActive(true);
    }

    public void ShowCanvas()
    {
        audio2.Play();
        canvas.gameObject.SetActive(true);
        buttonShow.gameObject.SetActive(false);
    }

    private void InitializePanels()
    {
        
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

        //panels.panels[8] = new Panel
        //{
        //    video = "Video-9",
        //    foto = "Thumbnail-9",
        //    title = "Hermigua",
        //    description = "Hermigua es un municipio de la Gomera que se encuentra en el norte de la isla. Sus costas son escarpadas y salvajes."
        //};

        //panels.panels[9] = new Panel
        //{
        //    video = "Video-10",
        //    foto = "Thumbnail-10",
        //    title = "Garajonay",
        //    description = "Se trata de un parque nacional que se encuentra en la isla de la Gomera. Una reserva de la Biosfera para la Laurisilva."
        //};

        

    }

    public void DoSomething()
    {
        Debug.Log("caracolónnnnnnnnnnnnnnnnnnnnnnnnnnnn,.,");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameObject DialogBoxJorge;
    private GameObject DialogBoxEdite;
    private GameObject DialogBoxFatima;
    private GameObject DialogBoxNelson;
    private GameObject DialogBoxClaudia;
    private GameObject DialogBoxRosa;
    private GameObject DialogBoxAlberto;
    private GameObject DialogBoxCarlos;

    // Use this for initialization
    void Start()
    {
        DialogBoxJorge = GameObject.Find("JorgeDialog");
        DialogBoxJorge.SetActive(false);

        DialogBoxEdite = GameObject.Find("EditeDialog");
        DialogBoxEdite.SetActive(false);

        DialogBoxFatima = GameObject.Find("FatimaDialog");
        DialogBoxFatima.SetActive(false);

        DialogBoxNelson = GameObject.Find("NelsonDialog");
        DialogBoxNelson.SetActive(false);

        DialogBoxClaudia = GameObject.Find("ClaudiaDialog");
        DialogBoxClaudia.SetActive(false);

        DialogBoxRosa = GameObject.Find("RosaDialog");
        DialogBoxRosa.SetActive(false);

        DialogBoxAlberto = GameObject.Find("AlbertoDialog");
        DialogBoxAlberto.SetActive(false);

        DialogBoxCarlos = GameObject.Find("CarlosDialog");
        DialogBoxCarlos.SetActive(false);
    }

    public void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "NPCquest1" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxJorge.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest2" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxEdite.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest3" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxFatima.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest4" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxNelson.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest5" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxClaudia.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest6" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxRosa.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest7" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxAlberto.SetActive(true);
        }
        if (hit.gameObject.tag == "NPCquest8" && Input.GetKeyDown(KeyCode.E))
        {
            DialogBoxCarlos.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "NPCquest1")
        {
            DialogBoxJorge.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest2")
        {
            DialogBoxEdite.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest3")
        {
            DialogBoxFatima.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest4")
        {
            DialogBoxNelson.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest5")
        {
            DialogBoxClaudia.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest6")
        {
            DialogBoxRosa.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest7")
        {
            DialogBoxAlberto.SetActive(false);
        }
        if (hit.gameObject.tag == "NPCquest8")
        {
            DialogBoxCarlos.SetActive(false);
        }
    }
}

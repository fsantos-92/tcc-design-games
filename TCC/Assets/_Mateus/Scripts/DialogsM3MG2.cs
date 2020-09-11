using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogsM3MG2 : MonoBehaviour {

    private int dialog1;
    private int dialog2;
    private int dialog3;
    private int dialog4;
    private int dialog5;
    private int dialog6;
    private int dialog7;
    private int dialog8;
    private int dialog9;
    private int dialog10;

    public GameObject RafaelaDialog;
    public GameObject MiguelDialog;
    public GameObject EdgarDialog;
    public GameObject MonicaDialog;
    public GameObject RicardoDialog;
    public GameObject VeraDialog;
    public GameObject JefersonDialog;
    public GameObject CelinaDialog;
    public GameObject ElisaDialog;
    public GameObject LeandroDialog;

    public GameObject[] dialogRafaela;
    public GameObject[] dialogMiguel;
    public GameObject[] dialogEdgar;
    public GameObject[] dialogMonica;
    public GameObject[] dialogRicardo;
    public GameObject[] dialogVera;
    public GameObject[] dialogJeferson;
    public GameObject[] dialogCelina;
    public GameObject[] dialogElisa;
    public GameObject[] dialogLeandro;

    // Use this for initialization
    void Start()
    {
        dialog1 = 0;
        dialog2 = 0;
        dialog3 = 0;
        dialog4 = 0;
        dialog5 = 0;
        dialog6 = 0;
        dialog7 = 0;
        dialog8 = 0;
        dialog9 = 0;
        dialog10 = 0;
    }

    #region Update
    void Update()
    {
        if (RafaelaDialog.activeInHierarchy == true && dialog1 == 0)
        {
            dialogRafaela[0].SetActive(true);
            dialogRafaela[4].SetActive(true); //button
        }
        if (MiguelDialog.activeInHierarchy == true && dialog2 == 0)
        {
            dialogMiguel[0].SetActive(true);
            dialogMiguel[4].SetActive(true); //button
        }
        if (EdgarDialog.activeInHierarchy == true && dialog3 == 0)
        {
            dialogEdgar[0].SetActive(true);
            dialogEdgar[4].SetActive(true); //button
        }
        if (MonicaDialog.activeInHierarchy == true && dialog4 == 0)
        {
            dialogMonica[0].SetActive(true);
            dialogMonica[4].SetActive(true); //button
        }
        if (RicardoDialog.activeInHierarchy == true && dialog5 == 0)
        {
            dialogRicardo[0].SetActive(true);
            dialogRicardo[4].SetActive(true); //button
        }
        if (VeraDialog.activeInHierarchy == true && dialog6 == 0)
        {
            dialogVera[0].SetActive(true);
            dialogVera[4].SetActive(true); //button
        }
        if (JefersonDialog.activeInHierarchy == true && dialog7 == 0)
        {
            dialogJeferson[0].SetActive(true);
            dialogJeferson[4].SetActive(true); //button
        }
        if (CelinaDialog.activeInHierarchy == true && dialog8 == 0)
        {
            dialogCelina[0].SetActive(true);
            dialogCelina[4].SetActive(true); //button
        }
        if (ElisaDialog.activeInHierarchy == true && dialog9 == 0)
        {
            dialogElisa[0].SetActive(true);
            dialogElisa[4].SetActive(true); //button
        }
        if (LeandroDialog.activeInHierarchy == true && dialog10 == 0)
        {
            dialogLeandro[0].SetActive(true);
            dialogLeandro[4].SetActive(true); //button
        }
    }
    #endregion

    #region Buttons
    public void RafaelaDButton()
    {
        dialog1++;
        RafaelaDialogBoxes();
    }
    public void MiguelDButton()
    {
        dialog2++;
        MiguelDialogBoxes();
    }
    public void EdgarDButton()
    {
        dialog3++;
        EdgarDialogBoxes();
    }
    public void MonicaDButton()
    {
        dialog4++;
        MonicaDialogBoxes();
    }
    public void RicardoDButton()
    {
        dialog5++;
        RicardoDialogBoxes();
    }
    public void VeraDButton()
    {
        dialog6++;
        VeraDialogBoxes();
    }
    public void JefersonDButton()
    {
        dialog7++;
        JefersonDialogBoxes();
    }
    public void CelinaDButton()
    {
        dialog8++;
        CelinaDialogBoxes();
    }
    public void ElisaDButton()
    {
        dialog9++;
        ElisaDialogBoxes();
    }
    public void LeandroDButton()
    {
        dialog10++;
        LeandroDialogBoxes();
    }
    #endregion

    #region Dialogs
    public void RafaelaDialogBoxes()
    {
        if (dialog1 == 0)
        {
            dialogRafaela[0].SetActive(true);
        }
        if (dialog1 == 1)
        {
            dialogRafaela[0].SetActive(false);
            dialogRafaela[1].SetActive(true);
        }
        if (dialog1 == 2)
        {
            dialogRafaela[1].SetActive(false);
            dialogRafaela[2].SetActive(true);
        }
        if (dialog1 == 3)
        {
            dialogRafaela[2].SetActive(false);
            dialogRafaela[3].SetActive(true);
        }
        if (dialog1 > 3)
        {
            dialogRafaela[3].SetActive(false);
            dialogRafaela[4].SetActive(false);
        }
    }

    public void MiguelDialogBoxes()
    {
        if (dialog2 == 0)
        {
            dialogMiguel[0].SetActive(true);
        }
        if (dialog2 == 1)
        {
            dialogMiguel[0].SetActive(false);
            dialogMiguel[1].SetActive(true);
        }
        if (dialog2 == 2)
        {
            dialogMiguel[1].SetActive(false);
            dialogMiguel[2].SetActive(true);
        }
        if (dialog2 == 3)
        {
            dialogMiguel[2].SetActive(false);
            dialogMiguel[3].SetActive(true);
        }
        if (dialog2 > 3)
        {
            dialogMiguel[3].SetActive(false);
            dialogMiguel[4].SetActive(false);
        }     
    }

    public void EdgarDialogBoxes()
    {
        if (dialog3 == 0)
        {
            dialogEdgar[0].SetActive(true);
        }
        if (dialog3 == 1)
        {
            dialogEdgar[0].SetActive(false);
            dialogEdgar[1].SetActive(true);
        }
        if (dialog3 == 2)
        {
            dialogEdgar[1].SetActive(false);
            dialogEdgar[2].SetActive(true);
        }
        if (dialog3 == 3)
        {
            dialogEdgar[2].SetActive(false);
            dialogEdgar[3].SetActive(true);
        }
        if (dialog3 > 3)
        {
            dialogEdgar[3].SetActive(false);
            dialogEdgar[4].SetActive(false);
        }
    }

    public void MonicaDialogBoxes()
    {
        if (dialog4 == 0)
        {
            dialogMonica[0].SetActive(true);
        }
        if (dialog4 == 1)
        {
            dialogMonica[0].SetActive(false);
            dialogMonica[1].SetActive(true);
        }
        if (dialog4 == 2)
        {
            dialogMonica[1].SetActive(false);
            dialogMonica[2].SetActive(true);
        }
        if (dialog4 == 3)
        {
            dialogMonica[2].SetActive(false);
            dialogMonica[3].SetActive(true);
        }
        if (dialog4 > 3)
        {
            dialogMonica[3].SetActive(false);
            dialogMonica[4].SetActive(false);
        }
    }

    public void RicardoDialogBoxes()
    {
        if (dialog5 == 0)
        {
            dialogRicardo[0].SetActive(true);
        }
        if (dialog5 == 1)
        {
            dialogRicardo[0].SetActive(false);
            dialogRicardo[1].SetActive(true);
        }
        if (dialog5 == 2)
        {
            dialogRicardo[1].SetActive(false);
            dialogRicardo[2].SetActive(true);
        }
        if (dialog5 == 3)
        {
            dialogRicardo[2].SetActive(false);
            dialogRicardo[3].SetActive(true);
        }
        if (dialog5 > 3)
        {
            dialogRicardo[3].SetActive(false);
            dialogRicardo[4].SetActive(false); //Button
        }
    }

    public void VeraDialogBoxes()
    {
        if (dialog6 == 0)
        {
            dialogVera[0].SetActive(true);
        }
        if (dialog6 == 1)
        {
            dialogVera[0].SetActive(false);
            dialogVera[1].SetActive(true);
        }
        if (dialog6 == 2)
        {
            dialogVera[1].SetActive(false);
            dialogVera[2].SetActive(true);
        }
        if (dialog6 == 3)
        {
            dialogVera[2].SetActive(false);
            dialogVera[3].SetActive(true);
        }
        if (dialog6 > 3)
        {
            dialogVera[3].SetActive(false);
            dialogVera[4].SetActive(false); //Button
        }
    }

    public void JefersonDialogBoxes()
    {
        if (dialog7 == 0)
        {
            dialogJeferson[0].SetActive(true);
        }
        if (dialog7 == 1)
        {
            dialogJeferson[0].SetActive(false);
            dialogJeferson[1].SetActive(true);
        }
        if (dialog7 == 2)
        {
            dialogJeferson[1].SetActive(false);
            dialogJeferson[2].SetActive(true);
        }
        if (dialog7 == 3)
        {
            dialogJeferson[2].SetActive(false);
            dialogJeferson[3].SetActive(true);
        }
        if (dialog7 > 3)
        {
            dialogJeferson[3].SetActive(false);
            dialogJeferson[4].SetActive(false); //button
        }
    }

    public void CelinaDialogBoxes()
    {
        if (dialog8 == 0)
        {
            dialogCelina[0].SetActive(true);
        }
        if (dialog8 == 1)
        {
            dialogCelina[0].SetActive(false);
            dialogCelina[1].SetActive(true);
        }
        if (dialog8 == 2)
        {
            dialogCelina[1].SetActive(false);
            dialogCelina[2].SetActive(true);
        }
        if (dialog8 == 3)
        {
            dialogCelina[2].SetActive(false);
            dialogCelina[3].SetActive(true);
        }
        if (dialog8 > 3)
        {
            dialogCelina[3].SetActive(false);
            dialogCelina[4].SetActive(false); //Button
        }
    }

    public void ElisaDialogBoxes()
    {
        if (dialog9 == 0)
        {
            dialogElisa[0].SetActive(true);
        }
        if (dialog9 == 1)
        {
            dialogElisa[0].SetActive(false);
            dialogElisa[1].SetActive(true);
        }
        if (dialog9 == 2)
        {
            dialogElisa[1].SetActive(false);
            dialogElisa[2].SetActive(true);
        }
        if (dialog9 == 3)
        {
            dialogElisa[2].SetActive(false);
            dialogElisa[3].SetActive(true);
        }
        if (dialog9 > 3)
        {
            dialogElisa[3].SetActive(false);
            dialogElisa[4].SetActive(false); //Button
        }
    }

    public void LeandroDialogBoxes()
    {
        if (dialog10 == 0)
        {
            dialogLeandro[0].SetActive(true);
        }
        if (dialog10 == 1)
        {
            dialogLeandro[0].SetActive(false);
            dialogLeandro[1].SetActive(true);
        }
        if (dialog10 == 2)
        {
            dialogLeandro[1].SetActive(false);
            dialogLeandro[2].SetActive(true);
        }
        if (dialog10 == 3)
        {
            dialogLeandro[2].SetActive(false);
            dialogLeandro[3].SetActive(true);
        }
        if (dialog10 > 3)
        {
            dialogLeandro[3].SetActive(false);
            dialogLeandro[4].SetActive(false); //Button
        }
    }
    #endregion
}

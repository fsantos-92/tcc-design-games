using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour {

    private int dialog1;
    private int dialog2;
    private int dialog3;
    private int dialog4;
    private int dialog5;
    private int dialog6;
    private int dialog7;
    private int dialog8;

    public GameObject JorgeDialog;
    public GameObject EditeDialog;
    public GameObject FatimaDialog;
    public GameObject NelsonDialog;
    public GameObject ClaudiaDialog;
    public GameObject RosaDialog;
    public GameObject AlbertoDialog;
    public GameObject CarlosDialog;
    public GameObject[] dialogJorge;
    public GameObject[] dialogEdite;
    public GameObject[] dialogFatima;
    public GameObject[] dialogNelson;
    public GameObject[] dialogClaudia;
    public GameObject[] dialogRosa;
    public GameObject[] dialogAlberto;
    public GameObject[] dialogCarlos;

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
    }

    #region Update
    void Update()
    {
        //Jorge
        if (JorgeDialog.activeInHierarchy == true && dialog1 == 0)
        {
            dialogJorge[0].SetActive(true);
            dialogJorge[6].SetActive(true); //button
        }
        //Edite
        if (EditeDialog.activeInHierarchy == true && dialog2 == 0)
        {
            dialogEdite[0].SetActive(true);
            dialogEdite[6].SetActive(true); //button
        }
        //Fatima
        if (FatimaDialog.activeInHierarchy == true && dialog3 == 0)
        {
            dialogFatima[0].SetActive(true);
            dialogFatima[6].SetActive(true); //button
        }
        //Nelson
        if (NelsonDialog.activeInHierarchy == true && dialog4 == 0)
        {
            dialogNelson[0].SetActive(true);
            dialogNelson[6].SetActive(true); //button
        }
        //Claudia
        if (ClaudiaDialog.activeInHierarchy == true && dialog5 == 0)
        {
            dialogClaudia[0].SetActive(true);
            dialogClaudia[4].SetActive(true); //button
        }
        //Rosa 
        if (RosaDialog.activeInHierarchy == true && dialog6 == 0)
        {
            dialogRosa[0].SetActive(true);
            dialogRosa[4].SetActive(true); //button
        }
        //Alberto
        if (AlbertoDialog.activeInHierarchy == true && dialog7 == 0)
        {
            dialogAlberto[0].SetActive(true);
            dialogAlberto[4].SetActive(true); //button
        }
        //Carlos
        if (CarlosDialog.activeInHierarchy == true && dialog8 == 0)
        {
            dialogCarlos[0].SetActive(true);
            dialogCarlos[4].SetActive(true); //button
        }
    }
    #endregion

    #region Buttons
    public void JorgeDButton()
    {
        dialog1++;
        JorgeDialogBoxes();
    }
    public void EditeDButton()
    {
        dialog2++;
        EditeDialogBoxes();
    }
    public void FatimaDButton()
    {
        dialog3++;
        FatimaDialogBoxes();
    }
    public void NelsonDButton()
    {
        dialog4++;
        NelsonDialogBoxes();
    }
    public void ClaudiaDButton()
    {
        dialog5++;
        ClaudiaDialogBoxes();
    }
    public void RosaDButton()
    {
        dialog6++;
        RosaDialogBoxes();
    }
    public void AlbertoDButton()
    {
        dialog7++;
        AlbertoDialogBoxes();
    }
    public void CarlosDButton()
    {
        dialog8++;
        CarlosDialogBoxes();
    }
    #endregion

    #region Dialogs
    public void JorgeDialogBoxes()
    {
        if (dialog1 == 0)
        {
            dialogJorge[0].SetActive(true);
        }
        if (dialog1 == 1)
        {
            dialogJorge[0].SetActive(false);
            dialogJorge[1].SetActive(true);
        }
        if (dialog1 == 2)
        {
            dialogJorge[1].SetActive(false);
            dialogJorge[2].SetActive(true);
        }
        if (dialog1 == 3)
        {
            dialogJorge[2].SetActive(false);
            dialogJorge[3].SetActive(true);
        }
        if (dialog1 == 4)
        {
            dialogJorge[3].SetActive(false);
            dialogJorge[4].SetActive(true);
        }
        if (dialog1 == 5)
        {
            dialogJorge[4].SetActive(false);
            dialogJorge[5].SetActive(true);
        }
        if (dialog1 > 5)
        {
            dialogJorge[5].SetActive(false);
            dialogJorge[6].SetActive(false); //button
        }
    }

    public void EditeDialogBoxes()
    {
        if (dialog2 == 0)
        {
            dialogEdite[0].SetActive(true);
        }
        if (dialog2 == 1)
        {
            dialogEdite[0].SetActive(false);
            dialogEdite[1].SetActive(true);
        }
        if (dialog2 == 2)
        {
            dialogEdite[1].SetActive(false);
            dialogEdite[2].SetActive(true);
        }
        if (dialog2 == 3)
        {
            dialogEdite[2].SetActive(false);
            dialogEdite[3].SetActive(true);
        }
        if (dialog2 == 4)
        {
            dialogEdite[3].SetActive(false);
            dialogEdite[4].SetActive(true);
        }
        if (dialog2 == 5)
        {
            dialogEdite[4].SetActive(false);
            dialogEdite[5].SetActive(true);
        }
        if (dialog2 > 5)
        {
            dialogEdite[5].SetActive(false);
            dialogEdite[6].SetActive(false); //button
        }
    }

    public void FatimaDialogBoxes()
    {
        if (dialog3 == 0)
        {
            dialogFatima[0].SetActive(true);
        }
        if (dialog3 == 1)
        {
            dialogFatima[0].SetActive(false);
            dialogFatima[1].SetActive(true);
        }
        if (dialog3 == 2)
        {
            dialogFatima[1].SetActive(false);
            dialogFatima[2].SetActive(true);
        }
        if (dialog3 == 3)
        {
            dialogFatima[2].SetActive(false);
            dialogFatima[3].SetActive(true);
        }
        if (dialog3 == 4)
        {
            dialogFatima[3].SetActive(false);
            dialogFatima[4].SetActive(true);
        }
        if (dialog3 == 5)
        {
            dialogFatima[4].SetActive(false);
            dialogFatima[5].SetActive(true);
        }
        if (dialog3 > 5)
        {
            dialogFatima[5].SetActive(false);
            dialogFatima[6].SetActive(false); //button
        }
    }

    public void NelsonDialogBoxes()
    {
        if (dialog4 == 0)
        {
            dialogNelson[0].SetActive(true);
        }
        if (dialog4 == 1)
        {
            dialogNelson[0].SetActive(false);
            dialogNelson[1].SetActive(true);
        }
        if (dialog4 == 2)
        {
            dialogNelson[1].SetActive(false);
            dialogNelson[2].SetActive(true);
        }
        if (dialog4 == 3)
        {
            dialogNelson[2].SetActive(false);
            dialogNelson[3].SetActive(true);
        }
        if (dialog4 == 4)
        {
            dialogNelson[3].SetActive(false);
            dialogNelson[4].SetActive(true);
        }
        if (dialog4 == 5)
        {
            dialogNelson[4].SetActive(false);
            dialogNelson[5].SetActive(true);
        }
        if (dialog4 > 5)
        {
            dialogNelson[5].SetActive(false);
            dialogNelson[6].SetActive(false); //button
        }
    }

    public void ClaudiaDialogBoxes()
    {
        if (dialog5 == 0)
        {
            dialogClaudia[0].SetActive(true);
        }
        if (dialog5 == 1)
        {
            dialogClaudia[0].SetActive(false);
            dialogClaudia[1].SetActive(true);
        }
        if (dialog5 == 2)
        {
            dialogClaudia[1].SetActive(false);
            dialogClaudia[2].SetActive(true);
        }
        if (dialog5 == 3)
        {
            dialogClaudia[2].SetActive(false);
            dialogClaudia[3].SetActive(true);
        }
        if (dialog5 > 3)
        {
            dialogClaudia[3].SetActive(false);
            dialogClaudia[4].SetActive(false); //Button
        }
    }

    public void RosaDialogBoxes()
    {
        if (dialog6 == 0)
        {
            dialogRosa[0].SetActive(true);
        }
        if (dialog6 == 1)
        {
            dialogRosa[0].SetActive(false);
            dialogRosa[1].SetActive(true);
        }
        if (dialog6 == 2)
        {
            dialogRosa[1].SetActive(false);
            dialogRosa[2].SetActive(true);
        }
        if (dialog6 == 3)
        {
            dialogRosa[2].SetActive(false);
            dialogRosa[3].SetActive(true);
        }
        if (dialog6 > 3)
        {
            dialogRosa[3].SetActive(false);
            dialogRosa[4].SetActive(false); //Button
        }
    }

    public void AlbertoDialogBoxes()
    {
        if (dialog7 == 0)
        {
            dialogAlberto[0].SetActive(true);
        }
        if (dialog7 == 1)
        {
            dialogAlberto[0].SetActive(false);
            dialogAlberto[1].SetActive(true);
        }
        if (dialog7 == 2)
        {
            dialogAlberto[1].SetActive(false);
            dialogAlberto[2].SetActive(true);
        }
        if (dialog7 == 3)
        {
            dialogAlberto[2].SetActive(false);
            dialogAlberto[3].SetActive(true);
        }
        if (dialog7 > 3)
        {
            dialogAlberto[3].SetActive(false);
            dialogAlberto[4].SetActive(false); //button
        }
    }

    public void CarlosDialogBoxes()
    {
        if (dialog8 == 0)
        {
            dialogCarlos[0].SetActive(true);
        }
        if (dialog8 == 1)
        {
            dialogCarlos[0].SetActive(false);
            dialogCarlos[1].SetActive(true);
        }
        if (dialog8 == 2)
        {
            dialogCarlos[1].SetActive(false);
            dialogCarlos[2].SetActive(true);
        }
        if (dialog8 == 3)
        {
            dialogCarlos[2].SetActive(false);
            dialogCarlos[3].SetActive(true);
        }
        if (dialog8 > 3)
        {
            dialogCarlos[3].SetActive(false);
            dialogCarlos[4].SetActive(false); //Button
        }
    }
    #endregion
}

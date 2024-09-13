using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Dropdown sceneDropdown; // El Dropdown con las opciones de escenas
    public Button confirmButton;   // El bot�n de confirmaci�n

    private int selectedSceneIndex = 0; // Para almacenar la opci�n seleccionada

    // Start is called before the first frame update
    void Start()
    {
        // A�adir un listener para cuando se cambie la selecci�n del Dropdown
        sceneDropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(sceneDropdown); });

        // A�adir un listener al bot�n para que llame al m�todo cuando se presione
        confirmButton.onClick.AddListener(OnConfirmButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDropdownValueChanged(Dropdown dropdown)
    {
        selectedSceneIndex = dropdown.value; // Guardar la opci�n seleccionada
    }
    void OnConfirmButtonClicked()
    {
        switch (selectedSceneIndex)
        {
            case 0:
                SceneManager.LoadScene("BarChartScene");
                break;
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}

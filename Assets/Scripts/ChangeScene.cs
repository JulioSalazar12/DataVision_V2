using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Dropdown sceneDropdown; // El Dropdown con las opciones de escenas
    public Button confirmButton;   // El botón de confirmación

    private int selectedSceneIndex = 0; // Para almacenar la opción seleccionada

    // Start is called before the first frame update
    void Start()
    {
        // Añadir un listener para cuando se cambie la selección del Dropdown
        sceneDropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(sceneDropdown); });

        // Añadir un listener al botón para que llame al método cuando se presione
        confirmButton.onClick.AddListener(OnConfirmButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDropdownValueChanged(Dropdown dropdown)
    {
        selectedSceneIndex = dropdown.value; // Guardar la opción seleccionada
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

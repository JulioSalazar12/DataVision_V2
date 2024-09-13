using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    public string filePath = "BarChart/data";  // Nombre del archivo CSV en la carpeta Resources

    // Lista para almacenar los puntos de datos
    public List<DataPoint> dataPoints = new List<DataPoint>();

    [System.Serializable]
    public class DataPoint
    {
        public string category;
        public float value;

        public DataPoint(string category, float value)
        {
            this.category = category;
            this.value = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        // Carga el archivo CSV desde la carpeta Resources
        TextAsset csvFile = Resources.Load<TextAsset>(filePath);
        if (csvFile != null)
        {
            string[] csvData = csvFile.text.Split('\n');
            for (int i = 1; i < csvData.Length; i++)  // Comienza desde 1 para saltar la cabecera
            {
                string[] row = csvData[i].Split(',');
                if (row.Length >= 2)
                {
                    string category = row[0];
                    float value;
                    if (float.TryParse(row[1], out value))
                    {
                        Debug.Log("Categoría: " + category + ", Valor: " + value);
                        dataPoints.Add(new DataPoint(category, value));
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No se encontró el archivo CSV en la ruta: " + filePath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using BarGraph.VittorCloud;

public class BarGraphExample : MonoBehaviour
{
    public List<BarGraphDataSet> exampleDataSet; // public data set for inserting data into the bar graph
    BarGraphGenerator barGraphGenerator; 

    void Start()
    {
        SetDataRandom();
        barGraphGenerator = GetComponent<BarGraphGenerator>();
        SetConfigurationDefaultBarGraph();

        //if the exampleDataSet list is empty then return.
        if (exampleDataSet.Count == 0)
        {

            Debug.LogError("ExampleDataSet is Empty!");
            return;
        }
        barGraphGenerator.GeneratBarGraph(exampleDataSet);

    }


    //call when the graph starting animation completed,  for updating the data on run time
    public void StartUpdatingGraph()
    {

       
        StartCoroutine(CreateDataSet());
    }



    IEnumerator CreateDataSet()
    {
        //  yield return new WaitForSeconds(3.0f);
        while (true)
        {

            GenerateRandomData();

            yield return new WaitForSeconds(2.0f);

        }

    }



    //Generates the random data for the created bars
    void GenerateRandomData()
    {
        
        int dataSetIndex = UnityEngine.Random.Range(0, exampleDataSet.Count);
        int xyValueIndex = UnityEngine.Random.Range(0, exampleDataSet[dataSetIndex].ListOfBars.Count);
        exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue = UnityEngine.Random.Range(barGraphGenerator.yMinValue, barGraphGenerator.yMaxValue);
        barGraphGenerator.AddNewDataSet(dataSetIndex, xyValueIndex, exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue);
    }

    private void SetDataRandom()
    {
        BarGraphDataSet dataSet1 = new BarGraphDataSet
        {
            GroupName = "Group A",
            barColor = Color.red,
            barMaterial = new Material(Shader.Find("Standard")),
            ListOfBars = new List<XYBarValues>
            {
                new XYBarValues { XValue = "Jan", YValue = 10f },
                new XYBarValues { XValue = "Feb", YValue = 20f },
                new XYBarValues { XValue = "Mar", YValue = 15f }
            }
        };

        // Crear otro objeto BarGraphDataSet
        BarGraphDataSet dataSet2 = new BarGraphDataSet
        {
            GroupName = "Group B",
            barColor = Color.blue,
            barMaterial = new Material(Shader.Find("Standard")),
            ListOfBars = new List<XYBarValues>
            {
                new XYBarValues { XValue = "Jan", YValue = 5f },
                new XYBarValues { XValue = "Feb", YValue = 25f },
                new XYBarValues { XValue = "Mar", YValue = 30f }
            }
        };

        BarGraphDataSet dataSet3 = new BarGraphDataSet
        {
            GroupName = "Group C",
            barColor = Color.green,
            barMaterial = new Material(Shader.Find("Standard")),
            ListOfBars = new List<XYBarValues>
            {
                new XYBarValues { XValue = "Jan", YValue = 15f },
                new XYBarValues { XValue = "Feb", YValue = 20f },
                new XYBarValues { XValue = "Mar", YValue = 35f }
            }
        };

        // Agregar los conjuntos de datos a la lista
        exampleDataSet.Add(dataSet1);
        exampleDataSet.Add(dataSet2);
        exampleDataSet.Add(dataSet3);
    }
    private void SetConfigurationDefaultBarGraph()
    {
        barGraphGenerator.MaxHeight = 5;
    }
}




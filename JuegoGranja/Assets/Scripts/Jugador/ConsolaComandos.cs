using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ConsolaComandos : MonoBehaviour
{
    private bool abierto;
    public TMP_InputField inputField;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !abierto)
        {
            inputField.gameObject.SetActive(true);
            abierto = true;
            inputField.ActivateInputField();
            inputField.Select();
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.T) && abierto)
        {
           closeInputField();
        }
    }

    public void RegistrarInput(string input)
    {
        string[] commands = input.Split(" ");
        switch (commands[0])
        {
            case "give":
                GiveFunction(commands);
                break;

            default:
                closeInputField();
                break;
        }
    }

    private void GiveFunction(string[] commands)
    {
        try{
            if (commands[1].Equals("gold"))
            {
                int result;
                int.TryParse(commands[2], out result);
                if(result != 0)
                    StatsGenerales.Instance.SumarOro(result);
                else
                    throw new ArgumentException();
                
            }
            else
            {
                UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ObjetoDrop.prefab", typeof(ObjetoDrop));
                ObjetoDrop drop = Instantiate(prefab,GameObject.FindGameObjectWithTag("ObjetosMapa").transform, true) as ObjetoDrop;

                int result;
                int result2;
                int.TryParse(commands[1], out result);
                int.TryParse(commands[2], out result2);

                if(result != 0 && result2 != 0)
                {
                drop.transform.position = Jugador.Instance.transform.position;
                drop.SetCantidad(int.Parse(commands[2]));
                drop.SetId(int.Parse(commands[1]));
                drop.GetComponent<ObjetoDrop>().enabled = true;
                }
                else
                    throw new ArgumentException();
                
            }
        }
        catch
        {
            //TODO
        }

       closeInputField();
    }

    private void closeInputField()
    {
        inputField.text = "";
        inputField.gameObject.SetActive(false);
        abierto = false;
        Time.timeScale = 1;
    }
}

using UnityEngine;

public class DarRegalo : MonoBehaviour
{
   public static DarRegalo Instance;

   void Awake()
    {
         if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private  int id;
    private ActorSO recipiente;


    private void MostrarMenu()
    {
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
    public void OcultarMenu()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void EmpezarProceso(ActorSO actorSO, int id)
    {
        this.recipiente = actorSO;
        this.id = id;
        MostrarMenu();
    }

    public void ClickDar()
    {
        if (recipiente.aplicable)
        {
            bool encontrado = false;
            GestorInventario.Instance.DesactivarHotbar();

            //0 neutro, 1 favorable, -1 negativo
            int neutralidad = 0;
            GestorInventario.Instance.RestarCantidad(id, 1);
            foreach (var idFav in recipiente.regalosFavoritos)
            {
                if(idFav == id)
                {
                    recipiente.nivelRelacion += 3;
                    encontrado = true;
                    neutralidad = 1;
                    break;
                }
            }

             foreach (var idNoFav in recipiente.regalosDesagradables)
            {
                if(idNoFav == id)
                {
                    recipiente.nivelRelacion -= 1;
                    encontrado = true;
                    neutralidad = -1;
                    break;
                }
            }

            if (!encontrado)
            {
                recipiente.nivelRelacion += 1;
            }

            if(recipiente.nivelRelacion > 10 && recipiente.nivelRelacion < 20)
                recipiente.nivelRelacion = 10;

            if(recipiente.nivelRelacion > 30 && recipiente.nivelRelacion < 40)
                recipiente.nivelRelacion = 30;

            if(recipiente.nivelRelacion > 50 && recipiente.nivelRelacion < 60)
                recipiente.nivelRelacion = 50;

                OcultarMenu();

            switch (neutralidad)
            {
                case 0:
                    GestorDIalogos.Instance.EmpezarDialogo(recipiente.dialogoNeutro);
                    break;
                case 1:
                    GestorDIalogos.Instance.EmpezarDialogo(recipiente.dialogoAgrado);
                    break;
                case -1:
                    GestorDIalogos.Instance.EmpezarDialogo(recipiente.dialogoDesagrado);
                    break;
            }


        }
    }
    

}
 
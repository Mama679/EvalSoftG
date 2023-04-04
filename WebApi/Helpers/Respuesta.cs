namespace WebApi.Helpers
{
    public class Respuesta
    {       
         public int Exito { get; set; }
         public int StateCode { get; set; }
         public string Mensaje { get; set; }
         public object Data { get; set; }
          
           public Respuesta()
            {
                this.Exito = 0;
            }
        
    }
}

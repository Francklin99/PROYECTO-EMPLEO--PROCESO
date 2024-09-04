namespace ProyectoEmpleo.API.Utilidad
{
    public class ResponseApi<T>
    {
        public bool status { get; set; }

        public T Value { get; set; }
        public string message { get; set; }
    }
}

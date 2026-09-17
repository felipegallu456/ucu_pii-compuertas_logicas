namespace Ucu.Poo.Exercise
{
    public class Valor
    {
        public bool estado { get; set; }

        // Constructor del diagrama
        public Valor(bool estado)
        {
            this.estado = estado;
        }

        public virtual bool evaluar()
        {
            return this.estado;
        }
    }
}
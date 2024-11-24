namespace Polinomios
{
    public class Monomio
    {
        public double Coeficiente;
        public int Exponente;
        public Monomio Siguiente;


        public Monomio(double Coeficiente, int Exponente)
        {
            this.Exponente = Exponente;
            this.Coeficiente= Coeficiente;
        }

        // Constructor de copia
        public Monomio(Monomio otro)
        {
            this.Coeficiente = otro.Coeficiente;
            this.Exponente = otro.Exponente;

            this.Siguiente = otro.Siguiente != null ? new Monomio(otro.Siguiente) : null;
        }
    }
}

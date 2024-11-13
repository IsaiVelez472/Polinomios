namespace Polinomios
{
    public class Polinomio
    {
        private Monomio Cabeza;


        public Polinomio()
        {
            Cabeza = null;
        }

        public Monomio GetCabeza()
        {
            return Cabeza;
        }

        public void Agregar(Monomio monomio)
        {
            if (monomio != null)
            {
                if (Cabeza == null)
                {
                    Cabeza = monomio;
                }
                else
                {
                    Monomio apuntador = Cabeza;
                    Monomio predecesor = null;
                    int encontrado = 0;
                    while (apuntador != null && encontrado == 0)
                    {
                        if (monomio.Exponente == apuntador.Exponente)
                        {
                            encontrado = 1;
                        }
                        else if (monomio.Exponente < apuntador.Exponente)
                        {
                            encontrado = 2;
                        }
                        else
                        {
                            predecesor = apuntador;
                            apuntador = apuntador.Siguiente;
                        }
                    }
                    if (encontrado == 1)
                    {
                        double coeficiente = monomio.Coeficiente + apuntador.Coeficiente;
                        if (coeficiente == 0)
                        {
                            if (predecesor == null)
                            {
                                Cabeza = apuntador.Siguiente;
                            }
                            else
                            {
                                predecesor.Siguiente = apuntador.Siguiente;
                            }
                        }
                        else
                        {
                            apuntador.Coeficiente = coeficiente;
                        }
                    }
                    else
                    {
                        Insertar(monomio, predecesor);
                    }
                }
            }
        }

        public void Insertar(Monomio monomio, Monomio predecesor)
        {
            if (monomio != null)
            {
                if (predecesor == null)
                {
                    monomio.Siguiente = Cabeza;
                    Cabeza = monomio;
                }
                else
                {
                    monomio.Siguiente = predecesor.Siguiente;
                    predecesor.Siguiente = monomio;
                }
            }
        }


        private String[] ObtenerTextos()
        {
            String[] textos = new String[2];
            textos[0] = "";
            textos[1] = "";

            Monomio apuntador = Cabeza;
            while (apuntador != null)
            {
                string texto = apuntador.Coeficiente.ToString() + " ";
                if (apuntador.Exponente != 0)
                {
                    texto += "X";
                }
                if (apuntador.Coeficiente >= 0)
                {
                    texto = "+" + texto;
                }
                textos[0] += new string(' ', texto.Length);
                textos[1] += texto;

                if (apuntador.Exponente != 0 && apuntador.Exponente != 1)
                {
                    texto = apuntador.Exponente.ToString();
                    textos[0] += texto;
                    textos[1] += new string(' ', texto.Length);
                }
                apuntador = apuntador.Siguiente;
            }


            return textos;
        }

        public void Mostrar(Label lbl)
        {
            String[] textos = ObtenerTextos();
            lbl.Font = new System.Drawing.Font("Courier New", 12);
            lbl.Text = textos[0] + "\n" + textos[1];
        }

        public Polinomio Derivar()
        {
            Polinomio pR = new Polinomio();

            Monomio apuntador = GetCabeza();
            while (apuntador != null)
            {
                if (apuntador.Exponente != 0)
                {
                    Monomio m = new Monomio(apuntador.Coeficiente*apuntador.Exponente,
                                            apuntador.Exponente-1);
                    pR.Agregar(m);
                }
                apuntador = apuntador.Siguiente;
            }

            return pR;
        }

        //********** Métodos estaticos **********

        public static Polinomio Sumar(Polinomio p1, Polinomio p2)
        {
            Polinomio pR = new Polinomio();
            Monomio apuntador1 = p1.GetCabeza();
            Monomio apuntador2 = p2.GetCabeza();

            Monomio monomio;
            while (apuntador1 != null || apuntador2 != null)
            {
                monomio = null;
                if (apuntador1 != null && apuntador2 != null &&
                    apuntador1.Exponente == apuntador2.Exponente)
                {
                    if (apuntador1.Coeficiente + apuntador2.Coeficiente != 0)
                        monomio = new Monomio(apuntador1.Coeficiente + apuntador2.Coeficiente, apuntador1.Exponente);
                    apuntador1 = apuntador1.Siguiente;
                    apuntador2 = apuntador2.Siguiente;
                }
                else if (apuntador1 != null &&
                    (apuntador2 == null || apuntador1.Exponente < apuntador2.Exponente))
                {
                    monomio = new Monomio(apuntador1.Coeficiente, apuntador1.Exponente);
                    apuntador1 = apuntador1.Siguiente;
                }
                else
                {
                    monomio = new Monomio(apuntador2.Coeficiente, apuntador2.Exponente);
                    apuntador2 = apuntador2.Siguiente;
                }

                if (monomio != null)
                {
                    pR.Agregar(monomio);
                }
            }

            return pR;
        }

        public static Polinomio Restar(Polinomio p1, Polinomio p2)
        {
            Polinomio pR = new Polinomio();
            Monomio apuntador1 = p1.GetCabeza();
            Monomio apuntador2 = p2.GetCabeza();

            Monomio monomio;
            while (apuntador1 != null || apuntador2 != null)
            {
                monomio = null;
                if (apuntador1 != null && apuntador2 != null &&
                    apuntador1.Exponente == apuntador2.Exponente)
                {
                    if (apuntador1.Coeficiente - apuntador2.Coeficiente != 0)
                        monomio = new Monomio(apuntador1.Coeficiente - apuntador2.Coeficiente, apuntador1.Exponente);
                    apuntador1 = apuntador1.Siguiente;
                    apuntador2 = apuntador2.Siguiente;
                }
                else if (apuntador1 != null &&
                    (apuntador2 == null || apuntador1.Exponente < apuntador2.Exponente))
                {
                    monomio = new Monomio(apuntador1.Coeficiente, apuntador1.Exponente);
                    apuntador1 = apuntador1.Siguiente;
                }
                else
                {
                    monomio = new Monomio(-apuntador2.Coeficiente, apuntador2.Exponente);
                    apuntador2 = apuntador2.Siguiente;
                }

                if (monomio != null)
                {
                    pR.Agregar(monomio);
                }
            }

            return pR;
        }

        public static Polinomio Multiplicar(Polinomio p1, Polinomio p2)
        {
            Polinomio pR = new Polinomio();
            Monomio apuntador1 = p1.GetCabeza();


            while (apuntador1 != null)
            {
                Monomio apuntador2 = p2.GetCabeza();
                while (apuntador2 != null)
                {
                    Monomio m = new Monomio(apuntador1.Coeficiente * apuntador2.Coeficiente,
                                            apuntador1.Exponente + apuntador2.Exponente);
                    apuntador2 = apuntador2.Siguiente;
                    pR.Agregar(m);
                }
                apuntador1 = apuntador1.Siguiente;
            }

            return pR;
        }


    }
}

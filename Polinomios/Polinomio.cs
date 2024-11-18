using Polinomios;

namespace Polinomios
{
    public class Polinomio
    {
        private Monomio Cabeza;


        public Polinomio()
        {
            Cabeza = null;
        }

        public Polinomio(Monomio cabeza)
        {
            Cabeza = cabeza;
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
                    Monomio m = new Monomio(apuntador.Coeficiente * apuntador.Exponente,
                                            apuntador.Exponente - 1);
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

        public static (Polinomio Cociente, Polinomio Residuo) Dividir(Polinomio dividendo, Polinomio divisor)
        {
            Polinomio cociente = new Polinomio();
            Polinomio residuo = new Polinomio();

            Monomio apuntadorResiduo = dividendo.GetCabeza();
            while (apuntadorResiduo != null)
            {
                residuo.Agregar(new Monomio(apuntadorResiduo.Coeficiente, apuntadorResiduo.Exponente));
                apuntadorResiduo = apuntadorResiduo.Siguiente;
            }

            // Obtener el mayor término del divisor
            Monomio divisorMayor = ObtenerMayorMonomio(divisor);
            if (divisorMayor == null)
            {
                MessageBox.Show("El divisor no puede ser un polinomio vacío.");
            }

            Monomio terminoCociente;
            Polinomio producto;

            // Realizar la división mientras el residuo tenga términos y el mayor exponente del residuo sea >= al del divisor
            while (residuo.GetCabeza() != null && ObtenerMayorMonomio(residuo).Exponente >= divisorMayor.Exponente)
            {
                // Obtener el mayor término del residuo
                Monomio residuoMayor = ObtenerMayorMonomio(residuo);

                MessageBox.Show($"{residuoMayor.Coeficiente} ^ {residuoMayor.Exponente} dividido {divisorMayor.Coeficiente} ^ {divisorMayor.Exponente}");

                // Dividir el mayor término del residuo por el mayor término del divisor
                double coeficienteCociente = residuoMayor.Coeficiente / divisorMayor.Coeficiente;
                int exponenteCociente = residuoMayor.Exponente - divisorMayor.Exponente;
                terminoCociente = new Monomio(coeficienteCociente, exponenteCociente);

                // Agregar el término cociente al polinomio cociente
                cociente.Agregar(terminoCociente);


                // Multiplicar el término cociente por el divisor completo
                Polinomio nuevo = new Polinomio();
                nuevo.Agregar(terminoCociente);
                MessageBox.Show($"Va a multiuplicar {nuevo.GetCabeza().Coeficiente} ^ {nuevo.GetCabeza().Exponente} (que es lo mismo que {terminoCociente.Coeficiente} ^ {terminoCociente.Exponente}) por {ObtenerMayorMonomio(divisor).Coeficiente} ^ {ObtenerMayorMonomio(divisor).Exponente}");
                producto = Multiplicar(nuevo, divisor);

                MessageBox.Show($"divide {residuoMayor.Coeficiente} ^ {residuoMayor.Exponente} por {cociente.GetCabeza().Coeficiente} ^ {cociente.GetCabeza().Exponente}, y el producto mayor es {ObtenerMayorMonomio(producto).Coeficiente} ^ {ObtenerMayorMonomio(producto).Exponente}");

                // Restar el producto al residuo
                residuo = Restar(residuo, producto);

                MessageBox.Show($"nuevo residuo mayor {ObtenerMayorMonomio(residuo).Coeficiente} ^ {ObtenerMayorMonomio(residuo).Exponente}");
            }

            return (cociente, residuo);
        }

        private static Monomio ObtenerMayorMonomio(Polinomio polinomio)
        {
            Monomio apuntador = polinomio.GetCabeza();
            if (apuntador == null) return null;


            while (apuntador.Siguiente != null)
            {
                apuntador = apuntador.Siguiente;
            }

            return apuntador;
        }
    }
}





//Monomio apuntadorResiduo = dividendo.GetCabeza();
//while (apuntadorResiduo != null)
//{
//    residuo.Agregar(new Monomio(apuntadorResiduo.Coeficiente, apuntadorResiduo.Exponente));
//    apuntadorResiduo = apuntadorResiduo.Siguiente;
//}

//Monomio divisorFinal = ObtenerUltimoMonomio(divisor);

//if (divisorFinal == null)
//{
//    throw new ArgumentException("El divisor no puede ser un polinomio vacío.");
//}

//while (residuo.GetCabeza() != null && ObtenerUltimoMonomio(residuo).Exponente >= divisorFinal.Exponente)
//{
//    Monomio residuoFinal = ObtenerUltimoMonomio(residuo);

//    double coeficienteCociente = residuoFinal.Coeficiente / divisorFinal.Coeficiente;
//    int exponenteCociente = residuoFinal.Exponente - divisorFinal.Exponente;
//    Monomio terminoCociente = new Monomio(coeficienteCociente, exponenteCociente);

//    cociente.Agregar(terminoCociente);

//    Polinomio producto = Multiplicar(new Polinomio { Cabeza = terminoCociente }, divisor);

//    residuo = Restar(residuo, producto);
//}

//return (cociente, residuo);
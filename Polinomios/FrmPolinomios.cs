namespace Polinomios
{
    public partial class FrmPolinomios : Form
    {
        public FrmPolinomios()
        {
            InitializeComponent();
        }

        Polinomio p1 = new Polinomio();
        Polinomio p2 = new Polinomio();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double coef = double.Parse(txtCoeficiente.Text);
            int expo = int.Parse(txtExponente.Text);
            switch (cmbPolinomio.SelectedIndex)
            {
                case 0:
                    p1.Agregar(new Monomio(coef, expo));
                    p1.Mostrar(lblPolinomio1);
                    break;
                case 1:
                    p2.Agregar(new Monomio(coef, expo));
                    p2.Mostrar(lblPolinomio2);
                    break;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            lblPolinomioR.Text = "";
            if (cmbOperacion.SelectedIndex >= 0)
            {
                Polinomio pR;
                switch (cmbOperacion.SelectedIndex)
                {
                    case 0:
                        pR = Polinomio.Sumar(p1, p2);
                        pR.Mostrar(lblPolinomioR);
                        break;
                    case 1:
                        pR = Polinomio.Restar(p1, p2);
                        pR.Mostrar(lblPolinomioR);
                        break;
                    case 2:
                        pR = Polinomio.Multiplicar(p1, p2);
                        pR.Mostrar(lblPolinomioR);
                        break;
                    case 3:
                        var (cociente, residuo) = Polinomio.Dividir(p1, p2);
                        cociente.Mostrar(lblPolinomioR);
                        residuo.Mostrar(lblPolinomioRR);
                        break;
                    case 4:
                        switch(cmbPolinomio.SelectedIndex){
                            case 0:
                                pR = p1.Derivar();
                                pR.Mostrar(lblPolinomioR);
                                break;
                            case 1:
                                pR = p2.Derivar();
                                pR.Mostrar(lblPolinomioR);
                                break;
                        }
                        break;
                    
                }
            }
        }

  

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            switch (cmbPolinomio.SelectedIndex)
            {
                case 0:
                    p1=new Polinomio();
                    p1.Mostrar(lblPolinomio1);
                    break;
                case 1:
                    p2 = new Polinomio();
                    p2.Mostrar(lblPolinomio2);
                    break;
            }
        }
    }
}

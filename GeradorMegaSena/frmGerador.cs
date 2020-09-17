using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorMegaSena
{
    public partial class frmGerador : Form
    {

        List<int> f_lstNumeros = new List<int>();

        public frmGerador()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            f_lstNumeros.Clear();
            f_lstNumeros.AddRange(SorteiaNumerosSemRepetir(6, 1, 60));
            Carrega_Numeros();

        }

        private static int[] SorteiaNumerosSemRepetir(int w_intQuantidade, int w_intMinimo, int w_intMaximo)
        {
            // Validações dos argumentos.
            if (w_intQuantidade < 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");
            else if (w_intQuantidade > w_intMaximo + 1 - w_intMinimo)
                throw new ArgumentException("Quantidade deve ser menor do que a diferença entre máximo e mínimo.");
            else if (w_intMaximo <= w_intMinimo)
                throw new ArgumentException("Máximo deve ser maior do que mínimo.");

            List<int> w_lstNumerosSorteados = new List<int>();

            while (w_lstNumerosSorteados.Count < w_intQuantidade)
            {
                Random w_rndGeraNumero = new Random();
                int w_intNumeroSorteado = w_rndGeraNumero.Next(w_intMinimo, w_intMaximo);

                // Número já foi sorteado? Então sorteamos novamente até o número não ter sido sorteado ainda.
                while (w_lstNumerosSorteados.Contains(w_intNumeroSorteado))
                {
                    int w_intVerificaNumero = w_intNumeroSorteado;
                    w_intNumeroSorteado = w_rndGeraNumero.Next(w_intMinimo, w_intMaximo);

                    if(w_intVerificaNumero == w_intNumeroSorteado + 1 || w_intVerificaNumero == w_intNumeroSorteado - 1) // Evitar que gere números sequenciais
                    {
                        w_intNumeroSorteado = w_rndGeraNumero.Next(w_intMinimo, w_intMaximo);
                    }
                }
                    
                w_lstNumerosSorteados.Add(w_intNumeroSorteado);
            }

            w_lstNumerosSorteados.Sort(); // Ordena a lista
            return w_lstNumerosSorteados.ToArray();
        }

        private void Carrega_Numeros()
        {
            try
            {
                int w_intCont = 1;
                List<Label> lbls = new List<Label>()
                {
                    lbl1,
                    lbl2,
                    lbl3,
                    lbl4,
                    lbl5,
                    lbl6
                };

                foreach (var lbl in lbls)
                {
                    lbl.Text = f_lstNumeros[w_intCont -1].ToString();
                    w_intCont++;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmGerador_Load(object sender, EventArgs e)
        {

            try
            {

                List<Label> lbls = new List<Label>()
                {
                    lbl1,
                    lbl2,
                    lbl3,
                    lbl4,
                    lbl5,
                    lbl6
                };

                int w_intCont = 1;
                foreach (var lbl in lbls)
                {

                    lbl.Text = "";
                    w_intCont++;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

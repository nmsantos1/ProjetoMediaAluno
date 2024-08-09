using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaAluno
{
    public partial class frmCalculoMedia : Form
    {
        public frmCalculoMedia()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double Nota1, Nota2, Trabalho;

            Nota1 = Convert.ToDouble(txtNota1.Text) * Convert.ToDouble(cboPesoNota1.Text);
            Nota2 = double.Parse(txtNota2.Text) * double.Parse(cboPesoNota2.Text);
            Trabalho = double.Parse(txtTrabalho.Text) * double.Parse(cboPesoTrabalho.Text);

            double Media  = Nota1 + Nota2 + Trabalho;

            txtMediaFinal.Text = Media.ToString();

            double QtdeAulas, QtdeFaltas;

            QtdeAulas = Convert.ToDouble(txtQtdeAula.Text);
            QtdeFaltas = Convert.ToDouble(txtQtdeFalta.Text);

            double PorcentagemPresenca = 100 - ((QtdeFaltas / QtdeAulas) * 100);

            txtAproveitamento.Text = Convert.ToString(((Media * 10) + (PorcentagemPresenca)) / 2) + "%";

            if (txtRecuperacao.Text == "")
            {
                if (Media >= Convert.ToDouble(numNotaCorte.Value) && PorcentagemPresenca >= 75)
                {
                    lblSituacao.Text = "Aprovado";
                    lblSituacao.ForeColor = Color.Green;
                } 
                else 
                    if(Media <= 2.5 || PorcentagemPresenca < 75)
                    {
                        lblSituacao.Text = "Reprovado";
                        lblSituacao.ForeColor= Color.Firebrick;
                    }
                else
                {
                    lblSituacao.Text = "Recuperação";
                    lblSituacao.ForeColor = Color.Firebrick;
                }
            }
            else
            {
                Media = (Media + Convert.ToDouble(txtRecuperacao.Text)) / 2;

                txtAproveitamento.Text = Convert.ToString(((Media * 10) + (PorcentagemPresenca)) / 2) + "%";

                if (Media >= 5)
                {
                    lblSituacao.Text = "Aprovado";
                    lblSituacao.ForeColor = Color.Green;
                }
                else
                {
                    lblSituacao.Text = "Reprovado";
                    lblSituacao.ForeColor = Color.Firebrick;
                }

                txtMediaFinal.Text = Media.ToString();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblSituacao.Text = "";
            txtRecuperacao.Text = String.Empty;

            foreach (Control Componente in this.Controls)
            {
                if (Componente is TextBox)
                {
                    (Componente as TextBox).Clear();
                }
                else
                {
                    if (Componente is ComboBox)
                    {
                        (Componente as ComboBox).SelectedItem = null;
                    }
                    else
                    {
                        if (Componente is NumericUpDown)
                        {
                            (Componente as NumericUpDown).Value = 5;
                        }
                    }
                }
            }
        }
    }
}

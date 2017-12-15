using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NNProject
{
    public partial class Form1 : Form
    {


        public MLP tryM;
        public RBF RadialBF;
        public LMS LeastMS;

        public bool MLPFlag = false;
        public bool RBFFlag = false;

        public int numOfHiddenLayers;
        public List<int> lstNeuronsPerEachHiddenLayer;


        int numOfEpochs = 0, numOfClusters = 0;
        double Eta = 0, KmeanThreshold , MseThreshold = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //RadialBF = new RBF(30, 0.4f);
            //RadialBF.Kmean();
            //RadialBF.calculateVariance();
            //RadialBF.TransformedInputGaussian();

            //LeastMS = new LMS(0.2, 100, 0.03, true, 30, RadialBF,true);
            //LeastMS.TrainingData();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
 

                    if ( RBFFlag )
                    {
                       LeastMS.TestingData();
                       LeastMS.Calculate_Accuracy();
                       lblAccuracy.Text = LeastMS.accuracy.ToString();
                       for (int i = 0; i < LeastMS.OutPutNodes ; i++)
                       {
                           grvConfusionMatrix.Rows.Add();
                           for (int j = 0; j < LeastMS.OutPutNodes; j++)
                               grvConfusionMatrix.Rows[i].Cells[j + 1].Value = LeastMS.confusionMatrix[i, j].ToString();
                         
                       }
                      
                    }
                    else
                    {
                        tryM.testing_all_data();
                        lblAccuracy.Text = tryM.accuracy.ToString();
                        for (int i = 0; i < LeastMS.OutPutNodes; i++)
                        {
                            grvConfusionMatrix.Rows.Add();
                            for (int j = 0; j < LeastMS.OutPutNodes; j++)
                                grvConfusionMatrix.Rows[i].Cells[j + 1].Value = tryM.confusionMatrix[i, j].ToString();
                         
                        }
                    }
                    grvConfusionMatrix.Rows[LeastMS.OutPutNodes].Cells[0].Value = "";
       }
           


        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(lblAccuracy.Text+".txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(RadialBF.clustersCount.ToString() + " " + RadialBF.KeyMeanThreshold + " " + LeastMS.eta + " " + LeastMS.epochs + " " + LeastMS.mse_threshold);


            for (int i = 0; i < LeastMS.OutPutNodes; i++)
            {
                for (int j = 0; j < LeastMS.InputNumRBF; j++)
                {
                    sw.Write(LeastMS.weights[i, j].ToString() + " ");

                }
                sw.WriteLine();
            }
            if (LeastMS.checkBias)
                for (int i = 0; i < LeastMS.OutPutNodes; sw.Write(LeastMS.bias[i++].ToString() + " ")) ;
            sw.WriteLine();
            for (int h = 0; h <80; h++)
            {
                for (int k= 0; k <LeastMS.InputNumRBF; k++)
                {
                    sw.Write(LeastMS.GaussianData[h,k].ToString() + " ");
                }
                sw.WriteLine();
            }


            sw.Close();
        }

        private void rbtnMLP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMLP.Checked)
            {
                grvNumOfNeuronsPerEachLayers.Visible = true;
                MLPFlag = true;
                lblKmeanThreshold.Visible = false;
                txtKmeanThreshold.Visible = false;
                lblNumClusters.Visible = false;
                txtCenters.Visible = false;
                lblMSEThreshold.Visible = false;
                txtMseThreshold.Visible = false;

                lblNumOfHiddenLayers.Visible = true;
                txtNumOfHiddenLayers.Visible = true;
            }
        }

        private void rbtnRBF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRBF.Checked)
            {
                RBFFlag = true;
                grvNumOfNeuronsPerEachLayers.Visible = false;
                lblNumOfHiddenLayers.Visible = false;
                txtNumOfHiddenLayers.Visible = false;

                lblKmeanThreshold.Visible = true;
                txtKmeanThreshold.Visible = true;
                lblNumClusters.Visible = true;
                txtCenters.Visible = true;
                lblMSEThreshold.Visible = true;
                txtMseThreshold.Visible = true;

            }

        }

        private void onClickTrainingButton(object sender, EventArgs e)
        {
            numOfEpochs = int.Parse(txtEpochs.Text);
          
            Eta = double.Parse(txtbxEta.Text);
           
            if (MLPFlag)
            {

                for (int i = 0; i < numOfHiddenLayers; i++)
                    lstNeuronsPerEachHiddenLayer.Add( int.Parse(grvNumOfNeuronsPerEachLayers.Rows[i].Cells[0].Value.ToString()) );
                                                                                                  //no Read Data From the Saved File
                tryM = new MLP(Eta, numOfEpochs, chbxBias.Checked, lstNeuronsPerEachHiddenLayer , false);
                tryM.TrainingData();
            }
            else if (RBFFlag)
            {
                numOfClusters = int.Parse(txtCenters.Text);
                KmeanThreshold = double.Parse(txtKmeanThreshold.Text);
                MseThreshold = double.Parse(txtMseThreshold.Text);

                RadialBF = new RBF(numOfClusters, KmeanThreshold);
                RadialBF.Kmean();
                RadialBF.calculateVariance();
                RadialBF.TransformedInputGaussian();
                                                                                                             //no Read Data From the Saved File
                LeastMS = new LMS(Eta, numOfEpochs, MseThreshold, chbxBias.Checked, numOfClusters, RadialBF, false);
                LeastMS.TrainingData();
            }
        }

        private void onEnterValuetoNumOfNeuronsPerEachLayer(object sender, EventArgs e)
        {
            grvNumOfNeuronsPerEachLayers.Rows.Clear();
            numOfHiddenLayers = int.Parse(txtNumOfHiddenLayers.Text);

            lstNeuronsPerEachHiddenLayer = new List<int>();

            for (int i = 0; i < numOfHiddenLayers - 1; i++)
                grvNumOfNeuronsPerEachLayers.Rows.Add();

        }

        private void btnTestOneSample_Click(object sender, EventArgs e)
        {

            #region OpenDialog
            openFileDialog1.ShowDialog();
            string fn = openFileDialog1.FileName;
            Bitmap B = PGMUtil.ToBitmap(fn);
            pictureBox1.Image = (Image)B;
            int s = fn.LastIndexOf('\\') + 1;
            #endregion
            if (txtEpochs.Text == "")
            {
                if (RBFFlag)
                {
                    RadialBF = new RBF();
                    LeastMS = new LMS(Eta, numOfEpochs, MseThreshold, chbxBias.Checked, numOfClusters, RadialBF, true);

                }
                else
                {
                    tryM = new MLP(Eta, numOfEpochs, chbxBias.Checked, new List<int> { 4, 4, 4 }, true);

                 
                }
                lblAccuracy.Text = "65";
            }
                
            if (RBFFlag)
            {
                LeastMS.get_sample_test_info(fn.Substring(s).Replace(".pgm", ".pts"));
                lblActualResult.Text = LeastMS.TestingOnePicture();
            }
            else
            {
                tryM.get_sample_test_info(fn.Substring(s).Replace(".pgm", ".pts"));
                lblActualResult.Text = tryM.Testing_Data_Sample();
            }

           
      }

        private void grvConfusionMatrix_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            grvConfusionMatrix.Rows[e.RowIndex].Cells[0].Value = grvConfusionMatrix.Columns[e.RowIndex + 1].Name;
        }
     
    }
}

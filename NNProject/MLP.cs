using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;               // For prcesss related information
using System.Runtime.InteropServices;   // For DLL importing

namespace NNProject
{
  public  class MLP
    {
      Process[] processRunning;
private const int SW_HIDE           = 0  ;
private const int SW_SHOWNORMAL     = 1  ;
private const int SW_NORMAL         = 1  ;
private const int SW_SHOWMINIMIZED  = 2  ;
private const int SW_SHOWMAXIMIZED  = 3  ;
private const int SW_MAXIMIZE       = 3  ;
private const int SW_SHOWNOACTIVATE = 4  ;
private const int SW_SHOW           = 5  ;
private const int SW_MINIMIZE       = 6  ;
private const int SW_SHOWMINNOACTIVE= 7  ;
private const int SW_SHOWNA         = 8  ;
private const int SW_RESTORE        = 9  ;
private const int SW_SHOWDEFAULT    = 10 ;
private const int SW_FORCEMINIMIZE  = 11 ;
private const int SW_MAX = 11;
public bool open;
        Process p;
        public int test_class_num,sample_index;
        int epochs, numHiddenLayers;
        List<int> RandomList;
        double netValue_V, eta, Error_E, sum_mean,alpha;
        public double accuracy;
        public bool Bias;
        List<List<double>> weights_HO;
        List<List<double>> NetInputs;
        List<List<double>> actualOutputs;
        List<List<double>> Deltas;
        public ReadData [] Class;
        public int[,] confusionMatrix;
        List<int> NumOfWeightsPerEachLayer;
        List<int> NumNodesperEachLayer_IHO;
        List<List<double>> biasLst;
        int []desiredOutputs_D;
        double[] Errors;
        public MLP(double pEta, int pEpochs, bool pBias, List<int> pNumNodesperHiddenLayer,bool readfile)
        {
            open = false;
            p = new Process();
            numHiddenLayers = pNumNodesperHiddenLayer.Count;
            accuracy = 0;
            desiredOutputs_D = new int[4] { 0, 0, 0 ,0};
            Errors = new double[4];
            pNumNodesperHiddenLayer.Add(4); //num of weights_HO per output Layer
            NumNodesperEachLayer_IHO = pNumNodesperHiddenLayer;
            NumNodesperEachLayer_IHO.Insert(0, 19);
            biasLst = new List<List<double>>();
            NumOfWeightsPerEachLayer = new List<int>();
            NetInputs = new List<List<double>>();
            actualOutputs = new List<List<double>>();
            Deltas = new List<List<double>>();

            int numOfPreviousWeights = 19;  //intial of numof weights_HO for input weights_HO
            for (int i = 0; i < numHiddenLayers + 1; numOfPreviousWeights = pNumNodesperHiddenLayer[i+1], i++)
                    NumOfWeightsPerEachLayer.Add((numOfPreviousWeights * pNumNodesperHiddenLayer[i+1]));

            Class = new ReadData[4];

            Class[0] = new ReadData("\\Dataset\\Training Dataset\\Closing Eyes", 1);
            Class[1] = new ReadData("\\Dataset\\Training Dataset\\Looking Down", 2);
            Class[2] = new ReadData("\\Dataset\\Training Dataset\\Looking Front", 3);
            Class[3] = new ReadData("\\Dataset\\Training Dataset\\Looking Left", 4);
            Normalize_Data();

            weights_HO = new List<List<double>>();
            RandomList = new List<int>();
            eta = pEta;
            Bias = pBias;
            epochs = pEpochs;
            if (readfile)
                ReadWeightFromFile();
            else
                Generate_Random_Weights();
            alpha = 1;
            confusionMatrix = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
         
        }
        public int generate_random()
        {
            Random rand = new Random();
            int curValue = rand.Next(-2, 65);
            while (RandomList.Contains(curValue) || (curValue < 0 || curValue > 59))
            {

                curValue = rand.Next(-2, 65);
            }
            RandomList.Add(curValue);

            return curValue;
        }
        void Generate_Random_Weights()
        {
            Random rand = new Random();
          
            for (int i = 0; i < numHiddenLayers + 1; i++)
            {
                if (Bias)
                {
                    biasLst.Add(new List<double>());
                    for (int k = 0; k < NumNodesperEachLayer_IHO[i + 1]; k++)
                        biasLst[i].Add((double)rand.NextDouble());
                }
                weights_HO.Add(new List<double>());

                for (int j = 0; j < NumOfWeightsPerEachLayer[i]; j++)
                    weights_HO[i].Add((double)rand.NextDouble());
            }
            
         
        }
        void ReadWeightFromFile()
        {
            FileStream fs = new FileStream("weights 65%(4,4,4,).txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            for (int i = 0; i < numHiddenLayers + 1; i++)
            {
                weights_HO.Add(new List<double>());

                for (int j = 0; j < NumOfWeightsPerEachLayer[i]; j++)
                    weights_HO[i].Add(double.Parse(sr.ReadLine()));
            }
            fs.Close();

        }
        public void Normalize_Data()
        {
            double[] mean = new double[19];
            double[] Max = new double[19];
            double[] Min = new double[19];

            List<double> tmp = new List<double>();
            for (int i = 0; i < 19; i++)
            {
                tmp.Clear();
                mean[i]=Max[i] = 0;
                for (int j = 0; j < 20; j++)
                {
                    tmp.Add( Class[0].samples[j, i]);
                    tmp.Add( Class[1].samples[j, i]);
                    tmp.Add( Class[2].samples[j, i]);
                    tmp.Add( Class[3].samples[j, i]);
                }
                Max[i] = tmp.Max();
                Min[i] = tmp.Min();
            }
            for (int i = 0; i < 19; i++)
            {

                for (int j = 0; j < 20; j++)
                {
                    Class[0].samples[j, i] = (Class[0].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
                    Class[1].samples[j, i] = (Class[1].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
                    Class[2].samples[j, i] = (Class[2].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
                    Class[3].samples[j, i] = (Class[3].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
                }
            }
        }
        public void TrainingData()
        {

            for (int i = 0; i < epochs; i++)
            {
                RandomList.Clear();//////////////////////////////////////////////////
                for (int j = 0, index = 0; j < 60; j++)
                {
                    for (int d = 0; d < 4; desiredOutputs_D[d++] = 0) ;
                    Deltas.Clear();
                    index = generate_random();
                    //ForwardStep
                    if (index <= 14)
                    {
                        desiredOutputs_D[0] = 1;
                        ForwardStep(0, index);
                    }
                    else if (index <= 29)
                    {
                        desiredOutputs_D[1] = 1;
                        ForwardStep(1, index % 15);

                    }
                    else if (index <= 44)
                    {
                        desiredOutputs_D[2] = 1;
                        ForwardStep(2, index % 15);
                    }
                    else
                    {
                        desiredOutputs_D[3] = 1;
                        ForwardStep(3, index % 15);

                    }


                    Calculate_Error_of_OutputLayer();
                    BackwardStep();
                    Update_Weights();
                               }
                eta -= (eta * 0.1);
            }


        }
        void Calculate_Error_of_OutputLayer()
        {
            for (int i = 0; i < 4; i++)
                Errors[i] = desiredOutputs_D[i] - actualOutputs[actualOutputs.Count - 1][i];
        }
        void ForwardStep(int class_num,int index)
        {
            NetInputs.Clear();
            actualOutputs.Clear();
            Errors[0] = Errors[1] = Errors[2] = Errors[3] = 0;
       
            
            actualOutputs.Add(new List<double>());
           for (int i = 0; i < 19; i++)
                actualOutputs[0].Add(Class[class_num].samples[index,i]);
			
           
            for (int i = 0; i < numHiddenLayers + 1/* for output layer*/ ; i++)
            {
                actualOutputs.Add(new List<double>());
                NetInputs.Add(new List<double>());
                for (int j  = 0; j < NumNodesperEachLayer_IHO[i+1] /* for next layer*/; j++)
                {
                       if (Bias)
                        NetInputs[i].Add(biasLst[i][j]);
                    else
                        NetInputs[i].Add(0);
                    for (int k = 0; k < NumNodesperEachLayer_IHO[i] ; k++)
                    {
                        int r = k + (j * NumNodesperEachLayer_IHO[i]);
                        NetInputs[i][j] +=  weights_HO[i][r]*actualOutputs[i][k];
                    }
                    actualOutputs[i + 1].Add(1 / (1 + Math.Exp(-alpha * NetInputs[i][NetInputs[i].Count - 1])));
                   // actualOutputs[i + 1].Add((1 - (double)Math.Exp(-a * NetInputs[i][NetInputs[i].Count - 1])) / (1 + (double)Math.Exp(-a * NetInputs[i][NetInputs[i].Count - 1])));
                }
            }
        }
        void BackwardStep()
        {
            Deltas.Clear();
            Delta_for_output_layer();
            Delta_for_Hidden_layers();
        }
        void Delta_for_output_layer()
        {
            Deltas.Add(new List<double>());   /////////////////////////////////////////////////////
            for (int i = 0; i < 4; i++)
            {
                Deltas[0].Add((double)alpha*Errors[i] * actualOutputs[actualOutputs.Count - 1][i] * (1 - actualOutputs[actualOutputs.Count - 1][i])); //Deltas[0] for output
            }
        }
        void Delta_for_Hidden_layers()
        {

            int next_layer_deltas = 0;
            for (int i = numHiddenLayers - 1; i >= 0; i--, next_layer_deltas++)
            {
                Deltas.Add(new List<double>());
                for (int j = 0; j < NumNodesperEachLayer_IHO[i + 1]; j++)
                {
                    Deltas[numHiddenLayers - i].Add(0);
                    for (int k = 0; k < NumNodesperEachLayer_IHO[i + 2]; k++)
                    {
                        Deltas[numHiddenLayers - i][j] += Deltas[next_layer_deltas][k] * weights_HO[i + 1][j + (k * NumNodesperEachLayer_IHO[i + 1])];
                    }
                    Deltas[numHiddenLayers - i][j] *= alpha * actualOutputs[i + 1][j] * (1 - actualOutputs[i + 1][j]);
                }

            }
        }
        public void get_sample_test_info(string fn)
        {
            fn = fn.ToLower();
            for (int i = 0; i < 4; i++)
            {
                if (Class[i].samples_info.ContainsKey(fn))
                {
                    sample_index = Class[i].samples_info[fn];
                    test_class_num = i;
                    break;
                }
            }

        }
        bool check_for_update(int index)
        {
            for (int i = 0; i < 4; i++)
            {
                if ((actualOutputs[actualOutputs.Count - 1][index / 15] < actualOutputs[actualOutputs.Count - 1][i]))
                    return false;
            }
            return true;
        }
        void Update_Weights()
        {

            for (int i = 0; i <numHiddenLayers+1; i++)
            {
                for (int j = 0; j < NumNodesperEachLayer_IHO[i+1]; j++)
                {
                    if(Bias)
                        biasLst[i][j] += eta * Deltas[numHiddenLayers - i][j];
                    for (int k = 0; k < NumNodesperEachLayer_IHO[i]; k++)
                    {
                        weights_HO[i][(j * NumNodesperEachLayer_IHO[i]) + k] +=(eta* Deltas[numHiddenLayers - i][j]*actualOutputs[i][k]);
                    }
                }

            }
      
        }
    
        public string Testing_Data_Sample()
        {
           
            ForwardStep(test_class_num,sample_index);
            SortedDictionary<double, int> outputs = new SortedDictionary<double, int>();

            for (int k = 0; k < 4; k++)
            {

                if (!outputs.ContainsKey(actualOutputs[actualOutputs.Count - 1][k]))
                    outputs.Add(actualOutputs[actualOutputs.Count - 1][k], k);
            }


           
            p.StartInfo.FileName = "s.txt";
            
            if (outputs.ElementAt(outputs.Count - 1).Value == 0)
            {
                if (open)
                {
                    p.Kill();
                    open = false;
                }
                return "  Closing Eyes ( Close the App. )";
            }
            else if (outputs.ElementAt(outputs.Count - 1).Value == 1)
            {
                try
                {
                    take_action(SW_MINIMIZE);
                }catch { }
                return "Looking Down ( Minimize the App. )";
                
            }
            else if (outputs.ElementAt(outputs.Count - 1).Value == 2)
            {
                if (!open)
                {   
                    p.Start();
                    open = true;
                }
                return "Looking Front ( Open the App. )";
            }
            else
            {
                try
                {

                    take_action(SW_MAXIMIZE);
                }
                catch { }
                return "Looking Left ( Maximize the App. )";
            }


        }
        public   void testing_all_data()
        {
            accuracy = 0;
            confusionMatrix = new int[4, 4];
            SortedDictionary<double, int> outputs = new SortedDictionary<double, int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 15; j < 20; j++)
                {
                    
                    outputs.Clear();
                    ForwardStep(i, j);
                    for (int k = 0; k < 4; k++)
                    {
                        
                      //  Console.Write( ( actualOutputs[actualOutputs.Count - 1][k]) +"\t");
                        
                        if (!outputs.ContainsKey(actualOutputs[actualOutputs.Count - 1][k]))
                        outputs.Add(actualOutputs[actualOutputs.Count - 1][k], k);
                    }
                   // Console.WriteLine();
                    confusionMatrix[i, outputs.ElementAt(outputs.Count - 1).Value]++;
                }
            }
            for (int i = 0; i < 4; i++)
                accuracy += confusionMatrix[i, i];
            accuracy =(accuracy/20)*100;
            //Console.WriteLine();

        }

        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        void take_action(int action)
        {
            int hWnd;
             processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName == "notepad")
                {
                    hWnd = pr.MainWindowHandle.ToInt32();
                    ShowWindow(hWnd, action);
                    break;
                }
            }  

        }
    }
}
            

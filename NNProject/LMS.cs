using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;               
using System.Runtime.InteropServices;  


namespace NNProject
{
    public class LMS
    {
        Process[] processRunning;
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_NORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_SHOWMINNOACTIVE = 7;
        private const int SW_SHOWNA = 8;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        private const int SW_FORCEMINIMIZE = 11;
        private const int SW_MAX = 11;
        public bool open;
        Process p;
        public int OutPutNodes = 4,count=0,sample_index;
        public   int InputNumRBF, epochs,TestClassNum,PicIndexINGDTest;
        List<int> RandomList;
        int[]  desiredOutput_D;
      public  double[,] weights;
      public  double netValue_V, eta, mse_threshold,sum_mean;
       public double[,] GaussianData;
        double[] actualOutput_Y,Error_E,TotalFatalError;
        public double accuracy;
     public   double []bias;
     public   bool checkBias;
        double ErrorForStoreWeights;
        double []TempBias;
        double[,] TempWeights;
      RBF RbfObj;
        public int[,] confusionMatrix;

        
        public LMS(double pEta , int pEpochs,double pmse_th, bool pBias,int input_num,RBF Obj,bool read_from_file)
        {

            p = new Process();
            RbfObj = Obj;
            RandomList=new List<int>();
            InputNumRBF = input_num;
            desiredOutput_D=new int [OutPutNodes];
            actualOutput_Y = new double[OutPutNodes];
            weights = new double[OutPutNodes, InputNumRBF];
            TempWeights = new double[OutPutNodes, InputNumRBF];
            ErrorForStoreWeights = 100000; 
            sum_mean = 0;
            Error_E = new double[OutPutNodes];
            TotalFatalError = new double[OutPutNodes];
            netValue_V = 0;
            mse_threshold = pmse_th;
            eta = pEta;
            checkBias = pBias;
            epochs = pEpochs;

            bias = new double[OutPutNodes];
            TempBias = new double[OutPutNodes];




            if (read_from_file)
                Read_weights_from_file();
            else
            {
                Generate_Random_Weights();
                GaussianData = Obj.gauss;//Trianing and Testing data
            }
           
            
                
            
            confusionMatrix = new int[OutPutNodes, OutPutNodes];
            for (int i = 0; i < OutPutNodes; i++)
			 for (int j = 0; j < OutPutNodes; j++)
                  confusionMatrix[i,j]=0;			
			
        }
      
       
        public int generate_random()
        {
            Random rand = new Random();
            //if (RandomList.Count >= 58) RandomList = new List<int>();
            int curValue = rand.Next(-2, 65);
            while (RandomList.Contains(curValue)||(curValue<0||curValue>59))
            {

                curValue = rand.Next(-2, 65);
            }
            RandomList.Add(curValue);

            return curValue;
        }
        void Generate_Random_Weights()
        {
            Random rand = new Random();

            for (int i = 0; i < OutPutNodes; i++)
            {
                if(checkBias)
                    bias[i] = TempBias[i] = rand.NextDouble();
                for (int j = 0; j < InputNumRBF; j++)
                    weights[i, j] = (double)rand.NextDouble();
            }
            Copy_2D(weights,ref TempWeights);
        }

        public void TrainingData()
        {
            //Training Stage

            int SampleNum = 0;
         for (int e = 0; e < epochs; e++)
        
            {
                
                for (int i = 0; i < OutPutNodes; TotalFatalError[i++] = 0) ;
                RandomList = new List<int>();
                for (int j = 0, index = 0; j < 60; j++)
                {
                    for (int i = 0; i < OutPutNodes; desiredOutput_D[i] = 0, actualOutput_Y[i++] = 0) ;


                    index = generate_random();
                    if (index <= 14)
                    { SampleNum = index; CalculateActual(SampleNum, 0); }

                    else if (index <= 29)
                    { SampleNum = index + 5; CalculateActual(SampleNum, 1); }

                    else if (index <= 44)
                    { SampleNum = index + 10; CalculateActual(SampleNum, 2); }

                    else
                    { SampleNum = index + 15; CalculateActual(SampleNum, 3); }




                    CalculateError();

                    Update_W(SampleNum);
                   
                }
                if (calculate_mean_square())
                 return;
              
                eta -= (eta * 0.1);
             
                   
                   
               
            }
            Copy_2D(TempWeights, ref weights);
            Copy_1D(TempBias, ref bias);
        }
     

        public void Update_W(int samplenum)
        {
            for (int i = 0; i < OutPutNodes; i++)
            {
                if (checkBias)
                    bias[i] += eta * Error_E[i];
                for (int j = 0; j < InputNumRBF; j++)
                    weights[i, j] += (double)eta * Error_E[i] * GaussianData[samplenum, j];
            }
       }

        public void Read_weights_from_file()
        {
          

            FileStream fs = new FileStream("65 %.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            string[] data;
            int count = 0;
            int count1=0;
            line = sr.ReadLine();
            data = line.Split(' ');
            InputNumRBF=int.Parse(data[0]);
            GaussianData = new double[80, InputNumRBF];
            weights = new double[OutPutNodes, int.Parse(data[0])];
            while (sr.Peek() != -1)
            {
                line =sr.ReadLine();
                data = line.Split(' ');
                if (count <= OutPutNodes)
                {
                    if (count == OutPutNodes)
                    {

                        for (int j = 0; j < OutPutNodes; j++)
                            bias[j] = double.Parse(data[j]);
                    }
                    else
                    {
                        for (int i = 0; i < InputNumRBF; i++)
                            weights[count, i] = double.Parse(data[i]);
                     
                    }
                    count++;
                }
                else
                {
                    for (int m = 0; m < InputNumRBF; m++)
                    {
                        GaussianData[count1, m] = double.Parse(data[m]);
                        
                    }
                    count1++;

                }

            }
            sr.Close();
          

        }
     

        public void CalculateActual(int Sampleindex, int Targetindex)
        {
            desiredOutput_D[Targetindex] = 1;
            for (int i = 0; i < OutPutNodes; i++)
            {
                netValue_V = 0;
                if (checkBias)
                    netValue_V = bias[i];
                for (int k = 0; k < InputNumRBF; k++)
                    netValue_V += GaussianData[Sampleindex, k] * weights[i, k];
                double temp = 1 / (1 + (double)Math.Exp(-1 * netValue_V));
                actualOutput_Y[i] = temp;
              
            }  
        }
        public void CalculateError()
        {
           
            for (int i = 0; i < OutPutNodes; i++)
            {
                Error_E[i] = desiredOutput_D[i] - actualOutput_Y[i];
             
            }
            
        }
        public bool calculate_mean_square()
        {

             int SampleNum = 0;
             RandomList = new List<int>();
             for (int j = 0, index = 0; j < 60; j++)
             {
                for (int i = 0; i < OutPutNodes; desiredOutput_D[i] = 0, actualOutput_Y[i++] = 0) ;


                index = generate_random();
                 if (index <= 14)
                 { SampleNum = index; CalculateActual(SampleNum, 0); }

                 else if (index <= 29)
                 { SampleNum = index + 5; CalculateActual(SampleNum, 1); }

                 else if (index <= 44)
                 { SampleNum = index + 10; CalculateActual(SampleNum , 2); }

                 else
                 { SampleNum = index + 15; CalculateActual(SampleNum, 3); }

                   CalculateError();

                for (int i = 0; i < OutPutNodes; TotalFatalError[i] += (double)Math.Pow(Error_E[i++], 2)) ;
                   
                
                
             }

            double AvgMeanErrorForOutPutNodes = 0;
            for (int i = 0; i < OutPutNodes; i++)
             {
                 TotalFatalError[i] /= 120;
                AvgMeanErrorForOutPutNodes += TotalFatalError[i];
             }
            AvgMeanErrorForOutPutNodes /= OutPutNodes;
            if (AvgMeanErrorForOutPutNodes > mse_threshold)
            {
                if (AvgMeanErrorForOutPutNodes < ErrorForStoreWeights)
                {
                    ErrorForStoreWeights = AvgMeanErrorForOutPutNodes;
                    Copy_1D(bias,ref TempBias);
                    Copy_2D(weights, ref TempWeights);
                }
                return false;
            }
             return true;
        
        }

        void Calculate_Actual_Output_using_Signum_Activation_Function(int indxofClass)
        {
            if (netValue_V >= 0)
                actualOutput_Y[indxofClass] = 1;
            else
                actualOutput_Y[indxofClass] = -1;
        }
    
        public void TestingData()
        {

            SortedDictionary<double, int> r = new SortedDictionary<double, int>();
            for (int i = 0; i < 20 ; i++)  // 20 ( 5 for each class )
            {
                r.Clear();
                for (int l = 0; l < OutPutNodes; desiredOutput_D[l++] = 0) ;
                netValue_V = 0;
                if (checkBias)
                    netValue_V = bias[i / 5];
                  for (int o = 0; o < OutPutNodes; actualOutput_Y[o++] = 0) ;
                for (int k = 0; k < OutPutNodes; k++)
                {
                  
                    for (int j = 0; j < InputNumRBF; j++)
                        netValue_V += GaussianData[i + 15 * ((i / 5) + 1), j] * weights[k, j];

                    double temp = 1 / (1 + (double)Math.Exp(-1 * netValue_V));

                    actualOutput_Y[k] = temp;
                    if (!r.ContainsKey(actualOutput_Y[k]))
                     r.Add(actualOutput_Y[k], k);
                   
                }
                int f = r.Values.Last();
                confusionMatrix[i / 5,f ]++;

            }
           
        }

        public void get_sample_test_info(string fn)
        {
            fn = fn.ToLower();
            for (int i = 0; i < 4; i++)
            {
                if (RbfObj.Class[i].samples_info.ContainsKey(fn))
                {
                    PicIndexINGDTest = RbfObj.Class[i].samples_info[fn];
                    TestClassNum = i;
                    break;
                }
            }

        }      
        public string TestingOnePicture()
        {       
                SortedDictionary<double, int> r = new SortedDictionary<double, int>();
                r.Clear();
                for (int l = 0; l < OutPutNodes; desiredOutput_D[l++] = 0) ;
                netValue_V = 0;
                if (checkBias)
                    netValue_V = bias[TestClassNum];
                  for (int o = 0; o < OutPutNodes; actualOutput_Y[o++] = 0) ;
                  for (int k = 0; k < OutPutNodes; k++)
                  {
                      for (int j = 0; j < InputNumRBF; j++)
                          netValue_V += GaussianData[PicIndexINGDTest + (TestClassNum * 20), j] * weights[k, j];

                      double temp = 1 / (1 + (double)Math.Exp(-1 * netValue_V));

                      actualOutput_Y[k] = temp;
                      if (!r.ContainsKey(actualOutput_Y[k]))
                          r.Add(actualOutput_Y[k], k);
                  }

                  p.StartInfo.FileName = "s.txt";


                  if (r.ElementAt(r.Count - 1).Value == 0)
                  {
                      if (open)
                      {
                          p.Kill();
                          open = false;
                      }
                      return "  Closing Eyes ( Close the App. )";
                  }
                  else if (r.ElementAt(r.Count - 1).Value == 1)
                  {
                      try
                      {
                          take_action(SW_MINIMIZE);
                      }
                      catch { }
                      return "Looking Down ( Minimize the App. )";

                  }
                  else if (r.ElementAt(r.Count - 1).Value == 2)
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


        public void Calculate_Accuracy()
        {
            for (int i = 0; i < OutPutNodes; accuracy += confusionMatrix[i, i++]);
            
            accuracy = accuracy * 100/20;
        }

        public void Copy_2D(double[,] Source, ref double[,] Dest)
        {
            for (int i = 0; i < Source.GetLength(0); i++)
                for (int j = 0; j < Source.GetLength(1); j++)
                    Dest[i, j] = Source[i, j];
        }

        public void Copy_1D(double[] Source, ref double[] Dest)
        {
            for (int i = 0; i < Source.Length; Dest[i] = Source[i++]) ;
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

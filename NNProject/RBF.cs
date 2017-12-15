using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNProject
{
    public class RBF
    {
        public ReadData[] Class;
        public double[,] centers,centers_copy, gauss;
        public List<List<int>> pos_vector;
        public double[] variances;
        public int clustersCount;
        public double KeyMeanThreshold;
        public bool terminate;
        public RBF(int clustersCount,double KmeanThreshold)
        {
            Class = new ReadData[4];
            Class[0] = new ReadData("\\Dataset\\Training Dataset\\Closing Eyes", 1);
            Class[1] = new ReadData("\\Dataset\\Training Dataset\\Looking Down", 2);
            Class[2] = new ReadData("\\Dataset\\Training Dataset\\Looking Front", 3);
            Class[3] = new ReadData("\\Dataset\\Training Dataset\\Looking Left", 4);
            pos_vector = new List<List<int>>();

            KeyMeanThreshold = KmeanThreshold;

            this.clustersCount = clustersCount;

            centers = new double[clustersCount, 19];
            centers_copy = new double[clustersCount, 19];

            variances = new double[clustersCount];

            gauss = new double[80, clustersCount];

            for (int i = 0; i < clustersCount; i++)
                pos_vector.Add(new List<int>());

            terminate = false;

            Normalize_Data();
        }
        public RBF() // Use it for Testing One Sample from The Saved Data
        {
            
            Class = new ReadData[4];
            Class[0] = new ReadData("\\Dataset\\Training Dataset\\Closing Eyes", 1);
            Class[1] = new ReadData("\\Dataset\\Training Dataset\\Looking Down", 2);
            Class[2] = new ReadData("\\Dataset\\Training Dataset\\Looking Front", 3);
            Class[3] = new ReadData("\\Dataset\\Training Dataset\\Looking Left", 4);
        }

        public void Kmean()
        {

            Random rand = new Random();
            SortedDictionary<double, int> Distances = new SortedDictionary<double, int>();
            for (int i = 0; i < clustersCount; i++)
            {
                int index = rand.Next(0, 14);
                for (int j = 0; j < 19; j++)
                    centers[i, j] = Class[i % 4].samples[index, j];
            }
          
            while(!terminate)
            {
              
              for (int i = 0; i < 60; i++)
              {
                    Distances.Clear();
                    for (int j = 0; j < clustersCount; j++)
                    {
                      double dist = 0;
                      for (int t = 0; t < 19; t++)
                        dist += (double)Math.Pow(Class[i / 15].samples[i % 15, t] - centers[j, t], 2);
                      if ( !Distances.ContainsKey((double)Math.Sqrt(dist)))
                      Distances.Add((double)Math.Sqrt(dist), j);
                    
                    }
                int min_pos = Distances.ElementAt(0).Value;
             
                pos_vector[min_pos].Add(i);
              }

             Copy_2D(centers,ref centers_copy);
             Update_Centers();
             terminate = Key_mean_termenation(KeyMeanThreshold);
             Distances.Clear();

            }
        }
        public void Update_Centers()
        {
           
            for (int i = 0; i < clustersCount; i++)
            {
                for (int j = 0; j < 19; j++) // x y z h g ..... features
                {
                    for (int k = 0; k < pos_vector[i].Count; k++)
                    {

                        centers[i, j] += Class[(pos_vector[i][k] / 15)].samples[(pos_vector[i][k] % 15), j];
                    }
                    centers[i, j] /= pos_vector[i].Count;
                }
               
            }
        }

        void Normalize_Data()
        {
            double[] mean = new double[19];
            double[] Max = new double[19];
            for (int i = 0; i < 19; i++)
            {
                mean[i] = Max[i] = 0;
                for (int j = 0; j < 20; j++)
                {
                    mean[i] = mean[i] + Class[0].samples[j, i] + Class[1].samples[j, i] + Class[2].samples[j, i] + Class[3].samples[j, i];
                    List<double> tmp = new List<double>() { (double)Max[i], Class[0].samples[j, i], Class[1].samples[j, i], Class[2].samples[j, i], Class[3].samples[j, i] };
                    Max[i] = tmp.Max();

                }

            }

            for (int i = 0; i < 19; i++)
                mean[i] /= 80;

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Class[0].samples[j, i] = (Class[0].samples[j, i] - mean[i]) / Max[i];
                    Class[1].samples[j, i] = (Class[1].samples[j, i] - mean[i]) / Max[i];
                    Class[2].samples[j, i] = (Class[2].samples[j, i] - mean[i]) / Max[i];
                    Class[3].samples[j, i] = (Class[3].samples[j, i] - mean[i]) / Max[i];
                }

            }

        }
        /// <summary>
        /// ///////////////////////
        /// </summary>
        //public void Normalize_Data()
        //{
        //    double[] mean = new double[19];
        //    double[] Max = new double[19];
        //    double[] Min = new double[19];

        //    List<double> tmp = new List<double>();
        //    for (int i = 0; i < 19; i++)
        //    {
        //        tmp.Clear();
        //        mean[i] = Max[i] = 0;
        //        for (int j = 0; j < 20; j++)
        //        {
        //            tmp.Add(Class[0].samples[j, i]);
        //            tmp.Add(Class[1].samples[j, i]);
        //            tmp.Add(Class[2].samples[j, i]);
        //            tmp.Add(Class[3].samples[j, i]);
        //        }
        //        Max[i] = tmp.Max();
        //        Min[i] = tmp.Min();
        //    }
        //    for (int i = 0; i < 19; i++)
        //    {

        //        for (int j = 0; j < 20; j++)
        //        {
        //            Class[0].samples[j, i] = (Class[0].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
        //            Class[1].samples[j, i] = (Class[1].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
        //            Class[2].samples[j, i] = (Class[2].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
        //            Class[3].samples[j, i] = (Class[3].samples[j, i] - Min[i]) / (Max[i] - Min[i]);
        //        }
        //    }
        //}
        public double ED(double [] X,double [] Y)
        {
            double dist = 0;
            for (int i = 0; i < X.Length; i++)
			{
                dist += (double)Math.Pow((X[i] - Y[i]), 2); 
			}
            dist = (double)Math.Sqrt(dist);
            return dist;
        }
        public void Copy_2D(double [,]Source,ref double [,]Dest)
        {
            for (int i = 0; i < Source.GetLength(0); i++)
                for (int j = 0; j < Source.GetLength(1); j++)
                    Dest[i, j] = Source[i,j]; 
        }
        public bool Key_mean_termenation(double threshold)
        {
            double difference = 0 , count = 0 ;
            for (int i = 0; i <clustersCount ; i++)
            {
             difference=ED(GetRow(centers,i),GetRow(centers_copy,i));
                if (difference < threshold)
                    count++;
            }
            if (count >= clustersCount / 2)
                return true;
            return false;
        }
        public void calculateVariance()
        {
            for (int i = 0; i < clustersCount; i++)
            {
                double dist = 0;
                for (int j = 0; j < pos_vector[i].Count; j++)
                {
                    int sampleNumber = pos_vector[i][j];
                    for (int k = 0; k < 19; k++)
                        dist += (double)Math.Pow(Class[sampleNumber / 15].samples[sampleNumber % 15, k] - centers[i, k], 2);
                        variances[i] = (double)Math.Sqrt(dist) / pos_vector[i].Count;
                }
            }
        }
        public void TransformedInputGaussian()
        {            
            for (int i = 0; i < 80; i++)
                for (int j = 0; j < clustersCount; j++)
                    gauss[i,j] = (double)Math.Exp(-Math.Pow(Magnitude(GetRow(Class[i/20].samples,i%20),GetRow(centers,j)),2)/(2*Math.Pow(variances[j],2))) ;
        }
        public double Magnitude(double[] x, double[] c)
        {
            double mag = 0;
            for (int i = 0; i < x.Length; i++)
            {
                mag += (double)Math.Pow(x[i] - c[i], 2);
            }
            return (double)Math.Sqrt(mag);
        }
        public double[] GetRow(double[,] x,int index)
        {
            double[] Row = new double[x.GetLength(1)];
            for (int i = 0; i < x.GetLength(1); i++)
                Row[i] = x[index, i];
            return Row;
        }
    }
}

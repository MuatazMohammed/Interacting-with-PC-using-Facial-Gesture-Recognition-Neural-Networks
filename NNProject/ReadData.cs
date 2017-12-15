using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NNProject
{
    public class ReadData
    {
        public List<KeyValuePair<double, double>> xy_data;
        public Dictionary<string,int> samples_info;
        public double[,] samples;
        int  Sample_number;
        string file_name;
        int desired;
        public ReadData(string path,int des)
        {
            xy_data = new List<KeyValuePair<double, double>>();
            
            samples = new double[20, 19];
            desired = des;
            Sample_number= 0;
            Read(path);
            string path_test = path.Replace("Training Dataset", "Testing Dataset");
           Read(path_test);
        }



        private void Read(string path)
        {
            samples_info = new Dictionary<string,int>();
            path = Directory.GetCurrentDirectory() + path;
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.pts"); //Getting Pts files
            string[] data;
            FileStream fs;
            StreamReader sr;
            foreach (FileInfo file in Files)
            {
                file_name =file.Name;

                fs = new FileStream(path + "\\" + file.Name, FileMode.Open);
                sr = new StreamReader(fs);
                
                for (int i = 0; i < 3; i++)sr.ReadLine();

                string temp = "";
                while (sr.Peek() != -1)
                {
                    temp = sr.ReadLine();
                    if (!temp.Contains("}"))
                    {
                        data = temp.Split(' ');
                        xy_data.Add(new KeyValuePair<double, double>(double.Parse(data[0]), double.Parse(data[1])));
                    }
                }
                sr.Close();
                Extract_Features();
                Sample_number++;
                xy_data = new List<KeyValuePair<double, double>>();
            }

        }


        
        private void Extract_Features()
        {
            double x = xy_data[14].Key , y = xy_data[14].Value;
            List<double> features = new List<double>();

            foreach (KeyValuePair<double, double> xy in xy_data)
            {
                double temp = (double)Math.Sqrt(Math.Pow(xy.Key - x, 2) + Math.Pow(xy.Value - y, 2));
                if(temp!=0) features.Add(temp);
            }

            for (int i = 0; i <features.Count; i++)
                 samples[Sample_number, i] = features[i];

            if (Sample_number > 14)
            {
                samples_info.Add(file_name, Sample_number);
            }
        }

    }    
}
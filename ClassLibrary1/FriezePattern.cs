using System;
using System.Collections;
namespace FriezeGenerator {
    public class CoxeterConwayFunc
    {
        int[] GenerateSequence(int n)
        {
            int[] seq = new int[n];
            for(int i = 0; i<n; i++)
            {
                seq[i] = i;
            }
            ArrayList output = new ArrayList();

            GenerateHelper(seq,output);
            int[] final = new int[n];
            for (int[] x : output)
            {
                for(int i = 0; i<x.Length; i++)
                {
                    final[x[i]] += 1;
                }
            }

            return final;
        }
        ArrayList GenerateHelper(int[] seq, ArrayList toFill)
        {
            if(seq.Length == 3)
            {
                toFill.Add(seq);
                return toFill;
            }
            Random random = new Random();
            int start = random.Next(seq.Length-1)+1;
            int next = random.Next(seq.Length-4);
                switch (next - start)
                {
                    case -1:
                        next = next+3;
                        break;
                    case 0:
                        next = next+2;
                        break;
                    case 1:
                        next = next + 1;
                        break;
                    default:
                        break;
                    }
            if (start > next)
            {
                int temp = start;
                start = next;
                next = temp;
            }
            int[] poly1 = new int[next-start];
            int[] poly2 = new int[Math.Abs(start-next)];
            
            for(int j = start; j<next; j++)
            {
                poly1[j-start] = seq[j];
            }
            for(int j = next; j!=start; j++)
            {
                poly2[Math.Abs(j-next)]
                if(j == seq.Length - 1)
                {
                    j = -1;
                }
            }

            GenerateHelper(poly1, toFill);
            GenerateHelper(poly2, toFill);
            
            return toFill;
            }
        
    }
    public class FriezeFunc
    {
        public ArrayList Run(int[] seq)
        {
            ArrayList toFill = new ArrayList();
            GenerateNextRow(Array.Fill<int>(new int[seq.Length-1], 1), seq, toFill);
        }

        protected ArrayList GenerateNextRow(int[] prev, int[] seq, ArrayList toFill)
        {
            int[] newRow = new int[seq.Length];
            for(int j = 0; j<prev.Length; j++){
                newRow[j] = (1 + seq[j] * seq[j + 1]) / prev[j];
            }
        }

    }
}
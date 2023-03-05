using System;
using System.Collections;
namespace FriezeGenerator {

   
    public class CoxeterConwayFunc
    {
        internal static int[] GenerateSequence(int n)
        {
            if(n < 3)
            {
                return null;
            }
            int[] seq = new int[n];
            for(int i = 0; i<n; i++)
            {
                seq[i] = i;
            }
            ArrayList output = new ArrayList();

            GenerateHelper(seq,output);
            int[] final = new int[n];
            foreach(int[] x in output)
            {
                for(int i = 0; i<x.Length; i++)
                {
                    final[x[i]] += 1;
                }
            }
            for(int i = 0; i<n; i++)
            {
                final[i] -= 1;
            }

            return final;
        }
        internal static ArrayList GenerateHelper(int[] seq, ArrayList toFill)
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
                poly2[Math.Abs(j - next)] = seq[j];
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
        internal static ArrayList Run(int[] seq)
        {
            ArrayList toFill = new ArrayList();
            int[] startingLine = new int[seq.Length + 1];
            Array.Fill(startingLine, 1);
            int[] fixedSeq = new int[seq.Length + 1];
            fixedSeq = seq;
            fixedSeq[fixedSeq.Length - 1] = seq[0];

            GenerateNextRow(startingLine, fixedSeq, toFill, true);
            return toFill;
        }

        internal static ArrayList GenerateNextRow(int[] prev, int[] seq, ArrayList toFill, Boolean stagger)
        {
            if (CycleCompleted(seq))
            {
                return toFill;
            }
            int[] newRow = new int[prev.Length];
            if (stagger)
            {
                for (int j = 0; j < prev.Length - 1; j++)
                {
                    newRow[j] = (seq[j] * seq[j + 1] - 1) / prev[j];
                }
                newRow[newRow.Length - 1] = newRow[0];
            }
            else
            {
                for (int j = 1; j < prev.Length; j++)
                {
                    newRow[j] = (seq[j - 1] * seq[j] - 1) / prev[j];
                }
                newRow[0] = newRow[newRow.Length - 1];
            }
            toFill.Add(newRow);
            GenerateNextRow(seq, newRow, toFill, !stagger);

            return toFill;
        }



        internal static Boolean CycleCompleted(int[] seq)
        {
            for (int i = 0; i < seq.Length; i++)
            {
                if (seq[i] != 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class Tests
    {
        static String F = "FAILED";
        static String P = "PASSED";
        
        static void main(String[] args){
            Console.WriteLine(Test1());
        }

        private static String Test1()
        {
            int[] x;
            try
            {
                x = CoxeterConwayFunc.GenerateSequence(3);
            }
            catch (Exception ex)
            {
                return F;
            }
            if(x.Length != 3)
            {
                return F;
            }
            return P;
        }
    }

}
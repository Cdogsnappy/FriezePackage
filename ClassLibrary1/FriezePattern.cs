using System;
using System.Collections;
namespace FriezeGenerator {

    public enum Stagger
    {
        RIGHT,
        LEFT,
        NONE
    }
    public class CoxeterConwayFunc
    {
        int[] GenerateSequence(int n)
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
        public ArrayList Run(int[] seq)
        {
            int patternLength = getPatternSize(seq);
            ArrayList toFill = new ArrayList();
            int[] startingLine = new int[seq.Length + 1];
            Array.Fill(startingLine, 1);

            GenerateNextRow(startingLine, seq, toFill, Stagger.NONE);
            return toFill;
        }

        protected ArrayList GenerateNextRow(int[] prev, int[] seq, ArrayList toFill, Stagger s)
        {
            int[] newRow = new int[prev.Length];
            for (int j = 0; j < prev.Length; j++) {
                newRow[j] = (seq[j] * seq[j + 1] - 1) / prev[j];
            }

            return null;
        }

        protected ArrayList findFactors(int num)
        {
            ArrayList toFill = new ArrayList();
            double bound = Math.Sqrt(num);
            for (int i = 2; i < bound; i++)
            {
                if (num % i == 0)
                {
                    toFill.Add(i);
                }
            }
            return toFill;
        }
        protected int getPatternSize(int[] seq)
        {
            int patternLength = seq.Length;
            if(seq.Length %2 != 0)
            {
                return patternLength;
            }
            ArrayList patternChecker = findFactors(seq.Length);
            for (int i = 0; i < patternChecker.Count; i++)
            {
                int factor = (int)patternChecker[i];
                for (int j = 0; j < seq.Length / factor; j++)
                {
                    if (seq[j] != seq[j + factor])
                    {
                        factor = -1;
                        break;
                    }

                }
                if (factor == -1)
                {
                    continue;
                }
                patternLength = factor;
                break;
            }
            return patternLength;
        }
        

    }
}
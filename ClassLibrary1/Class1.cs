using System;
using System.Collections;
namespace FriezeGenerator {
    public class CoxeterConwayFunc
    {
        ArrayList GenerateSequence(int n)
        {
            int[] seq = new int[n];
            for(int i = 0; i<n; i++)
            {
                seq[i] = i;
            }
            ArrayList output = new ArrayList();

            return GenerateHelper(seq, output);
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
            int next = random.Next(seq.Length - 4);
            for(int j = 0; j < random.Next(seq.Length - 4); j++)
            {
                if()
            }
            return toFill;
        }
    }
    public class FriezeFunc
    {

    }
}
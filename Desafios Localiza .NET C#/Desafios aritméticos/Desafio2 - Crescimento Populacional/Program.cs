using System; 

class minhaClasse {

    static void Main(string[] args) { 

            int t = Convert.ToInt32(Console.ReadLine());
            double[] arrayList = new double[4];
            int pa, pb;
            double cpa, cpb;
            int anos;

            for (int i = 0; i < t; i++)
            {
                anos = 0;
                string[] valores = Console.ReadLine().Split();
                pa = int.Parse(valores[0]);
                pb = int.Parse(valores[1]);

               //declare as variaveis corretamente
                cpa = Convert.ToDouble(valores[2]);
                cpb = Convert.ToDouble(valores[3]);

                while (pa <= pb)
                {
                    anos = anos +1;
                    pa = (int)(pa+(pa*cpa/100));
                    pb = (int)(pb+(pb*cpb/100));

                    if (anos > 100)
                    {
                       Console.WriteLine("Mais de 1 seculo.");
                       break;
                    }
            

                }

                if (anos <= 100)
                {
                   Console.WriteLine("{0} anos.", anos);
                }

            }

    }

}
using System; 


class URI {

    static void Main(string[] args) { 

            string n = Console.ReadLine();
            int n1 = int.Parse(n);
            char[] charArray = n.ToCharArray();
            Array.Reverse( charArray );
            string resultadoString = new string(charArray);
            ulong resultadoUlong = Convert.ToUInt64(resultadoString);
            if(resultadoString[0] == '0')
                Console.WriteLine($"0{Convert.ToUInt64(resultadoString)}\n");
            else
                Console.WriteLine($"{Convert.ToUInt64(resultadoString)}\n");
        
            Console.ReadLine();

    }
}

using System; 

class minhaClasse {

    static void Main(string[] args) { 

            int diaInicio, diaTermino, horaMomentoInicio, minutoMomentoInicio, segundoMomentoInicio;
            int horaMomentoTermino, minutoMomentoTermino, segundoMomentoTermino;
            int hora ,dia,minutos,segundos;
            //continue escrevendo a solucao

            string[] dadosInicio = Console.ReadLine().Split();
            diaInicio = Convert.ToInt32(dadosInicio[1]);

            string[] dadosMomentoInicio = Console.ReadLine().Split(':');
            horaMomentoInicio = Convert.ToInt32(dadosMomentoInicio[0]);
            minutoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[1]);
            segundoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[2]);
    

            string[] dadosTermino = Console.ReadLine().Split();
            diaTermino = Convert.ToInt32(dadosTermino[1]);

            string[] dadosMomentoTermino = Console.ReadLine().Split(':');
            horaMomentoTermino = Convert.ToInt32(dadosMomentoTermino[0]);
            minutoMomentoTermino = Convert.ToInt32(dadosMomentoTermino[1]);
            segundoMomentoTermino = Convert.ToInt32(dadosMomentoTermino[2]);
           
           var dataInicio = new DateTime (2021,1,diaInicio,horaMomentoInicio,minutoMomentoInicio,segundoMomentoInicio);
           var dataFinal = new DateTime (2021,1,diaTermino,horaMomentoTermino,minutoMomentoTermino,segundoMomentoTermino);
           TimeSpan diff1 = dataFinal.Subtract(dataInicio); // ou TimeSpan diff1 = dataFinal - dataInicio 

            int transformaSegundosInicio = horaMomentoInicio*3600+minutoMomentoInicio*60+segundoMomentoInicio;
            int transformaSegundosTermino = horaMomentoTermino*3600+minutoMomentoTermino*60+segundoMomentoTermino;

            TimeSpan ti = TimeSpan.FromSeconds( transformaSegundosInicio );
            TimeSpan tt = TimeSpan.FromSeconds( transformaSegundosTermino );
           
        
      
 
            Console.WriteLine("{0} dia(s)", diff1.Days);
            Console.WriteLine("{0} hora(s)", diff1.Hours);
            Console.WriteLine("{0} minuto(s)", diff1.Minutes);
            Console.WriteLine("{0} segundo(s)", diff1.Seconds);


    }

}


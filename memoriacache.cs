using System;

namespace MemoriaCache
{
    class Program
    {
        static void Main(string[] args)
        {
            int H = 0, M = 0, op1, op2 = 0, qtdEnd = 257, txAcerto = 0;
            MemoriaPrincipal m = new MemoriaPrincipal();
            MemoriaCache c = new MemoriaCache();
            do
            {
                Console.WriteLine("Menu de Opções");
                Console.WriteLine("1 - Acessar endereço de memória");
                Console.WriteLine("2 - Encerrar\n");
                Console.Write("Digite sua opção: ");
                op1 = int.Parse(Console.ReadLine());
                switch(op1)
                {
                    case 1:
                        Console.Write("Digite um endereço de memória no formato 0x0000: ");
                        string s = Console.ReadLine();
                        for (int i = 0; i < qtdEnd; i++) 
                        {
                            
                            m.SetEnd(s);
                            m.SetDado(i);
                            c.SetEnd(s);
                            c.SetDado(i);
                            c.SetPriori(i++);
                            if (i == 8)
                            {   
                                if (1 == c.GetPriori())
                                {
                                    c.SetEnd(s);
                                    c.SetDado(i);
                                }
                                for (int j = 0; j < 8; j++) c.SetPriori(i--);
                            }
                            qtdEnd++;
                            if (s == m.GetEnd()) M++;
                            else H++;
                            txAcerto = 100 * (H / (H + M));
                        }
                    break;

                    case 2:
                        Console.WriteLine($"\nHIT: {H} vezes");
                        Console.WriteLine($"MIS: {M} vezes");
                        Console.WriteLine($"Taxa de Acerto: {txAcerto}%");                      
                        op2 = 0;
                    break;
                }
            }
            while (op2 != 0);
            Console.ReadKey();
        }
    }
    class MemoriaPrincipal
    {
        private string[] end = new string[256];
        private int[] dado = new int[256];
        private int k = 0;
        public void SetEnd(string a)
        {
          end[k++] = a;
        }
        public void SetDado(int a)
        {
          dado[k++] = a;
        }
        public string GetEnd()
        {
          return end[k++];
        }
        public int GetDado()
        {
          return dado[k++];
        }
    }
    class MemoriaCache
    {
        private string[] end = new string[8];
        private int[] dado = new int[8];
        private int[] priori = new int[8];
        private int k;
        public void SetEnd(string a)
        {
          if (k < 8)
          end[k] = a;
          k++;
        }
        public void SetDado(int a)
        {
          if (k < 8)
          dado[k] = a;
          k++;
        }
        public void SetPriori(int a)
        {
          if (k < 8)
          priori[k] = a;
          k++;
        }
        public string GetEnd()
        {
          return end[k++];
        }
        public int GetDado()
        {
          return dado[k++];
        }
        public int GetPriori()
        {
          return priori[k++];
        }
    }
}

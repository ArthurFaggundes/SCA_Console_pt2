namespace SCA_Console.UI
{
    public class utilFuncs
    {
        public static int EntrarId()
        {
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (id > 0)
                {
                    return id;
                }
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido. Por favor, insira um número inteiro.");
                return EntrarId();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public static string EntrarNome()
        {
            string nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
            {
                Console.WriteLine("Nome inválido. Por favor, insira um nome válido.");
                return EntrarNome();
            }
            return nome;
        }
    }
}

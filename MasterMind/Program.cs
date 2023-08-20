using QuadaxMasterMindAssessment;

internal class Program
{
    private static void Main(string[] args)
    {
        MasterMind masterMind = new();
        Program program = new Program();
        program.PlayMastermind(masterMind);
    }

    private void PlayMastermind(MasterMind masterMind)
    {
        masterMind.StartNewGame();
#if DEBUG
        Console.WriteLine($"Secret code: {masterMind.SecretCode()}");
#endif
        Console.WriteLine(masterMind.HowToPlay());

        while (masterMind.GameInProgress)
        {
            Console.WriteLine(masterMind.PlayPrompt());
            string? input = Console.ReadLine();
            if (masterMind.ValidateInput(input))
            {
                string result = masterMind.PlayInput(input);
                Console.WriteLine($"Result: {result}");

                if (masterMind.GameWon)
                {
                    Console.WriteLine("Game Won!");
                    return;
                }
                Console.WriteLine($"Attempts left: {masterMind.PlayAttemptsLeft}");

            }
        }
        Console.WriteLine("Game over. You lost");
    }
}
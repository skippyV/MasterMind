namespace QuadaxMasterMindAssessment
{
    internal interface IMasterMind
    {
        bool GameInProgress { get; }
        bool GameWon { get; }
        int PlayAttemptsLeft { get; }
        string HowToPlay();
        string PlayInput(string input);
        string PlayPrompt();
        void StartNewGame();
        bool ValidateInput(string input);
        string SecretCode();
    }
}

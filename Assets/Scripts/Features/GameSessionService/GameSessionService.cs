using Cysharp.Threading.Tasks;

public class GameSessionService 
{
    private readonly UIService _uiService;
    
    private GameSessionService(UIService uiService)
    {
        _uiService = uiService;
        StartGame();
    }
    
    private void StartGame()
    {
        _uiService.ShowStartScreen().Forget();
    }
}

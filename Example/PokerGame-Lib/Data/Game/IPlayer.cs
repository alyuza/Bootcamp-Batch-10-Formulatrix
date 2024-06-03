namespace PokerGame;

public interface IPlayer
{
    string GetName();
    void SetPlayerName(string playerName);
    int GetId();
    void SetPlayerId(int playerId);
}

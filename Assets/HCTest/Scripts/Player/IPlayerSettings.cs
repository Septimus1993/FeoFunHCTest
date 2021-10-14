namespace HCTest.PlayerScripts
{
    public interface IPlayerSettings
    {
        float MoveSpeed { get; }
        float JumpAcceleration { get; }
        float JumpMinSpeed { get; }
        float JumpMaxSpeed { get; }
    }
}

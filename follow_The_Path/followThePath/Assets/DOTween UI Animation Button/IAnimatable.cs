namespace SamuelEinheri.UI
{
    public interface IAnimatable
    {
        void OnDown(DoButton doButton);
        void OnUp(DoButton doButton);
        void OnOver(DoButton doButton);
        void OnOut(DoButton doButton);
    }
}

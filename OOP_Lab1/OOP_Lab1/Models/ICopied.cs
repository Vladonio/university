namespace OOP_Lab1.Models
{
    public interface ICopied<T>
    {
        void CopyTo(T target);
    }
}

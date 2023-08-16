public class StorageItem
{
    private string v;

    public virtual double Weight { get; }
    public string V => v;

    public StorageItem(double weight) => Weight = weight;
}

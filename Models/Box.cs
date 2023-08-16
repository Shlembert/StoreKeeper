public class Box : StorageItem
{
    public int ID { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public DateTime ProductionDate { get; set; }

    public DateTime ExpirationDate
    {
        get
        {
            if (ProductionDate != DateTime.MinValue)
            {
                return ProductionDate.AddDays(100);
            }
            return DateTime.MinValue;
        }
    }

    public double Area
    {
        get { return Width * Length; }
    }

    public Box(int id, double width, double length, double height, double weight, DateTime productionDate)
        : base(weight)
    {
        ID = id;
        Width = width;
        Length = length;
        Height = height;
        ProductionDate = productionDate.Date;
    }

    public virtual double GetVolumeBox()
    {
        return Width * Length * Height;
    }

    public virtual DateTime GetDateTime()
    {
        return ProductionDate;
    }

    public override string ToString()
    {
        return ID.ToString();
    }

    public string GetExpirationStatus()
    {
        DateTime currentDate = DateTime.Now.Date;
        TimeSpan remainingTime = ExpirationDate.Date - currentDate;

        if (remainingTime.Days < 0)
        {
            return "Просрочено";
        }
        else
        {
            return $"Осталось {(ExpirationDate - currentDate).Days} дней";
        }
    }
}

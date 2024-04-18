namespace Solution.Services;

public class DigimonServiceService : BaseService<Digimon, int>, IDigimonServiceService<Digimon, int>
{
    public DigimonServiceService() : base()
    {
        this.Items = ReadDataFromUrlAsync("https://digimon-api.vercel.app/api/digimon").Result;
    }

    public override Digimon Create(Digimon model)
    {
        model.Id = Items.Last().Id + 1;
        Items.Add(model);

        return model;
    }

    public override void Delete(int id)
    {
        var item = GetById(id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
    }

    public override ICollection<Digimon> GetAll()
    {
        return Items;
    }

    public override IDictionary<int, ICollection<Digimon>> GetFiveRecords(int pageNumber)
    {
        IDictionary<int, ICollection<Digimon>> result = new Dictionary<int, ICollection<Digimon>>();

        if (pageNumber <= 0)
        {
            pageNumber = 0;
            result.Add(pageNumber, Items.Take(5).ToList());
        }
        else if (pageNumber >= 1 && pageNumber < Math.Floor(Items.Count / 5.0))
        {
            result.Add(pageNumber, Items.Skip(pageNumber * 5).Take(5).ToList());
        }
        else
        {
            pageNumber = Items.Count / 5-1;
            if (Items.Count - pageNumber * 5 == 0)
            {
                result.Add(pageNumber, Items.TakeLast(5).ToList());
            }
            else
            {
                result.Add(pageNumber, Items.TakeLast(Items.Count - pageNumber * 5).ToList());
            }
        }
        return result;
    }

    public override Digimon GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Digimon model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}

namespace Solution.Services;

public class AmazonsOfVolleyballService : BaseService<Player, int>, IAmazonsOfVolleyballService<Player, int>
{
    public AmazonsOfVolleyballService() : base()
    {
        this.Items = ReadDataFromJson("amazons_of_volleyball.json");
    }

    public override Player Create(Player model)
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

    public override ICollection<Player> GetAll()
    {
        return Items;
    }

    public override IDictionary<int, ICollection<Player>> GetFiveRecords(int pageNumber)
    {
        IDictionary<int, ICollection<Player>> result = new Dictionary<int, ICollection<Player>>();

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

    public override Player GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Player model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}

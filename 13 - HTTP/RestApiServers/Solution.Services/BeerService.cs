using Solution.Common.Models.View;
using System.Diagnostics.Metrics;

namespace Solution.Services;

public class BeerService : BaseService<Beer, int>, IBeerService<Beer, int>
{
    public BeerService() : base()
    {
        this.Items = ReadDataFromJson("beers.json");
    }

    public override Beer Create(Beer model)
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

    public override ICollection<Beer> GetAll()
    {
        return Items;
    }

    public override IDictionary<int, ICollection<Beer>> GetFiveRecords(int pageNumber)
    {
        IDictionary<int, ICollection<Beer>> result = new Dictionary<int, ICollection<Beer>>();

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
            pageNumber = Items.Count / 5;
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
            

    public override Beer GetById(int id)
    {
        var item = Items.Find(x => x.Id == id) ?? throw new Exception("Item not found!");
        return item;
    }

    public override void Update(Beer model)
    {
        var item = GetById(model.Id);
        int index = Items.IndexOf(item);
        Items.RemoveAt(index);
        Items.Insert(index, model);
    }
}

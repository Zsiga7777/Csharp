using Solution.Common.Models.View;

namespace Solution.Common.Interfaces;

public interface IDigimonServiceService<T, Tkey> : IBaseService<T, Tkey> where T : class
{
    IDictionary<int, ICollection<Digimon>> GetFiveRecords(int stepValue);
}

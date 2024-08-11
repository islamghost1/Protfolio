using Portfolio.Client.Models;

namespace Portfolio.Data.Interfaces
{
    public interface IPutData
    {
        Task CreateProject(Projects project);

    }
}

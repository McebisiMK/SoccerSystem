using TournMan.Models;

namespace TournMan.Repositories
{
    public interface ITeamRepository
    {
        int Save(Team team);
    }
}
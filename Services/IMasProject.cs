using Demo1.Models;

namespace Demo1.Services
{
    public interface IMasProject
    {
        ApiResponse GetAll(Query query);

        ApiResponse Get(int id);
    }
}

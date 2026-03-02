using EFCoreDemo.Models;

namespace EFCoreDemo.Repository;

public interface ITool
{
    void addTool(Tool newTool);
    void addTools(List<Tool> newTools);
}

using EFCoreDemo.Data;
using EFCoreDemo.Models;

namespace EFCoreDemo.Repository;

public class ToolRepository : ITool
{
    public void addTool(Tool newTool)
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();
        db.Tools.Add(newTool);
        db.SaveChanges();
    }

    public void addTools(List<Tool> newTools)
    {
        using var db = new HardwareStoreContext();
        db.Database.EnsureCreated();
        db.Tools.AddRange(newTools);
        db.SaveChanges();
    }
}
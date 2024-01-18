using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TaskProject.Model
{
    public interface ITaskE
    {
        public DataTable GetTasks();
    }
    public class TaskRepo: ITaskE
    {
        private readonly AppDbContext _context;

        public TaskRepo(AppDbContext context)
        {
            _context = context;

        }
        public DataTable GetTasks()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Taskdata";
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Assignee", typeof(string));
            dt.Columns.Add("DueDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            var _list = _context.Tasks.Include(x=>x.Status).ToList();
            if (_list.Count > 0)
            {
                _list.ForEach(item =>
                {
                    dt.Rows.Add(item.Id, item.Title, item.Description, item.Assignee, item.DueDate,item.Status.Name);
                });
            }

            return dt;
        }
    }
}

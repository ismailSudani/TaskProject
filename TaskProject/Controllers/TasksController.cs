using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using TaskProject.Model;
using Mailservice;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel;
using ClosedXML.Excel;
using Org.BouncyCastle.Ocsp;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.IdentityModel.Tokens;

namespace TaskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskE _task;

        private readonly AppDbContext _context;
        private readonly IEmailSender1 _sender;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TasksController(ITaskE taskE,AppDbContext context, IEmailSender1 sender, IWebHostEnvironment webHostEnvironment)
        {
            _task = taskE;
            _context = context;
            _sender = sender;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Task>>> GetTasks()
        {
           
            return await _context.Tasks.ToListAsync();
        }
        [HttpGet("ExcelTasks")]
        public async Task<ActionResult<IEnumerable<Model.Task>>> ExcelTasks(Excellist Excel)
        {
            var Tasks=_task.GetTasks();
            using (XLWorkbook wb = new XLWorkbook())
            {
                
                var sheet2 = wb.AddWorksheet(Tasks,"Tasks");

                wb.SaveAs("FILES/Tasks.xlsx");
                if (!string.IsNullOrEmpty(Excel.email))
                {
                    var message = new Mailservice.Message(new string[] { Excel.email }, "list of task", "<h1>" + "please find the attachment with list of tasks"+ "</h1>", "FILES/Tasks.xlsx");
                    _sender.SendEmail(message);
                }
                
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Tasks.xlsx");
                                             
                }
              
            }
            
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Task>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }
            //System.IO.File.Copy(Path.Combine(_webHostEnvironment.WebRootPath, "FILES/Tasks.xlsx"), Path.Combine(_webHostEnvironment.WebRootPath, "FILES/myTasks.xlsx"), true);
            
            
            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Model.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model.Task>> PostTask(NewTask newTask)
        {
            Model.Task task = new Model.Task();
            task.Assignee =newTask.Assignee;
            task.Title = newTask.Title; 
            task.Description =  newTask.Description;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            var message = new Mailservice.Message(new string[] { task.Assignee }, task.Title, "<h1>" + task.Description + "</h1>", "Tasks.xlsx");
            _sender.SendEmail(message);
            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}

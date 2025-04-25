using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_cli.Models
{
    public class TaskItem
    {
        public int id { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public TaskItem(int id, string description)
        {
            this.id = id;
            this.description = description;
            this.status = "todo";
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }
        public string TaskToString()
        {
            return $"TaskId = {id} \n| Description: {description} \n| Status: {status}\n| Created At: {createdAt}\n| Updated At: {updatedAt}\n";
        }
    }
}

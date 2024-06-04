namespace ToDoApp.Models
{
    public class ToDoStatus
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public ICollection<ToDo> ToDos { get; set; }
    }
}

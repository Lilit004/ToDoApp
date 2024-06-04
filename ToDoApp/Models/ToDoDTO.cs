namespace ToDoApp.Models
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Completed { get; set; }

        public ToDoDTO() { }
        public ToDoDTO(ToDo todoItem)
        {
            Id = todoItem.Id;
            Name = todoItem.Name;
            if (todoItem.ToDoStatusesId == 1)
                Completed = true;
            else
                Completed = false;
        }
    }
}

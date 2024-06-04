namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ToDoStatusesId { get; set; }
        public ToDoStatus ToDoStatuses { get; set; }
    }
}

namespace HostelManagementSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int roomNo { get; set; }
        public int floor { get; set; }
        public string type { get; set; }
        public int capacity { get; set; }
        public int vacancy { get; set; }

        // relationship with students for a room
        public ICollection<Student> Students { get; set; }

    }
}

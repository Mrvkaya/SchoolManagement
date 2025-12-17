namespace SchoolManagement.ENTITIES
{
    public class BaseEntities
    {
        public enum UserRole
        {
            Student = 1,
            Teacher = 2, // Burada kullanıcılaın yetkileri ve rollerini belirttim
            Admin = 3
        }

        public class User // Ortak özellikleri tutan temel kullanıcı sınıfımız
        {
            public int Id { get; set; }
            public string Username { get; set; }
           
            public string Password { get; set; }
            public UserRole Role { get; set; }
        }
    }
}

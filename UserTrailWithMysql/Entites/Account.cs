namespace UserTrailWithMysql.Entites
{
    public class Account
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}